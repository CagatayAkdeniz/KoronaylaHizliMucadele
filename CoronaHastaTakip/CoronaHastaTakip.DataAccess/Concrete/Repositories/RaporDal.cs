using CoronaHastaTakip.DataAccess.Concrete.Context;
using CoronaHastaTakip.Entities.Concrete;
using CoronaHastaTakipTaslak.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoronaHastaTakipTaslak.DataAccess.Concrete.Repositories
{
    public class RaporDal : GenericDal<Rapor>, IRaporDal
    {
        public Rapor GetirHastaIleAciliyetById(int id)
        {
            using (var context = new CoronaHastaTakipContext())
            {
                return context.Raporlar.Include(x => x.Hasta).ThenInclude(x => x.Aciliyet)
                    .FirstOrDefault(x => x.Id == id);
            }
        }

        public int GetirRaporSayisiAppUserId(int appUserId)
        {
            using (var context = new CoronaHastaTakipContext())
            {
                var result = context.Hastalar.Include(x => x.Raporlar).Where(x => x.AppUserId == appUserId);

                return result.SelectMany(x => x.Raporlar).Count();
            }
        }

        public int GetirToplamRaporSayisi()
        {
            using (var context = new CoronaHastaTakipContext())
            {
                return context.Raporlar.Count();
            }
        }
    }
}
