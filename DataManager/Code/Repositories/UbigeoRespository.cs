
using DataManager;
using DataManager.Recursos;
using Entity.Code.Base;
using Entity.Code.Base.FilterStructure;
using Entity.Code.Interfaces;
using Entity.Code.Location;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MinLab.Code.DataLayer
{

    public class UbigeoRespository : IEntityRepository<Ubigeo,string>
    {
        public void Add(Ubigeo entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Ubigeo Select(string id)
        {
            throw new NotImplementedException();
        }

        public Ubigeo Select(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, Ubigeo> SelectDic()
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

        public IDictionary<string, Ubigeo> SelectDic(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ubigeo> SelectList()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ubigeo> SelectList(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectTable(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Update(Ubigeo entity)
        {
            throw new NotImplementedException();
        }
    }
}
