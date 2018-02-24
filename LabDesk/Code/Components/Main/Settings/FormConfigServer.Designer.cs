using System;
using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Main.Settings
{
    partial class FormConfigServer
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
            this.BtnInicia = new Button();
            this.CampConexion = new TextBox();
            this.label1 = new Label();
            this.label2 = new Label();
            base.SuspendLayout();
            this.BtnInicia.BackColor = Color.DodgerBlue;
            this.BtnInicia.FlatAppearance.BorderColor = Color.Teal;
            this.BtnInicia.FlatAppearance.CheckedBackColor = Color.DeepSkyBlue;
            this.BtnInicia.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
            this.BtnInicia.FlatAppearance.MouseOverBackColor = Color.DeepSkyBlue;
            this.BtnInicia.FlatStyle = FlatStyle.Flat;
            this.BtnInicia.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.BtnInicia.ForeColor = SystemColors.Info;
            this.BtnInicia.Location = new Point(230, 0xdf);
            this.BtnInicia.Margin = new Padding(3, 4, 3, 4);
            this.BtnInicia.Name = "BtnInicia";
            this.BtnInicia.Size = new Size(0x6d, 0x24);
            this.BtnInicia.TabIndex = 3;
            this.BtnInicia.Text = "Conectar";
            this.BtnInicia.UseVisualStyleBackColor = false;
            this.BtnInicia.Click += new EventHandler(this.BtnInicia_Click);
            this.CampConexion.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampConexion.Location = new Point(0x20, 0x62);
            this.CampConexion.Margin = new Padding(3, 4, 3, 4);
            this.CampConexion.MaxLength = 300;
            this.CampConexion.Multiline = true;
            this.CampConexion.Name = "CampConexion";
            this.CampConexion.Size = new Size(0x133, 0x67);
            this.CampConexion.TabIndex = 1;
            this.CampConexion.TextAlign = HorizontalAlignment.Center;
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.Location = new Point(0x1d, 0x43);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x3b, 0x10);
            this.label1.TabIndex = 0x24;
            this.label1.Text = "Servidor:";
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.Location = new Point(0x1c, 0x1a);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0xcc, 0x13);
            this.label2.TabIndex = 0x25;
            this.label2.Text = "Configuracion de Conexion";
            base.AutoScaleDimensions = new SizeF(7f, 16f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = SystemColors.Window;
            base.ClientSize = new Size(0x176, 0x11f);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.CampConexion);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.BtnInicia);
            this.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            base.Margin = new Padding(3, 4, 3, 4);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FormConfigServer";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Autorizaci\x00f3n";
            base.Load += new EventHandler(this.FormAutorizacion_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion




        private System.Windows.Forms.Button BtnInicia;
        private System.Windows.Forms.TextBox CampConexion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}