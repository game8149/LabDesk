namespace MinLab.Code.ControlSistemaInterno
{
    /// <summary>
    /// Descripción breve de Configuracion
    /// </summary>
    public class ConfiguracionDataAccess
    {

        private static ConfiguracionDataAccess oConfig;


        public static ConfiguracionDataAccess GetInstance(){
 
            if (oConfig == null)
                oConfig = new ConfiguracionDataAccess();

            return oConfig;
        }
        
        /// <summary>
        /// Descripción breve de Configuracion
        /// </summary>
        public string CadenaConexion
        {
            get { return ConfigurationManager.ConnectionStrings["Server"].ConnectionString; }

            set { ConfigurationManager.ConnectionStrings["Server"].ConnectionString=value; }
        }
        
    }
}
