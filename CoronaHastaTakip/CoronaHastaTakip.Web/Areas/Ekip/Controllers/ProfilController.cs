using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using CoronaHastaTakip.Entities.Concrete;
using CoronaHastaTakip.Web.Areas.Admin.Models.UserViewModels;
using CoronaHastaTakip.Web.Areas.Ekip.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoronaHastaTakip.Web.Areas.Ekip.Controllers
{
    [Area("Ekip")]
    [Authorize(Roles ="Ekip")]
    public class ProfilController : Controller
    {
        private UserManager<AppUser> _userManager;
        public ProfilController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            EkipUpdateViewModel model = new EkipUpdateViewModel();
            model.Id = user.Id;
            model.Name = user.Name;
            model.Surname = user.Surname;
            model.Email = user.Email;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(EkipUpdateViewModel model)
        {
            if(ModelState.IsValid)
            {
                var guncellenecekEkip = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == model.Id);

                guncellenecekEkip.Name = model.Name;
                guncellenecekEkip.Surname = model.Surname;
                guncellenecekEkip.Email = model.Email;

                var result = await _userManager.UpdateAsync(guncellenecekEkip);

                if (result.Succeeded)
                {
                    TempData["message"] = "Güncelleme işlemi başarı bir şekilde gerçekleşti";
                    return RedirectToAction("Index");
                }

            }
            return View(model);
        }
    }
}