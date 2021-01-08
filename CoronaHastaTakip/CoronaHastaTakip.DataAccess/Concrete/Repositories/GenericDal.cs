using CoronaHastaTakip.DataAccess.Concrete.Context;
using CoronaHastaTakip.Entities.Interface;
using CoronaHastaTakipTaslak.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoronaHastaTakipTaslak.DataAccess.Concrete.Repositories
{
    public class GenericDal<Entity> : IGenericDal<Entity>
        where Entity : class, IEntity, new()
    {
        public List<Entity> GetirHepsi()
        {
            using (var context = new CoronaHastaTakipContext())
            {
                return context.Set<Entity>().ToList();
            }
        }

        public Entity GetirIdile(int id)
        {
            using (var context = new CoronaHastaTakipContext())
            {
                return context.Set<Entity>().Find(id);
            }
        }

        public void Guncelle(Entity entity)
        {
            using (var context = new CoronaHastaTakipContext())
            {
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Ekle(Entity entity)
        {
            using (var context = new CoronaHastaTakipContext())
            {
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Sil(Entity entity)
        {
            using (var context = new CoronaHastaTakipContext())
            {
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
