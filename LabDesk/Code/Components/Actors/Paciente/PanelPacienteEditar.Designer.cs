﻿
using LabDesk.Code.Base;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Actors.Paciente
{
    partial class PanelPacienteEditar
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(PanelPacienteEditar));
            this.label8 = new Label();
            this.ComboBoxSector = new ComboBox();
            this.ComboBoxDistrito = new ComboBox();
            this.label7 = new Label();
            this.label12 = new Label();
            this.CampFecha = new DateTimePicker();
            this.label10 = new Label();
            this.CampHistoria = new TextBox();
            this.label9 = new Label();
            this.CampDNI = new TextBox();
            this.ComboSexo = new ComboBox();
            this.label6 = new Label();
            this.label2 = new Label();
            this.CampDireccion = new TextBox();
            this.label4 = new Label();
            this.label5 = new Label();
            this.label3 = new Label();
            this.CampNombre = new TextBox();
            this.label11 = new Label();
            this.Campapellido2erno = new TextBox();
            this.Campapellido1erno = new TextBox();
            this.label1 = new Label();
            this.label13 = new Label();
            this.panel1 = new Panel();
            this.BtnPerfilEditarGuardar = new Button();
            this.BtnPerfilEditarCerrar = new Button();
            this.BtnUIPacienteEditar3 = new ButtonUI();
            this.label14 = new Label();
            this.label15 = new Label();
            this.label16 = new Label();
            this.label17 = new Label();
            this.label19 = new Label();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.label8.AutoSize = true;
            this.label8.Font = new Font("Futura Bk BT", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label8.Location = new Point(0x16b, 0x166);
            this.label8.Name = "label8";
            this.label8.Size = new Size(12, 15);
            this.label8.TabIndex = 170;
            this.label8.Text = "/";
            this.ComboBoxSector.Cursor = Cursors.Hand;
            this.ComboBoxSector.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ComboBoxSector.Font = new Font("Futura Bk BT", 9.75f);
            this.ComboBoxSector.FormattingEnabled = true;
            this.ComboBoxSector.Location = new Point(0x179, 0x161);
            this.ComboBoxSector.Name = "ComboBoxSector";
            this.ComboBoxSector.Size = new Size(0xb1, 0x18);
            this.ComboBoxSector.TabIndex = 0xa9;
            this.ComboBoxDistrito.Cursor = Cursors.Hand;
            this.ComboBoxDistrito.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ComboBoxDistrito.Font = new Font("Futura Bk BT", 9.75f);
            this.ComboBoxDistrito.FormattingEnabled = true;
            this.ComboBoxDistrito.Location = new Point(180, 0x161);
            this.ComboBoxDistrito.Name = "ComboBoxDistrito";
            this.ComboBoxDistrito.Size = new Size(0xb1, 0x18);
            this.ComboBoxDistrito.TabIndex = 0xa7;
            this.label7.AutoSize = true;
            this.label7.Font = new Font("Futura Bk BT", 9.75f);
            this.label7.Location = new Point(0x1d, 0x164);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x66, 0x10);
            this.label7.TabIndex = 0xa8;
            this.label7.Text = "Distrito / Sector :";
            this.label12.AutoSize = true;
            this.label12.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label12.Location = new Point(0x1c, 0x1c);
            this.label12.Name = "label12";
            this.label12.Size = new Size(0x9f, 0x13);
            this.label12.TabIndex = 0xa5;
            this.label12.Text = "Informaci\x00f3n Personal";
            this.CampFecha.Font = new Font("Futura Bk BT", 9.75f);
            this.CampFecha.Format = DateTimePickerFormat.Short;
            this.CampFecha.Location = new Point(180, 0x10f);
            this.CampFecha.Name = "CampFecha";
            this.CampFecha.RightToLeftLayout = true;
            this.CampFecha.Size = new Size(0xb1, 0x17);
            this.CampFecha.TabIndex = 0x99;
            this.label10.AutoSize = true;
            this.label10.Font = new Font("Futura Bk BT", 9.75f);
            this.label10.Location = new Point(0x1d, 0x74);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x60, 0x10);
            this.label10.TabIndex = 0xa4;
            this.label10.Text = "Historia Clinica:";
            this.CampHistoria.Font = new Font("Futura Bk BT", 9.75f);
            this.CampHistoria.Location = new Point(180, 0x71);
            this.CampHistoria.MaxLength = 15;
            this.CampHistoria.Name = "CampHistoria";
            this.CampHistoria.Size = new Size(0xb1, 0x17);
            this.CampHistoria.TabIndex = 0x95;
            this.CampHistoria.TextChanged += new EventHandler(this.CampHistoria_TextChanged);
            this.label9.AutoSize = true;
            this.label9.Font = new Font("Futura Bk BT", 9.75f);
            this.label9.Location = new Point(0x1d, 0x4c);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x22, 0x10);
            this.label9.TabIndex = 0xa3;
            this.label9.Text = "DNI:";
            this.CampDNI.Font = new Font("Futura Bk BT", 9.75f);
            this.CampDNI.Location = new Point(180, 0x49);
            this.CampDNI.MaxLength = 8;
            this.CampDNI.Name = "CampDNI";
            this.CampDNI.Size = new Size(0xb1, 0x17);
            this.CampDNI.TabIndex = 0x94;
            this.ComboSexo.BackColor = SystemColors.Window;
            this.ComboSexo.Cursor = Cursors.Hand;
            this.ComboSexo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ComboSexo.Font = new Font("Futura Bk BT", 9.75f);
            this.ComboSexo.FormattingEnabled = true;
            this.ComboSexo.Location = new Point(180, 0x139);
            this.ComboSexo.Name = "ComboSexo";
            this.ComboSexo.Size = new Size(0xb1, 0x18);
            this.ComboSexo.TabIndex = 0x9a;
            this.label6.AutoSize = true;
            this.label6.Font = new Font("Futura Bk BT", 9.75f);
            this.label6.Location = new Point(0x1d, 0x18c);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x41, 0x10);
            this.label6.TabIndex = 0xa2;
            this.label6.Text = "Direccion:";
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Futura Bk BT", 9.75f);
            this.label2.Location = new Point(0x1d, 0x9c);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x3b, 0x10);
            this.label2.TabIndex = 0x9d;
            this.label2.Text = "Nombre:";
            this.CampDireccion.Font = new Font("Futura Bk BT", 9.75f);
            this.CampDireccion.Location = new Point(180, 0x189);
            this.CampDireccion.MaxLength = 100;
            this.CampDireccion.Name = "CampDireccion";
            this.CampDireccion.Size = new Size(0x176, 0x17);
            this.CampDireccion.TabIndex = 0x9b;
            this.label4.AutoSize = true;
            this.label4.Font = new Font("Futura Bk BT", 9.75f);
            this.label4.Location = new Point(0x1d, 0x114);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x84, 0x10);
            this.label4.TabIndex = 160;
            this.label4.Text = "Fecha de Nacimiento:";
            this.label5.AutoSize = true;
            this.label5.Font = new Font("Futura Bk BT", 9.75f);
            this.label5.Location = new Point(0x1d, 0x13c);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x27, 0x10);
            this.label5.TabIndex = 0xa1;
            this.label5.Text = "Sexo:";
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Futura Bk BT", 9.75f);
            this.label3.Location = new Point(0x1d, 0xec);
            this.label3.Name = "label3";
            this.label3.Size = new Size(110, 0x10);
            this.label3.TabIndex = 0x9f;
            this.label3.Text = "Segundo Apellido:";
            this.CampNombre.Font = new Font("Futura Bk BT", 9.75f);
            this.CampNombre.Location = new Point(180, 0x99);
            this.CampNombre.MaxLength = 100;
            this.CampNombre.Name = "CampNombre";
            this.CampNombre.Size = new Size(0x176, 0x17);
            this.CampNombre.TabIndex = 150;
            this.label11.AutoSize = true;
            this.label11.Font = new Font("Futura Bk BT", 9.75f);
            this.label11.Location = new Point(0x1d, 0xc4);
            this.label11.Name = "label11";
            this.label11.Size = new Size(0x63, 0x10);
            this.label11.TabIndex = 0x9e;
            this.label11.Text = "Primer Apellido:";
            this.Campapellido2erno.Font = new Font("Futura Bk BT", 9.75f);
            this.Campapellido2erno.Location = new Point(180, 0xe9);
            this.Campapellido2erno.MaxLength = 100;
            this.Campapellido2erno.Name = "Campapellido2erno";
            this.Campapellido2erno.Size = new Size(0x176, 0x17);
            this.Campapellido2erno.TabIndex = 0x98;
            this.Campapellido1erno.Font = new Font("Futura Bk BT", 9.75f);
            this.Campapellido1erno.Location = new Point(180, 0xc1);
            this.Campapellido1erno.MaxLength = 100;
            this.Campapellido1erno.Name = "Campapellido1erno";
            this.Campapellido1erno.Size = new Size(0x176, 0x17);
            this.Campapellido1erno.TabIndex = 0x97;
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.Location = new Point(0x13, 0x13);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0xac, 0x13);
            this.label1.TabIndex = 0x7b;
            this.label1.Text = "Indicaciones Generales";
            this.label13.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.label13.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label13.Location = new Point(0x13, 50);
            this.label13.Name = "label13";
            this.label13.Size = new Size(0xcd, 0x13e);
            this.label13.TabIndex = 0x7c;
//            this.label13.Text = manager.GetString("label13.Text");
            this.panel1.Anchor = AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
            this.panel1.BorderStyle = BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new Point(0x323, 0x49);
            this.panel1.Margin = new Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0xf2, 0x1be);
            this.panel1.TabIndex = 0xa6;
            this.BtnPerfilEditarGuardar.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.BtnPerfilEditarGuardar.AutoSize = true;
            this.BtnPerfilEditarGuardar.FlatAppearance.BorderSize = 0;
            this.BtnPerfilEditarGuardar.FlatStyle = FlatStyle.Flat;
            //this.BtnPerfilEditarGuardar.Image = Resources.icon_guardar;
            this.BtnPerfilEditarGuardar.Location = new Point(0x3f5, 11);
            this.BtnPerfilEditarGuardar.Margin = new Padding(3, 4, 3, 4);
            this.BtnPerfilEditarGuardar.Name = "BtnPerfilEditarGuardar";
            this.BtnPerfilEditarGuardar.Size = new Size(0x16, 0x16);
            this.BtnPerfilEditarGuardar.TabIndex = 0xac;
            this.BtnPerfilEditarGuardar.UseVisualStyleBackColor = true;
            this.BtnPerfilEditarGuardar.Click += new EventHandler(this.BtnPerfilEditarGuardar_Click);
            this.BtnPerfilEditarCerrar.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.BtnPerfilEditarCerrar.FlatAppearance.BorderColor = Color.DimGray;
            this.BtnPerfilEditarCerrar.FlatAppearance.BorderSize = 0;
            this.BtnPerfilEditarCerrar.FlatStyle = FlatStyle.Flat;
            this.BtnPerfilEditarCerrar.Font = new Font("Futura Bk BT", 8.25f);
            this.BtnPerfilEditarCerrar.ForeColor = SystemColors.Window;
            //this.BtnPerfilEditarCerrar.Image = Resources.icon_cerrar;
            this.BtnPerfilEditarCerrar.Location = new Point(0x412, 12);
            this.BtnPerfilEditarCerrar.Margin = new Padding(0);
            this.BtnPerfilEditarCerrar.Name = "BtnPerfilEditarCerrar";
            this.BtnPerfilEditarCerrar.Padding = new Padding(5);
            this.BtnPerfilEditarCerrar.Size = new Size(20, 20);
            this.BtnPerfilEditarCerrar.TabIndex = 0xab;
            this.BtnPerfilEditarCerrar.TextAlign = ContentAlignment.MiddleLeft;
            this.BtnPerfilEditarCerrar.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.BtnPerfilEditarCerrar.UseVisualStyleBackColor = false;
            this.BtnPerfilEditarCerrar.Click += new EventHandler(this.BtnPerfilEditarCerrar_Click);
            this.BtnUIPacienteEditar3.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.BtnUIPacienteEditar3.BackColor = SystemColors.ActiveCaptionText;
            this.BtnUIPacienteEditar3.Location = new Point(0x20, 0x1e7);
            this.BtnUIPacienteEditar3.Margin = new Padding(0);
            this.BtnUIPacienteEditar3.Name = "BtnUIPacienteEditar3";
            this.BtnUIPacienteEditar3.Size = new Size(0x70, 40);
            this.BtnUIPacienteEditar3.TabIndex = 0;
            this.label14.AutoSize = true;
            this.label14.BackColor = Color.Transparent;
            this.label14.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label14.ForeColor = SystemColors.GrayText;
            this.label14.Location = new Point(0x16b, 0x4a);
            this.label14.Name = "label14";
            this.label14.Size = new Size(0x1a, 0x13);
            this.label14.TabIndex = 0xad;
            this.label14.Text = "(*)";
            this.label15.AutoSize = true;
            this.label15.BackColor = Color.Transparent;
            this.label15.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label15.ForeColor = SystemColors.GrayText;
            this.label15.Location = new Point(0x16b, 0x72);
            this.label15.Name = "label15";
            this.label15.Size = new Size(0x1a, 0x13);
            this.label15.TabIndex = 0xae;
            this.label15.Text = "(*)";
            this.label16.AutoSize = true;
            this.label16.BackColor = Color.Transparent;
            this.label16.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label16.ForeColor = SystemColors.GrayText;
            this.label16.Location = new Point(560, 0xc2);
            this.label16.Name = "label16";
            this.label16.Size = new Size(0x1a, 0x13);
            this.label16.TabIndex = 0xb0;
            this.label16.Text = "(*)";
            this.label17.AutoSize = true;
            this.label17.BackColor = Color.Transparent;
            this.label17.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label17.ForeColor = SystemColors.GrayText;
            this.label17.Location = new Point(560, 0x9a);
            this.label17.Name = "label17";
            this.label17.Size = new Size(0x1a, 0x13);
            this.label17.TabIndex = 0xaf;
            this.label17.Text = "(*)";
            this.label19.AutoSize = true;
            this.label19.BackColor = Color.Transparent;
            this.label19.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label19.ForeColor = SystemColors.GrayText;
            this.label19.Location = new Point(560, 0xea);
            this.label19.Name = "label19";
            this.label19.Size = new Size(0x1a, 0x13);
            this.label19.TabIndex = 0xb1;
            this.label19.Text = "(*)";
            base.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.White;
            base.Controls.Add(this.label19);
            base.Controls.Add(this.label16);
            base.Controls.Add(this.label17);
            base.Controls.Add(this.label15);
            base.Controls.Add(this.label14);
            base.Controls.Add(this.BtnPerfilEditarGuardar);
            base.Controls.Add(this.BtnPerfilEditarCerrar);
            base.Controls.Add(this.BtnUIPacienteEditar3);
            base.Controls.Add(this.label8);
            base.Controls.Add(this.ComboBoxSector);
            base.Controls.Add(this.ComboBoxDistrito);
            base.Controls.Add(this.label7);
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.label12);
            base.Controls.Add(this.CampFecha);
            base.Controls.Add(this.label10);
            base.Controls.Add(this.CampHistoria);
            base.Controls.Add(this.label9);
            base.Controls.Add(this.CampDNI);
            base.Controls.Add(this.ComboSexo);
            base.Controls.Add(this.label6);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.CampDireccion);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.CampNombre);
            base.Controls.Add(this.label11);
            base.Controls.Add(this.Campapellido2erno);
            base.Controls.Add(this.Campapellido1erno);
            base.Name = "PanelPacienteEditar";
            base.Size = new Size(0x435, 0x228);
            base.Load += new EventHandler(this.PanelPacienteEditar_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }


        #endregion
        private Button BtnPerfilEditarCerrar;
        private Button BtnPerfilEditarGuardar;
        private ButtonUI BtnUIPacienteEditar3;
        private TextBox Campapellido1erno;
        private TextBox Campapellido2erno;
        private TextBox CampDireccion;
        private TextBox CampDNI;
        private DateTimePicker CampFecha;
        private TextBox CampHistoria;
        private TextBox CampNombre;
        private ComboBox ComboBoxDistrito;
        private ComboBox ComboBoxSector;
        private ComboBox ComboSexo;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label19;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Panel panel1;

    }
}
