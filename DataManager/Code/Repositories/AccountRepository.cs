using DataManager.Recursos;
using Entity.Code.Base.FilterStructure;
using Entity.Code.Interfaces;
using Entity.Code.Management;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DataManager.Code.Repositories
{
    public class AccountRepository : IEntityRepository<Account, int>
    {
        IEntityRepository<AccountSecurity, int> SecurityRepo = new AccountSecurityRepository();

        public void Add(Account entity)
        {

            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcAdd.ADD_CUENTA,
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                command.Parameters.AddRange(new SqlParameter[] {
                    new SqlParameter { ParameterName = "@tag", SqlValue = entity.Tag, SqlDbType = SqlDbType.VarChar, Size = 100 },
                    new SqlParameter { ParameterName = "@names", SqlValue = entity.Name, SqlDbType = SqlDbType.VarChar, Size = 100 },
                    new SqlParameter { ParameterName = "@surnames", SqlValue = entity.Surnames, SqlDbType = SqlDbType.VarChar, Size = 100 },
                    new SqlParameter { ParameterName = "@password", SqlValue = entity.Password, SqlDbType = SqlDbType.VarChar, Size = 100 },
                    new SqlParameter { ParameterName = "@email", SqlValue = entity.Surnames, SqlDbType = SqlDbType.VarChar, Size = 100 },
                    new SqlParameter { ParameterName = "@account", SqlValue = entity.AccountInsert, SqlDbType = SqlDbType.VarChar, Size = 100 }
                });

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

        //
        /// <summary>
        /// Only inhabilite account
        /// </summary>
        /// <param name="id"></param>
        /// 

        public void Delete(int id)
        {
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcAdd.ADD_CUENTA,
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                command.Parameters.Add(new SqlParameter { ParameterName = "@id", SqlValue = id, SqlDbType = SqlDbType.Int });
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

        public Account Select(int id)
        {
            Account entity = null;
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcGet.GET_CUENTA_BYID,
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                command.Parameters.Add(new SqlParameter { ParameterName = "@id", SqlValue = id, SqlDbType = SqlDbType.Int });
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    entity = new Account
                    {
                        Id = (int)reader["id"],
                        Tag = (string)reader["tag"],
                        Name = (string)reader["name"],
                        Surnames = (string)reader["surnames"],
                        Password = (string)reader["password"],
                        Email = (string)reader["email"],
                        Phone = (string)reader["phone"],
                        CurrentSecurity = SecurityRepo.Select(
                            new FilterParameter[] {
                                new FilterParameter {
                                    Index = 0, Value = (string)reader["tag"], Type = Type.GetType("String")
                                }
                            }
                            )
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

            return entity;
        }

        public void Update(Account entity)
        {
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcUpd.UPD_CUENTA,
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                command.Parameters.AddRange(new SqlParameter[] {
                    new SqlParameter { ParameterName = "@id", SqlValue = entity.Id, SqlDbType = SqlDbType.Int },
                    new SqlParameter { ParameterName = "@tag", SqlValue = entity.Tag, SqlDbType = SqlDbType.VarChar, Size = 100 },
                    new SqlParameter { ParameterName = "@names", SqlValue = entity.Name, SqlDbType = SqlDbType.VarChar, Size = 100 },
                    new SqlParameter { ParameterName = "@surnames", SqlValue = entity.Surnames, SqlDbType = SqlDbType.VarChar, Size = 100 },
                    new SqlParameter { ParameterName = "@password", SqlValue = entity.Password, SqlDbType = SqlDbType.VarChar, Size = 100 },
                    new SqlParameter { ParameterName = "@email", SqlValue = entity.Surnames, SqlDbType = SqlDbType.VarChar, Size = 100 },
                    new SqlParameter { ParameterName = "@account", SqlValue = entity.AccountInsert, SqlDbType = SqlDbType.VarChar, Size = 100 }
                });

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

        public void UpdatePassword(int id, string pass)
        {
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcUpd.UPD_CUENTA_CLAVE,
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                command.Parameters.Add(new SqlParameter { ParameterName = "@id", SqlValue = id, SqlDbType = SqlDbType.Int });
                command.Parameters.Add(new SqlParameter { ParameterName = "@password", SqlValue = pass, SqlDbType = SqlDbType.VarChar });
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

        public bool CheckExist(string dni)
        {
            bool flag = false;
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcGet.GET_CUENTA_EXISTE,
                CommandType = CommandType.StoredProcedure
            };
            try
            {
                command.Parameters.Add(new SqlParameter { ParameterName = "@tag", SqlValue = dni, SqlDbType = SqlDbType.VarChar });
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    flag = Convert.ToInt32(reader["num"]) > 0;
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
            return flag;
        }

        public IDictionary<int, Account> SelectDic()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account> SelectList()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account> SelectList(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account> SelectDic(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectTable(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public Account Select(FilterParameter[] parameters)
        {
            Account entity = null;
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcGet.GET_CUENTA,
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    entity = new Account
                    {
                        Id = (int)reader["id"],
                        Tag = (string)reader["tag"],
                        Name = (string)reader["name"],
                        Surnames = (string)reader["surnames"],
                        Password = (string)reader["password"],
                        Email = (string)reader["email"],
                        Phone = (string)reader["phone"],
                        CurrentSecurity = SecurityRepo.Select((int)reader["id"])
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

            return entity;
        }

        IDictionary<int, Account> IEntityRepository<Account, int>.SelectDic(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        int IEntityRepository<Account, int>.Add(Account entity)
        {
            throw new NotImplementedException();
        }

        int IEntityRepository<Account, int>.Update(Account entity)
        {
            throw new NotImplementedException();
        }
    }
}
