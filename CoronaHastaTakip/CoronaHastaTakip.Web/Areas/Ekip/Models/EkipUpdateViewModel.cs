using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaHastaTakip.Web.Areas.Ekip.Models
{
    public class EkipUpdateViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad Alanı Boş Geçilemez.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad Alanı Boş Geçilemez.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Email Alanı Boş Geçilemez.")]
        public string Email { get; set; }
    }
}
