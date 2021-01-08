using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaHastaTakip.Business.Interfaces;
using CoronaHastaTakip.Entities.Concrete;
using CoronaHastaTakip.Web.Areas.Admin.Models.IsEmriViewModels;
using CoronaHastaTakip.Web.Areas.Ekip.Models;
using CoronaHastaTakipTaslak.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CoronaHastaTakip.Web.Areas.Ekip.Controllers
{
    [Area("Ekip")]
    [Authorize(Roles = "Ekip")]
    public class HastaController : Controller
    {
        private UserManager<AppUser> _userManager;
        private IHastaService _hastaService;
        private IRaporService _raporService;
        private IBildirimService _bildirimService;

        public HastaController(UserManager<AppUser> userManager,IHastaService hastaService, IRaporService raporService
            , IBildirimService bildirimService)
        {
            _bildirimService = bildirimService;
            _raporService = raporService;
            _hastaService = hastaService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var hastalar = _hastaService.GetirTumTablolarByFilter(x => x.AppUserId == user.Id && !x.Durum);

            List<HastaListAllViewModel> models = new List<HastaListAllViewModel>();

            foreach (var item in hastalar)
            {
                HastaListAllViewModel model = new HastaListAllViewModel();
                model.Id = item.Id;
                model.AppUser = item.AppUser;
                model.Aciliyet = item.Aciliyet;
                model.Raporlar = item.Raporlar;
                model.Aciklama = item.Aciklama;
                model.AdSoyad = item.AdSoyad;
                model.KimlikNo = item.KimlikNo;
                model.Yas = item.Yas;
                model.TestTarihi = item.TestTarihi;
                models.Add(model);
            }

            return View(models);
        }

        public IActionResult EkleRapor(int id)
        {
            var hasta = _hastaService.GetirAciliyetileHastaListesiById(id);

            RaporAddViewModel model = new RaporAddViewModel();
            model.HastaId = id;
            model.Hasta = hasta;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EkleRapor(RaporAddViewModel model)
        {
            if(ModelState.IsValid)
            {
                _raporService.Ekle(new Rapor()
                {
                    Tanim = model.Tanim,
                    Detay = model.Detay,
                    HastaId = model.HastaId
                });

                var aktifEkip = await _userManager.FindByNameAsync(User.Identity.Name);
                var adminler = await _userManager.GetUsersInRoleAsync("admin");

                foreach (var admin in adminler)
                {
                    _bildirimService.Ekle(new Bildirim()
                    {
                        AppUserId = admin.Id,
                        Mesaj = aktifEkip.UserName + " adlı ekip yeni bir rapor yazdı."
                    });
                }

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult GuncelleRapor(int id)
        {
            var rapor = _raporService.GetirHastaIleAciliyetById(id);

            RaporUpdateViewModel model = new RaporUpdateViewModel();
            model.Tanim = rapor.Tanim;
            model.Detay = rapor.Detay;
            model.Hasta = rapor.Hasta;
            model.HastaId = rapor.HastaId;
            model.Id = rapor.Id;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> GuncelleRapor(RaporUpdateViewModel model)
        {
            if(ModelState.IsValid)
            {
                var rapor = _raporService.GetirIdile(model.Id);

                rapor.Detay = model.Detay;
                rapor.Tanim = model.Tanim;

                _raporService.Guncelle(rapor);

                var aktifEkip = await _userManager.FindByNameAsync(User.Identity.Name);
                var adminler = await _userManager.GetUsersInRoleAsync("admin");

                foreach (var admin in adminler)
                {
                    _bildirimService.Ekle(new Bildirim()
                    {
                        AppUserId = admin.Id,
                        Mesaj = aktifEkip.UserName + " adlı vir raporu güncelledi."
                    });
                }

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Tamamlandi(int id)
        {
            var hasta = _hastaService.GetirIdile(id);
            hasta.Durum = true;
            _hastaService.Guncelle(hasta);

            var aktifEkip = await _userManager.FindByNameAsync(User.Identity.Name);
            var adminler = await _userManager.GetUsersInRoleAsync("admin");

            foreach (var admin in adminler)
            {
                _bildirimService.Ekle(new Bildirim()
                {
                    AppUserId = admin.Id,
                    Mesaj = aktifEkip.UserName + " adlı ekip bir hastayı iyileştirdi."
                });
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> IyilesenHasta(int aktifSayfa=1)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            int toplamsayfa;

            var hastalar = _hastaService.GetirEkipIyilestirilenHastalar(out toplamsayfa, user.Id, aktifSayfa);

            ViewBag.ToplamSayfa = toplamsayfa;
            ViewBag.AktifSayfa = aktifSayfa;

            List<HastaListAllViewModel> models = new List<HastaListAllViewModel>();

            foreach (var item in hastalar)
            {
                HastaListAllViewModel model = new HastaListAllViewModel();
                model.Id = item.Id;
                model.Aciklama = item.Aciklama;
                model.AppUser = item.AppUser;
                model.Aciliyet = item.Aciliyet;
                model.Raporlar = item.Raporlar;
                model.KimlikNo = item.KimlikNo;
                model.AdSoyad = item.AdSoyad;
                model.Yas = item.Yas;
                model.TestTarihi = item.TestTarihi;
                models.Add(model);
            }

            return View(models);
        }
    }
}