using LabDesk.Code.Base;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Main.ManagementAccount
{
    partial class FormModificarCuenta
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FormModificarCuenta));
            this.label1 = new Label();
            this.label2 = new Label();
            this.CampDni = new TextBox();
            this.label3 = new Label();
            this.CampPrimerApellido = new TextBox();
            this.CampNombre = new TextBox();
            this.CampSegundoApellido = new TextBox();
            this.label5 = new Label();
            this.label4 = new Label();
            this.CampEspecialidad = new TextBox();
            this.label6 = new Label();
            this.CampCodigo = new TextBox();
            this.label7 = new Label();
            this.BtnUIUsuarioDatos1 = new ButtonUI();
            this.BtnUIUsuarioDatos2 = new ButtonUI();
            this.label12 = new Label();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.Location = new Point(0x1d, 0x7d);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x3b, 0x10);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre:";
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.Location = new Point(0x1d, 0xa5);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x63, 0x10);
            this.label2.TabIndex = 3;
            this.label2.Text = "Primer Apellido:";
            this.CampDni.Font = new Font("Futura Bk BT", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampDni.Location = new Point(0xb5, 0x51);
            this.CampDni.MaxLength = 8;
            this.CampDni.Name = "CampDni";
            this.CampDni.Size = new Size(0xd0, 0x16);
            this.CampDni.TabIndex = 1;
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label3.Location = new Point(0x1d, 0x55);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x22, 0x10);
            this.label3.TabIndex = 15;
            this.label3.Text = "DNI:";
            this.CampPrimerApellido.Font = new Font("Futura Bk BT", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampPrimerApellido.Location = new Point(0xb5, 0xa1);
            this.CampPrimerApellido.Name = "CampPrimerApellido";
            this.CampPrimerApellido.Size = new Size(0xd0, 0x16);
            this.CampPrimerApellido.TabIndex = 3;
            this.CampNombre.Font = new Font("Futura Bk BT", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampNombre.Location = new Point(0xb5, 0x79);
            this.CampNombre.Name = "CampNombre";
            this.CampNombre.Size = new Size(0xd0, 0x16);
            this.CampNombre.TabIndex = 2;
            this.CampSegundoApellido.Font = new Font("Futura Bk BT", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampSegundoApellido.Location = new Point(0xb5, 200);
            this.CampSegundoApellido.Name = "CampSegundoApellido";
            this.CampSegundoApellido.Size = new Size(0xd0, 0x16);
            this.CampSegundoApellido.TabIndex = 4;
            this.label5.AutoSize = true;
            this.label5.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label5.Location = new Point(0x1d, 0xcc);
            this.label5.Name = "label5";
            this.label5.Size = new Size(110, 0x10);
            this.label5.TabIndex = 0x3a;
            this.label5.Text = "Segundo Apellido:";
            this.label4.AutoSize = true;
            this.label4.Font = new Font("Futura Bk BT", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label4.Location = new Point(30, 0x14e);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x128, 15);
            this.label4.TabIndex = 0x3b;
            this.label4.Text = "Nota: Ten en cuenta que tu DNI sera tu ID de usuario";
            this.CampEspecialidad.Font = new Font("Futura Bk BT", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampEspecialidad.Location = new Point(0xb5, 0xf1);
            this.CampEspecialidad.Name = "CampEspecialidad";
            this.CampEspecialidad.Size = new Size(0xd0, 0x16);
            this.CampEspecialidad.TabIndex = 5;
            this.label6.AutoSize = true;
            this.label6.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label6.Location = new Point(0x1d, 0xf5);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x40, 0x10);
            this.label6.TabIndex = 0x3d;
            this.label6.Text = "Profesion:";
            this.CampCodigo.Font = new Font("Futura Bk BT", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampCodigo.Location = new Point(0xb5, 0x117);
            this.CampCodigo.Name = "CampCodigo";
            this.CampCodigo.Size = new Size(0xd0, 0x16);
            this.CampCodigo.TabIndex = 6;
            this.label7.AutoSize = true;
            this.label7.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label7.Location = new Point(0x1d, 0x11b);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x34, 0x10);
            this.label7.TabIndex = 0x3f;
            this.label7.Text = "Codigo:";
            this.BtnUIUsuarioDatos1.AutoSize = true;
            this.BtnUIUsuarioDatos1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BtnUIUsuarioDatos1.BackColor = SystemColors.ActiveCaptionText;
            this.BtnUIUsuarioDatos1.Location = new Point(0x115, 380);
            this.BtnUIUsuarioDatos1.Margin = new Padding(0);
            this.BtnUIUsuarioDatos1.Name = "BtnUIUsuarioDatos1";
            this.BtnUIUsuarioDatos1.Size = new Size(0x70, 40);
            this.BtnUIUsuarioDatos1.TabIndex = 7;
            this.BtnUIUsuarioDatos1.Load += new EventHandler(this.BtnUIUsuarioDatos1_Load);
            this.BtnUIUsuarioDatos2.AutoSize = true;
            this.BtnUIUsuarioDatos2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BtnUIUsuarioDatos2.BackColor = SystemColors.ActiveCaptionText;
            this.BtnUIUsuarioDatos2.Location = new Point(0x85, 380);
            this.BtnUIUsuarioDatos2.Margin = new Padding(0);
            this.BtnUIUsuarioDatos2.Name = "BtnUIUsuarioDatos2";
            this.BtnUIUsuarioDatos2.Size = new Size(0x70, 40);
            this.BtnUIUsuarioDatos2.TabIndex = 8;
            this.label12.AutoSize = true;
            this.label12.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label12.Location = new Point(0x1c, 0x22);
            this.label12.Name = "label12";
            this.label12.Size = new Size(0x9f, 0x13);
            this.label12.TabIndex = 0x58;
            this.label12.Text = "Informaci\x00f3n Personal";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = SystemColors.Window;
            base.ClientSize = new Size(0x1a8, 0x1be);
            base.Controls.Add(this.label12);
            base.Controls.Add(this.BtnUIUsuarioDatos2);
            base.Controls.Add(this.BtnUIUsuarioDatos1);
            base.Controls.Add(this.CampCodigo);
            base.Controls.Add(this.label7);
            base.Controls.Add(this.CampEspecialidad);
            base.Controls.Add(this.label6);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.CampSegundoApellido);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.CampDni);
            base.Controls.Add(this.CampNombre);
            base.Controls.Add(this.CampPrimerApellido);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label3);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
//            base.Icon = (Icon)manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.Name = "FormModificarCuenta";
            this.RightToLeftLayout = true;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Actualizar Datos";
            base.Load += new EventHandler(this.FormModificarCuenta_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion

        private ButtonUI BtnUIUsuarioDatos1;
        private ButtonUI BtnUIUsuarioDatos2;
        private TextBox CampCodigo;
        private TextBox CampDni;
        private TextBox CampEspecialidad;
        private TextBox CampNombre;
        private TextBox CampPrimerApellido;
        private TextBox CampSegundoApellido;
        private Label label1;
        private Label label12;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;

    }
}