using DataManager.Code.Repositories;
using Entity.Code.Business;
using System;
using System.Collections.Generic;

namespace MinLab.Code.LogicLayer.LogicaPaciente
{

    public class PatientBL
    {
        private PatientRepository PatientRepo = new PatientRepository();


        public bool ActualizarPaciente(Patient pat)
        {
            if (pat.Validate())
            {
                PatientRepo.Save(pat);
                return true;
            }
            return false;
        }

        public bool CrearPaciente(Patient pat)
        {
            if (!pat.Validate())
            {
                return false;
            }
            if (PatientRepo.Get(pat.Id) != null)
            {
                throw new Exception("Ya existe una cuenta para ese DNI");
            }
            PatientRepo.Save(pat);
            return true;
        }

        public bool EliminarPaciente(Patient pat) =>
            PatientRepo.Remove(pat) == 1;


        public Patient ObtenerPerfilPorDNI(int DNI) =>
            PatientRepo.Get(DNI);

        public IEnumerable<Patient> ObtenerPerfilPorFiltro(Patient pat) =>
            PatientRepo.List(pat);


    }
}
