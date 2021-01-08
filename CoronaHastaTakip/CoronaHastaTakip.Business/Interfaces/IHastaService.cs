using CoronaHastaTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CoronaHastaTakipTaslak.Business.Interfaces
{
    public interface IHastaService: IGenericService<Hasta>
    {
        List<Hasta> GetirAciliyetIleHastaListesi();
        List<Hasta> GetirTumTablolar();
        Hasta GetirAciliyetileHastaListesiById(int id);
        List<Hasta> GetirileAppUserId(int appUserId);
        List<Hasta> GetirTumTablolarByFilter(Expression<Func<Hasta, bool>> filter);
        Hasta GetirRaporlarIleUserById(int id);
        List<Hasta> GetirEkipIyilestirilenHastalar(out int toplamSayfa, int appUserId, int aktifSayfa);
        List<Hasta> GetirIyilestirilenHastalar(out int toplamSayfa, int aktifSayfa);
        int GetirEkipOlmayanHasta();
        int GetirTamamlanmisHastaSayisi();
        int GetirIyilestirilenHastaSayisiAppUserId(int appUserId);
        int GetirAktifHastaSayisiAppUserId(int appUserId);
    }
}
