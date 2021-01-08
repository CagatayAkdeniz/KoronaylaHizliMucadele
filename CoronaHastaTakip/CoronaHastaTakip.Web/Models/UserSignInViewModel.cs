using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaHastaTakip.Web.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage = "Ekip Adını Giriniz!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Parolanızı Giriniz!")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
