using CoronaHastaTakip.Entities.Concrete;
using CoronaHastaTakipTaslak.Business.Interfaces;
using CoronaHastaTakipTaslak.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaHastaTakipTaslak.Business.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private IAppUserDal _userDal;
        public AppUserManager(IAppUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<AppUser> GetirAdminOlmayanlar(out int toplamSayfa, int aktifSayfa = 1)
        {
            return _userDal.GetirAdminOlmayanlar(out toplamSayfa, aktifSayfa);
        }
    }
}
