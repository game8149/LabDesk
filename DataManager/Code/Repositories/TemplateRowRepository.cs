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
    public class TemplateRowRepository : IRepositorySimpleRecord<TemplateRow, int>
    {
        public void Add(TemplateRow entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TemplateRow Select(int id)
        {
            throw new NotImplementedException();
        }

        public TemplateRow Select(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, TemplateRow> SelectDic()
        {
            Dictionary<int, TemplateRow> dictionary = new Dictionary<int, TemplateRow>();
            TemplateRow detalle = null;
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
                    detalle = new TemplateRow
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        IdTemplate = id
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

        public IDictionary<int, TemplateRow> SelectDic(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TemplateRow> SelectList()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TemplateRow> SelectList(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectTable(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Update(TemplateRow entity)
        {
            throw new NotImplementedException();
        }
    }
}
