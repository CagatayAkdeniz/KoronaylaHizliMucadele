using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaHastaTakip.Web.Areas.Admin.Models.HastaViewModels
{
    public class HastaAddViewModel
    {
        [Required(ErrorMessage ="Kimlik NO boş geçilemez.")]
        public string KimlikNo { get; set; }
        [Required(ErrorMessage = "Ad Soyad boş geçilemez.")]
        public string AdSoyad { get; set; }
        [Required(ErrorMessage = "Doğum Tarihi boş geçilemez.")]
        public DateTime DogumTarihi { get; set; }
        public int Yas { get; set; }
        [Required(ErrorMessage = "Açıklama boş geçilemez.")]
        public string Aciklama { get; set; }
        public bool Durum { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Lütfen Aciliyet Durumunu Seçiniz")]
        public int AciliyetId { get; set; }
    }
}
