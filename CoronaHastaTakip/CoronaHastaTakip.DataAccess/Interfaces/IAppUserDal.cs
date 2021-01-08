using CoronaHastaTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaHastaTakipTaslak.DataAccess.Interfaces
{
    public interface IAppUserDal
    {
        List<AppUser> GetirAdminOlmayanlar(out int toplamSayfa, int aktifSayfa = 1);
    }
}
