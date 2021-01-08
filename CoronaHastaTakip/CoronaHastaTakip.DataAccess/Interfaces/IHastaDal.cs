using CoronaHastaTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CoronaHastaTakipTaslak.DataAccess.Interfaces
{
    public interface IHastaDal: IGenericDal<Hasta>
    {      
        List<Hasta> GetirAciliyetIleHastaListesi();
        Hasta GetirAciliyetileHastaListesiById(int id);
        List<Hasta> GetirTumTablolar();
        List<Hasta> GetirileAppUserId(int appUserId);
        List<Hasta> GetirTumTablolarByFilter(Expression<Func<Hasta, bool>> filter);
        Hasta GetirRaporlarIleUserById(int id);
        List<Hasta> GetirEkipIyilestirilenHastalar(out int toplamSayfa, int appUserId, int aktifSayfa = 1);
        List<Hasta> GetirIyilestirilenHastalar(out int toplamSayfa,int aktifSayfa = 1);
        int GetirEkipOlmayanHasta();
        int GetirTamamlanmisHastaSayisi();
        int GetirIyilestirilenHastaSayisiAppUserId(int appUserId);
        int GetirAktifHastaSayisiAppUserId(int appUserId);
    }
}
