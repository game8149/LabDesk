using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Main.Loaders
{
    partial class PantallaDeCarga
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
            this.panel1 = new Panel();
            this.label4 = new Label();
            this.LabelVersion = new Label();
            this.panel2 = new Panel();
            this.LabelPropietario = new Label();
            this.LabelPrograma = new Label();
            this.campPoint = new Label();
            this.label1 = new Label();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.panel1.BackColor = Color.FromArgb(0x33, 0x66, 0xff);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.LabelVersion);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.LabelPropietario);
            this.panel1.Controls.Add(this.LabelPrograma);
            this.panel1.Controls.Add(this.campPoint);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x23e, 0x12d);
            this.panel1.TabIndex = 0;
            this.label4.AutoSize = true;
            this.label4.Font = new Font("Futura Bk BT", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label4.ForeColor = SystemColors.Window;
            this.label4.Location = new Point(0xe5, 0xc2);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x2e, 15);
            this.label4.TabIndex = 0x27;
            this.label4.Text = "Versi\x00f3n";
            this.LabelVersion.AutoSize = true;
            this.LabelVersion.Font = new Font("Futura Bk BT", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.LabelVersion.ForeColor = SystemColors.Window;
            this.LabelVersion.Location = new Point(0x113, 0xc2);
            this.LabelVersion.Name = "LabelVersion";
            this.LabelVersion.Size = new Size(0x1f, 14);
            this.LabelVersion.TabIndex = 0x26;
            this.LabelVersion.Text = "2016";
          //  this.panel2.BackgroundImage = Resources.microscope;
            this.panel2.BackgroundImageLayout = ImageLayout.Center;
            this.panel2.Location = new Point(0x3a, 0x4d);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(0x93, 0x84);
            this.panel2.TabIndex = 0x21;
            this.LabelPropietario.AutoSize = true;
            this.LabelPropietario.Font = new Font("Futura Md BT", 36f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.LabelPropietario.ForeColor = SystemColors.Window;
            this.LabelPropietario.Location = new Point(0xd3, 0x66);
            this.LabelPropietario.Name = "LabelPropietario";
            this.LabelPropietario.Size = new Size(0x127, 0x39);
            this.LabelPropietario.TabIndex = 0x20;
            this.LabelPropietario.Text = "Winchanzao";
            this.LabelPrograma.AutoSize = true;
            this.LabelPrograma.Font = new Font("Futura Bk BT", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.LabelPrograma.ForeColor = SystemColors.Window;
            this.LabelPrograma.Location = new Point(0xe4, 0x9f);
            this.LabelPrograma.Name = "LabelPrograma";
            this.LabelPrograma.Size = new Size(0x111, 0x16);
            this.LabelPrograma.TabIndex = 0x1f;
            this.LabelPrograma.Text = "Sistema de Laboratorio Clinico";
            this.campPoint.AutoSize = true;
            this.campPoint.Font = new Font("Futura Bk BT", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.campPoint.ForeColor = SystemColors.Window;
            this.campPoint.Location = new Point(0x141, 0xec);
            this.campPoint.Name = "campPoint";
            this.campPoint.Size = new Size(12, 0x12);
            this.campPoint.TabIndex = 2;
            this.campPoint.Text = ".";
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Futura Bk BT", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.ForeColor = SystemColors.Window;
            this.label1.Location = new Point(0xf9, 0xec);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x4d, 0x12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cargando";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x23e, 0x12d);
            base.ControlBox = false;
            base.Controls.Add(this.panel1);
            base.FormBorderStyle = FormBorderStyle.None;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "PantallaDeCarga";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Pantalla_de_Carga";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            base.ResumeLayout(false);
        }

        #endregion

        private Label campPoint;
        private Label label1;
        private Label label4;
        private Label LabelPrograma;
        private Label LabelPropietario;
        private Label LabelVersion;
        private Panel panel1;
        private Panel panel2;
    }
}