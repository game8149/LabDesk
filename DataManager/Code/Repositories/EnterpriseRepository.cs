using EntityLab.Code.Base;
using EntityLab.Code.Interfaces;
using EntityLab.Code.Management;
using System.Collections.Generic;
using System.Data;

namespace DataManager.Code.Repositories
{
    public class EnterpriseRepository : IRepositorySimpleRecord<Enterprise, int>
    {
        public void Add(Enterprise entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Enterprise Select(int id)
        {
            throw new System.NotImplementedException();
        }

        public Enterprise Select(FilterParameter[] parameters)
        {
            throw new System.NotImplementedException();
        }

        public IDictionary<int, Enterprise> SelectDic()
        {
            throw new System.NotImplementedException();
        }

        public IDictionary<int, Enterprise> SelectDic(FilterParameter[] parameters)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Enterprise> SelectList()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Enterprise> SelectList(FilterParameter[] parameters)
        {
            throw new System.NotImplementedException();
        }

        public DataTable SelectTable(FilterParameter[] parameters)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Enterprise entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
