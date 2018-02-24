using LabDesk.Code.Base;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.Forms.Main
{
    partial class FormInicioSesion
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FormInicioSesion));
            this.CampDni = new TextBox();
            this.CampClave = new TextBox();
            this.label3 = new Label();
            this.label4 = new Label();
            this.linkLabel1 = new LinkLabel();
            this.BtnUISesion1 = new ButtonUI();
            this.panelSesionUI1 = new PanelSesionUI();
            base.SuspendLayout();
            this.CampDni.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampDni.Location = new Point(0x51, 0xa5);
            this.CampDni.MaxLength = 8;
            this.CampDni.Name = "CampDni";
            this.CampDni.Size = new Size(0xa8, 0x17);
            this.CampDni.TabIndex = 1;
            this.CampDni.TextAlign = HorizontalAlignment.Center;
            this.CampClave.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampClave.Location = new Point(0x51, 0xec);
            this.CampClave.MaxLength = 0x10;
            this.CampClave.Name = "CampClave";
            this.CampClave.PasswordChar = '+';
            this.CampClave.Size = new Size(0xa8, 0x17);
            this.CampClave.TabIndex = 2;
            this.CampClave.TextAlign = HorizontalAlignment.Center;
            this.CampClave.UseSystemPasswordChar = true;
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label3.Location = new Point(140, 0x85);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x33, 0x10);
            this.label3.TabIndex = 0x1c;
            this.label3.Text = "Usuario";
            this.label4.AutoSize = true;
            this.label4.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label4.Location = new Point(0x91, 0xcc);
            this.label4.Name = "label4";
            this.label4.Size = new Size(40, 0x10);
            this.label4.TabIndex = 0x16;
            this.label4.Text = "Clave";
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Cursor = Cursors.Hand;
            this.linkLabel1.Font = new Font("Futura Bk BT", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.linkLabel1.LinkColor = Color.Black;
            this.linkLabel1.Location = new Point(0x67, 0x15d);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new Size(0x7d, 14);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Si eres nuevo, registrate.";
            this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.LinkLabel_LinkClicked);
            this.BtnUISesion1.AutoSize = true;
            this.BtnUISesion1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BtnUISesion1.BackColor = SystemColors.ActiveCaptionText;
            this.BtnUISesion1.Location = new Point(0x6d, 0x11e);
            this.BtnUISesion1.Margin = new Padding(0);
            this.BtnUISesion1.Name = "BtnUISesion1";
            this.BtnUISesion1.Size = new Size(0x70, 40);
            this.BtnUISesion1.TabIndex = 0x26;
            this.panelSesionUI1.AutoSize = true;
            this.panelSesionUI1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.panelSesionUI1.Location = new Point(0, 0);
            this.panelSesionUI1.Margin = new Padding(0);
            this.panelSesionUI1.Name = "panelSesionUI1";
            this.panelSesionUI1.Size = new Size(330, 110);
            this.panelSesionUI1.TabIndex = 0x27;
            this.panelSesionUI1.Tipo = PanelSesionUI.PanelUITipo.Default;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = SystemColors.Window;
            base.ClientSize = new Size(0x149, 0x18b);
            base.Controls.Add(this.panelSesionUI1);
            base.Controls.Add(this.BtnUISesion1);
            base.Controls.Add(this.linkLabel1);
            base.Controls.Add(this.CampDni);
            base.Controls.Add(this.CampClave);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label4);
//            base.Icon = (Icon)manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.Name = "FormInicioSesion";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Inicio de Sesi\x00f3n";
            base.Load += new EventHandler(this.FormInicioSesion_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion

        private ButtonUI BtnUISesion1;
        private TextBox CampClave;
        private TextBox CampDni;
        private Label label3;
        private Label label4;
        private LinkLabel linkLabel1;
        private PanelSesionUI panelSesionUI1;
    }
}