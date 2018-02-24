
using LabDesk.Code.Base;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Actors.Paciente
{
    partial class FormBuscarPaciente
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
            this.label10 = new Label();
            this.CampHistoria = new TextBox();
            this.label9 = new Label();
            this.CampDni = new TextBox();
            this.label1 = new Label();
            this.label3 = new Label();
            this.CampNombre = new TextBox();
            this.label2 = new Label();
            this.Campapellido2erno = new TextBox();
            this.Campapellido1erno = new TextBox();
            this.DGVPaciente = new DataGridView();
            this.Id = new DataGridViewTextBoxColumn();
            this.Dni = new DataGridViewTextBoxColumn();
            this.Historia = new DataGridViewTextBoxColumn();
            this.Nombre = new DataGridViewTextBoxColumn();
            this.ApellidoP = new DataGridViewTextBoxColumn();
            this.ApellidoM = new DataGridViewTextBoxColumn();
            this.groupBox1 = new GroupBox();
            this.label11 = new Label();
            this.BtnUIPacienteBuscar1 = new ButtonUI();
            this.BtnUIPacienteBuscar2 = new ButtonUI();
            ((ISupportInitialize)this.DGVPaciente).BeginInit();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.label10.AutoSize = true;
            this.label10.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label10.Location = new Point(0x166, 130);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x60, 0x10);
            this.label10.TabIndex = 0x12;
            this.label10.Text = "Historia Clinica:";
            this.CampHistoria.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampHistoria.Location = new Point(0x1ee, 0x7e);
            this.CampHistoria.MaxLength = 15;
            this.CampHistoria.Name = "CampHistoria";
            this.CampHistoria.Size = new Size(0xa9, 0x17);
            this.CampHistoria.TabIndex = 5;
            this.label9.AutoSize = true;
            this.label9.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label9.Location = new Point(14, 130);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x22, 0x10);
            this.label9.TabIndex = 15;
            this.label9.Text = "DNI:";
            this.CampDni.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampDni.Location = new Point(150, 0x7e);
            this.CampDni.MaxLength = 8;
            this.CampDni.Name = "CampDni";
            this.CampDni.Size = new Size(0xa9, 0x17);
            this.CampDni.TabIndex = 4;
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.Location = new Point(14, 0x40);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x3b, 0x10);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label3.Location = new Point(0x166, 0x61);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x6c, 0x10);
            this.label3.TabIndex = 2;
            this.label3.Text = "Apellido Materno:";
            this.CampNombre.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampNombre.Location = new Point(150, 60);
            this.CampNombre.MaxLength = 0x63;
            this.CampNombre.Name = "CampNombre";
            this.CampNombre.Size = new Size(0xa9, 0x17);
            this.CampNombre.TabIndex = 1;
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.Location = new Point(14, 0x61);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x68, 0x10);
            this.label2.TabIndex = 1;
            this.label2.Text = "Apellido Paterno:";
            this.Campapellido2erno.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Campapellido2erno.Location = new Point(0x1ee, 0x5d);
            this.Campapellido2erno.MaxLength = 0x63;
            this.Campapellido2erno.Name = "Campapellido2erno";
            this.Campapellido2erno.Size = new Size(0xa9, 0x17);
            this.Campapellido2erno.TabIndex = 3;
            this.Campapellido1erno.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Campapellido1erno.Location = new Point(150, 0x5d);
            this.Campapellido1erno.MaxLength = 0x63;
            this.Campapellido1erno.Name = "Campapellido1erno";
            this.Campapellido1erno.Size = new Size(0xa9, 0x17);
            this.Campapellido1erno.TabIndex = 2;
            this.DGVPaciente.AllowUserToAddRows = false;
            this.DGVPaciente.AllowUserToDeleteRows = false;
            this.DGVPaciente.BackgroundColor = SystemColors.ScrollBar;
            this.DGVPaciente.BorderStyle = BorderStyle.None;
            this.DGVPaciente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewColumn[] dataGridViewColumns = new DataGridViewColumn[] { this.Id, this.Dni, this.Historia, this.Nombre, this.ApellidoP, this.ApellidoM };
            this.DGVPaciente.Columns.AddRange(dataGridViewColumns);
            this.DGVPaciente.Dock = DockStyle.Fill;
            this.DGVPaciente.Location = new Point(3, 0x13);
            this.DGVPaciente.Name = "DGVPaciente";
            this.DGVPaciente.ReadOnly = true;
            this.DGVPaciente.Size = new Size(640, 0xbf);
            this.DGVPaciente.TabIndex = 7;
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Dni.HeaderText = "DNI";
            this.Dni.Name = "Dni";
            this.Dni.ReadOnly = true;
            this.Historia.HeaderText = "Historia";
            this.Historia.Name = "Historia";
            this.Historia.ReadOnly = true;
            this.Nombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.ApellidoP.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.ApellidoP.HeaderText = "Apellido Paterno";
            this.ApellidoP.Name = "ApellidoP";
            this.ApellidoP.ReadOnly = true;
            this.ApellidoM.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.ApellidoM.HeaderText = "Apellido Materno";
            this.ApellidoM.Name = "ApellidoM";
            this.ApellidoM.ReadOnly = true;
            this.groupBox1.Controls.Add(this.DGVPaciente);
            this.groupBox1.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.groupBox1.Location = new Point(0x11, 220);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x286, 0xd5);
            this.groupBox1.TabIndex = 0x1d;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resultados";
            this.label11.AutoSize = true;
            this.label11.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label11.Location = new Point(13, 0x12);
            this.label11.Name = "label11";
            this.label11.Size = new Size(140, 0x13);
            this.label11.TabIndex = 40;
            this.label11.Text = "Filtro de Busqueda";
            this.BtnUIPacienteBuscar1.AutoSize = true;
            this.BtnUIPacienteBuscar1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BtnUIPacienteBuscar1.BackColor = SystemColors.ActiveCaptionText;
            this.BtnUIPacienteBuscar1.Location = new Point(0x227, 0xac);
            this.BtnUIPacienteBuscar1.Margin = new Padding(0);
            this.BtnUIPacienteBuscar1.Name = "BtnUIPacienteBuscar1";
            this.BtnUIPacienteBuscar1.Size = new Size(0x70, 40);
            this.BtnUIPacienteBuscar1.TabIndex = 0x29;
            this.BtnUIPacienteBuscar2.AutoSize = true;
            this.BtnUIPacienteBuscar2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BtnUIPacienteBuscar2.BackColor = SystemColors.ActiveCaptionText;
            this.BtnUIPacienteBuscar2.Location = new Point(0x227, 0x1bb);
            this.BtnUIPacienteBuscar2.Margin = new Padding(0);
            this.BtnUIPacienteBuscar2.Name = "BtnUIPacienteBuscar2";
            this.BtnUIPacienteBuscar2.Size = new Size(0x70, 40);
            this.BtnUIPacienteBuscar2.TabIndex = 0x2a;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = SystemColors.Window;
            base.ClientSize = new Size(0x2ad, 0x1f7);
            base.Controls.Add(this.BtnUIPacienteBuscar2);
            base.Controls.Add(this.BtnUIPacienteBuscar1);
            base.Controls.Add(this.label11);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.label10);
            base.Controls.Add(this.CampHistoria);
            base.Controls.Add(this.label9);
            base.Controls.Add(this.CampDni);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.CampNombre);
            base.Controls.Add(this.Campapellido1erno);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.Campapellido2erno);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FormBuscarPaciente";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Buscar Perfil de Paciente";
            base.Load += new EventHandler(this.FormBuscarPaciente_Load);
            ((ISupportInitialize)this.DGVPaciente).EndInit();
            this.groupBox1.ResumeLayout(false);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion


        private DataGridViewTextBoxColumn ApellidoM;
        private DataGridViewTextBoxColumn ApellidoP;
        private ButtonUI BtnUIPacienteBuscar1;
        private ButtonUI BtnUIPacienteBuscar2;
        private TextBox Campapellido1erno;
        private TextBox Campapellido2erno;
        private TextBox CampDni;
        private TextBox CampHistoria;
        private TextBox CampNombre;
        private DataGridView DGVPaciente;
        private DataGridViewTextBoxColumn Dni;
        private GroupBox groupBox1;
        private DataGridViewTextBoxColumn Historia;
        private DataGridViewTextBoxColumn Id;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label2;
        private Label label3;
        private Label label9;
        private DataGridViewTextBoxColumn Nombre;

    }
}