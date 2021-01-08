using CoronaHastaTakip.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaHastaTakip.Entities.Concrete
{
    public class Aciliyet: IEntity
    {
        public int Id { get; set; }
        public string Tanim { get; set; }

        public List<Hasta> Hastalar { get; set; }
    }
}
