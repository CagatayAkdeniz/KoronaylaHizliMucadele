using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaHastaTakip.Entities.Concrete;
using CoronaHastaTakipTaslak.Business.Interfaces;
using CoronaHastaTakipTaslak.Web.Areas.Admin.Models.AciliyetViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoronaHastaTakipTaslak.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AciliyetController : Controller
    {
        private IAciliyetService _aciliyetService;
        public AciliyetController(IAciliyetService aciliyetService)
        {
            _aciliyetService = aciliyetService;
        }

        public IActionResult Index()
        {
            TempData["active"] = "aciliyet";

            List<Aciliyet> aciliyetler = _aciliyetService.GetirHepsi();

            List<AciliyetListViewModel> models = new List<AciliyetListViewModel>();

            foreach (var item in aciliyetler)
            {
                AciliyetListViewModel model = new AciliyetListViewModel();
                model.Id = item.Id;
                model.Tanim = item.Tanim;

                models.Add(model);
            }

            return View(models);
        }

        public IActionResult EkleAciliyet()
        {
            TempData["active"] = "aciliyet";

            return View(new AciliyetAddViewModel());
        }

        [HttpPost]
        public IActionResult EkleAciliyet(AciliyetAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                Aciliyet aciliyet = new Aciliyet();
                aciliyet.Tanim = model.Tanim;

                _aciliyetService.Ekle(aciliyet);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult GuncelleAciliyet(int id)
        {
            TempData["active"] = "aciliyet";

            var aciliyet = _aciliyetService.GetirIdile(id);

            AciliyetUpdateViewModel model = new AciliyetUpdateViewModel
            {
                Id = aciliyet.Id,
                Tanim = aciliyet.Tanim
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult GuncelleAciliyet(AciliyetUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _aciliyetService.Guncelle(new Aciliyet
                {
                    Id = model.Id,
                    Tanim = model.Tanim
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult SilAciliyet(int id)
        {
            var aciliyet = _aciliyetService.GetirIdile(id);

            _aciliyetService.Sil(aciliyet);

            return RedirectToAction("Index");
        }
    }
}