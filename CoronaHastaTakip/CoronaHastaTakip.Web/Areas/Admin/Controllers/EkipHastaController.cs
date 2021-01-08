using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaHastaTakip.Business.Interfaces;
using CoronaHastaTakip.Entities.Concrete;
using CoronaHastaTakip.Web.Areas.Admin.Models.HastaViewModels;
using CoronaHastaTakip.Web.Areas.Admin.Models.IsEmriViewModels;
using CoronaHastaTakip.Web.Areas.Admin.Models.RaporViewModels;
using CoronaHastaTakip.Web.Areas.Admin.Models.UserViewModels;
using CoronaHastaTakipTaslak.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CoronaHastaTakip.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class EkipHastaController : Controller
    {
        private IHastaService _hastaService;
        private IAppUserService _userService;
        private IBildirimService _bildirimService;
        private IDosyaService _dosyaService;
        private UserManager<AppUser> _userManager;

        public EkipHastaController(IHastaService hastaService, IAppUserService userService, UserManager<AppUser> userManager,
            IBildirimService bildirimService,IDosyaService dosyaService)
        {
            _dosyaService = dosyaService;
            _bildirimService = bildirimService;
            _userManager = userManager;
            _userService = userService;
            _hastaService = hastaService;
        }
        public IActionResult Index()
        {
            TempData["active"] = "isemri";

            var hastalar = _hastaService.GetirTumTablolar();
            List<HastaListAllViewModel> models = new List<HastaListAllViewModel>();

            foreach (var item in hastalar)
            {
                HastaListAllViewModel model = new HastaListAllViewModel();
                model.Id = item.Id;
                model.KimlikNo = item.KimlikNo;
                model.AdSoyad = item.AdSoyad;
                model.Yas = item.Yas;
                model.TestTarihi = item.TestTarihi;
                model.Aciklama = item.Aciklama;
                model.AppUser = item.AppUser;
                model.Aciliyet = item.Aciliyet;
                model.Raporlar = item.Raporlar;
                models.Add(model);
            }

            return View(models);
        }

        public IActionResult EkipGorevlendir(int id,int aktifSayfa=1)
        {
            TempData["active"] = "isemri";
            int toplamSayfa;

            var hasta = _hastaService.GetirAciliyetileHastaListesiById(id);
            var ekipler = _userService.GetirAdminOlmayanlar(out toplamSayfa, aktifSayfa);

            ViewBag.ToplamSayfa = toplamSayfa;

            List<AppUserListViewModel> appUserListViewModels = new List<AppUserListViewModel>();

            foreach (var item in ekipler)
            {
                AppUserListViewModel model = new AppUserListViewModel();
                model.Id = item.Id;
                model.UserName = item.UserName;
                model.Name = item.Name;
                model.Surname = item.Surname;
                model.Email = item.Email;
                appUserListViewModels.Add(model);
            }

            ViewBag.Ekipler = appUserListViewModels;

            HastaListViewModel hastaModel = new HastaListViewModel();
            
            hastaModel.Id = id;
            hastaModel.KimlikNo = hasta.KimlikNo;
            hastaModel.AdSoyad = hasta.AdSoyad;
            hastaModel.Aciklama = hasta.Aciklama;
            hastaModel.Yas = hasta.Yas;
            hastaModel.TestTarihi = hasta.TestTarihi;
            hastaModel.Aciliyet = hasta.Aciliyet;

            return View(hastaModel);
        }

        public IActionResult GoreviOnayla(GorevlendirEkipViewModel model)
        {
            var hasta = _hastaService.GetirAciliyetileHastaListesiById(model.HastaId);
            var ekip = _userManager.Users.FirstOrDefault(x=>x.Id==model.UserId);

            AppUserListViewModel userModel = new AppUserListViewModel();
            userModel.Id = ekip.Id;
            userModel.Email = ekip.Email;
            userModel.Name = ekip.Name;
            userModel.Surname = ekip.Surname;
            userModel.UserName = ekip.UserName;

            HastaListViewModel hastaModel = new HastaListViewModel();
            hastaModel.Id = hasta.Id;
            hastaModel.KimlikNo = hasta.KimlikNo;
            hastaModel.AdSoyad = hasta.AdSoyad;
            hastaModel.Aciklama = hasta.Aciklama;
            hastaModel.Yas = hasta.Yas;
            hastaModel.TestTarihi = hasta.TestTarihi;
            hastaModel.Aciliyet = hasta.Aciliyet;

            GorevlendirEkipListViewModel gorevlendirEkipModel = new GorevlendirEkipListViewModel();
            gorevlendirEkipModel.AppUser = userModel;
            gorevlendirEkipModel.Hasta = hastaModel;

            return View(gorevlendirEkipModel);
        }

        [HttpPost]
        public IActionResult EkipGorevlendir(GorevlendirEkipViewModel model)
        {
            var guncellenecekHasta = _hastaService.GetirIdile(model.HastaId);
            guncellenecekHasta.AppUserId = model.UserId;
            _hastaService.Guncelle(guncellenecekHasta);

            _bildirimService.Ekle(new Bildirim()
            {
                AppUserId = model.UserId,
                Mesaj = guncellenecekHasta.KimlikNo + " kimlik numaralı hasta için görevlendirildiniz."
            });

            return RedirectToAction("Index");
        }

        public IActionResult Detay(int id)
        {
            var hasta = _hastaService.GetirRaporlarIleUserById(id);

            HastaListAllViewModel model = new HastaListAllViewModel();
            model.Id = hasta.Id;
            model.Raporlar = hasta.Raporlar;
            model.AppUser = hasta.AppUser;
            model.Aciliyet = hasta.Aciliyet;

            return View(model);
        }

        public IActionResult GetirExcel(int id)
        {
            var hasta = _hastaService.GetirRaporlarIleUserById(id).Raporlar;

            List<RaporViewModels> models = new List<RaporViewModels>();
            foreach (var item in hasta)
            {
                RaporViewModels model = new RaporViewModels();
                model.Tanim = item.Tanim;
                model.Detay = item.Detay;
                models.Add(model);
            }

            return File(_dosyaService.AktarExcel(models),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Guid.NewGuid() + ".xlsx");
        }

        public IActionResult GetirPdf(int id)
        {
            var hasta = _hastaService.GetirRaporlarIleUserById(id).Raporlar;
            
            List<RaporViewModels> models = new List<RaporViewModels>();
            foreach (var item in hasta)
            {
                RaporViewModels model = new RaporViewModels();
                model.Tanim = item.Tanim;
                model.Detay = item.Detay;
                models.Add(model);
            }
            
            var path = _dosyaService.AktarPdf(models);

            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }
    }
}