using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Main.Loaders
{
    partial class FormCargando
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            this.components = new Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.PanelLateral = new Panel();
            this.campPoint = new Label();
            this.label1 = new Label();
            this.PanelLateral.SuspendLayout();
            base.SuspendLayout();
            this.PanelLateral.BackColor = Color.FromArgb(0x33, 0x66, 0xff);
            this.PanelLateral.Controls.Add(this.campPoint);
            this.PanelLateral.Controls.Add(this.label1);
            this.PanelLateral.Dock = DockStyle.Fill;
            this.PanelLateral.Location = new Point(0, 0);
            this.PanelLateral.Name = "PanelLateral";
            this.PanelLateral.Size = new Size(0xb6, 0x41);
            this.PanelLateral.TabIndex = 0;
            this.campPoint.AutoSize = true;
            this.campPoint.Font = new Font("Futura Bk BT", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.campPoint.ForeColor = SystemColors.Window;
            this.campPoint.Location = new Point(0x73, 0x18);
            this.campPoint.Name = "campPoint";
            this.campPoint.Size = new Size(12, 0x12);
            this.campPoint.TabIndex = 2;
            this.campPoint.Text = ".";
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Futura Bk BT", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.ForeColor = SystemColors.Window;
            this.label1.Location = new Point(0x2b, 0x18);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x4d, 0x12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cargando";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0xb6, 0x41);
            base.ControlBox = false;
            base.Controls.Add(this.PanelLateral);
            base.FormBorderStyle = FormBorderStyle.None;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FormCargando";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Pantalla_de_Carga";
            this.PanelLateral.ResumeLayout(false);
            this.PanelLateral.PerformLayout();
            base.ResumeLayout(false);
        }


        #endregion
        private Label campPoint;
        private Label label1;
        private Panel PanelLateral;
    }
}