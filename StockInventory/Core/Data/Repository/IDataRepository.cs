using Stock.Web.Data;
using System.Collections.Generic;

namespace Stock.Web.Data.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        void Add(TEntity entity);
        void Update(TEntity updateentity, TEntity entity);
        void Delete(TEntity updateentity);
    }
}
