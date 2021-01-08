using CoronaHastaTakip.DataAccess.Concrete.Context;
using CoronaHastaTakip.DataAccess.Interfaces;
using CoronaHastaTakip.Entities.Concrete;
using CoronaHastaTakipTaslak.DataAccess.Concrete.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoronaHastaTakip.DataAccess.Concrete.Repositories
{
    public class BildirimDal : GenericDal<Bildirim>, IBildirimDal
    {      
        public int GetirOkunmayanBildirimSayisi(int appUserId)
        {
            using (var context = new CoronaHastaTakipContext())
            {
                return context.Bildirimler.Where(x => x.AppUserId == appUserId && !x.Durum).Count();
            }
        }

        public List<Bildirim> GetirOkunmayanlar(int appUserId)
        {
            using (var context = new CoronaHastaTakipContext())
            {
                return context.Bildirimler.Where(x => x.AppUserId == appUserId && !x.Durum).ToList();
            }
        }
    }
}
