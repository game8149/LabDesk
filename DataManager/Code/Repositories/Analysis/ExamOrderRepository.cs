using DataManager.Code.Interfaces;
using DataManager.Recursos;
using Entity.Code.Analysis;
using Entity.Code.Base.Documentary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataManager.Repositories.Analysis
{
    public class ExamOrderRepository : IEntityDetailRepository<ExamOrder, ExamOrderDetail, int>
    {    
        public int Save(ExamOrder entity)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                command.Connection = connection;
                command.CommandText = ProcUpd.UPD_ORDENCAB;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", entity.Id);
                command.Parameters.AddWithValue("@numero", entity.DocumentNumberAssociated);
                command.Parameters.AddWithValue("@estado", entity.State);
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
                command.Parameters.AddWithValue("@id", entity.Id);
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
            return 1;

        }

        public int Remove(ExamOrder obj)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                command.Connection = connection;
                command.CommandText = ProcDel.DEL_ORDENCAB;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idOrden", obj.Id);
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
            return 1;
        }

        public int Check(ExamOrder obj)
        {
            throw new NotImplementedException();
        }

        public ExamOrder Get(int id)
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

                    entity.Items = null;
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

        public IEnumerable<ExamOrder> List()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExamOrder> List(ExamOrder obj)
        {
            Dictionary<int, ExamOrder> dictionary = new Dictionary<int, ExamOrder>();
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            ExamOrder entity = null;
            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                command.Connection = connection;
                command.CommandText = "";

                command.CommandType = CommandType.StoredProcedure;
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    entity = new ExamOrder
                    {
                        DocumentNumberAssociated = reader["numero"].ToString(),
                        IdPaciente = Convert.ToInt32(reader["idPaciente"]),
                        Id = Convert.ToInt32(reader["id"]),
                        State = (EntityDocumentState.DocumentState)Convert.ToInt32(reader["estado"]),
                        EnGestacion = Convert.ToBoolean(reader["gestante"]),
                        IdMedic = Convert.ToInt32(reader["idMedico"]),
                        IdHospitalOffice = Convert.ToInt32(reader["idConsultorio"])
                    };
                    entity.Items = null;
                    dictionary.Add(entity.Id, entity);
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
            return dictionary.Values;
        }

        public IDictionary<int, ExamOrder> Index()
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, ExamOrder> Index(ExamOrder obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExamOrderDetail> ListDetail(ExamOrderDetail obj)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, ExamOrderDetail> IndexDetail(ExamOrderDetail obj)
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

        public DataTable GetTable(ExamOrder obj)
        {
            throw new NotImplementedException();
        }
    }
}
