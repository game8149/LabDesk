using DataManager.Code.Interfaces;
using Entity.Code.Business;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataManager.Code.Repositories
{
    public class OfficeRepository : IEntityRepository<Office, int>
    {
        //public IDictionary<int, Office> SelectDic()
        //{
        //    SqlConnection connection = new SqlConnection
        //    {
        //        ConnectionString = DataConfig.Default.ConnectionString
        //    };
        //    SqlCommand command = new SqlCommand();
        //    Dictionary<int, Office> dictionary = new Dictionary<int, Office>();
        //    command.Connection = connection;
        //    command.CommandText = ProcGet.GET_CONSULTORIO_ALL;
        //    command.CommandType = CommandType.StoredProcedure;
        //    command.Connection.Open();
        //    SqlDataReader reader = command.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        Office consultorio = new Office
        //        {
        //            Id = Convert.ToInt32(reader["id"]),
        //            Nombre = reader["nombre"].ToString()
        //        };
        //        dictionary.Add(consultorio.Id, consultorio);
        //    }
        //    connection.Close();
        //    command.Dispose();
        //    return dictionary;
        //}
        public int Check(Office obj)
        {
            throw new NotImplementedException();
        }

        public Office Get(int id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetTable(Office obj)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, Office> Index()
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, Office> Index(Office obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Office> List()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Office> List(Office obj)
        {
            throw new NotImplementedException();
        }

        public int Remove(Office obj)
        {
            throw new NotImplementedException();
        }

        public int Save(Office entity)
        {
            throw new NotImplementedException();
        }
    }
}
