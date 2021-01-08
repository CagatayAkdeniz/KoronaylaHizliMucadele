using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaHastaTakip.Business.Interfaces;
using CoronaHastaTakip.Entities.Concrete;
using CoronaHastaTakip.Web.Areas.Admin.Models.Bildirim;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoronaHastaTakip.Web.Areas.Ekip.Controllers
{
    [Area("Ekip")]
    [Authorize(Roles ="Ekip")]
    public class BildirimController : Controller
    {
        private IBildirimService _bildirimService;
        private UserManager<AppUser> _userManager;
        public BildirimController(IBildirimService bildirimService, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _bildirimService = bildirimService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var bildirimler = _bildirimService.GetirOkunmayanlar(user.Id);

            List<BildirimListViewModel> models = new List<BildirimListViewModel>();
            foreach (var item in bildirimler)
            {
                BildirimListViewModel model = new BildirimListViewModel();
                model.Id = item.Id;
                model.Mesaj = item.Mesaj;
                models.Add(model);
            }

            return View(models);
        }

        [HttpPost]
        public IActionResult BildirimOkundu(int id)
        {
            var bildirim = _bildirimService.GetirIdile(id);
            bildirim.Durum = true;
            _bildirimService.Guncelle(bildirim);
            return RedirectToAction("Index");
        }
    }
}