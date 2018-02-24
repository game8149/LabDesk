namespace LabDesk.Code.PresentationLayer
{
    using LabDesk.Code.PresentationLayer.ComponenteGeneral;
    using LabDesk.Code.PresentationLayer.GUISistema;
    using System;
    using System.Data.SqlClient;
    using System.Threading;
    using System.Windows.Forms;

    internal static class SistemaWinchanzao
    {
        private static bool isRunning = true;

        [STAThread]
        private static void Main()
        {
            bool flag = false;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                SqlConnection connection1 = new SqlConnection {
                    ConnectionString = ConfiguracionSystem.ConexionConfig
                };
                connection1.Open();
                connection1.Close();
                flag = true;
            }
            catch (Exception exception)
            {
                FormMensaje.Error(RecursosUIMensajes.MsgConexionError + " \n" + exception);
            }
            if (flag)
            {
                try
                {
                    Thread hilo = new Thread(new ThreadStart(new CargadorArchivos().cargar));
                    hilo.Start();
                    while (!hilo.IsAlive)
                    {
                    }
                    PantallaDeCarga carga1 = new PantallaDeCarga(2, hilo);
                    carga1.ShowDialog();
                    carga1.Dispose();
                    LogicaControlSistema sistema = new LogicaControlSistema();
                    do
                    {
                        FormInicioSesion sesion1 = new FormInicioSesion();
                        sesion1.ShowDialog();
                        sesion1.Dispose();
                        if (sistema.EsLoggeado())
                        {
                            Principal mainForm = new Principal();
                            LogicaControlSistema.FormPrincipal = mainForm;
                            Application.Run(mainForm);
                            if (mainForm.ModeExit)
                            {
                                isRunning = false;
                            }
                            else
                            {
                                isRunning = true;
                            }
                            sistema.CerrarSesion();
                            mainForm.Dispose();
                        }
                        else
                        {
                            isRunning = false;
                        }
                    }
                    while (isRunning);
                    Application.Exit();
                }
                catch (Exception exception2)
                {
                    FormMensaje.Error(exception2.Message);
                    isRunning = false;
                }
            }
        }
    }
}
