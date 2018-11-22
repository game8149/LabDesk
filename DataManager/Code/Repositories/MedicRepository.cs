using DataManager.Code.Base;
using DataManager.Recursos;
using Entity.Code.Base.FilterStructure;
using Entity.Code.Business;
using Entity.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataManager.Code.Repositories
{
    public class MedicRepository : RepositoryBase, IEntitySimpeRepository<Medic, int>
    {
        public int Save(Medic entity)
        {
            using (SqlConnection connection = new SqlConnection(DataConfig.Default.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand { Connection = connection, CommandText = ProcAdd.ADD_MEDICO, CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new SqlParameter { ParameterName = "@id", SqlValue = entity.Id, SqlDbType = SqlDbType.Int });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@names", SqlValue = entity.Names, SqlDbType = SqlDbType.VarChar, Size = 100 });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@firstSurname", SqlValue = entity.FirstSurname, SqlDbType = SqlDbType.VarChar, Size = 100 });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@lastSurname", SqlValue = entity.LastSurname, SqlDbType = SqlDbType.VarChar, Size = 100 });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@sex", SqlValue = entity.Sex, SqlDbType = SqlDbType.Int });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@documentNumber", SqlValue = entity.DocumentNumber, SqlDbType = SqlDbType.VarChar, Size = 100 });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@birthDate", SqlValue = entity.BirthDate, SqlDbType = SqlDbType.VarChar, Size = 100 });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@idEspecialidad", SqlValue = entity.IdEspecialidad, SqlDbType = SqlDbType.VarChar, Size = 100 });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@codigoColegiatura", SqlValue = entity.CodigoColegiatura, SqlDbType = SqlDbType.VarChar, Size = 100 });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@habil", SqlValue = entity.Habil, SqlDbType = SqlDbType.Bit });
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            return -1;
        }

        public int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(DataConfig.Default.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand { Connection = connection, CommandText = ProcAdd.ADD_MEDICO, CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new SqlParameter { ParameterName = "@id", SqlValue = id, SqlDbType = SqlDbType.Int });
                    command.Connection.Open();
                    command.ExecuteNonQuery(); 
                }
            }

            return -1;
        }

        public IEnumerable<Medic> SelectList()
        {
            throw new Exception();
        }

        public Medic Select(int id)
        {
            Medic medico = null; 
            using (SqlConnection connection = new SqlConnection(DataConfig.Default.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand { Connection = connection, CommandText = ProcAdd.ADD_MEDICO, CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new SqlParameter { ParameterName = "@ID", SqlValue = id });
                    command.Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        medico = new Medic();
                        FillObject(medico, reader);
                    }
                }
            }
             
            return medico;
        }

        public IDictionary<int, Medic> SelectDic()
        {
            throw new NotImplementedException();
        }


        public Medic Select(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Medic> SelectList(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, Medic> SelectDic(FilterParameter[] parameters)
        {
            IDictionary<int, Medic> dictionary = new Dictionary<int, Medic>();
            using (SqlConnection connection = new SqlConnection(DataConfig.Default.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand { Connection = connection, CommandText = ProcAdd.ADD_MEDICO, CommandType = CommandType.StoredProcedure })
                {
                    command.Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Medic medico = new Medic();
                        FillObject(medico, reader);
                        dictionary.Add(medico.Id, medico);
                    }
                }
            }

            return dictionary;
        }
          
        public DataTable SelectTable(FilterParameter[] parameters)
        {
            DataTable dataResult = new DataTable();
            using (SqlConnection connection = new SqlConnection(DataConfig.Default.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand { Connection = connection, CommandText = ProcAdd.ADD_MEDICO, CommandType = CommandType.StoredProcedure })
                {
                    command.Connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataResult);
                }
            }

            return dataResult;
        }

        public override void FillObject(object entity, SqlDataReader reader)
        {
            Medic medico = (Medic)entity; 
            medico.Id = (int)reader["id"];
            medico.Names = (string)reader["names"];
            medico.FirstSurname = (string)reader["firstSurname"];
            medico.LastSurname = (string)reader["lastSurname"];
            medico.Sex = (Person.SexType)reader["sex"];
            medico.DocumentNumber = (string)reader["documentNumber"];
            medico.BirthDate = (DateTime)reader["birthDate"];
            medico.IdEspecialidad = (string)reader["idEspecialidad"];
            medico.CodigoColegiatura = (string)reader["codigoColegiatura"];
            medico.Habil = (bool)reader["habil"]; 
        }
    }
}
