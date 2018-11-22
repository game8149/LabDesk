using DataManager.Recursos;
using EntityLab.Code.Base;
using EntityLab.Code.Business;
using EntityLab.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using static EntityLab.Code.Business.Person;

namespace DataManager.Code.Repositories
{
    public class PatientRepository : IEntitySimpleRepository<Patient, int>
    {
        public int Save(Patient entity)
        { 
           using ( SqlConnection connection = new SqlConnection(DataConfig.Default.ConnectionString))
           {
               using (  SqlCommand command = new SqlCommand { Connection = connection, CommandText = ProcAdd.ADD_PACIENTE,CommandType = CommandType.StoredProcedure})
               {
                    command.Parameters.Add(new SqlParameter { ParameterName = "@id", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@idDocumentType", SqlValue = entity.IdDocumentType });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@documentNumber", SqlValue = entity.DocumentNumber });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@historialCode", SqlValue = entity.HistorialCode });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@names", SqlValue = entity.Names });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@firstSurname", SqlValue = entity.FirstSurname });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@lastSurname", SqlValue = entity.LastSurname });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@birthDate", SqlValue = entity.BirthDate });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@sex", SqlValue = entity.Sex });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@idOriginalUbigeo", SqlValue = entity.IdOriginalUbigeo });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@idCurrentUbigeo", SqlValue = entity.IdCurrentUbigeo });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@idSector", SqlValue = entity.IdSector });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@address", SqlValue = entity.Address });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@account", SqlValue = entity.AccountInsert });
                    command.Connection.Open();
                    command.ExecuteNonQuery();
               }
           } 
        }

        public int Delete(int id)
        {
            using ( SqlConnection connection = new SqlConnection(DataConfig.Default.ConnectionString))
           {
               using (  SqlCommand command = new SqlCommand { Connection = connection, CommandText = ProcAdd.ADD_PACIENTE,CommandType = CommandType.StoredProcedure})
               {
                    command.Parameters.Add(new SqlParameter { ParameterName = "@id", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output });
                    command.Connection.Open();
                    command.ExecuteNonQuery();
               }
           } 
        }

        public IEnumerable<Patient> SelectList()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Patient> Select(FilterParameter[] parameters)
        {

            throw new NotImplementedException();
        }

        public Patient Select(int id)
        {
            Patient paciente = null;
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcGet.GET_PACIENTE_BYID,
                CommandType = CommandType.StoredProcedure
            };

            try
            {

                command.Parameters.Add(new SqlParameter { ParameterName = "@id", SqlValue = id });
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    paciente = new Patient
                    {
                        Id = (int)reader["id"],
                        Names = (string)reader["names"],
                        LastSurname = (string)reader["LastSurname"],
                        FirstSurname = (string)reader["firstSurname"],
                        Address = (string)reader["address"],
                        HistorialCode = (string)reader["historialCode"],
                        DocumentNumber = (string)reader["documentNumber"],
                        Sex = (SexType)Convert.ToInt32(reader["sex"]),
                        BirthDate = Convert.ToDateTime(reader["birthDate"]),
                        IdOriginalUbigeo = (string)reader["idCurrentUbigeo"],
                        IdCurrentUbigeo = (string)reader["idCurrentUbigeo"],
                        IdSector = (string)reader["idSector"]
                    };
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
                if (command != null)
                    command.Dispose();
            }
            return paciente;
        }
 
        public IEnumerable<Patient> SelectList(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, Patient> SelectDic(FilterParameter[] parameters)
        {
            Dictionary<int, Patient> dictionary = new Dictionary<int, Patient>();
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandType = CommandType.Text
            };
            
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Patient paciente = new Patient
                    {
                        Id = (int)reader["id"],
                        IdDocumentType = (string)reader["idDocumentType"],
                        DocumentNumber = (string)reader["documentNumber"],
                        HistorialCode = (string)reader["historialCode"],
                        Names = (string)reader["names"],
                        LastSurname = (string)reader["lastSurname"],
                        FirstSurname = (string)reader["firstSurname"],
                        Sex = (SexType)reader["sex"],
                        BirthDate = (DateTime)reader["birthDate"],
                        IdOriginalUbigeo = (string)reader["idCurrentUbigeo"],
                        IdCurrentUbigeo = (string)reader["idCurrentUbigeo"],
                        IdSector = (string)reader["idSector"],
                        Address = (string)reader["address"]
                    };
                    dictionary.Add(paciente.Id, paciente);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
                if (command != null)
                    command.Dispose();
            }
            return dictionary;
        }

        public DataTable SelectTable(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, Patient> SelectDic()
        {
            throw new NotImplementedException();
        }

        Patient IRepositorySimpleRecord<Patient, int>.Select(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
