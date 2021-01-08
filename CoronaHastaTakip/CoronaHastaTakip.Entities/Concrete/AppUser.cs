using CoronaHastaTakip.Entities.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaHastaTakip.Entities.Concrete
{
    public class AppUser: IdentityUser<int>, IEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public List<Hasta> Hastalar { get; set; }
        public List<Bildirim> Bildirimler { get; set; }
    }
}
