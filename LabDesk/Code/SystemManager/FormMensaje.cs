
using LabDesk.Code.ControlSistemaInterno.GestorSonido;
using System.Windows.Forms;

namespace LabDesk.Code.PresentationLayer.ComponenteGeneral
{
    public class FormMensaje
    {
        public static DialogResult Advertencia(string mensaje)
        {
            ReproductorSonido.Instance().RequestPlaySound(ReproductorSonido.TipoSonido.Advertencia);
            return MessageBox.Show(mensaje, RecursosUIMensajes.MsgAdvertencia, MessageBoxButtons.OK);
        }

        public static DialogResult Confirmacion(string mensaje)
        {
            ReproductorSonido.Instance().RequestPlaySound(ReproductorSonido.TipoSonido.Confirmacion);
            return MessageBox.Show(mensaje, RecursosUIMensajes.MsgConfirmacion, MessageBoxButtons.OK);
        }

        public static DialogResult DecisionAdvertencia(string mensaje)
        {
            ReproductorSonido.Instance().RequestPlaySound(ReproductorSonido.TipoSonido.Advertencia);
            return MessageBox.Show(mensaje, RecursosUIMensajes.MsgAdvertencia, MessageBoxButtons.YesNo);
        }

        public static DialogResult Error(string mensaje)
        {
            ReproductorSonido.Instance().RequestPlaySound(ReproductorSonido.TipoSonido.Error);
            return MessageBox.Show(mensaje, RecursosUIMensajes.MsgPeligro, MessageBoxButtons.OK);
        }
    }
}
