using DataManager.Recursos;
using EntityLab.Code.Base;
using EntityLab.Code.Hospital;
using EntityLab.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static EntityLab.Code.Actors.Person;

namespace DataManager.Code.Repositories
{
    public class PacienteRepository : IRepositorySimpleRecord<Paciente, int>
    {
        public void Add(Paciente entity)
        {
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcAdd.ADD_PACIENTE,
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter { ParameterName = "@hc", Value = entity.CodigoHistoria });
            command.Parameters.AddWithValue("@nombre", entity.Names);
            command.Parameters.AddWithValue("@apellidoP", entity.FirstSurname);
            command.Parameters.AddWithValue("@apellidoM", entity.LastSurname);
            command.Parameters.AddWithValue("@direccion", entity.Direccion);
            command.Parameters.AddWithValue("@sexo", entity.Sex);
            command.Parameters.AddWithValue("@fechaNac", entity.BirthDate);
            command.Parameters.AddWithValue("@dni", entity.IdDocumentType);
            command.Parameters.AddWithValue("@dni", entity.DocumentNumber);
            command.Parameters.AddWithValue("@idDistrito", entity.IdCurrentUbigeo);
            command.Parameters.AddWithValue("@idDistrito", entity.IdOriginalUbigeo);
            command.Parameters.AddWithValue("@idSector", entity.IdSector);
            command.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
            command.Connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            command.Dispose();
            //return Convert.ToInt32(command.Parameters["@id"].Value);
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
                CommandText = ProcDel.DEL_PACIENTE,
                CommandType = CommandType.StoredProcedure
            };
            command1.Parameters.AddWithValue("@idPaciente", id);
            command1.Connection.Open();
            command1.ExecuteReader();
            connection.Close();
            command1.Dispose();
        }

        public IEnumerable<Paciente> SelectList()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Paciente> Select(FilterParameter[] parameters)
        {

            throw new NotImplementedException();
        }

        public Paciente Select(int id)
        {
            Paciente paciente = null;
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcGet.GET_PACIENTE_BYID,
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@idPaciente", id);
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                paciente = new Paciente
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Names = reader["nombre"].ToString(),
                    LastSurname = reader["apellido2"].ToString(),
                    FirstSurname = reader["apellido1"].ToString(),
                    Direccion = reader["direccion"].ToString(),
                    CodigoHistoria = reader["hclinica"].ToString(),
                    DocumentNumber = reader["dni"].ToString(),
                    Sex = (SexType)Convert.ToInt32(reader["sexo"]),
                    BirthDate = Convert.ToDateTime(reader["fechaNacimiento"]),
                    IdOriginalUbigeo = reader["idDistrito"].ToString(),
                    IdCurrentUbigeo = reader["idDistrito"].ToString(),
                    IdSector = reader["idSector"].ToString()
                };
            }
            reader.Close();
            connection.Close();
            command.Dispose();
            return paciente;
        }

        //public Paciente Select(string historia)
        //{
        //    Paciente entity = null;
        //    SqlConnection connection = new SqlConnection
        //    {
        //        ConnectionString = DataConfig.Default.ConnectionString
        //    };
        //    SqlCommand command = new SqlCommand
        //    {
        //        Connection = connection,
        //        CommandText = ProcGet.GET_PACIENTE_BYHISTORIA,
        //        CommandType = CommandType.StoredProcedure
        //    };
        //    command.Parameters.AddWithValue("@historia", historia);
        //    command.Connection.Open();
        //    SqlDataReader reader = command.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        entity = new Paciente
        //        {
        //            IdData = Convert.ToInt32(reader["id"]),
        //            Nombre = reader["nombre"].ToString(),
        //            LastSurname = reader["apellido2"].ToString(),
        //            FirstSurname = reader["apellido1"].ToString(),
        //            Direccion = reader["direccion"].ToString(),
        //            Historia = reader["hclinica"].ToString(),
        //            Dni = reader["dni"].ToString(),
        //            Sex = (Sex)Convert.ToInt32(reader["sexo"]),
        //            BirthDate = Convert.ToDateTime(reader["fechaNacimiento"]),
        //            IdDistrito = Convert.ToInt32(reader["idDistrito"]),
        //            IdSector = Convert.ToInt32(reader["idSector"])
        //        };
        //    }
        //    reader.Close();
        //    connection.Close();
        //    command.Dispose();
        //    return entity;
        //}

        public Paciente Select(string dni)
        {
            Paciente entity = null;
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcGet.GET_PACIENTE_BYDNI,
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@Dni", dni);
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                entity = new Paciente
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Names = reader["nombre"].ToString(),
                    LastSurname = reader["apellido2"].ToString(),
                    FirstSurname = reader["apellido1"].ToString(),
                    Direccion = reader["direccion"].ToString(),
                    CodigoHistoria = reader["hclinica"].ToString(),
                    DocumentNumber = reader["dni"].ToString(),
                    Sex = (SexType)Convert.ToInt32(reader["sexo"]),
                    BirthDate = Convert.ToDateTime(reader["fechaNacimiento"]),
                    IdOriginalUbigeo = reader["idDistrito"].ToString(),
                    IdCurrentUbigeo = reader["idDistrito"].ToString(),
                    IdSector = reader["idSector"].ToString()
                };
            }
            reader.Close();
            connection.Close();
            command.Dispose();
            return entity;
        }

        public void Update(Paciente entity)
        {
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command1 = new SqlCommand
            {
                Connection = connection,
                CommandText = ProcUpd.UPD_PACIENTE,
                CommandType = CommandType.StoredProcedure
            };
            command1.Parameters.AddWithValue("@id", entity.Id);
            command1.Parameters.AddWithValue("@hc", entity.CodigoHistoria);
            command1.Parameters.AddWithValue("@nombre", entity.Names);
            command1.Parameters.AddWithValue("@apellidoP", entity.FirstSurname);
            command1.Parameters.AddWithValue("@apellidoM", entity.LastSurname);
            command1.Parameters.AddWithValue("@direccion", entity.Direccion);
            command1.Parameters.AddWithValue("@sexo", entity.Sex);
            command1.Parameters.AddWithValue("@fechaNac", entity.BirthDate);
            command1.Parameters.AddWithValue("@dni", entity.DocumentNumber);
            command1.Parameters.AddWithValue("@dni", entity.IdDocumentType);
            command1.Parameters.AddWithValue("@idDistrito", entity.IdOriginalUbigeo);
            command1.Parameters.AddWithValue("@idDistrito", entity.IdCurrentUbigeo);
            command1.Parameters.AddWithValue("@idSector", entity.IdSector);
            command1.Connection.Open();
            command1.ExecuteNonQuery();
            connection.Close();
            command1.Dispose();
        }
        

        public IEnumerable<Paciente> SelectList(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int,Paciente> SelectDic(FilterParameter[] parameters)
        {
            Dictionary<int, Paciente> dictionary = new Dictionary<int, Paciente>();
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = DataConfig.Default.ConnectionString
            };
            SqlCommand command = new SqlCommand
            {
                Connection = connection
            };
            command.CommandType = CommandType.Text;
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Paciente paciente = new Paciente
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Names = reader["nombre"].ToString(),
                    LastSurname = reader["apellido2"].ToString(),
                    FirstSurname = reader["apellido1"].ToString(),
                    Direccion = reader["direccion"].ToString(),
                    CodigoHistoria = reader["hclinica"].ToString(),
                    DocumentNumber = reader["dni"].ToString(),
                    Sex = (SexType)Convert.ToInt32(reader["sexo"]),
                    BirthDate = Convert.ToDateTime(reader["fechaNacimiento"]),
                    IdOriginalUbigeo = reader["idDistrito"].ToString(),
                    IdCurrentUbigeo = reader["idDistrito"].ToString(),
                    IdSector = reader["idSector"].ToString()
                };
                dictionary.Add(paciente.Id, paciente);
            }
            reader.Close();
            connection.Close();
            command.Dispose();
            return dictionary;
        }

        public DataTable SelectTable(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, Paciente> SelectDic()
        {
            throw new NotImplementedException();
        }

        Paciente IRepositorySimpleRecord<Paciente, int>.Select(FilterParameter[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
