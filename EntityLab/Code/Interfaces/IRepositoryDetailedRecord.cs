using Entity.Code.Base.FilterStructure;
using System.Collections.Generic;
using System.Data;

namespace Entity.Code.Interfaces
{
    public interface IRepositoryDetailedRecord<TEntity,TDetail,TKey>
    {
        void Add(TEntity entity);
        void Update(TEntity entity);

        TEntity Select(TKey id);
        TEntity Select(FilterParameter[] parameters);

        IEnumerable<TDetail> SelectDetailedList(TKey id);
        IEnumerable<TDetail> SelectDetailedList(FilterParameter[] parameters);
        IDictionary<TKey, TDetail> SelectDetailedDic(TKey id);
        IDictionary<TKey, TDetail> SelectDetailedDic(FilterParameter[] parameters);

        IEnumerable<TEntity> SelectList(FilterParameter[] parameters);        
        IDictionary<TKey, TEntity> SelectDic(FilterParameter[] parameters);

        DataTable SelectTable(FilterParameter[] parameters);

    }
}
