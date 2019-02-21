using DataManager.Code.Interfaces;
using DataManager.Recursos;
using Entity.Code.Analysis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataManager.Code.Repositories
{
    public class PriceListRepository : IEntityDetailRepository<PriceList, PriceListDetail, int>
    {
        public static PriceList GetTarifarioVigente()
        {
            PriceList tarifario = null;
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
                    tarifario = new PriceList
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Year = Convert.ToInt32(reader["ano"]),
                        OpenDay = Convert.ToDateTime(reader["fechaReg"]),
                        Active = true
                    };
                    //tarifario.Prices  = (tarifario.Id );
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

        //public static Dictionary<int, Package> GetAnalisis()
        //{
        //    Dictionary<int, Package> dictionary = new Dictionary<int, Package>();
        //    Package analisis = null;
        //    SqlConnection connection = new SqlConnection();
        //    SqlCommand command = new SqlCommand();
        //    try
        //    {
        //        connection.ConnectionString = DataConfig.Default.ConnectionString;
        //        command.Connection = connection;
        //        command.CommandText = ProcGet.GET_PAQUETE_ALL;
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.Connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            analisis = new Package
        //            {
        //                Code = reader["codigo"].ToString(),
        //                Name = reader["nombre"].ToString(),
        //                Type = (Package.PackageType)Convert.ToInt32(reader["tipo"]),
        //                Id = (string)reader["id"]

        //            };
        //            analisis.TemplatesCode = GetCodPruebaByPaquete(analisis.Id);
        //            dictionary.Add(analisis.Id, analisis);
        //        }
        //        reader.Close();
        //    }
        //    catch (SqlException exception1)
        //    {
        //        throw new Exception(exception1.Message);
        //    }
        //    finally
        //    {
        //        connection.Close();
        //        command.Dispose();
        //    }
        //    return dictionary;
        //}

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

        //public PriceList Select(int id)
        //{ 
        //    //\\\\\\\\\\\\\\\\\\\\\
        //    PriceList tarifario = null;
        //    SqlConnection connection = new SqlConnection();
        //    SqlCommand command = new SqlCommand();
        //    try
        //    {
        //        connection.ConnectionString = DataConfig.Default.ConnectionString;
        //        command.Connection = connection;
        //        command.CommandText = ProcGet.GET_TARIFARIOCAB_BYANO;
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.Parameters.AddWithValue("@ano", ano);
        //        command.Connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            tarifario = new PriceList
        //            {
        //                IdData = Convert.ToInt32(reader["id"]),
        //                Año = Convert.ToInt32(reader["ano"]),
        //                FechaRegistro = Convert.ToDateTime(reader["fechaReg"]),
        //                Vigente = false
        //            };
        //            tarifario.Listado = GetTarifarioDet(tarifario.IdData);
        //        }
        //        reader.Close();
        //    }
        //    catch (SqlException exception1)
        //    {
        //        throw new Exception(exception1.Message);
        //    }
        //    finally
        //    {
        //        connection.Close();
        //        command.Dispose();
        //    }
        //    return tarifario;
        //}


        public int Save(PriceList entity)
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
                foreach (PriceListDetail detalle in entity.Items)
                {
                    DataRow row = table.NewRow();
                    row[0] = 0;
                    row[1] = detalle.Price;
                    row[2] = detalle.IdPackage;
                    row[3] = detalle.IdPriceList;
                    table.Rows.Add(row);
                }
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                command.Connection = connection;
                command.CommandText = ProcAdd.ADD_TARIFARIOCAB;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@vigente", entity.Active);
                command.Parameters.AddWithValue("@ano", entity.Year);
                command.Parameters.AddWithValue("@FECHAREG", entity.OpenDay);
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
            return 1;
        }

        public static void SetActive(PriceList entity)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                command.Connection = connection;
                command.CommandText = ProcUpd.UPD_TARIFARIOCAB_VIGENTE;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", entity.Id);
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

        public int Remove(PriceList obj)
        {
            throw new NotImplementedException();
        }

        public int Check(PriceList obj)
        {
            throw new NotImplementedException();
        }

        public PriceList Get(int id)
        {
            PriceList tarifario = null;
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                command.Connection = connection;
                command.CommandText = ProcGet.GET_TARIFARIOCAB_BYID;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tarifario = new PriceList
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Year = Convert.ToInt32(reader["ano"]),
                        Active = Convert.ToBoolean(reader["vigente"])
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
        }

        public IEnumerable<PriceList> List()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PriceList> List(PriceList obj)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, PriceList> Index()
        {
            Dictionary<int, PriceList> dictionary = new Dictionary<int, PriceList>();
            PriceList priceList = null;
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
                    priceList = new PriceList
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Year = Convert.ToInt32(reader["ano"]),
                        RegisteredTime = Convert.ToDateTime(reader["fechaReg"]),
                        Active = Convert.ToBoolean(reader["vigente"])
                    }; 
                    dictionary.Add(priceList.Id, priceList);
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

        public IDictionary<int, PriceList> Index(PriceList obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PriceListDetail> ListDetail(PriceListDetail obj)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, PriceListDetail> IndexDetail(PriceListDetail obj)
        {
            Dictionary<int, PriceListDetail> dictionary = new Dictionary<int, PriceListDetail>();
            PriceListDetail detail = null;
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                command.Connection = connection;
                command.CommandText = ProcGet.GET_TARIFARIODET_BYTARIFARIOCAB;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDTARIFARIOCAB", obj.Id);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    detail = new PriceListDetail
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        IdPriceList = Convert.ToInt32(reader["idPriceList"]),
                        Price = Convert.ToDecimal(reader["price"]),
                        IdPackage = Convert.ToInt32(reader["idPackage"])
                    };
                    dictionary.Add(detail.Id, detail);
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

        public DataTable GetTable(PriceList obj)
        {
            throw new NotImplementedException();
        }
    }
}
