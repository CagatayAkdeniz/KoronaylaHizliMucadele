using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaHastaTakip.Entities.Concrete;
using CoronaHastaTakip.Web.Areas.Admin.Models.HastaViewModels;
using CoronaHastaTakip.Web.Areas.Admin.Models.IsEmriViewModels;
using CoronaHastaTakipTaslak.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoronaHastaTakipTaslak.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class HastaController : Controller
    {
        private IAciliyetService _aciliyetService;
        private IHastaService _hastaService;
        public HastaController(IHastaService hastaService,IAciliyetService aciliyetService)
        {
            _aciliyetService = aciliyetService;
            _hastaService = hastaService;
        }

        public IActionResult Index()
        {
            TempData["active"] = "hasta";

            List<Hasta> hastalar = _hastaService.GetirAciliyetIleHastaListesi();

            List<HastaListViewModel> models = new List<HastaListViewModel>();

            foreach (var item in hastalar)
            {
                HastaListViewModel model = new HastaListViewModel();
                model.Id = item.Id;
                model.KimlikNo = item.KimlikNo;
                model.AdSoyad = item.AdSoyad;
                model.DogumTarihi = item.DogumTarihi;
                model.Yas = item.Yas;
                model.Aciklama = item.Aciklama;
                model.TestTarihi = item.TestTarihi;
                model.AciliyetId = item.AciliyetId;
                model.Aciliyet = item.Aciliyet;
                model.Durum = item.Durum;
                models.Add(model);
            }

            return View(models);
        }

        public IActionResult IyilesenHastalar(int aktifSayfa=1)
        {
            int toplamSayfa;

            var hastalar = _hastaService.GetirIyilestirilenHastalar(out toplamSayfa, aktifSayfa);

            ViewBag.ToplamSayfa = toplamSayfa;
            ViewBag.AktifSayfa = aktifSayfa;

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

        public IActionResult EkleHasta()
        {
            TempData["active"] = "hasta";

            ViewBag.Aciliyetler = new SelectList(_aciliyetService.GetirHepsi(), "Id", "Tanim");
            return View();
        }

        [HttpPost]
        public IActionResult EkleHasta(HastaAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _hastaService.Ekle(new Hasta()
                {
                    AdSoyad = model.AdSoyad,
                    KimlikNo = model.KimlikNo,
                    DogumTarihi=model.DogumTarihi,
                    Aciklama=model.Aciklama,
                    AciliyetId=model.AciliyetId,
                });

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult GuncelleHasta(int id)
        {
            TempData["active"] = "hasta";
            ViewBag.Aciliyetler = new SelectList(_aciliyetService.GetirHepsi(), "Id", "Tanim");

            var hasta = _hastaService.GetirIdile(id);

            HastaUpdateViewModel model = new HastaUpdateViewModel();
            model.AdSoyad = hasta.AdSoyad;
            model.KimlikNo = hasta.KimlikNo;
            model.DogumTarihi = hasta.DogumTarihi;
            model.Aciklama = hasta.Aciklama;
            model.AciliyetId = hasta.AciliyetId;

            return View(model);
        }

        [HttpPost]
        public IActionResult GuncelleHasta(HastaUpdateViewModel model)
        {
            if(ModelState.IsValid)
            {
                var hasta = _hastaService.GetirIdile(model.Id);

                hasta.KimlikNo = model.KimlikNo;
                hasta.AdSoyad = model.AdSoyad;
                hasta.DogumTarihi = model.DogumTarihi;
                hasta.Aciklama = model.Aciklama;
                hasta.AciliyetId = model.AciliyetId;

                _hastaService.Guncelle(hasta);

                return RedirectToAction("Index", "Hasta");
            }
            return View(model);
        }

        public IActionResult SilHasta(int id)
        {
            var hasta = _hastaService.GetirIdile(id);

            _hastaService.Sil(hasta);

            return RedirectToAction("Index");
        }
    }
}