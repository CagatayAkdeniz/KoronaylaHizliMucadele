using CoronaHastaTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaHastaTakip.Web.Areas.Admin.Models.HastaViewModels
{
    public class HastaListViewModel
    {
        public int Id { get; set; }
        public string KimlikNo { get; set; }
        public string AdSoyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public int Yas { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
        public DateTime TestTarihi { get; set; } = DateTime.Now;

        public int AciliyetId { get; set; }
        public Aciliyet Aciliyet { get; set; }
    }
}
