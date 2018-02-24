using DataManager.Recursos;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataManager.Code.Repositories
{
    class ReportRespository
    {

        public Dictionary<int, int> GetReporteAcumuladoFromDB(int cobertura, int año, int mes)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                command.Connection = connection;
                command.CommandText = ProcGet.GET_REPORTE_ACUMULADOMES;
                command.Parameters.AddWithValue("@cobertura", cobertura);
                command.Parameters.AddWithValue("@ano", año);
                command.Parameters.AddWithValue("@mes", mes);
                command.CommandType = CommandType.StoredProcedure;
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dictionary.Add(Convert.ToInt32(reader["idPaquete"]), Convert.ToInt32(reader["cantidad"]));
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



        public Dictionary<int, int> GetReporteAcumuladoFromDB(int cobertura, int año, int mes, int idMedico)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                command.Connection = connection;
                command.CommandText = ProcGet.GET_REPORTE_MEDICO_ACUMULADOMES;
                command.Parameters.AddWithValue("@idMedico", idMedico);
                command.Parameters.AddWithValue("@cobertura", cobertura);
                command.Parameters.AddWithValue("@ano", año);
                command.Parameters.AddWithValue("@mes", mes);
                command.CommandType = CommandType.StoredProcedure;
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dictionary.Add(Convert.ToInt32(reader["idPaquete"]), Convert.ToInt32(reader["cantidad"]));
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





        public Dictionary<int, int> GetReporteCantidadFromDB(int cobertura, int año, int mes)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                command.Connection = connection;
                command.CommandText = ProcGet.GET_REPORTE_CANTIDADMES;
                command.Parameters.AddWithValue("@cobertura", cobertura);
                command.Parameters.AddWithValue("@ano", año);
                command.Parameters.AddWithValue("@mes", mes);
                command.CommandType = CommandType.StoredProcedure;
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dictionary.Add(Convert.ToInt32(reader["idPaquete"]), Convert.ToInt32(reader["cantidad"]));
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

        public Dictionary<int, int> GetReporteCantidadFromDB(int cobertura, int año, int mes, int idMedico)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                command.Connection = connection;
                command.CommandText = ProcGet.GET_REPORTE_MEDICO_CANTIDADMES;
                command.Parameters.AddWithValue("@idMedico", idMedico);
                command.Parameters.AddWithValue("@cobertura", cobertura);
                command.Parameters.AddWithValue("@ano", año);
                command.Parameters.AddWithValue("@mes", mes);
                command.CommandType = CommandType.StoredProcedure;
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dictionary.Add(Convert.ToInt32(reader["idPaquete"]), Convert.ToInt32(reader["cantidad"]));
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

        public List<int[]> GetReporteEdadFromDB(int cobertura, int año, int mes)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            List<int[]> list = new List<int[]>();
            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                command.Connection = connection;
                command.CommandText = ProcGet.GET_REPORTE_EDAD;
                command.Parameters.AddWithValue("@cobertura", cobertura);
                command.Parameters.AddWithValue("@ano", año);
                command.Parameters.AddWithValue("@mes", mes);
                command.CommandType = CommandType.StoredProcedure;
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int[] item = new int[0x22];
                    int index = 0;
                    item[index] = Convert.ToInt32(reader["idPaquete"]);
                    index++;
                    while (index <= 20)
                    {
                        item[index] = Convert.ToInt32(reader["c" + (index - 1)]);
                        index++;
                    }
                    int num2 = 20;
                    while (num2 < 0x4c)
                    {
                        item[index] = Convert.ToInt32(reader["c" + num2]);
                        num2 += 5;
                        index++;
                    }
                    item[index] = Convert.ToInt32(reader["c80"]);
                    list.Add(item);
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

        public List<object[]> GetReporteResultadoFromDB(int año, int mes)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            List<object[]> list = new List<object[]>();
            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                command.Connection = connection;
                command.CommandText = ProcGet.GET_REPORTE_RESULTADO;
                command.Parameters.AddWithValue("@ano", año);
                command.Parameters.AddWithValue("@mes", mes);
                command.CommandType = CommandType.StoredProcedure;
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    object[] item = new object[] { Convert.ToInt32(reader["idPlantilla"]), reader["dni"], reader["nombre"].ToString(), reader["apellido1"].ToString(), reader["apellido2"].ToString(), Convert.ToDouble(reader["edad"]), Convert.ToInt32(reader["sexo"]), Convert.ToBoolean(reader["gestante"]), reader["respuesta"].ToString(), reader["unidad"].ToString(), Convert.ToInt32(reader["cobertura"]), Convert.ToInt32(reader["estado"]) };
                    list.Add(item);
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
    }
}
