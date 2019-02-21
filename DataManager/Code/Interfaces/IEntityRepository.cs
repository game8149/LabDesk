using System.Collections.Generic;
using System.Data;

namespace DataManager.Code.Interfaces
{
    public interface IEntityRepository<TEntity, TKey>
        where TEntity : class
    {
        int Save(TEntity entity);
        int Remove(TEntity obj);
        int Check(TEntity obj);
        TEntity Get(TKey id);
        IEnumerable<TEntity> List();
        IEnumerable<TEntity> List(TEntity obj);
        IDictionary<TKey, TEntity> Index();
        IDictionary<TKey, TEntity> Index(TEntity obj);
        DataTable GetTable(TEntity obj);

    }
}
