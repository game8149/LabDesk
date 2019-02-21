
using DataManager;
using DataManager.Code.Interfaces;
using DataManager.Recursos;
using Entity.Code.Location;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MinLab.Code.DataLayer
{

    public class UbigeoRespository : IEntityRepository<Ubigeo,string>
    {
        public int Check(Ubigeo obj)
        {
            throw new NotImplementedException();
        }

        public Ubigeo Get(string id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetTable(Ubigeo obj)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, Ubigeo> Index()
        {
            Ubigeo entity = null;
            Dictionary<string, Ubigeo> dictionary = new Dictionary<string, Ubigeo>();
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcGet.GET_DISTRITO_ALL,
                CommandType = CommandType.StoredProcedure
            };
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                entity = new Ubigeo
                {
                    Id  =reader["id"].ToString(),
                    Description = reader["nombre"].ToString()
                };
                //distrito.Sectores = this.GetSectorAll(distrito.IdData);
                dictionary.Add(entity.Id, entity);
            }
            reader.Close();
            connection.Close();
            command.Dispose();
            return dictionary;
        }

        public IDictionary<string, Ubigeo> Index(Ubigeo obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ubigeo> List()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ubigeo> List(Ubigeo obj)
        {
            throw new NotImplementedException();
        }

        public int Remove(Ubigeo obj)
        {
            throw new NotImplementedException();
        }

        public int Save(Ubigeo entity)
        {
            throw new NotImplementedException();
        }
    }
}
