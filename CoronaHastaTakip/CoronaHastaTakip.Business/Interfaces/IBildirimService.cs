using CoronaHastaTakip.Entities.Concrete;
using CoronaHastaTakipTaslak.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaHastaTakip.Business.Interfaces
{
    public interface IBildirimService: IGenericService<Bildirim>
    {
        List<Bildirim> GetirOkunmayanlar(int appUserId);
        int GetirOkunmayanBildirimSayisi(int appUserId);
    }
}
