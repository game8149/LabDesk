
using DataManager.Code.Repositories;
using Entity.Code.Hospital;
using Entity.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MinLab.Code.LogicLayer.LogicaPaciente
{

    public class LogicaPaciente
    {
        private IRepositorySimpleRecord<Patient, int> repoPaciente = new PatientRepository();


        public bool ActualizarPaciente(Patient pac)
        {
            if (pac.Validate())
            {
                repoPaciente.Update(pac);
                return true;
            }
            return false;
        }

        public bool CrearPaciente(Patient pac)
        {
            if (!pac.Validate())
            {
                return false;
            }
            if (repoPaciente.GetPacienteByDni(pac.Dni) != null)
            {
                throw new Exception("Ya existe una cuenta para ese DNI");
            }
            repoPaciente.Add(pac);
            return true;
        }

        public bool EliminarPaciente(Patient pac) => 
            repoPaciente.Delete(pac.Id);


        public Patient ObtenerPerfilPorDNI(string DNI) => 
            repoPaciente.GetPacienteByDni(DNI);

        public Dictionary<int, Patient> ObtenerPerfilPorFiltro(string dni, string historia, string nombre, string apellidoP, string apellidoM) => 
            repoPaciente.GetPacientesByFiltro(dni, historia, nombre, apellidoM, apellidoP);

        public Patient ObtenerPerfilPorHC(string HC) => 
            repoPaciente.GetPacienteByHistoria(HC);

        public Patient ObtenerPerfilPorId(int id) => 
            repoPaciente.GetPacienteById(id);

        
    }
}
