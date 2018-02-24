
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System;

namespace LabDesk.Code.Components.Main.Panels
{
    partial class ControlBienvenida
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(ControlBienvenida));
            this.PanelLateral = new Panel();
            this.label4 = new Label();
            this.pictureBox2 = new PictureBox();
            this.LinkCerrarSesion = new LinkLabel();
            this.linkLabel2 = new LinkLabel();
            this.linkLabel3 = new LinkLabel();
            this.linkLabel1 = new LinkLabel();
            this.CampNivel = new Label();
            this.CampNombre = new Label();
            this.label1 = new Label();
            this.label2 = new Label();
            this.TextoBienvenida = new Label();
            this.ImagenBienvenida = new PictureBox();
            this.PanelLateral.SuspendLayout();
            ((ISupportInitialize)this.pictureBox2).BeginInit();
            ((ISupportInitialize)this.ImagenBienvenida).BeginInit();
            base.SuspendLayout();
            this.PanelLateral.Anchor = AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
            this.PanelLateral.BackColor = Color.DarkGoldenrod;
            this.PanelLateral.Controls.Add(this.label4);
            this.PanelLateral.Controls.Add(this.pictureBox2);
            this.PanelLateral.Controls.Add(this.LinkCerrarSesion);
            this.PanelLateral.Controls.Add(this.linkLabel2);
            this.PanelLateral.Controls.Add(this.linkLabel3);
            this.PanelLateral.Controls.Add(this.linkLabel1);
            this.PanelLateral.Controls.Add(this.CampNivel);
            this.PanelLateral.Controls.Add(this.CampNombre);
            this.PanelLateral.Controls.Add(this.label1);
            this.PanelLateral.Location = new Point(0x32b, 0);
            this.PanelLateral.Margin = new Padding(0);
            this.PanelLateral.Name = "PanelLateral";
            this.PanelLateral.Size = new Size(0x10a, 0x22a);
            this.PanelLateral.TabIndex = 0;
            this.label4.AutoSize = true;
            this.label4.BackColor = Color.Transparent;
            this.label4.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label4.ForeColor = SystemColors.ControlLightLight;
            this.label4.Location = new Point(0x16, 0xfd);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x35, 0x13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ayuda";
            this.pictureBox2.BackColor = Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = ImageLayout.None;
           // this.pictureBox2.Image = Resources.icon_user;
          //  this.pictureBox2.InitialImage = (Image)manager.GetObject("pictureBox2.InitialImage");
            this.pictureBox2.Location = new Point(0x1a, 0x3d);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Size(70, 70);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            this.LinkCerrarSesion.ActiveLinkColor = Color.DodgerBlue;
            this.LinkCerrarSesion.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.LinkCerrarSesion.LinkColor = Color.White;
            this.LinkCerrarSesion.Location = new Point(0x17, 0x1fd);
            this.LinkCerrarSesion.Name = "LinkCerrarSesion";
            this.LinkCerrarSesion.Size = new Size(0x56, 0x10);
            this.LinkCerrarSesion.TabIndex = 5;
            this.LinkCerrarSesion.TabStop = true;
            this.LinkCerrarSesion.Text = "Cerrar Sesi\x00f3n";
            this.LinkCerrarSesion.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            this.linkLabel2.ActiveLinkColor = Color.White;
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.BackColor = Color.Transparent;
            this.linkLabel2.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.linkLabel2.ForeColor = SystemColors.ControlLightLight;
            this.linkLabel2.LinkColor = Color.White;
            this.linkLabel2.Location = new Point(0x17, 0xbd);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new Size(0x5d, 0x10);
            this.linkLabel2.TabIndex = 4;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Cambiar Clave";
            this.linkLabel2.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            this.linkLabel3.ActiveLinkColor = Color.White;
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.BackColor = Color.Transparent;
            this.linkLabel3.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.linkLabel3.ForeColor = SystemColors.ControlLightLight;
            this.linkLabel3.LinkColor = Color.White;
            this.linkLabel3.Location = new Point(0x17, 0x124);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new Size(0x73, 0x10);
            this.linkLabel3.TabIndex = 6;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Manual de Usuario";
            this.linkLabel3.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            this.linkLabel1.ActiveLinkColor = Color.White;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = Color.Transparent;
            this.linkLabel1.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.linkLabel1.ForeColor = SystemColors.ControlLightLight;
            this.linkLabel1.LinkColor = Color.White;
            this.linkLabel1.Location = new Point(0x17, 0x9b);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new Size(0x62, 0x10);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Actualizar Datos";
            this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            this.CampNivel.BackColor = Color.Transparent;
            this.CampNivel.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampNivel.ForeColor = SystemColors.ControlLightLight;
            this.CampNivel.Location = new Point(0x60, 0x61);
            this.CampNivel.Name = "CampNivel";
            this.CampNivel.Size = new Size(0x9b, 0x10);
            this.CampNivel.TabIndex = 2;
            this.CampNivel.Text = "Cuenta";
            this.CampNombre.BackColor = Color.Transparent;
            this.CampNombre.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampNombre.ForeColor = SystemColors.ControlLightLight;
            this.CampNombre.Location = new Point(0x60, 0x4a);
            this.CampNombre.Name = "CampNombre";
            this.CampNombre.Size = new Size(0x9b, 0x10);
            this.CampNombre.TabIndex = 1;
            this.CampNombre.Text = "Cuenta";
            this.label1.AutoSize = true;
            this.label1.BackColor = Color.Transparent;
            this.label1.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.ForeColor = SystemColors.ControlLightLight;
            this.label1.Location = new Point(0x16, 0x19);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x55, 0x13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Credencial";
            this.label2.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.ForeColor = SystemColors.ControlText;
            this.label2.Location = new Point(0x15, 15);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x1f6, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bienvenido al Sistema de Laboratorio de An\x00e1lisis Cl\x00ednico: Winchanzao";
            this.label2.TextAlign = ContentAlignment.MiddleLeft;
            this.TextoBienvenida.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.TextoBienvenida.Location = new Point(0x16, 0x3d);
            this.TextoBienvenida.Margin = new Padding(0);
            this.TextoBienvenida.Name = "TextoBienvenida";
            this.TextoBienvenida.Size = new Size(0x1c5, 0x1cf);
            this.TextoBienvenida.TabIndex = 2;
//            this.TextoBienvenida.Text = manager.GetString("TextoBienvenida.Text");
            //this.ImagenBienvenida.BackgroundImage = Resources.laboratorioclinico;
            this.ImagenBienvenida.BackgroundImageLayout = ImageLayout.None;
            this.ImagenBienvenida.Location = new Point(0x1f6, 0x3d);
            this.ImagenBienvenida.Margin = new Padding(0);
            this.ImagenBienvenida.Name = "ImagenBienvenida";
            this.ImagenBienvenida.Size = new Size(0x120, 0x1cf);
            this.ImagenBienvenida.TabIndex = 5;
            this.ImagenBienvenida.TabStop = false;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = SystemColors.Window;
            this.BackgroundImageLayout = ImageLayout.Center;
            base.Controls.Add(this.label2);
            base.Controls.Add(this.PanelLateral);
            base.Controls.Add(this.ImagenBienvenida);
            base.Controls.Add(this.TextoBienvenida);
            this.DoubleBuffered = true;
            base.Margin = new Padding(0);
            this.MinimumSize = new Size(0x433, 550);
            base.Name = "ControlBienvenida";
            base.Size = new Size(0x435, 0x228);
            base.Load += new EventHandler(this.ControlBienvenida_Load);
            this.PanelLateral.ResumeLayout(false);
            this.PanelLateral.PerformLayout();
            ((ISupportInitialize)this.pictureBox2).EndInit();
            ((ISupportInitialize)this.ImagenBienvenida).EndInit();
            base.ResumeLayout(false);
        }

        #endregion

        private Label CampNivel;
        private Label CampNombre;
        private PictureBox ImagenBienvenida;
        private Label label1;
        private Label label2;
        private Label label4;
        private LinkLabel LinkCerrarSesion;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
        private LinkLabel linkLabel3;
        private Panel PanelLateral;
        private PictureBox pictureBox2;
        private Label TextoBienvenida;

    }
}
