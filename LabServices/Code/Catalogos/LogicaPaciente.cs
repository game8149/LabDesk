
using DataManager.Code.Repositories;
using EntityLab.Code.Hospital;
using EntityLab.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MinLab.Code.LogicLayer.LogicaPaciente
{

    public class LogicaPaciente
    {
        private IRepositorySimpleRecord<Paciente, int> repoPaciente = new PacienteRepository();


        public bool ActualizarPaciente(Paciente pac)
        {
            if (pac.Validar())
            {
                repoPaciente.Update(pac);
                return true;
            }
            return false;
        }

        public bool CrearPaciente(Paciente pac)
        {
            if (!pac.Validar())
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

        public bool EliminarPaciente(Paciente pac) => 
            repoPaciente.Delete(pac.Id);


        public Paciente ObtenerPerfilPorDNI(string DNI) => 
            repoPaciente.GetPacienteByDni(DNI);

        public Dictionary<int, Paciente> ObtenerPerfilPorFiltro(string dni, string historia, string nombre, string apellidoP, string apellidoM) => 
            repoPaciente.GetPacientesByFiltro(dni, historia, nombre, apellidoM, apellidoP);

        public Paciente ObtenerPerfilPorHC(string HC) => 
            repoPaciente.GetPacienteByHistoria(HC);

        public Paciente ObtenerPerfilPorId(int id) => 
            repoPaciente.GetPacienteById(id);

        
    }
}
