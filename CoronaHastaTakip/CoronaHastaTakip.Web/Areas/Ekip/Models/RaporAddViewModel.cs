using CoronaHastaTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaHastaTakip.Web.Areas.Ekip.Models
{
    public class RaporAddViewModel
    {
        [Required(ErrorMessage = "Tanım alanı boş geçilemez.")]
        public string Tanim { get; set; }
        [Required(ErrorMessage = "Detay alanı boş geçilemez.")]
        public string Detay { get; set; }
        public int HastaId { get; set; }
        public Hasta Hasta { get; set; }
    }
}
