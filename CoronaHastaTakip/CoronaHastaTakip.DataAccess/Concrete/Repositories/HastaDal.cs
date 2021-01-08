using CoronaHastaTakip.DataAccess.Concrete.Context;
using CoronaHastaTakip.Entities.Concrete;
using CoronaHastaTakipTaslak.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CoronaHastaTakipTaslak.DataAccess.Concrete.Repositories
{
    public class HastaDal: GenericDal<Hasta>, IHastaDal
    {     
        public List<Hasta> GetirAciliyetIleHastaListesi()
        {
            using (var context = new CoronaHastaTakipContext())
            {
                return context.Hastalar.Include(x => x.Aciliyet).Where(x => !x.Durum).
                    OrderByDescending(x => x.TestTarihi).ToList();
            }
        }

        public Hasta GetirAciliyetileHastaListesiById(int id)
        {
            using (var context = new CoronaHastaTakipContext())
            {
                return context.Hastalar.Include(x => x.Aciliyet).FirstOrDefault(x => !x.Durum
                                                                                && x.Id == id);
            }
        }

        public int GetirAktifHastaSayisiAppUserId(int appUserId)
        {
            using (var context = new CoronaHastaTakipContext())
            {
                return context.Hastalar.Where(x => x.AppUserId == appUserId && !x.Durum).Count();
            }
        }

        public List<Hasta> GetirEkipIyilestirilenHastalar(out int toplamSayfa, int appUserId, int aktifSayfa = 1)
        {
            using (var context = new CoronaHastaTakipContext())
            {
                var result = context.Hastalar.Include(x => x.Aciliyet).Include(x => x.AppUser).Include(x=>x.Raporlar)
                    .Where(x => x.AppUserId == appUserId && x.Durum);

                toplamSayfa = (int)Math.Ceiling((double)result.Count() / 3);

                return result.Skip((aktifSayfa - 1) * 6).Take(6).ToList();
            }
        }

        public int GetirEkipOlmayanHasta()
        {
            using (var context = new CoronaHastaTakipContext())
            {
                return context.Hastalar.Where(x => x.AppUserId == null && !x.Durum).Count();
            }
        }

        public List<Hasta> GetirileAppUserId(int appUserId)
        {
            using (var context = new CoronaHastaTakipContext())
            {
                return context.Hastalar.Where(x => x.AppUserId == appUserId).ToList();
            }
        }

        public List<Hasta> GetirIyilestirilenHastalar(out int toplamSayfa, int aktifSayfa = 1)
        {
            using (var context = new CoronaHastaTakipContext())
            {
                var result = context.Hastalar.Include(x => x.Aciliyet).Include(x => x.AppUser).Include(x => x.Raporlar)
                    .Where(x => x.Durum);

                toplamSayfa = (int)Math.Ceiling((double)result.Count() / 3);

                return result.Skip((aktifSayfa - 1) * 6).Take(6).ToList();
            }
        }

        public Hasta GetirRaporlarIleUserById(int id)
        {
            using (var context = new CoronaHastaTakipContext())
            {
                return context.Hastalar.Include(x => x.Raporlar).Include(x => x.AppUser).Include(x=>x.Aciliyet)
                    .FirstOrDefault(x => x.Id == id);
            }
        }

        public int GetirTamamlanmisHastaSayisi()
        {
            using (var context = new CoronaHastaTakipContext())
            {
                return context.Hastalar.Where(x => x.Durum).Count();
            }
        }

        public List<Hasta> GetirTumTablolar()
        {
            using (var context = new CoronaHastaTakipContext())
            {
                return context.Hastalar.Include(x => x.AppUser).Include(x => x.Aciliyet).Include(x => x.Raporlar)
                    .Where(x => !x.Durum).OrderByDescending(x => x.TestTarihi).ToList();
            }
        }

        public List<Hasta> GetirTumTablolarByFilter(Expression<Func<Hasta, bool>> filter)
        {
            using (var context = new CoronaHastaTakipContext())
            {
                return context.Hastalar.Include(x => x.AppUser).Include(x => x.Aciliyet).Include(x => x.Raporlar)
                    .Where(filter).OrderByDescending(x => x.TestTarihi).ToList();
            }
        }

        public int GetirIyilestirilenHastaSayisiAppUserId(int appUserId)
        {
            using (var context = new CoronaHastaTakipContext())
            {
                return context.Hastalar.Where(x => x.AppUserId == appUserId && x.Durum).Count();
            }
        }
    }
}
