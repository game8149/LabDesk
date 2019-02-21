using DataManager.Code.Base;
using DataManager.Code.Interfaces;
using DataManager.Recursos;
using Entity.Code.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataManager.Code.Repositories
{
    public class MedicRepository : RepositoryBase, IEntityRepository<Medic, int>
    {
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

        public int Remove(Medic obj)
        {
            using (SqlConnection connection = new SqlConnection(DataConfig.Default.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand { Connection = connection, CommandText = ProcAdd.ADD_MEDICO, CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new SqlParameter { ParameterName = "@id", SqlValue = obj.Id, SqlDbType = SqlDbType.Int });
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return -1;
        }

        public int Check(Medic obj)
        {
            throw new NotImplementedException();
        }

        public Medic Get(int id)
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

        public IEnumerable<Medic> List()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Medic> List(Medic obj)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, Medic> Index()
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, Medic> Index(Medic obj)
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

        public DataTable GetTable(Medic obj)
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
    }
}
