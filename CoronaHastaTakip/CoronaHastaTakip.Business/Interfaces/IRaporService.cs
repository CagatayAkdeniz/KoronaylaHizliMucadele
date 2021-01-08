using CoronaHastaTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaHastaTakipTaslak.Business.Interfaces
{
    public interface IRaporService: IGenericService<Rapor>
    {
        Rapor GetirHastaIleAciliyetById(int id);
        int GetirToplamRaporSayisi();
        int GetirRaporSayisiAppUserId(int appUserId);
    }
}
