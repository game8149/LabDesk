
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Main.ManagementAccount
{
    partial class FormAutorizacion
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
            this.CampClave = new TextBox();
            this.label3 = new Label();
            this.CampDni = new TextBox();
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
            this.BtnInicia.Location = new Point(0xe9, 0xc1);
            this.BtnInicia.Margin = new Padding(3, 4, 3, 4);
            this.BtnInicia.Name = "BtnInicia";
            this.BtnInicia.Size = new Size(0x76, 0x27);
            this.BtnInicia.TabIndex = 3;
            this.BtnInicia.Text = "Verificar";
            this.BtnInicia.UseVisualStyleBackColor = false;
            this.BtnInicia.Click += new EventHandler(this.BtnInicia_Click);
            this.CampClave.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampClave.Location = new Point(170, 0x76);
            this.CampClave.Margin = new Padding(3, 4, 3, 4);
            this.CampClave.MaxLength = 8;
            this.CampClave.Name = "CampClave";
            this.CampClave.PasswordChar = '+';
            this.CampClave.Size = new Size(0xb5, 0x17);
            this.CampClave.TabIndex = 2;
            this.CampClave.TextAlign = HorizontalAlignment.Center;
            this.CampClave.UseSystemPasswordChar = true;
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label3.Location = new Point(0x16, 0x79);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x51, 0x10);
            this.label3.TabIndex = 0x22;
            this.label3.Text = "Autorizaci\x00f3n:";
            this.CampDni.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampDni.Location = new Point(170, 0x4e);
            this.CampDni.Margin = new Padding(3, 4, 3, 4);
            this.CampDni.MaxLength = 8;
            this.CampDni.Name = "CampDni";
            this.CampDni.Size = new Size(0xb5, 0x17);
            this.CampDni.TabIndex = 1;
            this.CampDni.TextAlign = HorizontalAlignment.Center;
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.Location = new Point(0x16, 0x51);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x22, 0x10);
            this.label1.TabIndex = 0x24;
            this.label1.Text = "DNI:";
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.Location = new Point(0x15, 0x19);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0xd9, 0x13);
            this.label2.TabIndex = 0x25;
            this.label2.Text = "Verificacion de Administrador";
            base.AutoScaleDimensions = new SizeF(7f, 16f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = SystemColors.Window;
            base.ClientSize = new Size(0x17b, 260);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.CampDni);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.BtnInicia);
            base.Controls.Add(this.CampClave);
            base.Controls.Add(this.label3);
            this.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            base.Margin = new Padding(3, 4, 3, 4);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FormAutorizacion";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Autorizaci\x00f3n";
            base.Load += new EventHandler(this.FormAutorizacion_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion

        private Button BtnInicia;
        private TextBox CampClave;
        private TextBox CampDni;
        private Label label1;
        private Label label2;
        private Label label3;

    }
}