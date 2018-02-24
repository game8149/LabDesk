using LabDesk.Code.Base;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Laboratory.Orden
{
    partial class FormOrdenBuscar
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
            this.Nombre = new DataGridViewTextBoxColumn();
            this.groupBox1 = new GroupBox();
            this.BtnUIOrdenBuscar1 = new ButtonUI();
            this.label11 = new Label();
            this.groupBox2 = new GroupBox();
            this.ComboEstado = new ComboBox();
            this.label5 = new Label();
            this.DGVOrden = new DataGridView();
            this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            this.PickerEnd = new DateTimePicker();
            this.PickerInit = new DateTimePicker();
            this.label6 = new Label();
            this.label4 = new Label();
            this.panel2 = new Panel();
            this.BtnUIOrdenBuscar2 = new ButtonUI();
            ((ISupportInitialize)this.DGVPaciente).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((ISupportInitialize)this.DGVOrden).BeginInit();
            base.SuspendLayout();
            this.label10.AutoSize = true;
            this.label10.Location = new Point(0x15, 190);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x60, 0x10);
            this.label10.TabIndex = 0x12;
            this.label10.Text = "Historia Clinica:";
            this.CampHistoria.Location = new Point(0xa3, 0xba);
            this.CampHistoria.MaxLength = 15;
            this.CampHistoria.Name = "CampHistoria";
            this.CampHistoria.Size = new Size(0xd6, 0x17);
            this.CampHistoria.TabIndex = 5;
            this.label9.AutoSize = true;
            this.label9.Location = new Point(0x15, 0x97);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x22, 0x10);
            this.label9.TabIndex = 15;
            this.label9.Text = "DNI:";
            this.CampDni.Location = new Point(0xa3, 0x94);
            this.CampDni.MaxLength = 8;
            this.CampDni.Name = "CampDni";
            this.CampDni.Size = new Size(0xd6, 0x17);
            this.CampDni.TabIndex = 4;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x15, 0x25);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x3b, 0x10);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0x15, 0x71);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x6c, 0x10);
            this.label3.TabIndex = 2;
            this.label3.Text = "Apellido Materno:";
            this.CampNombre.Location = new Point(0xa3, 0x22);
            this.CampNombre.MaxLength = 0x63;
            this.CampNombre.Name = "CampNombre";
            this.CampNombre.Size = new Size(0xd6, 0x17);
            this.CampNombre.TabIndex = 1;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x15, 0x4b);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x68, 0x10);
            this.label2.TabIndex = 1;
            this.label2.Text = "Apellido Paterno:";
            this.Campapellido2erno.Location = new Point(0xa3, 110);
            this.Campapellido2erno.MaxLength = 0x63;
            this.Campapellido2erno.Name = "Campapellido2erno";
            this.Campapellido2erno.Size = new Size(0xd6, 0x17);
            this.Campapellido2erno.TabIndex = 3;
            this.Campapellido1erno.Location = new Point(0xa3, 0x48);
            this.Campapellido1erno.MaxLength = 0x63;
            this.Campapellido1erno.Name = "Campapellido1erno";
            this.Campapellido1erno.Size = new Size(0xd6, 0x17);
            this.Campapellido1erno.TabIndex = 2;
            this.DGVPaciente.AllowUserToAddRows = false;
            this.DGVPaciente.AllowUserToDeleteRows = false;
            this.DGVPaciente.BackgroundColor = SystemColors.ScrollBar;
            this.DGVPaciente.BorderStyle = BorderStyle.None;
            this.DGVPaciente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewColumn[] dataGridViewColumns = new DataGridViewColumn[] { this.Id, this.Dni, this.Nombre };
            this.DGVPaciente.Columns.AddRange(dataGridViewColumns);
            this.DGVPaciente.Location = new Point(0x18, 0x111);
            this.DGVPaciente.Name = "DGVPaciente";
            this.DGVPaciente.ReadOnly = true;
            this.DGVPaciente.Size = new Size(0x161, 0xc5);
            this.DGVPaciente.TabIndex = 7;
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Dni.HeaderText = "DNI";
            this.Dni.Name = "Dni";
            this.Dni.ReadOnly = true;
            this.Nombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.groupBox1.Controls.Add(this.BtnUIOrdenBuscar1);
            this.groupBox1.Controls.Add(this.DGVPaciente);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Campapellido2erno);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Campapellido1erno);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.CampNombre);
            this.groupBox1.Controls.Add(this.CampHistoria);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.CampDni);
            this.groupBox1.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.groupBox1.Location = new Point(0x16, 0x3b);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x197, 0x1e7);
            this.groupBox1.TabIndex = 0x1d;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pacientes";
            this.BtnUIOrdenBuscar1.AutoSize = true;
            this.BtnUIOrdenBuscar1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BtnUIOrdenBuscar1.BackColor = SystemColors.ActiveCaptionText;
            this.BtnUIOrdenBuscar1.Location = new Point(0x109, 0xe1);
            this.BtnUIOrdenBuscar1.Margin = new Padding(0);
            this.BtnUIOrdenBuscar1.Name = "BtnUIOrdenBuscar1";
            this.BtnUIOrdenBuscar1.Size = new Size(0x83, 0x31);
            this.BtnUIOrdenBuscar1.TabIndex = 0x13;
            this.label11.AutoSize = true;
            this.label11.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label11.Location = new Point(0x12, 20);
            this.label11.Name = "label11";
            this.label11.Size = new Size(140, 0x13);
            this.label11.TabIndex = 40;
            this.label11.Text = "Filtro de Busqueda";
            this.groupBox2.Controls.Add(this.ComboEstado);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.DGVOrden);
            this.groupBox2.Controls.Add(this.PickerEnd);
            this.groupBox2.Controls.Add(this.PickerInit);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.groupBox2.Location = new Point(0x1f3, 0x3b);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x181, 0x1b5);
            this.groupBox2.TabIndex = 0x29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ordenes";
            this.ComboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ComboEstado.FlatStyle = FlatStyle.Flat;
            this.ComboEstado.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.ComboEstado.ForeColor = SystemColors.WindowText;
            this.ComboEstado.FormattingEnabled = true;
            this.ComboEstado.Location = new Point(0x48, 0x3f);
            this.ComboEstado.Name = "ComboEstado";
            this.ComboEstado.Size = new Size(0x62, 0x18);
            this.ComboEstado.TabIndex = 0x51;
            this.ComboEstado.SelectedIndexChanged += new EventHandler(this.ComboEstado_SelectedIndexChanged);
            this.label5.AutoSize = true;
            this.label5.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label5.ForeColor = SystemColors.WindowText;
            this.label5.Location = new Point(20, 0x42);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x30, 0x10);
            this.label5.TabIndex = 80;
            this.label5.Text = "Estado:";
            this.DGVOrden.AllowUserToAddRows = false;
            this.DGVOrden.AllowUserToDeleteRows = false;
            this.DGVOrden.BackgroundColor = SystemColors.ScrollBar;
            this.DGVOrden.BorderStyle = BorderStyle.None;
            this.DGVOrden.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewColumn[] columnArray2 = new DataGridViewColumn[] { this.dataGridViewTextBoxColumn1, this.dataGridViewTextBoxColumn2, this.dataGridViewTextBoxColumn3 };
            this.DGVOrden.Columns.AddRange(columnArray2);
            this.DGVOrden.Location = new Point(0x17, 110);
            this.DGVOrden.Name = "DGVOrden";
            this.DGVOrden.ReadOnly = true;
            this.DGVOrden.Size = new Size(0x155, 0x131);
            this.DGVOrden.TabIndex = 7;
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn2.HeaderText = "Codigo";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "Fecha / Hora";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.PickerEnd.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.PickerEnd.Format = DateTimePickerFormat.Short;
            this.PickerEnd.Location = new Point(0xda, 0x1f);
            this.PickerEnd.Name = "PickerEnd";
            this.PickerEnd.Size = new Size(0x61, 0x17);
            this.PickerEnd.TabIndex = 0x4c;
            this.PickerEnd.ValueChanged += new EventHandler(this.PickerEnd_ValueChanged);
            this.PickerInit.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.PickerInit.Format = DateTimePickerFormat.Short;
            this.PickerInit.Location = new Point(0x48, 0x1f);
            this.PickerInit.MaxDate = new DateTime(0x83e, 12, 0x1f, 0, 0, 0, 0);
            this.PickerInit.MinDate = new DateTime(0x7e0, 10, 15, 0, 0, 0, 0);
            this.PickerInit.Name = "PickerInit";
            this.PickerInit.Size = new Size(0x62, 0x17);
            this.PickerInit.TabIndex = 0x4d;
            this.PickerInit.Value = new DateTime(0x7e0, 10, 15, 15, 0x3b, 0x24, 0);
            this.PickerInit.ValueChanged += new EventHandler(this.PickerInit_ValueChanged);
            this.label6.AutoSize = true;
            this.label6.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label6.ForeColor = SystemColors.WindowText;
            this.label6.Location = new Point(0xb0, 0x22);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x25, 0x10);
            this.label6.TabIndex = 0x4f;
            this.label6.Text = "hasta";
            this.label4.AutoSize = true;
            this.label4.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label4.ForeColor = SystemColors.WindowText;
            this.label4.Location = new Point(20, 0x22);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x2f, 0x10);
            this.label4.TabIndex = 0x4e;
            this.label4.Text = "Desde ";
            this.panel2.BackColor = SystemColors.ScrollBar;
            this.panel2.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.panel2.Location = new Point(0x1d0, 0x3b);
            this.panel2.Margin = new Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(2, 480);
            this.panel2.TabIndex = 0x4b;
            this.BtnUIOrdenBuscar2.AutoSize = true;
            this.BtnUIOrdenBuscar2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BtnUIOrdenBuscar2.BackColor = SystemColors.ActiveCaptionText;
            this.BtnUIOrdenBuscar2.Location = new Point(0x304, 0x1fc);
            this.BtnUIOrdenBuscar2.Margin = new Padding(3, 4, 3, 4);
            this.BtnUIOrdenBuscar2.Name = "BtnUIOrdenBuscar2";
            this.BtnUIOrdenBuscar2.Size = new Size(0x70, 40);
            this.BtnUIOrdenBuscar2.TabIndex = 20;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = SystemColors.Window;
            base.ClientSize = new Size(0x38c, 570);
            base.Controls.Add(this.BtnUIOrdenBuscar2);
            base.Controls.Add(this.panel2);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.label11);
            base.Controls.Add(this.groupBox1);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FormBuscarOrdenIngreso";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Busqueda de Orden de Ingreso";
            base.Load += new EventHandler(this.FormBuscarPaciente_Load);
            ((ISupportInitialize)this.DGVPaciente).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((ISupportInitialize)this.DGVOrden).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }



        #endregion
        private DataGridViewTextBoxColumn Dni;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private DataGridViewTextBoxColumn Id;
        private ButtonUI BtnUIOrdenBuscar1;
        private ButtonUI BtnUIOrdenBuscar2;
        private TextBox Campapellido1erno;
        private TextBox Campapellido2erno;
        private TextBox CampDni;
        private TextBox CampHistoria;
        private TextBox CampNombre;
        private ComboBox ComboEstado;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridView DGVOrden;
        private DataGridView DGVPaciente;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label9;
        private DataGridViewTextBoxColumn Nombre;
        private Panel panel2;
        private DateTimePicker PickerEnd;
        private DateTimePicker PickerInit;

    }
}
