using DataManager.Recursos;
using EntityLab.Code.Analisis.Templates;
using EntityLab.Code.Base;
using EntityLab.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataManager.Code.Repositories
{
    public class TemplateExamAskDataRepository : IRepositorySimpleRecord<TemplateExamAskData, int>

    {
        public void Add(TemplateExamAskData entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TemplateExamAskData Select(int id)
        {
            throw new NotImplementedException();
        }

        public TemplateExamAskData Select(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, TemplateExamAskData> SelectDic(FilterParameter[] parameters)
        {
            Dictionary<int, TemplateExamAskData> dictionary = new Dictionary<int, TemplateExamAskData>();
            TemplateExamAskData list = null;
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
            command.Parameters.AddWithValue("@idItem", idData);
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                list = new PlantillaItemList
                {
                    IdData = Convert.ToInt32(reader["id"]),
                    Nombre = reader["nombre"].ToString(),
                    Indice = Convert.ToInt32(reader["indice"])
                };
                dictionary.Add(list.IdData, list);
            }
            reader.Close();
            connection.Close();
            command.Dispose();
            return dictionary;
        }

        public IDictionary<int, TemplateExamAskData> SelectDic()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TemplateExamAskData> SelectList()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TemplateExamAskData> SelectList(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectTable(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Update(TemplateExamAskData entity)
        {
            throw new NotImplementedException();
        }
    }
}
