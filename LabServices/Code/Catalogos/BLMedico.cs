namespace MinLab.Code.LogicLayer
{
    using System.Collections.Generic;
    using System.Globalization;

    public class BLMedico
    {
        public bool ActualizarMedico(Medico medico)
        {
            this.ValidarDatos(medico);
            new DataMedico().UpdMedico(medico);
            return true;
        }

        public bool CrearMedico(Medico medico)
        {
            this.ValidarDatos(medico);
            new DataMedico().AddMedico(medico);
            return true;
        }

        public bool EliminarMedico(int id)
        {
            new DataMedico().DelMedico(id);
            return true;
        }

        public static string FormatearNombre(Medico medico)
        {
            string[] textArray1 = new string[] { medico.Nombre, " ", medico.PrimerApellido, " ", medico.SegundoApellido };
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(string.Concat(textArray1));
        }

        public Dictionary<int, string> ObtenerListaGeneral()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            foreach (Medico medico in new DataMedico().GetAllMedico().Values)
            {
                dictionary.Add(medico.IdData, medico.PrimerApellido + " " + medico.SegundoApellido + ", " + medico.Nombre);
            }
            return dictionary;
        }

        public Dictionary<int, string> ObtenerListaHabil()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            foreach (Medico medico in new DataMedico().GetAllMedicoHabil().Values)
            {
                dictionary.Add(medico.IdData, FormatearNombre(medico));
            }
            return dictionary;
        }

        public Medico ObtenerMedico(int id) => 
            new DataMedico().GetMedico(id);

        public Dictionary<int, Medico> ObtenerMedico(string nombre, string primerApellido, string segundoApellido, bool habil) => 
            new DataMedico().GetMedicoByFiltro(nombre, primerApellido, segundoApellido, habil);

        public Dictionary<int, Medico> ObtenerMedicosHabil() => 
            new DataMedico().GetAllMedicoHabil();

        
    }
}
