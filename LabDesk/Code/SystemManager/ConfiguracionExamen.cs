namespace LabDesk.Code.PresentationLayer.Controles.ComponentesExamen.ComponentesExamenEditor
{
    public class ConfiguracionExamen
    {
        private static ConfiguracionExamen config;

        public static ConfiguracionExamen GetInstance()
        {
            if (config == null)
            {
                config = new ConfiguracionExamen();
            }
            return config;
        }

        public bool Changed { get; set; }

        public bool Loading { get; set; }
    }
}
