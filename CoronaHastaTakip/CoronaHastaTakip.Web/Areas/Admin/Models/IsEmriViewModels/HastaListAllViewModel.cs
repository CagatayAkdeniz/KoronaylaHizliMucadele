using CoronaHastaTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaHastaTakip.Web.Areas.Admin.Models.IsEmriViewModels
{
    public class HastaListAllViewModel
    {
        public int Id { get; set; }
        public string KimlikNo { get; set; }
        public string AdSoyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public int Yas { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
        public DateTime TestTarihi { get; set; } = DateTime.Now;

        public AppUser AppUser { get; set; }

        public Aciliyet Aciliyet { get; set; }

        public List<Rapor> Raporlar { get; set; }
    }
}
