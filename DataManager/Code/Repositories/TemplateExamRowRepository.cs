using DataManager.Recursos;
using EntityLab.Code.Hospital.Analisis.Templates;
using EntityLab.Code.Base;
using EntityLab.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataManager.Code.Repositories
{
    public class TemplateExamRowRepository : IRepositorySimpleRecord<TemplateExamRow, int>
    {
        public void Add(TemplateExamRow entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TemplateExamRow Select(int id)
        {
            throw new NotImplementedException();
        }

        public TemplateExamRow Select(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, TemplateExamRow> SelectDic()
        {
            Dictionary<int, TemplateExamRow> dictionary = new Dictionary<int, TemplateExamRow>();
            TemplateExamRow detalle = null;
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                command.Connection = connection;
                command.CommandText = ProcGet.GET_TARIFARIODET_BYTARIFARIOCAB;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDTARIFARIOCAB", id);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    detalle = new TemplateExamRow
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        IdTemplateExam = id
                        //Precio = Convert.ToDouble(reader["precio"]),
                        //IdPaquete = Convert.ToInt32(reader["idPaquete"])
                    };
                    dictionary.Add(detalle.Id , detalle);
                }
                reader.Close();
            }
            catch (SqlException exception1)
            {
                throw new Exception(exception1.Message);
            }
            finally
            {
                connection.Close();
                command.Dispose();
            }
            return dictionary;
        }

        public IDictionary<int, TemplateExamRow> SelectDic(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TemplateExamRow> SelectList()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TemplateExamRow> SelectList(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectTable(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Update(TemplateExamRow entity)
        {
            throw new NotImplementedException();
        }
    }
}
