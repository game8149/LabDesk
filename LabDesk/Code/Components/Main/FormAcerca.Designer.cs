using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Main
{
    partial class FormAcerca
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FormAcerca));
            this.panel1 = new Panel();
            this.pictureBox1 = new PictureBox();
            this.LabelVersion = new Label();
            this.linkLabel1 = new LinkLabel();
            this.label4 = new Label();
            this.label1 = new Label();
            this.LabelPropietario = new Label();
            this.LabelPrograma = new Label();
            this.panel1.SuspendLayout();
            ((ISupportInitialize)this.pictureBox1).BeginInit();
            base.SuspendLayout();
            this.panel1.BackColor = Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.LabelVersion);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.LabelPropietario);
            this.panel1.Controls.Add(this.LabelPrograma);
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x1d1, 0xf1);
            this.panel1.TabIndex = 0x25;
           // this.pictureBox1.Image = Resources.microscope;
            this.pictureBox1.Location = new Point(0x24, 0x34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(0x88, 0x84);
            this.pictureBox1.TabIndex = 0x25;
            this.pictureBox1.TabStop = false;
            this.LabelVersion.AutoSize = true;
            this.LabelVersion.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.LabelVersion.ForeColor = SystemColors.WindowText;
            this.LabelVersion.Location = new Point(0x105, 120);
            this.LabelVersion.Name = "LabelVersion";
            this.LabelVersion.Size = new Size(40, 0x10);
            this.LabelVersion.TabIndex = 0x24;
            this.LabelVersion.Text = "2016";
            this.linkLabel1.ActiveLinkColor = Color.DodgerBlue;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.linkLabel1.LinkColor = Color.FromArgb(0x40, 0x40, 0x40);
            this.linkLabel1.Location = new Point(0xcf, 0xbd);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new Size(0x68, 0x10);
            this.linkLabel1.TabIndex = 0x23;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Notas de Versi\x00f3n";
            this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            this.label4.AutoSize = true;
            this.label4.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label4.ForeColor = SystemColors.WindowText;
            this.label4.Location = new Point(0x188, 70);
            this.label4.Name = "label4";
            this.label4.Size = new Size(40, 0x10);
            this.label4.TabIndex = 1;
            this.label4.Text = "2017";
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.ForeColor = SystemColors.WindowText;
            this.label1.Location = new Point(0xcf, 120);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0xd5, 0x30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Version:\r\nAutor: Alexis Gavidia Meza\r\nContacto: gavidia.alex@outlook.com\r\n";
            this.label1.TextAlign = ContentAlignment.MiddleLeft;
            this.LabelPropietario.AutoSize = true;
            this.LabelPropietario.Font = new Font("Futura Md BT", 24f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.LabelPropietario.ForeColor = SystemColors.WindowText;
            this.LabelPropietario.Location = new Point(0xcb, 0x1f);
            this.LabelPropietario.Name = "LabelPropietario";
            this.LabelPropietario.Size = new Size(0xc6, 0x27);
            this.LabelPropietario.TabIndex = 0x22;
            this.LabelPropietario.Text = "Winchanzao";
            this.LabelPrograma.AutoSize = true;
            this.LabelPrograma.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.LabelPrograma.ForeColor = SystemColors.WindowText;
            this.LabelPrograma.Location = new Point(0xcf, 70);
            this.LabelPrograma.Name = "LabelPrograma";
            this.LabelPrograma.Size = new Size(0xb3, 0x10);
            this.LabelPrograma.TabIndex = 0x21;
            this.LabelPrograma.Text = "Sistema de Laboratorio Clinico";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x1d1, 0xf1);
            base.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
//            base.Icon = (Icon)manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FormAcerca";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Acerca";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((ISupportInitialize)this.pictureBox1).EndInit();
            base.ResumeLayout(false);
        }

        #endregion


        private Label label1;
        private Label label4;
        private Label LabelPrograma;
        private Label LabelPropietario;
        private Label LabelVersion;
        private LinkLabel linkLabel1;
        private Panel panel1;
        private PictureBox pictureBox1;
    }
}