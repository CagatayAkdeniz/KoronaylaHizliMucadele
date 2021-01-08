using CoronaHastaTakip.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaHastaTakip.Entities.Concrete
{
    public class Rapor: IEntity
    {
        public int Id { get; set; }
        public string Tanim { get; set; }
        public string Detay { get; set; }

        public int HastaId { get; set; }
        public Hasta Hasta { get; set; }
    }
}
