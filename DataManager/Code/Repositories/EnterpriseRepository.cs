using DataManager.Code.Interfaces;
using Entity.Code.Business;
using System.Collections.Generic;
using System.Data;

namespace DataManager.Code.Repositories
{
    public class EnterpriseRepository : IEntityRepository<Enterprise, int>
    {
        public int Check(Enterprise obj)
        {
            throw new System.NotImplementedException();
        }

        public Enterprise Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetTable(Enterprise obj)
        {
            throw new System.NotImplementedException();
        }

        public IDictionary<int, Enterprise> Index()
        {
            throw new System.NotImplementedException();
        }

        public IDictionary<int, Enterprise> Index(Enterprise obj)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Enterprise> List()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Enterprise> List(Enterprise obj)
        {
            throw new System.NotImplementedException();
        }

        public int Remove(Enterprise obj)
        {
            throw new System.NotImplementedException();
        }

        public int Save(Enterprise entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
