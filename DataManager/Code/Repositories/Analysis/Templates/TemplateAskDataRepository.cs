using DataManager.Code.Interfaces;
using DataManager.Recursos;
using Entity.Code.Analysis.Templates;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataManager.Code.Repositories.Analysis.Templates
{
    public class TemplateAskDataRepository : IEntityRepository<TemplateAskData, int> 
    {
        public int Check(TemplateAskData obj)
        {
            throw new NotImplementedException();
        }

        public TemplateAskData Get(int id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetTable(TemplateAskData obj)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, TemplateAskData> Index()
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, TemplateAskData> Index(TemplateAskData obj)
        {
            Dictionary<int, TemplateAskData> dictionary = new Dictionary<int, TemplateAskData>();
            TemplateAskData list = null;
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcGet.GET_LISTA_BYITEM,
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@idItem", obj.Id);
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                list = new TemplateAskData
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Name = reader["nombre"].ToString(),
                    Index = Convert.ToInt32(reader["indice"])
                };
                dictionary.Add(list.Id, list);
            }
            reader.Close();
            connection.Close();
            command.Dispose();
            return dictionary;
        }

        public IEnumerable<TemplateAskData> List()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TemplateAskData> List(TemplateAskData obj)
        {
            throw new NotImplementedException();
        }

        public int Remove(TemplateAskData obj)
        {
            throw new NotImplementedException();
        }

        public int Save(TemplateAskData entity)
        {
            throw new NotImplementedException();
        } 
         
    }
}
