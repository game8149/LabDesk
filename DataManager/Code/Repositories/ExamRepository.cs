using DataManager.Recursos;
using EntityLab.Code.Analisis;
using EntityLab.Code.Base.FilterStructure;
using EntityLab.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataManager
{
    public class ExamResultRespository : IRepositoryDetailedRecord<ExamResult, ExamResultDetail, int>
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
                    row[1] = examen.IdOrder;
                    row[2] = examen.IdTemplate ;
                    row[3] = examen.OnInsert ;
                    row[4] = examen.OnUpdate ;
                    row[5] = examen.OnTerminated ;
                    row[6] = examen.AccountBegun ;
                    row[7] = (int)examen.State ;
                    foreach (ExamResultDetail detalle in examen.Items.Values)
                    {
                        DataRow row2 = table2.NewRow();
                        row2[0] = 0;
                        row2[1] = num;
                        row2[2] = detalle.IdTemplateExamAsk ;
                        row2[3] = detalle.Value ;
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

        public static bool ExistenExamenes(ExamOrderDetail ordenDetalle)
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
            command.Parameters.AddWithValue("@idOrdenDetalle", ordenDetalle.Id);
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

        public static Dictionary<int, ExamResultDetail> GetExamenDetalleByExamen(ExamResult examen)
        {
            Dictionary<int, ExamResultDetail> dictionary = new Dictionary<int, ExamResultDetail>();
            new Dictionary<int, ExamResultDetail>();
            ExamResultDetail detalle = null;
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
            command.Parameters.AddWithValue("@idExamen", examen.Id);
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                detalle = new ExamResultDetail
                {
                    Id = Convert.ToInt32(reader["id"]),
                    IdTemplateExamAsk  = Convert.ToInt32(reader["idItem"]),
                    Value  = reader["respuesta"].ToString()
                };
                dictionary.Add(detalle.IdTemplateExamAsk, detalle);
            }
            reader.Close();
            connection.Close();
            command.Dispose();
            return dictionary;
        }

        public static Dictionary<int, ExamResult> GetExamenesByOrdenDetalle(ExamOrderDetail ordenDetalle)
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
            command.Parameters.AddWithValue("@idOrden", ordenDetalle.Id );
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                examen = new ExamResult
                {
                    //Id  = Convert.ToInt32(reader["id"]),
                    //IdOrdenDetalle = ordenDetalle.IdData,
                    //IdPlantilla = Convert.ToInt32(reader["idPlantilla"]),
                    //FechaRegistro = Convert.ToDateTime(reader["fechaRegistro"]),
                    //Estado = (ExamResult.EstadoExamen)Convert.ToInt32(reader["estado"]),
                    //FechaFinalizado = Convert.ToDateTime(reader["fechaFinalizacion"]),
                    //UltimaModificacion = Convert.ToDateTime(reader["fechaModificacion"]),
                    //IdCuenta = Convert.ToInt32(reader["idCuenta"])
                };
                examen.Items  = GetExamenDetalleByExamen(examen);
                dictionary.Add(examen.Id, examen);
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
                //row[0] = examen.IdData;
                //row[1] = examen.IdOrdenDetalle;
                //row[2] = examen.IdPlantilla;
                //row[3] = examen.FechaRegistro;
                //row[4] = examen.UltimaModificacion;
                //row[5] = examen.FechaFinalizado;
                //row[6] = examen.IdCuenta;
                //row[7] = (int)examen.Estado;
                foreach (ExamResultDetail detalle in examen.Items .Values)
                {
                    DataRow row2 = table2.NewRow();
                    row2[0] = detalle.Id ;
                    row2[1] = examen.Id ;
                    row2[2] = detalle.IdTemplateExamAsk ;
                    row2[3] = detalle.Value ;
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
                    row[0] = examen.Id;
                    row[1] = examen.IdOrder;
                    row[2] = examen.IdTemplate ;
                    row[3] = examen.OnInsert ;
                    row[4] = examen.OnUpdate ;
                    row[5] = examen.OnTerminated;
                    row[6] = examen.AccountBegun ;
                    row[7] = (int)examen.State ;
                    foreach (ExamResultDetail detalle in examen.Items .Values)
                    {
                        DataRow row2 = table2.NewRow();
                        row2[0] = detalle.Id ;
                        row2[1] = examen.Id ;
                        row2[2] = detalle.IdTemplateExamAsk ;
                        row2[3] = detalle.Value ;
                        table2.Rows.Add(row2);
                    }
                    table.Rows.Add(row);
                }
                command.Connection = connection;
                command.CommandText = ProcUpd.UPD_EXAMEN;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idOrden", orden.Id );
                command.Parameters.AddWithValue("@estado", orden.State );
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

        public ExamResult Select(int id)
        {
            throw new NotImplementedException();
        }

        public ExamResult Select(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public ExamResult Select(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, ExamResultDetail> SelectDetailedDic(int id)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, ExamResultDetail> SelectDetailedDic(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, ExamResultDetail> SelectDetailedDic(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExamResultDetail> SelectDetailedList(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExamResultDetail> SelectDetailedList(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExamResultDetail> SelectDetailedList(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, ExamResult> SelectDic(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, ExamResult> SelectDic(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExamResult> SelectList(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExamResult> SelectList(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectTable(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectTable(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Update(ExamResult entity)
        {
            throw new NotImplementedException();
        }
    }
}
