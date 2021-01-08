using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaHastaTakip.Entities.Concrete;
using CoronaHastaTakip.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoronaHastaTakipTaslak.Web.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GirisYap(UserSignInViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user!=null)
                {
                    var userPasswordCheck = await _signInManager.PasswordSignInAsync(user, model.Password,
                                                                            model.RememberMe, false);
                    if(userPasswordCheck.Succeeded)
                    {
                        var rol = await _userManager.GetRolesAsync(user);
                        if(rol.Contains("Admin"))
                        {
                            return RedirectToAction("Index", "AnaSayfa", new { area = "Admin" });
                        }
                        else
                        {
                            return RedirectToAction("Index", "AnaSayfa", new { area = "Ekip" });
                        }
                    }
                }
                ModelState.AddModelError("", "Ekip Adı veya Şifre HATALI !");
            }

            return View("Index",model);
        }

        [HttpPost]
        public async Task<IActionResult> KayitOl(UserSignUpViewModel model)
        {
            if(ModelState.IsValid)
            {
                var userName = await _userManager.FindByNameAsync(model.UserName);
                if(userName==null)
                {
                    AppUser user = new AppUser()
                    {
                        UserName = model.UserName,
                        Name = model.Name,
                        Surname = model.Surname,
                        Email = model.Email
                    };

                    var userCreate = await _userManager.CreateAsync(user, model.Password);
                    if(userCreate.Succeeded)
                    {
                        var role = await _userManager.AddToRoleAsync(user, "Ekip");
                        if(role.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
                ModelState.AddModelError("", "Bu Ekip Adı Kullanılıyor.");
            }

            return View("KayitOl", model);
        }

        public async Task<IActionResult> CikisYap()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}