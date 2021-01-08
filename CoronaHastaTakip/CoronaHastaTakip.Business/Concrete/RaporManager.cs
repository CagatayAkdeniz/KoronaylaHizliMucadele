using CoronaHastaTakip.Entities.Concrete;
using CoronaHastaTakipTaslak.Business.Interfaces;
using CoronaHastaTakipTaslak.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaHastaTakipTaslak.Business.Concrete
{
    public class RaporManager: IRaporService
    {
        private IRaporDal _raporDal;
        public RaporManager(IRaporDal raporDal)
        {
            _raporDal = raporDal;
        }

        public void Ekle(Rapor entity)
        {
            _raporDal.Ekle(entity);
        }

        public Rapor GetirHastaIleAciliyetById(int id)
        {
            return _raporDal.GetirHastaIleAciliyetById(id);
        }

        public List<Rapor> GetirHepsi()
        {
            return _raporDal.GetirHepsi();
        }

        public Rapor GetirIdile(int id)
        {
            return _raporDal.GetirIdile(id);
        }

        public int GetirRaporSayisiAppUserId(int appUserId)
        {
            return _raporDal.GetirRaporSayisiAppUserId(appUserId);
        }

        public int GetirToplamRaporSayisi()
        {
            return _raporDal.GetirToplamRaporSayisi();
        }

        public void Guncelle(Rapor entity)
        {
            _raporDal.Guncelle(entity);
        }

        public void Sil(Rapor entity)
        {
            _raporDal.Sil(entity);
        }
    }
}
