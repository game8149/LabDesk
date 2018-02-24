using DataManager.Recursos;
using EntityLab.Code.Hospital.Analisis;
using EntityLab.Code.Base;
using EntityLab.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataManager.Code.Repositories
{
    public class TemplateExamItemList : IRepositorySimpleRecord<PlantillaItemList, int>

    {
        public void Add(PlantillaItemList entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PlantillaItemList Select(int id)
        {
            throw new NotImplementedException();
        }

        public PlantillaItemList Select(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, PlantillaItemList> SelectDic()
        {


            throw new NotImplementedException();
        }

        public IDictionary<int, PlantillaItemList> SelectDic(FilterParameter[] parameters)
        {
            Dictionary<int, PlantillaItemList> dictionary = new Dictionary<int, PlantillaItemList>();
            PlantillaItemList list = null;
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcGet.GET_LISTA_BYITEM,
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@idItem", idData);
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                list = new PlantillaItemList
                {
                    IdData = Convert.ToInt32(reader["id"]),
                    Nombre = reader["nombre"].ToString(),
                    Indice = Convert.ToInt32(reader["indice"])
                };
                dictionary.Add(list.IdData, list);
            }
            reader.Close();
            connection.Close();
            command.Dispose();
            return dictionary;
        }

        public IEnumerable<PlantillaItemList> SelectList()
        {

            throw new NotImplementedException();
        }

        public IEnumerable<PlantillaItemList> SelectList(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectTable(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Update(PlantillaItemList entity)
        {
            throw new NotImplementedException();
        }
    }
}
