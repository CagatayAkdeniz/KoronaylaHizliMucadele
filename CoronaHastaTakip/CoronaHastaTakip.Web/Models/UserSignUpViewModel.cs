using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaHastaTakip.Web.Models
{
    public class UserSignUpViewModel
    {
        [Required(ErrorMessage = "Ekip Adı Alanı Boş Geçilemez.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre Alanı Boş Geçilemez.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Şifreler Eşleşmiyor")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Email Alanı Boş Geçilemez.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Ekip Başkan Adı Alanı Boş Geçilemez.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ekip Başkan Soydı Alanı Boş Geçilemez.")]
        public string Surname { get; set; }
    }
}
