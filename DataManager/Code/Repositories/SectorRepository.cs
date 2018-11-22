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
    public class SectorRepository : IRepositorySimpleRecord<UbigeoSector, int>
    {
        public void Add(UbigeoSector entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public UbigeoSector Select(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UbigeoSector> SelectList()
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, UbigeoSector> SelectDic()
        {
            UbigeoSector sector = null;
            Dictionary<int, UbigeoSector> dictionary = new Dictionary<int, UbigeoSector>();
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
                sector = new UbigeoSector
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

        public void Update(UbigeoSector entity)
        {
            throw new NotImplementedException();
        }

        public UbigeoSector Select(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UbigeoSector> SelectList(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, UbigeoSector> SelectDic(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectTable(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
