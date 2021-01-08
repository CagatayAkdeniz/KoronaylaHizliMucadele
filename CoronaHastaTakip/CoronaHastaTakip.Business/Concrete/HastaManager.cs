using CoronaHastaTakip.Entities.Concrete;
using CoronaHastaTakipTaslak.Business.Interfaces;
using CoronaHastaTakipTaslak.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CoronaHastaTakipTaslak.Business.Concrete
{
    public class HastaManager : IHastaService
    {
        private IHastaDal _hastaDal;
        public HastaManager(IHastaDal hastaDal)
        {
            _hastaDal = hastaDal;
        }

        public void Ekle(Hasta entity)
        {
            _hastaDal.Ekle(entity);
        }

        public List<Hasta> GetirAciliyetIleHastaListesi()
        {
            return _hastaDal.GetirAciliyetIleHastaListesi();
        }

        public Hasta GetirAciliyetileHastaListesiById(int id)
        {
            return _hastaDal.GetirAciliyetileHastaListesiById(id);
        }

        public int GetirAktifHastaSayisiAppUserId(int appUserId)
        {
            return _hastaDal.GetirAktifHastaSayisiAppUserId(appUserId);
        }

        public List<Hasta> GetirEkipIyilestirilenHastalar(out int toplamSayfa, int appUserId, int aktifSayfa)
        {
            return _hastaDal.GetirEkipIyilestirilenHastalar(out toplamSayfa, appUserId, aktifSayfa);
        }

        public int GetirEkipOlmayanHasta()
        {
            return _hastaDal.GetirEkipOlmayanHasta();
        }

        public List<Hasta> GetirHepsi()
        {
            return _hastaDal.GetirHepsi();
        }

        public Hasta GetirIdile(int id)
        {
            return _hastaDal.GetirIdile(id);
        }

        public List<Hasta> GetirileAppUserId(int appUserId)
        {
            return _hastaDal.GetirileAppUserId(appUserId);
        }

        public List<Hasta> GetirIyilestirilenHastalar(out int toplamSayfa, int aktifSayfa)
        {
            return _hastaDal.GetirIyilestirilenHastalar(out toplamSayfa, aktifSayfa);
        }

        public Hasta GetirRaporlarIleUserById(int id)
        {
            return _hastaDal.GetirRaporlarIleUserById(id);
        }

        public int GetirTamamlanmisHastaSayisi()
        {
            return _hastaDal.GetirTamamlanmisHastaSayisi();
        }

        public List<Hasta> GetirTumTablolar()
        {
            return _hastaDal.GetirTumTablolar();
        }

        public List<Hasta> GetirTumTablolarByFilter(Expression<Func<Hasta, bool>> filter)
        {
            return _hastaDal.GetirTumTablolarByFilter(filter);
        }

        public int GetirIyilestirilenHastaSayisiAppUserId(int appUserId)
        {
            return _hastaDal.GetirIyilestirilenHastaSayisiAppUserId(appUserId);
        }

        public void Guncelle(Hasta entity)
        {
            _hastaDal.Guncelle(entity);
        }
        
        public void Sil(Hasta entity)
        {
            _hastaDal.Sil(entity);
        }
    }
}
