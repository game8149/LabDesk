using DataManager.Code.Interfaces;
using DataManager.Recursos;
using Entity.Code.Analysis.Templates;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataManager.Code.Repositories.Analysis.Templates
{
    public class TemplateRowRepository : IEntityRepository<TemplateRow, int>
    { 
        public int Save(TemplateRow entity)
        {
            throw new NotImplementedException();
        }

        public int Remove(TemplateRow obj)
        {
            throw new NotImplementedException();
        }

        public int Check(TemplateRow obj)
        {
            throw new NotImplementedException();
        }

        public TemplateRow Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TemplateRow> List()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TemplateRow> List(TemplateRow obj)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, TemplateRow> Index()
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, TemplateRow> Index(TemplateRow obj)
        {

            TemplateRow row = null;
            Dictionary<int, TemplateRow> dictionary = new Dictionary<int, TemplateRow>();
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
            command.Parameters.AddWithValue("@idPlantilla", obj.IdAnalysisTemplate);
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                row = new TemplateRow
                {
                    Index = Convert.ToInt32(reader["indice"]),
                    Type = TemplateRow.TemplateRowType.Singled,
                    Ask = new TemplateAsk()
                };
                row.Ask.Id = Convert.ToInt32(reader["id"]);
                row.Ask.Name = reader["nombre"].ToString();
                row.Ask.DefaultValue = reader["porDefault"].ToString();
                row.Ask.DataType = (TemplateAsk.AnalysisTemplateAskDataType)Convert.ToInt32(reader["idTipoItem"]);
                row.Ask.Type = (TemplateAsk.AnalysisTemplateAskType)Convert.ToInt32(reader["idTipoCampo"]);
                row.Ask.HasUnit = Convert.ToBoolean(reader["tieneUnidad"]);
                row.Ask.Unit = reader["unidad"].ToString();
                if (row.Ask.Type == TemplateAsk.AnalysisTemplateAskType.List)
                {
                    //row.Ask.DataList = GetListItemByItem(row.Ask.Id);
                }

                //PlantillaFilaGrupo grupo = new PlantillaFilaGrupo
                //{
                //    Tipo = PlantillaFila.PlantillaFilaTipo.Agrupada,
                //    Indice = Convert.ToInt32(reader["indice"]),
                //    IdData = Convert.ToInt32(reader["id"]),
                //    Nombre = reader["nombre"].ToString()
                //};

                //grupo.Items = GetItemByGrupo(grupo.IdData);
                //dictionary.Add(grupo.Indice, grupo);

                try
                {
                    int indice = row.Index;
                    dictionary.Add(row.Index, row);
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

        public DataTable GetTable(TemplateRow obj)
        {
            throw new NotImplementedException();
        }
    }
}
