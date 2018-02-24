using DataManager.Recursos;
using EntityLab.Code.Hospital.Analisis;
using EntityLab.Code.Base;
using EntityLab.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EntityLab.Code.Hospital.Analisis.Result;

namespace DataManager
{
    public class RepositoryExam : IRepositoryDetailedRecord<ExamResult, ExamResultDetailed, int>
    {

        public static void AddExamen(Dictionary<int, ExamResult> examenes)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                DataTable table = new DataTable();
                DataTable table2 = new DataTable();
                table.Columns.Add("idTemp", typeof(int));
                table.Columns.Add("idOrdenDetalle", typeof(int));
                table.Columns.Add("idPlantilla", typeof(int));
                table.Columns.Add("fechaRegistro", typeof(DateTime));
                table.Columns.Add("fechaModificacion", typeof(DateTime));
                table.Columns.Add("fechaFinalizacion", typeof(DateTime));
                table.Columns.Add("idCuenta", typeof(int));
                table.Columns.Add("estado", typeof(int));
                table2.Columns.Add("id", typeof(int));
                table2.Columns.Add("idExamen", typeof(int));
                table2.Columns.Add("idItem", typeof(int));
                table2.Columns.Add("respuesta", typeof(string));
                int num = 1;
                foreach (ExamResult examen in examenes.Values)
                {
                    DataRow row = table.NewRow();
                    row[0] = num;
                    row[1] = examen.IdOrdenDetalle;
                    row[2] = examen.IdPlantilla;
                    row[3] = examen.FechaRegistro;
                    row[4] = examen.UltimaModificacion;
                    row[5] = examen.FechaFinalizado;
                    row[6] = examen.IdCuenta;
                    row[7] = (int)examen.Estado;
                    foreach (ExamResultDetailed detalle in examen.DetallesByItem.Values)
                    {
                        DataRow row2 = table2.NewRow();
                        row2[0] = 0;
                        row2[1] = num;
                        row2[2] = detalle.IdItem;
                        row2[3] = detalle.Campo;
                        table2.Rows.Add(row2);
                    }
                    table.Rows.Add(row);
                    num++;
                }
                command.Connection = connection;
                command.CommandText = ProcAdd.ADD_EXAMEN;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@examenes", table).SqlDbType = SqlDbType.Structured;
                command.Parameters.AddWithValue("@detalles", table2).SqlDbType = SqlDbType.Structured;
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

        public static bool ExistenExamenes(ExamOrderDetailed ordenDetalle)
        {
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcGet.GET_EXAMENCAB_EXISTE,
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@idOrdenDetalle", ordenDetalle.IdData);
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            int num = 0;
            while (reader.Read())
            {
                num = Convert.ToInt32(reader["num"]);
            }
            reader.Close();
            connection.Close();
            command.Dispose();
            return (num > 0);
        }

        public static Dictionary<int, ExamResultDetailed> GetExamenDetalleByExamen(ExamResult examen)
        {
            Dictionary<int, ExamResultDetailed> dictionary = new Dictionary<int, ExamResultDetailed>();
            new Dictionary<int, ExamResultDetailed>();
            ExamResultDetailed detalle = null;
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcGet.GET_EXAMENDET_BYEXAMENCAB,
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@idExamen", examen.IdData);
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                detalle = new ExamResultDetailed
                {
                    IdData = Convert.ToInt32(reader["id"]),
                    IdItem = Convert.ToInt32(reader["idItem"]),
                    Campo = reader["respuesta"].ToString()
                };
                dictionary.Add(detalle.IdItem, detalle);
            }
            reader.Close();
            connection.Close();
            command.Dispose();
            return dictionary;
        }

        public static Dictionary<int, ExamResult> GetExamenesByOrdenDetalle(ExamOrderDetailed ordenDetalle)
        {
            Dictionary<int, ExamResult> dictionary = new Dictionary<int, ExamResult>();
            ExamResult examen = null;
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcGet.GET_EXAMENCAB_BYORDENDET,
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@idOrden", ordenDetalle.IdData);
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                examen = new ExamResult
                {
                    IdData = Convert.ToInt32(reader["id"]),
                    IdOrdenDetalle = ordenDetalle.IdData,
                    IdPlantilla = Convert.ToInt32(reader["idPlantilla"]),
                    FechaRegistro = Convert.ToDateTime(reader["fechaRegistro"]),
                    Estado = (ExamResult.EstadoExamen)Convert.ToInt32(reader["estado"]),
                    FechaFinalizado = Convert.ToDateTime(reader["fechaFinalizacion"]),
                    UltimaModificacion = Convert.ToDateTime(reader["fechaModificacion"]),
                    IdCuenta = Convert.ToInt32(reader["idCuenta"])
                };
                examen.DetallesByItem = GetExamenDetalleByExamen(examen);
                dictionary.Add(examen.IdData, examen);
            }
            reader.Close();
            connection.Close();
            command.Dispose();
            return dictionary;
        }

        public static void GuardarExamen(ExamResult examen)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                DataTable table = new DataTable();
                DataTable table2 = new DataTable();
                table.Columns.Add("idTemp", typeof(int));
                table.Columns.Add("idOrdenDetalle", typeof(int));
                table.Columns.Add("idPlantilla", typeof(int));
                table.Columns.Add("fechaRegistro", typeof(DateTime));
                table.Columns.Add("fechaModificacion", typeof(DateTime));
                table.Columns.Add("fechaFinalizacion", typeof(DateTime));
                table.Columns.Add("idCuenta", typeof(int));
                table.Columns.Add("estado", typeof(int));
                table2.Columns.Add("id", typeof(int));
                table2.Columns.Add("idExamen", typeof(int));
                table2.Columns.Add("idItem", typeof(int));
                table2.Columns.Add("respuesta", typeof(string));
                DataRow row = table.NewRow();
                row[0] = examen.IdData;
                row[1] = examen.IdOrdenDetalle;
                row[2] = examen.IdPlantilla;
                row[3] = examen.FechaRegistro;
                row[4] = examen.UltimaModificacion;
                row[5] = examen.FechaFinalizado;
                row[6] = examen.IdCuenta;
                row[7] = (int)examen.Estado;
                foreach (ExamResultDetailed detalle in examen.DetallesByItem.Values)
                {
                    DataRow row2 = table2.NewRow();
                    row2[0] = detalle.IdData;
                    row2[1] = examen.IdData;
                    row2[2] = detalle.IdItem;
                    row2[3] = detalle.Campo;
                    table2.Rows.Add(row2);
                }
                table.Rows.Add(row);
                command.Connection = connection;
                command.CommandText = ProcUpd.UPD_EXAMEN_SINGLE;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@examenes", table).SqlDbType = SqlDbType.Structured;
                command.Parameters.AddWithValue("@detalles", table2).SqlDbType = SqlDbType.Structured;
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

        public static void GuardarExamenes(Dictionary<int, ExamResult> examenes, ExamOrder orden)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            try
            {
                connection.ConnectionString = DataConfig.Default.ConnectionString;
                DataTable table = new DataTable();
                DataTable table2 = new DataTable();
                table.Columns.Add("idTemp", typeof(int));
                table.Columns.Add("idOrdenDetalle", typeof(int));
                table.Columns.Add("idPlantilla", typeof(int));
                table.Columns.Add("fechaRegistro", typeof(DateTime));
                table.Columns.Add("fechaModificacion", typeof(DateTime));
                table.Columns.Add("fechaFinalizacion", typeof(DateTime));
                table.Columns.Add("idCuenta", typeof(int));
                table.Columns.Add("estado", typeof(int));
                table2.Columns.Add("id", typeof(int));
                table2.Columns.Add("idExamen", typeof(int));
                table2.Columns.Add("idItem", typeof(int));
                table2.Columns.Add("respuesta", typeof(string));
                foreach (ExamResult examen in examenes.Values)
                {
                    DataRow row = table.NewRow();
                    row[0] = examen.IdData;
                    row[1] = examen.IdOrdenDetalle;
                    row[2] = examen.IdPlantilla;
                    row[3] = examen.FechaRegistro;
                    row[4] = examen.UltimaModificacion;
                    row[5] = examen.FechaFinalizado;
                    row[6] = examen.IdCuenta;
                    row[7] = (int)examen.Estado;
                    foreach (ExamResultDetailed detalle in examen.DetallesByItem.Values)
                    {
                        DataRow row2 = table2.NewRow();
                        row2[0] = detalle.IdData;
                        row2[1] = examen.IdData;
                        row2[2] = detalle.IdItem;
                        row2[3] = detalle.Campo;
                        table2.Rows.Add(row2);
                    }
                    table.Rows.Add(row);
                }
                command.Connection = connection;
                command.CommandText = ProcUpd.UPD_EXAMEN;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idOrden", orden.IdData);
                command.Parameters.AddWithValue("@estado", orden.Estado);
                command.Parameters.AddWithValue("@examenes", table).SqlDbType = SqlDbType.Structured;
                command.Parameters.AddWithValue("@detalles", table2).SqlDbType = SqlDbType.Structured;
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


        public void Add(ExamResult entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ExamResult Select(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExamResult> SelectList()
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<ExamResult> Select(FilterParameter[] parameters)
        //{
        //    throw new NotImplementedException();
        //}

        public IDictionary<int, ExamResult> SelectDic()
        {
            throw new NotImplementedException();
        }

        public void Update(ExamResult entity)
        {
            throw new NotImplementedException();
        }

        public ExamResult Select(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExamResult> SelectList(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, ExamResult> SelectDic(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectTable(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Add(ExamResult entity)
        {
            throw new NotImplementedException();
        }

        public void Update(ExamResult entity)
        {
            throw new NotImplementedException();
        }

        ExamResult IRepositoryDetailedRecord<ExamResult, ExamResultDetailed, int>.Select(int id)
        {
            throw new NotImplementedException();
        }

        ExamResult IRepositoryDetailedRecord<ExamResult, ExamResultDetailed, int>.Select(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExamResultDetailed> SelectDetailedList(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExamResultDetailed> SelectDetailedList(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, ExamResultDetailed> SelectDetailedDic(int id)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, ExamResultDetailed> SelectDetailedDic(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        IEnumerable<ExamResult> IRepositoryDetailedRecord<ExamResult, ExamResultDetailed, int>.SelectList(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        IDictionary<int, ExamResult> IRepositoryDetailedRecord<ExamResult, ExamResultDetailed, int>.SelectDic(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
