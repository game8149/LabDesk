using DataManager.Recursos;
using EntityLab.Code.Analisis;
using EntityLab.Code.Base.FilterStructure;
using EntityLab.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataManager.Repositories
{
    public class ExamOrderRepository : IRepositoryDetailedRecord<ExamOrder, ExamOrderDetail,int>
    {
        public void Add(ExamOrder entity)
        {
            DataTable table = null;
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                table = new DataTable();
                table.Columns.Add("idTemp", typeof(int));
                table.Columns.Add("idPaquete", typeof(int));
                table.Columns.Add("cobertura", typeof(int));
                foreach (ExamOrderDetail detalle in entity.Items.Values)
                {
                    DataRow row = table.NewRow();
                    row[0] = 0;
                    row[1] = detalle.IdPackage;
                    row[2] = detalle.Cobertura;
                    table.Rows.Add(row);
                }
                command.Connection = connection;
                command.CommandText = ProcAdd.ADD_ORDENCAB;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@numero", entity.DocumentNumberAssociated );
                command.Parameters.AddWithValue("@fecha", entity.OnInsert);
                command.Parameters.AddWithValue("@ultimaModificacion", entity.OnUpdate);
                command.Parameters.AddWithValue("@estado", entity.State );
                command.Parameters.AddWithValue("@idPaciente", entity.IdPaciente);
                command.Parameters.AddWithValue("@gestante", entity.EnGestacion);
                command.Parameters.AddWithValue("@idConsultorio", entity.IdHospitalOffice);
                command.Parameters.AddWithValue("@idMedico", entity.IdMedic);
                command.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                command.Parameters.AddWithValue("@detalle", table).SqlDbType = SqlDbType.Structured;
                command.Connection.Open();
                command.ExecuteNonQuery();
                entity.Id = Convert.ToInt32(command.Parameters["@id"].Value);
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

            
            table = new DataTable();
            table.Columns.Add("idTemp", typeof(int));
            table.Columns.Add("idPaquete", typeof(int));
            table.Columns.Add("cobertura", typeof(int));
            foreach (ExamOrderDetail detalle in entity.Items .Values)
            {
                DataRow row = table.NewRow();
                row[0] = detalle.Id ;
                row[1] = detalle.IdPackage ;
                row[2] = detalle.Cobertura;
                table.Rows.Add(row);
            }

            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                command.Connection = connection;
                command.CommandText = ProcAdd.ADD_ORDENDET;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", entity.Id );
                command.Parameters.AddWithValue("@detalleInsert", table).SqlDbType = SqlDbType.Structured;
                command.Connection.Open();
                command.ExecuteNonQuery();
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



        }

        public void Delete(int id)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                command.Connection = connection;
                command.CommandText = ProcDel.DEL_ORDENCAB;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idOrden", id);
                command.Connection.Open();
                command.ExecuteNonQuery();
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
            
        }

        public IEnumerable<ExamOrder> SelectList()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ExamOrder> SelectList(FilterParameter[] parameters)
        {
            Dictionary<int, ExamOrder> dictionary = new Dictionary<int, ExamOrder>();
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            ExamOrder entity = null;
            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                command.Connection = connection;
                command.CommandText ="";

                command.Parameters.Add(new SqlParameter { ParameterName = "parameters", Value = FilterParameterTableFactory.MakeTable(parameters), SqlDbType = SqlDbType.Structured });

                command.CommandType = CommandType.StoredProcedure;
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    entity = new ExamOrder
                    {
                        DocumentNumberAssociated  = reader["numero"].ToString(),
                        OnInsert = Convert.ToDateTime(reader["fechaRegistro"]),
                        IdPaciente = Convert.ToInt32(reader["idPaciente"]),
                        Id  = Convert.ToInt32(reader["id"]),
                        State  = (EntityDocumentState.DocumentState)Convert.ToInt32(reader["estado"]),
                        OnUpdate  = Convert.ToDateTime(reader["ultimaModificacion"]),
                        EnGestacion = Convert.ToBoolean(reader["gestante"]),
                        IdMedic = Convert.ToInt32(reader["idMedico"]),
                        IdHospitalOffice = Convert.ToInt32(reader["idConsultorio"])
                    };
                    entity.Items  = null;
                    dictionary.Add(entity.Id , entity);
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
            return dictionary.Values ;
        }

        public ExamOrder Select(int id)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            ExamOrder entity = null;
            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                command.Connection = connection;
                command.CommandText = ProcGet.GET_ORDENCAB_BYID;
                command.Parameters.AddWithValue("@idOrden", id);
                command.CommandType = CommandType.StoredProcedure;
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    entity = new ExamOrder
                    { 
                    };
                    entity.EnGestacion = Convert.ToBoolean(reader["gestante"]);
                    entity.IdMedic = Convert.ToInt32(reader["idMedico"]);
                    entity.IdHospitalOffice = Convert.ToInt32(reader["idConsultorio"]);

                    entity.Items  = null;
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

            return entity;

        }

        public IDictionary<int, ExamOrderDetail> SelectDic()
        {

            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            Dictionary<int, ExamOrderDetail> dictionary = new Dictionary<int, ExamOrderDetail>();
            ExamOrderDetail detalle = null;
            connection = new SqlConnection();
            command = new SqlCommand();
            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                command.Connection = connection;
                command.CommandText = ProcGet.GET_ORDENDET_BYORDENCAB;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idOrden", 0);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    detalle = new ExamOrderDetail
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        IdPackage = Convert.ToInt32(reader["idPaquete"]),
                        Cobertura = Convert.ToInt32(reader["cobertura"])
                    };
                    dictionary.Add(detalle.Id, detalle);
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
       
        public void Update(ExamOrderDetail entity)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            connection = new SqlConnection();
            command = new SqlCommand();
            DataTable table = new DataTable();
            table.Columns.Add("id", typeof(int));
            table.Columns.Add("idPaquete", typeof(int));
            table.Columns.Add("cobertura", typeof(int)); 
            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                command.Connection = connection;
                command.CommandText = ProcUpd.UPD_ORDENDET;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", entity.Id );
                command.Parameters.AddWithValue("@detalleUpdate", table).SqlDbType = SqlDbType.Structured;
                command.Connection.Open();
                command.ExecuteNonQuery();
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
        }

        public void Update(ExamOrder entity)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                command.Connection = connection;
                command.CommandText = ProcUpd.UPD_ORDENCAB;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", entity.Id );
                command.Parameters.AddWithValue("@numero", entity.DocumentNumberAssociated );
                command.Parameters.AddWithValue("@fecha", entity.OnInsert);
                command.Parameters.AddWithValue("@ultimaModificacion", entity.OnUpdate );
                command.Parameters.AddWithValue("@estado", entity.State );
                command.Parameters.AddWithValue("@gestante", entity.EnGestacion);
                command.Parameters.AddWithValue("@idConsultorio", entity.IdHospitalOffice);
                command.Parameters.AddWithValue("@idMedico", entity.IdMedic);
                command.Connection.Open();
                command.ExecuteNonQuery();
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

        }

        public ExamOrder Select(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }
         

        public IEnumerable<ExamOrder> SelectDic(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectTable(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExamOrderDetail> SelectDetailedList(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExamOrderDetail> SelectDetailedList(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, ExamOrderDetail> SelectDetailedDic(int id)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, ExamOrderDetail> SelectDetailedDic(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        IDictionary<int, ExamOrder> IRepositoryDetailedRecord<ExamOrder, ExamOrderDetail, int>.SelectDic(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        
    }
}
