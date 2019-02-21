using DataManager.Code.Interfaces;
using DataManager.Recursos;
using Entity.Code.Analysis.Templates;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataManager.Code.Repositories.Analysis.Templates
{
    public class TemplateRepository : IEntityRepository<Template, int>
    {
        public int Check(Template obj)
        {
            throw new NotImplementedException();
        }

        public Template Get(int id)
        {
            Template plantilla = null;
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataReader reader = null;
            connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            command = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcGet.GET_PLANTILLA,
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@id", id);
            command.Connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                plantilla = new Template
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Code = reader["codigo"].ToString(),
                    Name = reader["nombre"].ToString(),
                    Rows = new List<TemplateRow>()
                };
            }
            reader.Close();
            command.Connection.Close();
            command.Dispose();
            return plantilla;
        }

        public DataTable GetTable(Template obj)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, Template> Index()
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, Template> Index(Template obj)
        {
            Dictionary<int, Template> dictionary = new Dictionary<int, Template>();
            Template plantilla = null;
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcGet.GET_PLANTILLA_ALL,
                CommandType = CommandType.StoredProcedure
            };
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                plantilla = new Template
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Code = reader["codigo"].ToString(),
                    Name = reader["nombre"].ToString(),
                    Rows = new List<TemplateRow>()
                };
                dictionary.Add(plantilla.Id, plantilla);
            }
            reader.Close();
            command.Connection.Close();
            command.Dispose();
            return dictionary;
        }

        public IEnumerable<Template> List()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Template> List(Template obj)
        {
            throw new NotImplementedException();
        }

        public int Remove(Template obj)
        {
            throw new NotImplementedException();
        }

        public int Save(Template entity)
        {
            throw new NotImplementedException();
        }


    }
}
