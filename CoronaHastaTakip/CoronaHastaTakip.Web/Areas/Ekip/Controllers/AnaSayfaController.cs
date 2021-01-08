using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaHastaTakip.Business.Interfaces;
using CoronaHastaTakip.Entities.Concrete;
using CoronaHastaTakipTaslak.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoronaHastaTakip.Web.Areas.Ekip.Controllers
{
    [Area("Ekip")]
    [Authorize(Roles = "Ekip")]
    public class AnaSayfaController : Controller
    {
        private UserManager<AppUser> _userManager;
        private IHastaService _hastaService;
        private IRaporService _raporService;
        private IBildirimService _bildirimService;

        public AnaSayfaController(UserManager<AppUser> userManager, IHastaService hastaService,
            IRaporService raporService, IBildirimService bildirimService)
        {
            _userManager = userManager;
            _bildirimService = bildirimService;
            _raporService = raporService;
            _hastaService = hastaService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.OkunmayanBildirimSayisi = _bildirimService.GetirOkunmayanBildirimSayisi(user.Id);
            ViewBag.RaporSayisi = _raporService.GetirRaporSayisiAppUserId(user.Id);
            ViewBag.İyilesenHastaSayisi = _hastaService.GetirIyilestirilenHastaSayisiAppUserId(user.Id);
            ViewBag.AktifHastaSayisi = _hastaService.GetirAktifHastaSayisiAppUserId(user.Id);

            return View();
        }
    }
}