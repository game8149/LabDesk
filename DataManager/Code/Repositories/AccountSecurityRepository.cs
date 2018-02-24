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
    public class AccountSecurityRepository : IRepositorySimpleRecord<AccountSecurity, int>
    {
        public void Add(AccountSecurity entity)
        {
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command1 = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcAdd.ADD_SEGURIDAD,
                CommandType = CommandType.StoredProcedure
            };
            command1.Parameters.AddWithValue("@idCuenta", entity.IdAccount);
            command1.Parameters.AddWithValue("@codigo", entity.Code );
            command1.Connection.Open();
            command1.ExecuteNonQuery();
            connection.Close();
            command1.Dispose();
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
            command.Parameters.AddWithValue("@idCuenta", id);
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                obj = new AccountSecurity
                {
                    Id = id,
                    Code = reader["code"].ToString(),
                    IdAccount = (int)reader["code"]
                };
            }
            reader.Close();
            connection.Close();
            command.Dispose();
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
            SqlCommand command1 = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcUpd.UPD_SEGURIDAD,
                CommandType = CommandType.StoredProcedure
            };
            command1.Parameters.AddWithValue("@idCuenta", entity.IdAccount);
            command1.Parameters.AddWithValue("@codigo", entity.Code);
            command1.Connection.Open();
            command1.ExecuteNonQuery();
            connection.Close();
            command1.Dispose();
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
