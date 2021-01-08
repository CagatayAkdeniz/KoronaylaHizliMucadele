using CoronaHastaTakip.Business.Interfaces;
using CoronaHastaTakip.DataAccess.Interfaces;
using CoronaHastaTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaHastaTakip.Business.Concrete
{
    public class BildirimManager: IBildirimService
    {
        private IBildirimDal _bildirimDal;
        public BildirimManager(IBildirimDal bildirimDal)
        {
            _bildirimDal = bildirimDal;
        }

        public void Ekle(Bildirim entity)
        {
            _bildirimDal.Ekle(entity);
        }

        public List<Bildirim> GetirHepsi()
        {
            return _bildirimDal.GetirHepsi();
        }

        public Bildirim GetirIdile(int id)
        {
            return _bildirimDal.GetirIdile(id);
        }

        public int GetirOkunmayanBildirimSayisi(int appUserId)
        {
            return _bildirimDal.GetirOkunmayanBildirimSayisi(appUserId);
        }

        public List<Bildirim> GetirOkunmayanlar(int appUserId)
        {
            return _bildirimDal.GetirOkunmayanlar(appUserId);
        }

        public void Guncelle(Bildirim entity)
        {
            _bildirimDal.Guncelle(entity);
        }

        public void Sil(Bildirim entity)
        {
            _bildirimDal.Sil(entity);
        }
    }
}
