using CoronaHastaTakip.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaHastaTakipTaslak.DataAccess.Interfaces
{
    public interface IGenericDal<Entity> where Entity : class,IEntity,new()
    {
        void Ekle(Entity entity);
        void Sil(Entity entity);
        void Guncelle(Entity entity);
        Entity GetirIdile(int id);
        List<Entity> GetirHepsi();
    }
}
