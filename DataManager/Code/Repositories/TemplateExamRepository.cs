using DataManager.Recursos;
using EntityLab.Code.Analisis.Templates;
using EntityLab.Code.Base;
using EntityLab.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataManager.Code.Repositories
{
    public class TemplateExamRepository : IRepositoryDetailedRecord<TemplateExam, TemplateExamRow, int>
    {
        public void Add(TemplateExam entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TemplateExam Select(int id)
        {
            TemplateExam plantilla = null;
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
                plantilla = new TemplateExam
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

        public IEnumerable<TemplateExam> SelectList()
        {
            Dictionary<int, TemplateExam> dictionary = new Dictionary<int, TemplateExam>();
            TemplateExam plantilla = null;
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
                plantilla = new TemplateExam
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

        public IEnumerable<TemplateExam> SelectList(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Update(TemplateExam entity)
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

        public TemplateExam Select(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TemplateExamRow> SelectDetailedList(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TemplateExamRow> SelectDetailedList(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, TemplateExamRow> SelectDetailedDic(int id)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, TemplateExamRow> SelectDetailedDic(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, TemplateExam> SelectDic(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectTable(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
