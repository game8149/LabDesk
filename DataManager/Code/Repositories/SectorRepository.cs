using DataManager.Recursos;
using EntityLab.Code.Base;
using EntityLab.Code.Interfaces;
using EntityLab.Code.Location;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataManager.Code.Repositories
{
    public class SectorRepository : IRepositorySimpleRecord<Sector, int>
    {
        public void Add(Sector entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Sector Select(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sector> SelectList()
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, Sector> SelectDic()
        {
            Sector sector = null;
            Dictionary<int, Sector> dictionary = new Dictionary<int, Sector>();
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcGet.GET_SECTOR_BYDISTRITO,
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("idDistrito", 0);
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                sector = new Sector
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Description = reader["nombre"].ToString(),
                    IdUbigeo = reader["idDistrito"].ToString()
                };
                dictionary.Add(sector.Id, sector);
            }
            reader.Close();
            connection.Close();
            command.Dispose();
            return dictionary;
        }

        public void Update(Sector entity)
        {
            throw new NotImplementedException();
        }

        public Sector Select(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sector> SelectList(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, Sector> SelectDic(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectTable(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
