using LabDesk.Code.ControlSistemaInterno.Configuracion;
using System;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;


namespace LabDesk.Code.ControlSistemaInterno.GestorSonido
{
    public class ReproductorSonido
    {
        private static ReproductorSonido obj;

        public void InitVolume()
        {
            int num = 0x1999 * Opciones.Default.SoundVolumen;
            uint dwVolume = (uint) ((num & 0xffff) | (num << 0x10));
            waveOutSetVolume(IntPtr.Zero, dwVolume);
        }

        public static ReproductorSonido Instance()
        {
            if (obj == null)
            {
                obj = new ReproductorSonido();
                uint dwVolume = 0;
                waveOutGetVolume(IntPtr.Zero, out dwVolume);
                int num2 = 0x1999 * Opciones.Default.SoundVolumen;
                uint num3 = (uint) ((num2 & 0xffff) | (num2 << 0x10));
                waveOutSetVolume(IntPtr.Zero, num3);
            }
            return obj;
        }

        private void PlaySound(Stream audio)
        {
            SoundPlayer player = new SoundPlayer {
                Stream = audio
            };
            player.Load();
            if (player.IsLoadCompleted)
            {
                player.Play();
            }
        }

        public void RequestPlaySound(TipoSonido orden)
        {
            Stream audio = RecursosSound.ResourceManager.GetStream(orden.ToString(), RecursosSound.Culture);
            if (ConfiguracionSystem.SoundEnabled)
            {
                if (ConfiguracionSystem.SoundMouseEnabled && (orden == TipoSonido.ClickBtnUI))
                {
                    this.PlaySound(audio);
                }
                if (ConfiguracionSystem.SoundMouseEnabled && ((orden == TipoSonido.InicioSesion) || (orden == TipoSonido.FinalSesion)))
                {
                    this.PlaySound(audio);
                }
                if (((orden == TipoSonido.Error) || (orden == TipoSonido.Confirmacion)) || (orden == TipoSonido.Advertencia))
                {
                    this.PlaySound(audio);
                }
            }
        }

        public void TestSound(int volumen)
        {
            int num = 0x1999 * volumen;
            uint dwVolume = (uint) ((num & 0xffff) | (num << 0x10));
            waveOutSetVolume(IntPtr.Zero, dwVolume);
            TipoSonido testVol = TipoSonido.TestVol;
            Stream audio = RecursosSound.ResourceManager.GetStream(testVol.ToString(), RecursosSound.Culture);
            this.PlaySound(audio);
        }

        public void UpdateVolumen()
        {
            this.InitVolume();
        }

        [DllImport("winmm.dll")]
        public static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);
        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

        public enum TipoSonido
        {
            InicioSesion,
            FinalSesion,
            ClickBtnUI,
            Error,
            Advertencia,
            Confirmacion,
            TestVol
        }
    }
}
