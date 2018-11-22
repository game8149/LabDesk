using DataManager.Recursos;
using EntityLab.Code.Base;
using EntityLab.Code.Business;
using EntityLab.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataManager.Code.Repositories
{
    public class OfficeRepository : IRepositorySimpleRecord<Office, int>
    {
        public void Add(Office entity)
        {
            
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Office Select(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Office> SelectList()
        {
            throw new NotImplementedException();
        }
        

        public IDictionary<int, Office> SelectDic()
        {
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command = new SqlCommand();
            Dictionary<int, Office> dictionary = new Dictionary<int, Office>();
            command.Connection = connection;
            command.CommandText = ProcGet.GET_CONSULTORIO_ALL;
            command.CommandType = CommandType.StoredProcedure;
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Office consultorio = new Office
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Nombre = reader["nombre"].ToString()
                };
                dictionary.Add(consultorio.Id, consultorio);
            }
            connection.Close();
            command.Dispose();
            return dictionary;
        }

        public void Update(Office entity)
        {
            throw new NotImplementedException();
        }

        public Office Select(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Office> SelectList(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, Office> SelectDic(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectTable(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
