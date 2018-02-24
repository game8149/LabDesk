using EntityLab.Code.Base;
using System.Collections.Generic;
using System.Data;

namespace EntityLab.Code.Interfaces
{
    public interface IRepositorySimpleRecord<TEntity,TId> where TEntity : class 
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TId id);
        TEntity Select(TId id);
        TEntity Select(FilterParameter[] parameters);
        IEnumerable<TEntity> SelectList();
        IDictionary<TId, TEntity> SelectDic();
        IEnumerable<TEntity> SelectList(FilterParameter[] parameters);
        IDictionary<TId, TEntity> SelectDic(FilterParameter[] parameters);
        DataTable SelectTable(FilterParameter[] parameters);

    }
}
