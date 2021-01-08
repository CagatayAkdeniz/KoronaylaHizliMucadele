using CoronaHastaTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaHastaTakipTaslak.DataAccess.Interfaces
{
    public interface IRaporDal: IGenericDal<Rapor>
    {
        Rapor GetirHastaIleAciliyetById(int id);
        int GetirToplamRaporSayisi();
        int GetirRaporSayisiAppUserId(int appUserId);
    }
}
