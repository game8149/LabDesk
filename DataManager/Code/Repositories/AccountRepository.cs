using DataManager.Recursos;
using EntityLab.Code.Base;
using EntityLab.Code.Interfaces;
using EntityLab.Code.Management;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataManager.Code.Repositories
{
    public class RepositoryAccount : IRepositorySimpleRecord<Account, int>
    {
        public void Add(Account entity)
        {
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command1 = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcAdd.ADD_CUENTA,
                CommandType = CommandType.StoredProcedure
            };
            command1.Parameters.AddWithValue("@nombre", entity.Name);
            command1.Parameters.AddWithValue("@primerApellido", entity.Surnames);
            //command1.Parameters.AddWithValue("@especialidad", entity.Especialidad);
            command1.Parameters.AddWithValue("@dni", entity.Tag);
            command1.Parameters.AddWithValue("@clave", entity.Password);
            command1.Connection.Open();
            command1.ExecuteNonQuery();
            connection.Close();
            command1.Dispose();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
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
            command.Parameters.AddWithValue("@idCuenta", id);
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                entity = new Account
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Name = reader["nombre"].ToString(),
                    Surnames = reader["primerApellido"].ToString(),
                    //SegundoApellido = reader["segundoApellido"].ToString(),
                   // Especialidad = reader["especialidad"].ToString(),
                   // CodigoPro = reader["codigo"].ToString(),
                    Tag = reader["dni"].ToString(),
                    Password = reader["clave"].ToString(),
                    //Nivel = Convert.ToInt32(reader["nivel"].ToString())
                };
            }
            reader.Close();
            connection.Close();
            command.Dispose();
            return entity;
        }

        public void Update(Account entity)
        {
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command1 = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcUpd.UPD_CUENTA,
                CommandType = CommandType.StoredProcedure
            };
            command1.Parameters.AddWithValue("@idCuenta", entity.Id);
            command1.Parameters.AddWithValue("@nombre", entity.Name);
            command1.Parameters.AddWithValue("@primerApellido", entity.Surnames);
            //command1.Parameters.AddWithValue("@segundoApellido", entity.SegundoApellido);
           // command1.Parameters.AddWithValue("@especialidad", entity.Especialidad);
          //  command1.Parameters.AddWithValue("@codigo", entity.CodigoPro);
            command1.Parameters.AddWithValue("@dni", entity.Tag);
            command1.Connection.Open();
            command1.ExecuteNonQuery();
            connection.Close();
            command1.Dispose();
        }
        
        public void UpdatePassword(int id, string pass)
        {
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command1 = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcUpd.UPD_CUENTA_CLAVE,
                CommandType = CommandType.StoredProcedure
            };
            command1.Parameters.AddWithValue("@idCuenta", id);
            command1.Parameters.AddWithValue("@clave", pass);
            command1.Connection.Open();
            command1.ExecuteNonQuery();
            connection.Close();
            command1.Dispose();
        }
        
        public bool CheckExist(string dni)
        {
            bool flag = false;
            try
            {
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
                command.Parameters.AddWithValue("@dni", dni);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    flag = Convert.ToInt32(reader["num"]) > 0;
                }
                reader.Close();
                connection.Close();
                command.Dispose();
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
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
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                entity = new Account
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Name = reader["nombre"].ToString(),
                    Surnames = reader["primerApellido"].ToString(),
                   // SegundoApellido = reader["segundoApellido"].ToString(),
                   // Especialidad = reader["especialidad"].ToString(),
                    //CodigoPro = reader["codigo"].ToString(),
                    Tag = reader["dni"].ToString(),
                    Password = reader["clave"].ToString()
                   // Nivel = Convert.ToInt32(reader["nivel"].ToString())
                };
            }
            reader.Close();
            connection.Close();
            command.Dispose();
            return entity;
        }

        IDictionary<int, Account> IRepositorySimpleRecord<Account, int>.SelectDic(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
