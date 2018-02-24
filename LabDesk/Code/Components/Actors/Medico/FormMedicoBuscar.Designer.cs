using LabDesk.Code.Base;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.PresentationLayer.Controles.ComponentesMedico
{
    partial class FormMedicoBuscar

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
            this.label1 = new Label();
            this.label3 = new Label();
            this.CampNombre = new TextBox();
            this.label2 = new Label();
            this.Campapellido2erno = new TextBox();
            this.Campapellido1erno = new TextBox();
            this.DGVMedico = new DataGridView();
            this.Id = new DataGridViewTextBoxColumn();
            this.colegiatura = new DataGridViewTextBoxColumn();
            this.Nombre = new DataGridViewTextBoxColumn();
            this.especialidad = new DataGridViewTextBoxColumn();
            this.groupBox1 = new GroupBox();
            this.CheckBoxHabil = new CheckBox();
            this.BtnUIMedicoBuscar1 = new ButtonUI();
            this.BtnUIMedicoBuscar2 = new ButtonUI();
            this.label12 = new Label();
            ((ISupportInitialize)this.DGVMedico).BeginInit();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.Location = new Point(15, 0x3f);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x3b, 0x10);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label3.Location = new Point(0x160, 100);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x6c, 0x10);
            this.label3.TabIndex = 2;
            this.label3.Text = "Apellido Materno:";
            this.CampNombre.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampNombre.Location = new Point(0x97, 60);
            this.CampNombre.MaxLength = 0x63;
            this.CampNombre.Name = "CampNombre";
            this.CampNombre.Size = new Size(0xa9, 0x17);
            this.CampNombre.TabIndex = 1;
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.Location = new Point(15, 100);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x68, 0x10);
            this.label2.TabIndex = 1;
            this.label2.Text = "Apellido Paterno:";
            this.Campapellido2erno.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Campapellido2erno.Location = new Point(0x1ec, 0x61);
            this.Campapellido2erno.MaxLength = 0x63;
            this.Campapellido2erno.Name = "Campapellido2erno";
            this.Campapellido2erno.Size = new Size(0xa9, 0x17);
            this.Campapellido2erno.TabIndex = 3;
            this.Campapellido1erno.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Campapellido1erno.Location = new Point(0x97, 0x61);
            this.Campapellido1erno.MaxLength = 0x63;
            this.Campapellido1erno.Name = "Campapellido1erno";
            this.Campapellido1erno.Size = new Size(0xa9, 0x17);
            this.Campapellido1erno.TabIndex = 2;
            this.DGVMedico.AllowUserToAddRows = false;
            this.DGVMedico.AllowUserToDeleteRows = false;
            this.DGVMedico.BackgroundColor = SystemColors.ScrollBar;
            this.DGVMedico.BorderStyle = BorderStyle.None;
            this.DGVMedico.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewColumn[] dataGridViewColumns = new DataGridViewColumn[] { this.Id, this.colegiatura, this.Nombre, this.especialidad };
            this.DGVMedico.Columns.AddRange(dataGridViewColumns);
            this.DGVMedico.Dock = DockStyle.Fill;
            this.DGVMedico.Location = new Point(3, 0x13);
            this.DGVMedico.Name = "DGVMedico";
            this.DGVMedico.ReadOnly = true;
            this.DGVMedico.Size = new Size(640, 0xe1);
            this.DGVMedico.TabIndex = 7;
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.colegiatura.HeaderText = "Colegiatura";
            this.colegiatura.Name = "colegiatura";
            this.colegiatura.ReadOnly = true;
            this.Nombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.especialidad.HeaderText = "Especialidad";
            this.especialidad.Name = "especialidad";
            this.especialidad.ReadOnly = true;
            this.groupBox1.Controls.Add(this.DGVMedico);
            this.groupBox1.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.groupBox1.Location = new Point(15, 0xc1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x286, 0xf7);
            this.groupBox1.TabIndex = 0x1d;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resultados";
            this.CheckBoxHabil.AutoSize = true;
            this.CheckBoxHabil.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CheckBoxHabil.Location = new Point(0x163, 0x3d);
            this.CheckBoxHabil.Name = "CheckBoxHabil";
            this.CheckBoxHabil.RightToLeft = RightToLeft.Yes;
            this.CheckBoxHabil.Size = new Size(0x57, 20);
            this.CheckBoxHabil.TabIndex = 0x29;
            this.CheckBoxHabil.Text = ":Habilitado";
            this.CheckBoxHabil.UseVisualStyleBackColor = true;
            this.BtnUIMedicoBuscar1.AutoSize = true;
            this.BtnUIMedicoBuscar1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BtnUIMedicoBuscar1.BackColor = SystemColors.ActiveCaptionText;
            this.BtnUIMedicoBuscar1.Location = new Point(0x225, 0x8d);
            this.BtnUIMedicoBuscar1.Margin = new Padding(0);
            this.BtnUIMedicoBuscar1.Name = "BtnUIMedicoBuscar1";
            this.BtnUIMedicoBuscar1.Size = new Size(0x70, 40);
            this.BtnUIMedicoBuscar1.TabIndex = 0x2a;
            this.BtnUIMedicoBuscar2.AutoSize = true;
            this.BtnUIMedicoBuscar2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BtnUIMedicoBuscar2.BackColor = SystemColors.ActiveCaptionText;
            this.BtnUIMedicoBuscar2.Location = new Point(0x225, 0x1be);
            this.BtnUIMedicoBuscar2.Margin = new Padding(0);
            this.BtnUIMedicoBuscar2.Name = "BtnUIMedicoBuscar2";
            this.BtnUIMedicoBuscar2.Size = new Size(0x70, 40);
            this.BtnUIMedicoBuscar2.TabIndex = 0x2b;
            this.label12.AutoSize = true;
            this.label12.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label12.Location = new Point(0x11, 20);
            this.label12.Name = "label12";
            this.label12.Size = new Size(140, 0x13);
            this.label12.TabIndex = 0x9d;
            this.label12.Text = "Filtro de Busqueda";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = SystemColors.Window;
            base.ClientSize = new Size(0x2ad, 510);
            base.Controls.Add(this.label12);
            base.Controls.Add(this.BtnUIMedicoBuscar2);
            base.Controls.Add(this.BtnUIMedicoBuscar1);
            base.Controls.Add(this.CheckBoxHabil);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.CampNombre);
            base.Controls.Add(this.Campapellido1erno);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.Campapellido2erno);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FormMedicoBuscar";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Busqueda de Medico";
            ((ISupportInitialize)this.DGVMedico).EndInit();
            this.groupBox1.ResumeLayout(false);
            base.ResumeLayout(false);
            base.PerformLayout();
        }


        #endregion
        private ButtonUI BtnUIMedicoBuscar1;
        private ButtonUI BtnUIMedicoBuscar2;
        private TextBox Campapellido1erno;
        private TextBox Campapellido2erno;
        private TextBox CampNombre;
        private CheckBox CheckBoxHabil;
        private DataGridViewTextBoxColumn colegiatura;
        private DataGridView DGVMedico;
        private DataGridViewTextBoxColumn especialidad;
        private GroupBox groupBox1;
        private DataGridViewTextBoxColumn Id;
        private Label label1;
        private Label label12;
        private Label label2;
        private Label label3;
        private DataGridViewTextBoxColumn Nombre;
    }
}