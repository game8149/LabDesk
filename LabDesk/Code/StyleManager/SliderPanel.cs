
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LabDesk.Code.StyleManager
{
    internal class SliderPanel
    {
        private Point actualPos;
        private int increment;
        private int maxWidthSlide;
        private Panel panelSlide;
        private static SliderPanel slider;
        private System.Threading.Timer timerSlide;
        private TypeSlide tipoSlide;

        private SliderPanel()
        {
        }

        public static SliderPanel Instance()
        {
            if (slider == null)
            {
                slider = new SliderPanel();
            }
            return slider;
        }

        private void moveLeftPanel(object stateInfo)
        {
            if (this.panelSlide.Width != this.maxWidthSlide)
            {
                this.panelSlide.SuspendLayout();
                this.panelSlide.Width += this.increment;
                this.panelSlide.ResumeLayout(false);
            }
            if (Math.Sign((int) (this.maxWidthSlide - this.panelSlide.Width)) != Math.Sign(this.increment))
            {
                this.panelSlide.Width = this.maxWidthSlide;
                this.timerSlide.Dispose();
            }
        }

        private void moveRightPanel(object stateInfo)
        {
            if (this.panelSlide.Width != this.maxWidthSlide)
            {
                this.panelSlide.SuspendLayout();
                this.panelSlide.Width += this.increment;
                this.panelSlide.Location = new Point(this.panelSlide.Location.X - this.increment, this.panelSlide.Location.Y);
                this.panelSlide.ResumeLayout(false);
            }
            if (Math.Sign((int) (this.maxWidthSlide - this.panelSlide.Width)) != Math.Sign(this.increment))
            {
                this.panelSlide.Width = this.maxWidthSlide;
                this.panelSlide.Location = new Point(this.actualPos.X - (Math.Sign(this.increment) * this.maxWidthSlide), this.actualPos.Y);
                this.timerSlide.Dispose();
            }
        }

        public void SlidePanel(Panel panel, int widthObject, TypeSlide tipo)
        {
            AutoResetEvent state = new AutoResetEvent(false);
            this.tipoSlide = tipo;
            this.maxWidthSlide = widthObject;
            this.panelSlide = panel;
            this.increment = (widthObject - panel.Width) / 15;
            this.actualPos = panel.Location;
            if (this.timerSlide != null)
            {
                this.timerSlide.Dispose();
            }
            switch (this.tipoSlide)
            {
                case TypeSlide.Right:
                    this.timerSlide = new System.Threading.Timer(new TimerCallback(this.moveRightPanel), state, 0, 15);
                    break;

                case TypeSlide.Left:
                    this.timerSlide = new System.Threading.Timer(new TimerCallback(this.moveLeftPanel), state, 0, 15);
                    return;
            }
        }

        public enum TypeSlide
        {
            Right,
            Left,
            Top,
            Botton
        }
    }
}
