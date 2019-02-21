using System.Collections.Generic;
using System.Data;

namespace DataManager.Code.Interfaces
{
    public interface IEntityDetailRepository<TEntity, TDetail, TKey>
        where TEntity : class
        where TDetail : class
    {
        int Save(TEntity entity);
        int Remove(TEntity obj);
        int Check(TEntity obj);
        TEntity Get(TKey id);
        IEnumerable<TEntity> List();
        IEnumerable<TEntity> List(TEntity obj);
        IDictionary<TKey, TEntity> Index();
        IDictionary<TKey, TEntity> Index(TEntity obj);
        IEnumerable<TDetail> ListDetail(TDetail obj);
        IDictionary<TKey, TDetail> IndexDetail(TDetail obj);
        DataTable GetTable(TEntity obj);
    }
}
