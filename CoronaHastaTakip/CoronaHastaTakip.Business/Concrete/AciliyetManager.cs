using CoronaHastaTakip.Entities.Concrete;
using CoronaHastaTakipTaslak.Business.Interfaces;
using CoronaHastaTakipTaslak.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaHastaTakipTaslak.Business.Concrete
{
    public class AciliyetManager : IAciliyetService
    {
        private IAciliyetDal _aciliyetDal;
        public AciliyetManager(IAciliyetDal aciliyetDal)
        {
            _aciliyetDal = aciliyetDal;
        }

        public void Ekle(Aciliyet entity)
        {
            _aciliyetDal.Ekle(entity);
        }

        public List<Aciliyet> GetirHepsi()
        {
            return _aciliyetDal.GetirHepsi();
        }

        public Aciliyet GetirIdile(int id)
        {
            return _aciliyetDal.GetirIdile(id);
        }

        public void Guncelle(Aciliyet entity)
        {
            _aciliyetDal.Guncelle(entity);
        }

        public void Sil(Aciliyet entity)
        {
            _aciliyetDal.Sil(entity);
        }
    }
}
