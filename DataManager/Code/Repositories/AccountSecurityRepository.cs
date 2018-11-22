using DataManager.Recursos;
using Entity.Code.Base.FilterStructure;
using Entity.Code.Interfaces;
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

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public AccountSecurity Select(int id)
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

        public IEnumerable<AccountSecurity> SelectList()
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, AccountSecurity> SelectDic()
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

        public AccountSecurity Select(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AccountSecurity> SelectList(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, AccountSecurity> SelectDic(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectTable(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

      
    }
}
