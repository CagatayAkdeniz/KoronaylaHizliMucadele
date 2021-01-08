using CoronaHastaTakip.Entities.Concrete;
using CoronaHastaTakipTaslak.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaHastaTakip.DataAccess.Interfaces
{
    public interface IBildirimDal: IGenericDal<Bildirim>
    {
        List<Bildirim> GetirOkunmayanlar(int appUserId);
        int GetirOkunmayanBildirimSayisi(int appUserId);
    }
}
