using DataManager.Recursos;
using EntityLab.Code.Actors;
using EntityLab.Code.Base;
using EntityLab.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataManager.Code.Repositories
{
    public class MedicRepository : IRepositorySimpleRecord<Medic, int>
    {
        public void Add(Medic entity)
        {
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command1 = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcAdd.ADD_MEDICO,
                CommandType = CommandType.StoredProcedure
            };
            command1.Parameters.AddWithValue("@nombre", entity.Nombres);
            command1.Parameters.AddWithValue("@primerApellido", entity.PrimerApellido);
            command1.Parameters.AddWithValue("@segundoApellido", entity.SegundoApellido);
            command1.Parameters.AddWithValue("@colegiatura", entity.CodigoColegiatura);
            command1.Parameters.AddWithValue("@especialidad", entity.IdEspecialidad);
            command1.Parameters.AddWithValue("@habil", entity.Habil);
            command1.Connection.Open();
            command1.ExecuteNonQuery();
            connection.Close();
            command1.Dispose();
        }

        public void Delete(int id)
        {
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command1 = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcDel.DEL_MEDICO,
                CommandType = CommandType.StoredProcedure
            };
            command1.Parameters.AddWithValue("@id", id);
            command1.Connection.Open();
            command1.ExecuteNonQuery();
            connection.Close();
            command1.Dispose();
        }

        public IEnumerable<Medic> SelectList()
        {
            throw new Exception();
        }

        //public IEnumerable<Medico> Select(FilterParameter[] parameters)
        //{
        //    Dictionary<int, Medico> dictionary = new Dictionary<int, Medico>();
        //    SqlConnection connection = new SqlConnection
        //    {
        //        ConnectionString = DataConfig.Default.ConnectionString
        //    };
        //    SqlCommand command = new SqlCommand();
        //    Medico medico = null;
        //    command.Connection = connection;
        //    object[] objArray1 = new object[] { "select id,colegiatura,nombre,primerApellido,segundoApellido,Especialidad,habil from Medico where nombre like '", nombre, "%' and primerApellido like '", primerApellido, "%' and segundoApellido like '", segundoApellido, "%' and habil=", Convert.ToInt16(habil) };
        //    command.CommandText = string.Concat(objArray1);
        //    command.CommandType = CommandType.Text;
        //    command.Connection.Open();
        //    SqlDataReader reader = command.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        medico = new Medico
        //        {
        //            Id = Convert.ToInt32(reader["id"]),
        //            Nombres = reader["nombre"].ToString(),
        //            PrimerApellido = reader["primerApellido"].ToString(),
        //            SegundoApellido = reader["segundoApellido"].ToString(),
        //            Colegiatura = reader["colegiatura"].ToString().Trim(),
        //            Especialidad = reader["especialidad"].ToString(),
        //            Habil = Convert.ToBoolean(reader["habil"])
        //        };
        //        dictionary.Add(medico.Id, medico);
        //    }
        //    connection.Close();
        //    command.Dispose();
        //    return dictionary;

        //    //SqlConnection connection = new SqlConnection
        //    //{
        //    //    ConnectionString = DataConfig.Default.ConnectionString
        //    //};
        //    //SqlCommand command = new SqlCommand();
        //    //Dictionary<int, Medico> dictionary = new Dictionary<int, Medico>();
        //    //command.Connection = connection;
        //    //command.CommandText = ProcGet.GET_MEDICO_ALL_HABIL;
        //    //command.CommandType = CommandType.StoredProcedure;
        //    //command.Connection.Open();
        //    //SqlDataReader reader = command.ExecuteReader();
        //    //while (reader.Read())
        //    //{
        //    //    Medico medico = new Medico
        //    //    {
        //    //        IdData = Convert.ToInt32(reader["id"]),
        //    //        Nombre = reader["nombre"].ToString(),
        //    //        PrimerApellido = reader["primerApellido"].ToString(),
        //    //        SegundoApellido = reader["segundoApellido"].ToString(),
        //    //        Colegiatura = reader["colegiatura"].ToString().Trim(),
        //    //        Especialidad = reader["especialidad"].ToString(),
        //    //        Habil = Convert.ToBoolean(reader["habil"])
        //    //    };
        //    //    dictionary.Add(medico.IdData, medico);
        //    //}
        //    //connection.Close();
        //    //command.Dispose();
        //    //return dictionary;
        //}

        public Medic Select(int id)
        {
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command = new SqlCommand();
            Medic medico = null;
            command.Connection = connection;
            command.CommandText = ProcGet.GET_MEDICO;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ID", id);
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                medico = new Medic
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Nombres = reader["nombre"].ToString(),
                    PrimerApellido = reader["primerApellido"].ToString(),
                    SegundoApellido = reader["segundoApellido"].ToString(),
                    CodigoColegiatura = reader["colegiatura"].ToString().Trim(),
                    IdEspecialidad = reader["especialidad"].ToString(),
                    Habil = Convert.ToBoolean(reader["habil"])
                };
            }
            connection.Close();
            command.Dispose();
            return medico;
        }

        public IDictionary<int, Medic> SelectDic()
        {
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command = new SqlCommand();
            Dictionary<int, Medic> dictionary = new Dictionary<int, Medic>();
            command.Connection = connection;
            command.CommandText = ProcGet.GET_MEDICO_ALL;
            command.CommandType = CommandType.StoredProcedure;
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Medic medico = new Medic
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Nombres = reader["nombre"].ToString(),
                    PrimerApellido = reader["primerApellido"].ToString(),
                    SegundoApellido = reader["segundoApellido"].ToString(),
                    CodigoColegiatura = reader["colegiatura"].ToString().Trim(),
                    IdEspecialidad = reader["especialidad"].ToString(),
                    Habil = Convert.ToBoolean(reader["habil"])
                };
                dictionary.Add(medico.Id, medico);
            }
            connection.Close();
            command.Dispose();
            return dictionary;
        }

        public void Update(Medic entity)
        {
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command1 = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcUpd.UPD_MEDICO,
                CommandType = CommandType.StoredProcedure
            };
            command1.Parameters.AddWithValue("@id", entity.Id);
            command1.Parameters.AddWithValue("@nombre", entity.Nombres);
            command1.Parameters.AddWithValue("@primerApellido", entity.PrimerApellido);
            command1.Parameters.AddWithValue("@segundoApellido", entity.SegundoApellido);
            command1.Parameters.AddWithValue("@colegiatura", entity.CodigoColegiatura);
            command1.Parameters.AddWithValue("@especialidad", entity.IdEspecialidad);
            command1.Parameters.AddWithValue("@habil", entity.Habil);
            command1.Connection.Open();
            command1.ExecuteNonQuery();
            connection.Close();
            command1.Dispose();
        }

        public Medic Select(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Medic> SelectList(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, Medic> SelectDic(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectTable(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
