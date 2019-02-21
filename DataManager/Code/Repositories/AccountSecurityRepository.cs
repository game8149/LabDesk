using DataManager.Code.Interfaces;
using DataManager.Recursos;
using Entity.Code.Base.FilterStructure;
using Entity.Code.Management;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using static Entity.Code.Management.AccountSecurity;

namespace DataManager.Code.Repositories
{
    public class AccountSecurityRepository : IEntityRepository<AccountSecurity, int>
    {
        public void Add(AccountSecurity entity)
        {
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcAdd.ADD_SEGURIDAD,
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                command.Parameters.Add(new SqlParameter { ParameterName = "@id", SqlValue = entity.Id, SqlDbType = SqlDbType.Int });
                command.Parameters.Add(new SqlParameter { ParameterName = "@idAccount", SqlValue = entity.IdAccount, SqlDbType = SqlDbType.Int });
                command.Parameters.Add(new SqlParameter { ParameterName = "@level", SqlValue = entity.IdAccount, SqlDbType = SqlDbType.Int });
                command.Parameters.Add(new SqlParameter { ParameterName = "@code", SqlValue = entity.Code, SqlDbType = SqlDbType.Int });
                command.Parameters.Add(new SqlParameter { ParameterName = "@account", SqlValue = entity.IdAccount, SqlDbType = SqlDbType.Int });

                command.Connection.Open();
                command.ExecuteNonQuery();
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
        }

        public int Check(AccountSecurity obj)
        {
            throw new NotImplementedException();
        }

        public AccountSecurity Get(int id)
        {
            AccountSecurity obj = null;
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcGet.GET_SEGURIDAD,
                CommandType = CommandType.StoredProcedure
            };


            try
            {
                command.Parameters.Add(new SqlParameter { ParameterName = "@id", SqlValue = id, SqlDbType = SqlDbType.Int });
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    obj = new AccountSecurity
                    {
                        Id = id,
                        Code = (string)reader["code"],
                        Level = (AccountSecurityLevel)reader["level"],
                        IdAccount = (int)reader["idAccount"]
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

            return obj;
        }

        public DataTable GetTable(AccountSecurity obj)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, AccountSecurity> Index()
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, AccountSecurity> Index(AccountSecurity obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AccountSecurity> List()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AccountSecurity> List(AccountSecurity obj)
        {
            throw new NotImplementedException();
        }

        public int Remove(AccountSecurity obj)
        {
            throw new NotImplementedException();
        }

        public int Save(AccountSecurity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(AccountSecurity entity)
        {
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcUpd.UPD_SEGURIDAD,
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add(new SqlParameter { ParameterName = "@id", SqlValue = entity.Id, SqlDbType = SqlDbType.Int });
            command.Parameters.Add(new SqlParameter { ParameterName = "@level", SqlValue = entity.IdAccount, SqlDbType = SqlDbType.Int });
            command.Parameters.Add(new SqlParameter { ParameterName = "@code", SqlValue = entity.Code, SqlDbType = SqlDbType.Int });
            command.Parameters.Add(new SqlParameter { ParameterName = "@account", SqlValue = entity.IdAccount, SqlDbType = SqlDbType.Int });

            command.Connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            command.Dispose();
        }
         
    }
}
