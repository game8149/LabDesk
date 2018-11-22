using Entity.Code.Base.FilterStructure;
using System.Collections.Generic;
using System.Data;

namespace Entity.Code.Interfaces
{
    public interface IEntitySimpeRepository<TEntity,TId> where TEntity : class 
    {
        int Save(TEntity entity);

        //
        /// <summary>
        /// Delete an object from database. In some cases only inhabilite object.
        /// </summary>
        /// <param name="id"></param>
        /// 

        int Delete(TId id);

        /// <summary>
        /// Select an object using their id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> An object of TEntity</returns>
        TEntity Select(TId id);

        
        /// <summary>
        ///  Select an object using a set of filter parameters
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        TEntity Select(FilterParameter[] parameters);

        /// <summary>
        /// Select a list of all objects
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> SelectList();

        /// <summary>
        /// Select a dictionary of all objects
        /// </summary>
        /// <returns>A dictionary of objects indexed by their id</returns>
        IDictionary<TId, TEntity> SelectDic();

        /// <summary>
        /// Select a list of objects using a set of filter parameters
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IEnumerable<TEntity> SelectList(FilterParameter[] parameters);

        /// <summary>
        /// Select a dictionary of objects using a set of filter parameters
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IDictionary<TId, TEntity> SelectDic(FilterParameter[] parameters);

        /// <summary>
        /// Select a datatable of objects using a set of filter parameters
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>

    }
}
