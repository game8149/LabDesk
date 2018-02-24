using LabDesk.Code.Base;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Main.ManagementAccount
{
    partial class FormCrearCuenta
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FormCrearCuenta));
            this.label4 = new Label();
            this.label6 = new Label();
            this.CampClave = new TextBox();
            this.CampCodigo = new TextBox();
            this.label8 = new Label();
            this.CampEspecialidad = new TextBox();
            this.label9 = new Label();
            this.CampSegundoApellido = new TextBox();
            this.label11 = new Label();
            this.label14 = new Label();
            this.CampDni = new TextBox();
            this.CampNombre = new TextBox();
            this.CampPrimerApellido = new TextBox();
            this.label15 = new Label();
            this.label16 = new Label();
            this.CampAutorizacion = new TextBox();
            this.BtnUIUsuarioNuevo1 = new ButtonUI();
            this.BtnUIUsuarioNuevo2 = new ButtonUI();
            this.label12 = new Label();
            base.SuspendLayout();
            this.label4.AutoSize = true;
            this.label4.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label4.Location = new Point(0x1d, 0x159);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x51, 0x10);
            this.label4.TabIndex = 5;
            this.label4.Text = "Autorizaci\x00f3n:";
            this.label6.AutoSize = true;
            this.label6.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label6.Location = new Point(0x1d, 0x132);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x2c, 0x10);
            this.label6.TabIndex = 13;
            this.label6.Text = "Clave:";
            this.CampClave.BackColor = Color.White;
            this.CampClave.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampClave.Location = new Point(180, 0x130);
            this.CampClave.MaxLength = 0x10;
            this.CampClave.Name = "CampClave";
            this.CampClave.PasswordChar = '*';
            this.CampClave.Size = new Size(0xc0, 0x17);
            this.CampClave.TabIndex = 7;
            this.CampClave.UseSystemPasswordChar = true;
            this.CampCodigo.BackColor = Color.White;
            this.CampCodigo.Font = new Font("Futura Bk BT", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampCodigo.Location = new Point(180, 0x109);
            this.CampCodigo.Name = "CampCodigo";
            this.CampCodigo.Size = new Size(0xc0, 0x16);
            this.CampCodigo.TabIndex = 6;
            this.label8.AutoSize = true;
            this.label8.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label8.Location = new Point(0x1d, 0x10b);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x76, 0x10);
            this.label8.TabIndex = 0x4e;
            this.label8.Text = "Codigo Profesional:";
            this.CampEspecialidad.BackColor = Color.White;
            this.CampEspecialidad.Font = new Font("Futura Bk BT", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampEspecialidad.Location = new Point(180, 0xe2);
            this.CampEspecialidad.Name = "CampEspecialidad";
            this.CampEspecialidad.Size = new Size(0xc0, 0x16);
            this.CampEspecialidad.TabIndex = 5;
            this.label9.AutoSize = true;
            this.label9.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label9.Location = new Point(0x1d, 0xe4);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x40, 0x10);
            this.label9.TabIndex = 0x4c;
            this.label9.Text = "Profesion:";
            this.CampSegundoApellido.BackColor = Color.White;
            this.CampSegundoApellido.Font = new Font("Futura Bk BT", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampSegundoApellido.Location = new Point(180, 0xbb);
            this.CampSegundoApellido.Name = "CampSegundoApellido";
            this.CampSegundoApellido.Size = new Size(0xc0, 0x16);
            this.CampSegundoApellido.TabIndex = 4;
            this.label11.AutoSize = true;
            this.label11.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label11.Location = new Point(0x1d, 0xbd);
            this.label11.Name = "label11";
            this.label11.Size = new Size(110, 0x10);
            this.label11.TabIndex = 0x49;
            this.label11.Text = "Segundo Apellido:";
            this.label14.AutoSize = true;
            this.label14.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label14.Location = new Point(0x1d, 0x6f);
            this.label14.Name = "label14";
            this.label14.Size = new Size(0x3b, 0x10);
            this.label14.TabIndex = 0x41;
            this.label14.Text = "Nombre:";
            this.CampDni.BackColor = Color.White;
            this.CampDni.Font = new Font("Futura Bk BT", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampDni.Location = new Point(180, 70);
            this.CampDni.MaxLength = 8;
            this.CampDni.Name = "CampDni";
            this.CampDni.Size = new Size(0xc0, 0x16);
            this.CampDni.TabIndex = 1;
            this.CampNombre.BackColor = Color.White;
            this.CampNombre.Font = new Font("Futura Bk BT", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampNombre.Location = new Point(180, 0x6d);
            this.CampNombre.Name = "CampNombre";
            this.CampNombre.Size = new Size(0xc0, 0x16);
            this.CampNombre.TabIndex = 2;
            this.CampPrimerApellido.BackColor = Color.White;
            this.CampPrimerApellido.Font = new Font("Futura Bk BT", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampPrimerApellido.Location = new Point(180, 0x94);
            this.CampPrimerApellido.Name = "CampPrimerApellido";
            this.CampPrimerApellido.Size = new Size(0xc0, 0x16);
            this.CampPrimerApellido.TabIndex = 3;
            this.label15.AutoSize = true;
            this.label15.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label15.Location = new Point(0x1d, 150);
            this.label15.Name = "label15";
            this.label15.Size = new Size(0x63, 0x10);
            this.label15.TabIndex = 0x44;
            this.label15.Text = "Primer Apellido:";
            this.label16.AutoSize = true;
            this.label16.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label16.Location = new Point(0x1d, 0x48);
            this.label16.Name = "label16";
            this.label16.Size = new Size(0x22, 0x10);
            this.label16.TabIndex = 70;
            this.label16.Text = "DNI:";
            this.CampAutorizacion.BackColor = Color.White;
            this.CampAutorizacion.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampAutorizacion.Location = new Point(180, 0x157);
            this.CampAutorizacion.MaxLength = 5;
            this.CampAutorizacion.Name = "CampAutorizacion";
            this.CampAutorizacion.PasswordChar = '+';
            this.CampAutorizacion.Size = new Size(0xc0, 0x17);
            this.CampAutorizacion.TabIndex = 8;
            this.CampAutorizacion.UseSystemPasswordChar = true;
            this.BtnUIUsuarioNuevo1.AutoSize = true;
            this.BtnUIUsuarioNuevo1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BtnUIUsuarioNuevo1.BackColor = SystemColors.ActiveCaptionText;
            this.BtnUIUsuarioNuevo1.Location = new Point(260, 0x195);
            this.BtnUIUsuarioNuevo1.Margin = new Padding(0);
            this.BtnUIUsuarioNuevo1.Name = "BtnUIUsuarioNuevo1";
            this.BtnUIUsuarioNuevo1.Size = new Size(0x70, 40);
            this.BtnUIUsuarioNuevo1.TabIndex = 0x54;
            this.BtnUIUsuarioNuevo2.AutoSize = true;
            this.BtnUIUsuarioNuevo2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BtnUIUsuarioNuevo2.BackColor = SystemColors.ActiveCaptionText;
            this.BtnUIUsuarioNuevo2.Location = new Point(0x80, 0x195);
            this.BtnUIUsuarioNuevo2.Margin = new Padding(0);
            this.BtnUIUsuarioNuevo2.Name = "BtnUIUsuarioNuevo2";
            this.BtnUIUsuarioNuevo2.Size = new Size(0x70, 40);
            this.BtnUIUsuarioNuevo2.TabIndex = 0x56;
            this.label12.AutoSize = true;
            this.label12.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label12.Location = new Point(0x1c, 0x1d);
            this.label12.Name = "label12";
            this.label12.Size = new Size(0x9f, 0x13);
            this.label12.TabIndex = 0x57;
            this.label12.Text = "Informaci\x00f3n Personal";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.ClientSize = new Size(0x18e, 0x1d7);
            base.Controls.Add(this.label12);
            base.Controls.Add(this.BtnUIUsuarioNuevo2);
            base.Controls.Add(this.BtnUIUsuarioNuevo1);
            base.Controls.Add(this.CampCodigo);
            base.Controls.Add(this.label8);
            base.Controls.Add(this.CampEspecialidad);
            base.Controls.Add(this.label9);
            base.Controls.Add(this.CampSegundoApellido);
            base.Controls.Add(this.label11);
            base.Controls.Add(this.label14);
            base.Controls.Add(this.CampDni);
            base.Controls.Add(this.CampNombre);
            base.Controls.Add(this.CampPrimerApellido);
            base.Controls.Add(this.label15);
            base.Controls.Add(this.label16);
            base.Controls.Add(this.CampClave);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.label6);
            base.Controls.Add(this.CampAutorizacion);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            //            base.Icon = (Icon)manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.Name = "FormCrearCuenta";
            this.RightToLeftLayout = true;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Nuevo Usuario";
            base.ResumeLayout(false);
            base.PerformLayout();
        }
        #endregion


        private ButtonUI BtnUIUsuarioNuevo1;
        private ButtonUI BtnUIUsuarioNuevo2;
        private TextBox CampAutorizacion;
        private TextBox CampClave;
        private TextBox CampCodigo;
        private TextBox CampDni;
        private TextBox CampEspecialidad;
        private TextBox CampNombre;
        private TextBox CampPrimerApellido;
        private TextBox CampSegundoApellido;
        private Label label11;
        private Label label12;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label4;
        private Label label6;
        private Label label8;
        private Label label9;
    }
}