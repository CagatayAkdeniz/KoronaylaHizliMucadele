using CoronaHastaTakip.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaHastaTakip.Entities.Concrete
{
    public class Hasta: IEntity
    {
        public int Id { get; set; }
        public string KimlikNo { get; set; }
        public string AdSoyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public int Yas 
        {
            get
            {
                return Convert.ToInt32((DateTime.Now.Year) - (DogumTarihi.Year));
            }
        }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
        public DateTime TestTarihi { get; set; } = DateTime.Now;

        public int AciliyetId { get; set; }
        public Aciliyet Aciliyet { get; set; }

        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public List<Rapor> Raporlar { get; set; }
    }
}
