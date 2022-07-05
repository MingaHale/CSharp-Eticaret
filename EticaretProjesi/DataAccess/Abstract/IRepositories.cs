using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRepositories<TEntity> where TEntity : class
    {
        public void Insert(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(Expression<Func<TEntity, bool>> where);
        public List<TEntity> GetAll();
        public TEntity GetById(Expression<Func<TEntity, bool>> where);
        public int SaveChanges();
    }
}
