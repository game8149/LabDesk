using DataManager.Code.Interfaces;
using DataManager.Recursos;
using Entity.Code.Location;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataManager.Code.Repositories
{
    public class SectorRepository : IEntityRepository<UbigeoSector, int>
    {
        public int Check(UbigeoSector obj)
        {
            throw new NotImplementedException();
        }

        public UbigeoSector Get(int id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetTable(UbigeoSector obj)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, UbigeoSector> Index()
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, UbigeoSector> Index(UbigeoSector obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UbigeoSector> List()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UbigeoSector> List(UbigeoSector obj)
        {
            throw new NotImplementedException();
        }

        public int Remove(UbigeoSector obj)
        {
            throw new NotImplementedException();
        }

        public int Save(UbigeoSector entity)
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
         
    }
}
