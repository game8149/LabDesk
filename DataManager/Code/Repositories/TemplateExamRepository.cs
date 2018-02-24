using DataManager.Recursos;
using EntityLab.Code.Base;
using EntityLab.Code.Hospital.Analisis.Templates;
using EntityLab.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataManager.Code.Repositories
{
    public class TemplateExamRepository : IRepositoryDetailedRecord<Template, TemplateRow, int>
    {
        public void Add(Template entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Template Select(int id)
        {
            Template plantilla = null;
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
                CommandText = ProcGet.GET_PLANTILLA,
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@codigo", codigo);
            command.Connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                plantilla = new Template
                {
                    IdDataPlantilla = Convert.ToInt32(reader["id"]),
                    Codigo = reader["codigo"].ToString(),
                    Nombre = reader["nombre"].ToString(),
                    TieneItems = Convert.ToBoolean(reader["tieneItem"]),
                    TieneGrupos = Convert.ToBoolean(reader["tieneGrupo"]),
                    Filas = new Dictionary<int, PlantillaFila>()
                };
                if (plantilla.TieneGrupos)
                {
                    foreach (PlantillaFila fila in GetPlantillaFilasGrupo(plantilla.IdDataPlantilla).Values)
                    {
                        plantilla.Filas.Add(fila.Indice, fila);
                    }
                }
                if (plantilla.TieneItems)
                {
                    foreach (PlantillaFila fila2 in GetPlantillaFilaSimple(plantilla.IdDataPlantilla).Values)
                    {
                        plantilla.Filas.Add(fila2.Indice, fila2);
                    }
                }
                plantilla.IndexarByItem();
            }
            reader.Close();
            command.Connection.Close();
            command.Dispose();
            return plantilla;
        }

        public IEnumerable<Template> SelectList()
        {
            Dictionary<int, Template> dictionary = new Dictionary<int, Template>();
            Template plantilla = null;
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcGet.GET_PLANTILLA_ALL,
                CommandType = CommandType.StoredProcedure
            };
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                plantilla = new Template
                {
                    IdDataPlantilla = Convert.ToInt32(reader["id"]),
                    Codigo = reader["codigo"].ToString(),
                    Nombre = reader["nombre"].ToString(),
                    Area = Convert.ToInt32(reader["area"]),
                    TieneItems = Convert.ToBoolean(reader["tieneItem"]),
                    TieneGrupos = Convert.ToBoolean(reader["tieneGrupo"]),
                    Filas = new Dictionary<int, PlantillaFila>()
                };
                if (plantilla.TieneGrupos)
                {
                    foreach (PlantillaFila fila in GetPlantillaFilasGrupo(plantilla.IdDataPlantilla).Values)
                    {
                        plantilla.Filas.Add(fila.Indice, fila);
                    }
                }
                if (plantilla.TieneItems)
                {
                    foreach (PlantillaFila fila2 in GetPlantillaFilaSimple(plantilla.IdDataPlantilla).Values)
                    {
                        plantilla.Filas.Add(fila2.Indice, fila2);
                    }
                }
                plantilla.IndexarByItem();
                dictionary.Add(plantilla.IdDataPlantilla, plantilla);
            }
            reader.Close();
            command.Connection.Close();
            command.Dispose();
            return dictionary;
        }

        public IEnumerable<Template> SelectList(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Update(Template entity)
        {
            throw new NotImplementedException();
        }

        public static Dictionary<int, PlantillaFila> GetPlantillaFilasGrupo(int idData)
        {
            Dictionary<int, PlantillaFila> dictionary = new Dictionary<int, PlantillaFila>();
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcGet.GET_GRUPO_BYPLANTILLA,
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@idPlantilla", idData);
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                PlantillaFilaGrupo grupo = new PlantillaFilaGrupo
                {
                    Tipo = PlantillaFila.PlantillaFilaTipo.Agrupada,
                    Indice = Convert.ToInt32(reader["indice"]),
                    IdData = Convert.ToInt32(reader["id"]),
                    Nombre = reader["nombre"].ToString()
                };
                grupo.Items = GetItemByGrupo(grupo.IdData);
                dictionary.Add(grupo.Indice, grupo);
            }
            reader.Close();
            connection.Close();
            command.Dispose();
            connection.Dispose();
            return dictionary;
        }

        public static Dictionary<int, PlantillaFila> GetPlantillaFilaSimple(int idData)
        {
            Dictionary<int, PlantillaFila> dictionary = new Dictionary<int, PlantillaFila>();
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcGet.GET_ITEM_BYPLANTILLA,
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@idPlantilla", idData);
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                PlantillaFilaSimple simple = new PlantillaFilaSimple
                {
                    Indice = Convert.ToInt32(reader["indice"]),
                    Tipo = PlantillaFila.PlantillaFilaTipo.Simple,
                    Item = new PlantillaItem()
                };
                simple.Item.IdData = Convert.ToInt32(reader["id"]);
                simple.Item.Nombre = reader["nombre"].ToString();
                simple.Item.PorDefault = reader["porDefault"].ToString();
                simple.Item.TipoDato = (TipoDato)Convert.ToInt32(reader["idTipoItem"]);
                simple.Item.TipoCampo = (TipoCampo)Convert.ToInt32(reader["idTipoCampo"]);
                simple.Item.TieneUnidad = Convert.ToBoolean(reader["tieneUnidad"]);
                simple.Item.Unidad = reader["unidad"].ToString();
                if (simple.Item.TipoCampo == TipoCampo.Lista)
                {
                    simple.Item.Opciones = GetListItemByItem(simple.Item.IdData);
                }
                try
                {
                    int indice = simple.Indice;
                    dictionary.Add(simple.Indice, simple);
                    continue;
                }
                catch (SqlException exception1)
                {
                    throw new Exception(exception1.Message);
                }
            }
            reader.Close();
            connection.Close();
            command.Dispose();
            return dictionary;
        }

        public Template Select(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TemplateRow> SelectDetailedList(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TemplateRow> SelectDetailedList(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, TemplateRow> SelectDetailedDic(int id)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, TemplateRow> SelectDetailedDic(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, Template> SelectDic(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectTable(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
