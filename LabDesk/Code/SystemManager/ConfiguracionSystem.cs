using MinLab;
using System.Collections.Generic;

namespace LogicLab.Code
{
    public class ConfiguracionSystem
    {
        private static Dictionary<int, string> estilos;

        public static void Init()
        {
            if (estilos == null)
            {
                estilos = new Dictionary<int, string>();
                estilos.Add(0, "Normal");
                estilos.Add(1, "Morado");
            }
        }

        public static void ResetDefaultAccesibilidad()
        {
            Daltonic = true;
        }

        public static void ResetDefaultGeneral()
        {
            Style = 0;
        }

        public static void ResetDefaultSonido()
        {
            SoundMouseEnabled = true;
            SoundSesionEnabled = true;
            SoundEnabled = true;
            Volumen = 100;
        }
        
        public static bool Daltonic
        {
            get => 
                Opciones.Default.Daltonic;
            set
            {
                Opciones.Default.Daltonic = value;
                Opciones.Default.Save();
            }
        }

        public static Dictionary<int, string> Estilos =>
            estilos;

        public static bool SoundEnabled
        {
            get => 
                Opciones.Default.Sound;
            set
            {
                Opciones.Default.Sound = value;
                Opciones.Default.Save();
            }
        }

        public static bool SoundMouseEnabled
        {
            get => 
                Opciones.Default.SoundClick;
            set
            {
                Opciones.Default.SoundClick = value;
                Opciones.Default.Save();
            }
        }

        public static bool SoundSesionEnabled
        {
            get => 
                Opciones.Default.SoundSesion;
            set
            {
                Opciones.Default.SoundSesion = value;
                Opciones.Default.Save();
            }
        }

        public static int Style
        {
            get => 
                Opciones.Default.Style;
            set
            {
                Opciones.Default.Style = value;
                Opciones.Default.Save();
            }
        }

        public static int Volumen
        {
            get => 
                Opciones.Default.SoundVolumen;
            set
            {
                Opciones.Default.SoundVolumen = value;
                Opciones.Default.Save();
            }
        }
    }
}
