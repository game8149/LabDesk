using EntityLab.Code.Base;
using EntityLab.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataManager.Code.Repositories
{
    public class TemplateExamItemRepository : IRepositorySimpleRecord<TemplateExamItem, int>
    {

        public IEnumerable<PlantillaItem> SelectList()
        {
            PlantillaItem item = new PlantillaItem();
            Dictionary<int, PlantillaItem> dictionary = new Dictionary<int, PlantillaItem>();
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataReader reader = null;
            connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            command = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcGet.GET_ITEM_ALL_BYPLANTILLA,
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@idPlantilla", IdPlantilla);
            command.Connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                item.IdData = Convert.ToInt32(reader["id"]);
                item.TipoDato = (TipoDato)Convert.ToInt32(reader["tipoDato"]);
                dictionary.Add(item.IdData, item);
            }
            reader.Close();
            command.Connection.Close();
            command.Dispose();
            return dictionary;
        }

        public IEnumerable<PlantillaItem> SelectList(FilterParameter[] parameters)
        {
            Dictionary<int, PlantillaItem> dictionary = new Dictionary<int, PlantillaItem>();
            PlantillaItem item = null;
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcGet.GET_ITEM_BYGRUPO,
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@idGrupo", idData);
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                item = new PlantillaItem
                {
                    IdData = Convert.ToInt32(reader["id"]),
                    Nombre = reader["nombre"].ToString(),
                    PorDefault = reader["porDefault"].ToString(),
                    TipoDato = (TipoDato)Convert.ToInt32(reader["idTipoItem"]),
                    TipoCampo = (TipoCampo)Convert.ToInt32(reader["idTipoCampo"]),
                    TieneUnidad = Convert.ToBoolean(reader["tieneUnidad"]),
                    Unidad = reader["unidad"].ToString()
                };
                int key = Convert.ToInt32(reader["indice"]);
                if (item.TipoCampo == TipoCampo.Lista)
                {
                    item.Opciones = GetListItemByItem(item.IdData);
                }
                dictionary.Add(key, item);
            }
            reader.Close();
            connection.Close();
            command.Dispose();
            return dictionary;
        }
        
    }
}
