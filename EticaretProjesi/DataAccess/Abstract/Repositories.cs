using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;




using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public class Repositories<TEntity> : IRepositories<TEntity> where TEntity : class
    {
        private EticaretContext db;
        public Repositories(EticaretContext _db)
        {
            db = _db;
        }

        public void Delete(Expression<Func<TEntity, bool>> where)
        {
            db.Remove(GetById(where));
        }

        public List<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList();
        }

        public TEntity GetById(Expression<Func<TEntity, bool>> where)
        {
            //First => Kesinlikle data gelicektir.
            //FirstOrDefault => Data gelmeyebilir. Data yok ise NULL yap.
            return db.Set<TEntity>().Where(where).FirstOrDefault();
        }

        public void Insert(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Added;
        }

        public int SaveChanges()
        {
            using (db.Database.BeginTransaction())
            {
                //db.SaveChanges();
                //db.Database.CommitTransaction();
                //return 1;
                
                try
                {
                    db.SaveChanges();
                    db.Database.CommitTransaction();
                    return 1;
                }
                catch (Exception)
                {
                    db.Database.RollbackTransaction();
                    return 0;

                }
                
            }
        }

        public void Update(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }
    }
}
