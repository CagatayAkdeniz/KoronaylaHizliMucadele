using CoronaHastaTakip.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaHastaTakip.Entities.Concrete
{
    public class Bildirim: IEntity
    {
        public int Id { get; set; }
        public string Mesaj { get; set; }
        public bool Durum { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
