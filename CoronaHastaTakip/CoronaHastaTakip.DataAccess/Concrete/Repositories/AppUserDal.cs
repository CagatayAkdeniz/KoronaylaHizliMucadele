using CoronaHastaTakip.DataAccess.Concrete.Context;
using CoronaHastaTakip.Entities.Concrete;
using CoronaHastaTakipTaslak.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CoronaHastaTakipTaslak.DataAccess.Concrete.Repositories
{
    public class AppUserDal : IAppUserDal
    {
        public List<AppUser> GetirAdminOlmayanlar(out int toplamSayfa, int aktifSayfa = 1)
        {
            using (var context = new CoronaHastaTakipContext())
            {
                var result = from user in context.Users
                             join userRoles in context.UserRoles on user.Id equals userRoles.UserId
                             join roles in context.Roles on userRoles.RoleId equals roles.Id
                             where roles.Name == "Ekip"
                             select new AppUser()
                             {
                                 Id = user.Id,
                                 Name = user.Name,
                                 Surname = user.Surname,
                                 Email = user.Email,
                                 UserName = user.UserName
                             };

                toplamSayfa = (int)Math.Ceiling((double)result.Count() / 3);

                result = result.Skip((aktifSayfa - 1) * 3).Take(3);

                return result.ToList();
            }
        }
    }
}
