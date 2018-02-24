using DataManager.Recursos;
using EntityLab.Code.Hospital.Analisis;
using EntityLab.Code.Base;
using EntityLab.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataManager.Code.Repositories
{
    public class PricesRepository : IRepositoryDetailedRecord<Tarifario,TarifarioDetalle, int>
    {
        public void Add(Tarifario entity)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            try
            {
                DataTable table = new DataTable();
                table.Columns.Add("ID", typeof(int));
                table.Columns.Add("PRECIO", typeof(double));
                table.Columns.Add("IDPAQUETE", typeof(int));
                table.Columns.Add("IDTARIFARIOCAB", typeof(int));
                foreach (TarifarioDetalle detalle in entity.Listado.Values)
                {
                    DataRow row = table.NewRow();
                    row[0] = 0;
                    row[1] = detalle.Precio;
                    row[2] = detalle.IdPaquete;
                    row[3] = detalle.IdTarifarioCab;
                    table.Rows.Add(row);
                }
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                command.Connection = connection;
                command.CommandText = ProcAdd.ADD_TARIFARIOCAB;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@vigente", entity.Vigente);
                command.Parameters.AddWithValue("@ano", entity.Año);
                command.Parameters.AddWithValue("@FECHAREG", entity.FechaRegistro);
                command.Parameters.AddWithValue("@DETALLE", table).SqlDbType = SqlDbType.Structured;
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
            throw new NotImplementedException();
        }


        public static Tarifario GetTarifarioVigente()
        {
            Tarifario tarifario = null;
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                command.Connection = connection;
                command.CommandText = ProcGet.GET_TARIFARIOCAB_HABIL;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tarifario = new Tarifario
                    {
                        IdData = Convert.ToInt32(reader["id"]),
                        Año = Convert.ToInt32(reader["ano"]),
                        FechaRegistro = Convert.ToDateTime(reader["fechaReg"]),
                        Vigente = true
                    };
                    tarifario.Listado = (tarifario.IdData);
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
            return tarifario;
        }

        public static Dictionary<int, Package> GetAnalisis()
        {
            Dictionary<int, Package> dictionary = new Dictionary<int, Package>();
            Package analisis = null;
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                command.Connection = connection;
                command.CommandText = ProcGet.GET_PAQUETE_ALL;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    analisis = new Package
                    {
                        Codigo = reader["codigo"].ToString(),
                        Nombre = reader["nombre"].ToString(),
                        Tipo = (TipoPaquete)Convert.ToInt32(reader["tipo"]),
                        IdData = Convert.ToInt32(reader["id"])
                    };
                    analisis.PlantillasId = GetCodPruebaByPaquete(analisis.IdData);
                    dictionary.Add(analisis.IdData, analisis);
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


        public static bool GetCheckTarifarioByAño(int ano)
        {
            bool flag = false;
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                command.Connection = connection;
                command.CommandText = ProcGet.GET_TARIFARIOCAB_CHECK_BYYEAR;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@YEAR", ano);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    flag = Convert.ToBoolean(reader["count"]);
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
            return flag;
        }
        
        public static List<int> GetCodPruebaByPaquete(int idData)
        {
            List<int> list = new List<int>();
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command = new SqlCommand();
            try
            {
                command.Connection = connection;
                command.CommandText = ProcGet.GET_PLANTILLA_COD_BYPAQUETE;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idPaquete", idData);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(Convert.ToInt32(reader["id"]));
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
            return list;
        }

        public Tarifario Select(int id)
        {

            Tarifario tarifario = null;
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                command.Connection = connection;
                command.CommandText = ProcGet.GET_TARIFARIOCAB_BYID;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", id);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tarifario = new Tarifario
                    {
                        IdData = Convert.ToInt32(reader["id"]),
                        Año = Convert.ToInt32(reader["ano"]),
                        FechaRegistro = Convert.ToDateTime(reader["fechaReg"]),
                        Vigente = Convert.ToBoolean(reader["vigente"])
                    };
                    //tarifario.Listado = GetTarifarioDet(tarifario.IdData);
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
            return tarifario;
            //\\\\\\\\\\\\\\\\\\\\\
            Tarifario tarifario = null;
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                command.Connection = connection;
                command.CommandText = ProcGet.GET_TARIFARIOCAB_BYANO;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ano", ano);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tarifario = new Tarifario
                    {
                        IdData = Convert.ToInt32(reader["id"]),
                        Año = Convert.ToInt32(reader["ano"]),
                        FechaRegistro = Convert.ToDateTime(reader["fechaReg"]),
                        Vigente = false
                    };
                    tarifario.Listado = GetTarifarioDet(tarifario.IdData);
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
            return tarifario;
        }

        public IEnumerable<Tarifario> SelectList()
        {
            Dictionary<int, Tarifario> dictionary = new Dictionary<int, Tarifario>();
            Tarifario tarifario = null;
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                command.Connection = connection;
                command.CommandText = ProcGet.GET_TARIFARIOCAB_ALL;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tarifario = new Tarifario
                    {
                        IdData = Convert.ToInt32(reader["id"]),
                        Año = Convert.ToInt32(reader["ano"]),
                        FechaRegistro = Convert.ToDateTime(reader["fechaReg"]),
                        Vigente = Convert.ToBoolean(reader["vigente"])
                    };
                    tarifario.Listado = GetTarifarioDet(tarifario.IdData);
                    dictionary.Add(tarifario.IdData, tarifario);
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

        public IEnumerable<Tarifario> SelectList(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Update(Tarifario entity)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                command.Connection = connection;
                command.CommandText = ProcUpd.UPD_TARIFARIO;
                command.CommandType = CommandType.StoredProcedure;
                DataTable table = new DataTable();
                table.Columns.Add("ID", typeof(int));
                table.Columns.Add("PRECIO", typeof(double));
                table.Columns.Add("IDPAQUETE", typeof(int));
                table.Columns.Add("IDTARIFARIOCAB", typeof(int));
                foreach (TarifarioDetalle detalle in entity.Listado.Values)
                {
                    DataRow row = table.NewRow();
                    row[0] = detalle.IdData;
                    row[1] = detalle.Precio;
                    row[2] = detalle.IdPaquete;
                    row[3] = detalle.IdTarifarioCab;
                    table.Rows.Add(row);
                }
                command.Parameters.AddWithValue("@ID", entity.IdData);
                command.Parameters.AddWithValue("@ANO", entity.IdData);
                command.Parameters.AddWithValue("@FECHAREG", entity.FechaRegistro);
                command.Parameters.AddWithValue("@VIGENTE", entity.IdData);
                command.Parameters.AddWithValue("@DETALLE", table).SqlDbType = SqlDbType.Structured;
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


        public static void UpdTarifarioVigente(Tarifario entity)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                command.Connection = connection;
                command.CommandText = ProcUpd.UPD_TARIFARIOCAB_VIGENTE;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", entity.IdData);
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

        public Tarifario Select(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TarifarioDetalle> SelectDetailedList(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TarifarioDetalle> SelectDetailedList(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, TarifarioDetalle> SelectDetailedDic(int id)
        {
            Dictionary<int, TarifarioDetalle> dictionary = new Dictionary<int, TarifarioDetalle>();
            TarifarioDetalle detalle = null;
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
                    detalle = new TarifarioDetalle
                    {
                        IdData = Convert.ToInt32(reader["id"]),
                        IdTarifarioCab = id,
                        Precio = Convert.ToDouble(reader["precio"]),
                        IdPaquete = Convert.ToInt32(reader["idPaquete"])
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
            return dictionary;
        }

        public IDictionary<int, TarifarioDetalle> SelectDetailedDic(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, Tarifario> SelectDic(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectTable(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
