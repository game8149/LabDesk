using DataManager.Recursos;
using EntityLab.Code.Hospital.Analisis;
using EntityLab.Code.Base;
using EntityLab.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataManager.Repositories
{
    public class ExamOrderRepository : IRepositoryDetailedRecord<ExamOrder, ExamOrderDetailed,int>
    {
        public void Add(ExamOrder entity)
        {

            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                DataTable table = new DataTable();
                table.Columns.Add("idTemp", typeof(int));
                table.Columns.Add("idPaquete", typeof(int));
                table.Columns.Add("cobertura", typeof(int));
                foreach (ExamOrderDetailed detalle in entity.Detalle.Values)
                {
                    DataRow row = table.NewRow();
                    row[0] = 0;
                    row[1] = detalle.IdDataPaquete;
                    row[2] = detalle.Cobertura;
                    table.Rows.Add(row);
                }
                command.Connection = connection;
                command.CommandText = ProcAdd.ADD_ORDENCAB;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@numero", entity.Boleta);
                command.Parameters.AddWithValue("@fecha", entity.FechaRegistro);
                command.Parameters.AddWithValue("@ultimaModificacion", entity.UltimaModificacion);
                command.Parameters.AddWithValue("@estado", entity.Estado);
                command.Parameters.AddWithValue("@idPaciente", entity.IdPaciente);
                command.Parameters.AddWithValue("@gestante", entity.EnGestacion);
                command.Parameters.AddWithValue("@idConsultorio", entity.IdHospitalOffice);
                command.Parameters.AddWithValue("@idMedico", entity.IdMedic);
                command.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                command.Parameters.AddWithValue("@detalle", table).SqlDbType = SqlDbType.Structured;
                command.Connection.Open();
                command.ExecuteNonQuery();
                entity.IdData = Convert.ToInt32(command.Parameters["@id"].Value);
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

            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            DataTable table = new DataTable();
            table.Columns.Add("idTemp", typeof(int));
            table.Columns.Add("idPaquete", typeof(int));
            table.Columns.Add("cobertura", typeof(int));
            foreach (ExamOrderDetailed detalle in entity.Detalle.Values)
            {
                DataRow row = table.NewRow();
                row[0] = detalle.IdData;
                row[1] = detalle.IdDataPaquete;
                row[2] = detalle.Cobertura;
                table.Rows.Add(row);
            }
            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                command.Connection = connection;
                command.CommandText = ProcAdd.ADD_ORDENDET;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", entity.IdData);
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
                        Boleta = reader["numero"].ToString(),
                        FechaRegistro = Convert.ToDateTime(reader["fechaRegistro"]),
                        IdPaciente = Convert.ToInt32(reader["idPaciente"]),
                        IdData = Convert.ToInt32(reader["id"]),
                        Estado = (ExamOrder.EstadoOrden)Convert.ToInt32(reader["estado"]),
                        UltimaModificacion = Convert.ToDateTime(reader["ultimaModificacion"]),
                        EnGestacion = Convert.ToBoolean(reader["gestante"]),
                        IdMedic = Convert.ToInt32(reader["idMedico"]),
                        IdHospitalOffice = Convert.ToInt32(reader["idConsultorio"])
                    };
                    entity.Detalle = null;
                    dictionary.Add(entity.IdData, entity);
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
                        Boleta = reader["numero"].ToString(),
                        FechaRegistro = Convert.ToDateTime(reader["fechaRegistro"]),
                        IdPaciente = Convert.ToInt32(reader["idPaciente"]),
                        IdData = Convert.ToInt32(reader["id"]),
                        Estado = (ExamOrder.EstadoOrden)Convert.ToInt32(reader["estado"]),
                        UltimaModificacion = Convert.ToDateTime(reader["ultimaModificacion"])
                    };
                    entity.EnGestacion = Convert.ToBoolean(reader["gestante"]);
                    entity.IdMedic = Convert.ToInt32(reader["idMedico"]);
                    entity.IdHospitalOffice = Convert.ToInt32(reader["idConsultorio"]);

                    entity.Detalle = null;
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

        }
        public void Delete(int id)
        {
            connection = new SqlConnection();
            command = new SqlCommand();
            DataTable table = new DataTable();
            table.Columns.Add("idTemp", typeof(int));
            table.Columns.Add("idPaquete", typeof(int));
            table.Columns.Add("cobertura", typeof(int));
            foreach (ExamOrderDetailed detalle in entity.Detalle.Values)
            {
                DataRow row = table.NewRow();
                row[0] = detalle.IdData;
                row[1] = detalle.IdDataPaquete;
                row[2] = detalle.Cobertura;
                table.Rows.Add(row);
            }
            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                command.Connection = connection;
                command.CommandText = ProcDel.DEL_ORDENDET;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@detalleDeleted", table).SqlDbType = SqlDbType.Structured;
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

        public IDictionary<int, ExamOrderDetailed> SelectDic()
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            Dictionary<int, ExamOrderDetailed> dictionary = new Dictionary<int, ExamOrderDetailed>();
            ExamOrderDetailed detalle = null;
            connection = new SqlConnection();
            command = new SqlCommand();
            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                command.Connection = connection;
                command.CommandText = ProcGet.GET_ORDENDET_BYORDENCAB;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idOrden", id);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    detalle = new ExamOrderDetailed
                    {
                        IdData = Convert.ToInt32(reader["id"]),
                        IdDataPaquete = Convert.ToInt32(reader["idPaquete"]),
                        Cobertura = Convert.ToInt32(reader["cobertura"])
                    };
                    dictionary.Add(detalle.IdData, detalle);
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
        }

        public void Update(ExamOrderDetailed entity)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            connection = new SqlConnection();
            command = new SqlCommand();
            DataTable table = new DataTable();
            table.Columns.Add("id", typeof(int));
            table.Columns.Add("idPaquete", typeof(int));
            table.Columns.Add("cobertura", typeof(int));
            foreach (ExamOrderDetailed detalle in entity.Detalle.Values)
            {
                DataRow row = table.NewRow();
                row[0] = detalle.IdData;
                row[1] = detalle.IdDataPaquete;
                row[2] = detalle.Cobertura;
                table.Rows.Add(row);
            }
            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                command.Connection = connection;
                command.CommandText = ProcUpd.UPD_ORDENDET;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", entity.IdData);
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
                command.Parameters.AddWithValue("@id", entity.IdData);
                command.Parameters.AddWithValue("@numero", entity.Boleta);
                command.Parameters.AddWithValue("@fecha", entity.FechaRegistro);
                command.Parameters.AddWithValue("@ultimaModificacion", entity.UltimaModificacion);
                command.Parameters.AddWithValue("@estado", entity.Estado);
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

        public IDictionary<int, ExamOrder> SelectDic()
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

        public IEnumerable<ExamOrderDetailed> SelectDetailedList(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExamOrderDetailed> SelectDetailedList(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, ExamOrderDetailed> SelectDetailedDic(int id)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, ExamOrderDetailed> SelectDetailedDic(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        IDictionary<int, ExamOrder> IRepositoryDetailedRecord<ExamOrder, ExamOrderDetailed, int>.SelectDic(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
