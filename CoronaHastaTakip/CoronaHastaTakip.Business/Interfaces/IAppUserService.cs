using CoronaHastaTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaHastaTakipTaslak.Business.Interfaces
{
    public interface IAppUserService
    {
        List<AppUser> GetirAdminOlmayanlar(out int toplamSayfa, int aktifSayfa = 1);
    }
}
