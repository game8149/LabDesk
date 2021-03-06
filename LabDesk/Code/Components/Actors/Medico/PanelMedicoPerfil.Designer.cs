﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Actors.Medico
{
    partial class PanelMedicoPerfil
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
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            DataGridViewCellStyle style3 = new DataGridViewCellStyle();
            this.PanelBarTable = new Panel();
            this.ComboEstado = new ComboBox();
            this.BtnPerfilPrintExamen = new Button();
            this.PickerEnd = new DateTimePicker();
            this.PickerInit = new DateTimePicker();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.CampHabil = new Label();
            this.CampColegiatura = new Label();
            this.CampNombre = new Label();
            this.DGVExamen = new DataGridView();
            this.Id = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn1 = new DataGridViewTextBoxColumn();
            this.lastModif = new DataGridViewTextBoxColumn();
            this.IdOrden = new DataGridViewTextBoxColumn();
            this.label11 = new Label();
            this.label12 = new Label();
            this.label13 = new Label();
            this.label14 = new Label();
            this.label18 = new Label();
            this.CampEspecialidad = new Label();
            this.label5 = new Label();
            this.BtnPerfilEditar = new Button();
            this.BtnPerfilCerrar = new Button();
            this.PanelBarTable.SuspendLayout();
            ((ISupportInitialize)this.DGVExamen).BeginInit();
            base.SuspendLayout();
            this.PanelBarTable.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.PanelBarTable.BackColor = Color.SteelBlue;
            this.PanelBarTable.Controls.Add(this.ComboEstado);
            this.PanelBarTable.Controls.Add(this.BtnPerfilPrintExamen);
            this.PanelBarTable.Controls.Add(this.PickerEnd);
            this.PanelBarTable.Controls.Add(this.PickerInit);
            this.PanelBarTable.Controls.Add(this.label1);
            this.PanelBarTable.Controls.Add(this.label2);
            this.PanelBarTable.Controls.Add(this.label3);
            this.PanelBarTable.Location = new Point(0x20, 0xec);
            this.PanelBarTable.Margin = new Padding(0);
            this.PanelBarTable.Name = "PanelBarTable";
            this.PanelBarTable.Size = new Size(0x3f5, 0x22);
            this.PanelBarTable.TabIndex = 0x59;
            this.ComboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ComboEstado.Enabled = false;
            this.ComboEstado.FlatStyle = FlatStyle.Flat;
            this.ComboEstado.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.ComboEstado.FormattingEnabled = true;
            this.ComboEstado.Location = new Point(0x19c, 5);
            this.ComboEstado.Name = "ComboEstado";
            this.ComboEstado.Size = new Size(0x79, 0x18);
            this.ComboEstado.TabIndex = 0x45;
            this.ComboEstado.SelectedIndexChanged += new EventHandler(this.ComboEstado_SelectedIndexChanged);
            this.BtnPerfilPrintExamen.Anchor = AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
            this.BtnPerfilPrintExamen.AutoSize = true;
            this.BtnPerfilPrintExamen.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BtnPerfilPrintExamen.Enabled = false;
            this.BtnPerfilPrintExamen.FlatAppearance.BorderSize = 0;
            this.BtnPerfilPrintExamen.FlatAppearance.CheckedBackColor = Color.DeepSkyBlue;
            this.BtnPerfilPrintExamen.FlatStyle = FlatStyle.Flat;
            this.BtnPerfilPrintExamen.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.BtnPerfilPrintExamen.ForeColor = SystemColors.Info;
            //this.BtnPerfilPrintExamen.Image = Resources.icon_printer;
            this.BtnPerfilPrintExamen.Location = new Point(0x3d7, 6);
            this.BtnPerfilPrintExamen.Name = "BtnPerfilPrintExamen";
            this.BtnPerfilPrintExamen.Size = new Size(0x16, 0x16);
            this.BtnPerfilPrintExamen.TabIndex = 0x47;
            this.BtnPerfilPrintExamen.UseVisualStyleBackColor = false;
            this.BtnPerfilPrintExamen.Visible = false;
            this.BtnPerfilPrintExamen.Click += new EventHandler(this.BtnPrint_Click);
            this.PickerEnd.Enabled = false;
            this.PickerEnd.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.PickerEnd.Format = DateTimePickerFormat.Short;
            this.PickerEnd.Location = new Point(0xce, 6);
            this.PickerEnd.Name = "PickerEnd";
            this.PickerEnd.Size = new Size(0x61, 0x17);
            this.PickerEnd.TabIndex = 0x40;
            this.PickerEnd.ValueChanged += new EventHandler(this.PickerEnd_ValueChanged);
            this.PickerInit.Enabled = false;
            this.PickerInit.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.PickerInit.Format = DateTimePickerFormat.Short;
            this.PickerInit.Location = new Point(0x39, 6);
            this.PickerInit.MaxDate = new DateTime(0x83e, 12, 0x1f, 0, 0, 0, 0);
            this.PickerInit.MinDate = new DateTime(0x7e0, 10, 15, 0, 0, 0, 0);
            this.PickerInit.Name = "PickerInit";
            this.PickerInit.Size = new Size(0x62, 0x17);
            this.PickerInit.TabIndex = 0x41;
            this.PickerInit.Value = new DateTime(0x7e0, 10, 15, 15, 0x3b, 0x24, 0);
            this.PickerInit.ValueChanged += new EventHandler(this.PickerInit_ValueChanged);
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.ForeColor = SystemColors.Window;
            this.label1.Location = new Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x2f, 0x10);
            this.label1.TabIndex = 0x42;
            this.label1.Text = "Desde ";
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.ForeColor = SystemColors.Window;
            this.label2.Location = new Point(0x15c, 9);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x30, 0x10);
            this.label2.TabIndex = 0x44;
            this.label2.Text = "Estado:";
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label3.ForeColor = SystemColors.Window;
            this.label3.Location = new Point(0xa4, 9);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x25, 0x10);
            this.label3.TabIndex = 0x43;
            this.label3.Text = "hasta";
            this.CampHabil.AutoSize = true;
            this.CampHabil.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampHabil.Location = new Point(0x13c, 0x6d);
            this.CampHabil.Name = "CampHabil";
            this.CampHabil.Size = new Size(40, 0x10);
            this.CampHabil.TabIndex = 0x58;
            this.CampHabil.Text = "Alexis";
            this.CampColegiatura.AutoSize = true;
            this.CampColegiatura.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampColegiatura.Location = new Point(0x77, 0x6d);
            this.CampColegiatura.Name = "CampColegiatura";
            this.CampColegiatura.Size = new Size(40, 0x10);
            this.CampColegiatura.TabIndex = 0x55;
            this.CampColegiatura.Text = "Alexis";
            this.CampNombre.AutoSize = true;
            this.CampNombre.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampNombre.Location = new Point(0x77, 0x42);
            this.CampNombre.Name = "CampNombre";
            this.CampNombre.Size = new Size(40, 0x10);
            this.CampNombre.TabIndex = 0x53;
            this.CampNombre.Text = "Alexis";
            this.DGVExamen.AllowUserToAddRows = false;
            this.DGVExamen.AllowUserToDeleteRows = false;
            this.DGVExamen.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.DGVExamen.BackgroundColor = SystemColors.ScrollBar;
            this.DGVExamen.BorderStyle = BorderStyle.None;
            this.DGVExamen.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style.BackColor = SystemColors.Control;
            style.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            style.ForeColor = SystemColors.WindowText;
            style.SelectionBackColor = SystemColors.Highlight;
            style.SelectionForeColor = SystemColors.HighlightText;
            style.WrapMode = DataGridViewTriState.True;
            this.DGVExamen.ColumnHeadersDefaultCellStyle = style;
            this.DGVExamen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewColumn[] dataGridViewColumns = new DataGridViewColumn[] { this.Id, this.dataGridViewTextBoxColumn1, this.dataGridViewTextBoxColumn2, this.dataGridViewComboBoxColumn1, this.lastModif, this.IdOrden };
            this.DGVExamen.Columns.AddRange(dataGridViewColumns);
            style2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style2.BackColor = SystemColors.Window;
            style2.Font = new Font("Futura Bk BT", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            style2.ForeColor = SystemColors.ControlText;
            style2.SelectionBackColor = SystemColors.Highlight;
            style2.SelectionForeColor = SystemColors.HighlightText;
            style2.WrapMode = DataGridViewTriState.False;
            this.DGVExamen.DefaultCellStyle = style2;
            this.DGVExamen.Enabled = false;
            this.DGVExamen.Location = new Point(0x20, 270);
            this.DGVExamen.Margin = new Padding(0);
            this.DGVExamen.Name = "DGVExamen";
            this.DGVExamen.ReadOnly = true;
            style3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style3.BackColor = SystemColors.Control;
            style3.Font = new Font("Futura Bk BT", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            style3.ForeColor = SystemColors.WindowText;
            style3.SelectionBackColor = SystemColors.Highlight;
            style3.SelectionForeColor = SystemColors.HighlightText;
            style3.WrapMode = DataGridViewTriState.True;
            this.DGVExamen.RowHeadersDefaultCellStyle = style3;
            this.DGVExamen.Size = new Size(0x3f5, 0x101);
            this.DGVExamen.TabIndex = 0x52;
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.dataGridViewTextBoxColumn1.HeaderText = "Codigo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 90;
            this.dataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Examen";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.ToolTipText = "Abrir Examen";
            this.dataGridViewComboBoxColumn1.HeaderText = "Responsable";
            this.dataGridViewComboBoxColumn1.MinimumWidth = 150;
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.ReadOnly = true;
            this.dataGridViewComboBoxColumn1.Resizable = DataGridViewTriState.False;
            this.dataGridViewComboBoxColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewComboBoxColumn1.Width = 150;
            this.lastModif.HeaderText = "Ultima Modificaci\x00f3n";
            this.lastModif.Name = "lastModif";
            this.lastModif.ReadOnly = true;
            this.lastModif.Width = 150;
            this.IdOrden.HeaderText = "IdOrden";
            this.IdOrden.Name = "IdOrden";
            this.IdOrden.ReadOnly = true;
            this.IdOrden.Visible = false;
            this.label11.AutoSize = true;
            this.label11.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label11.Location = new Point(0x1c, 0xbf);
            this.label11.Name = "label11";
            this.label11.Size = new Size(0xa1, 0x13);
            this.label11.TabIndex = 0x51;
            this.label11.Text = "Historia de Examenes";
            this.label12.AutoSize = true;
            this.label12.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label12.Location = new Point(0x1c, 0x1c);
            this.label12.Name = "label12";
            this.label12.Size = new Size(0x9f, 0x13);
            this.label12.TabIndex = 80;
            this.label12.Text = "Informaci\x00f3n Personal";
            this.label13.AutoSize = true;
            this.label13.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label13.Location = new Point(0x102, 0x6d);
            this.label13.Name = "label13";
            this.label13.Size = new Size(0x34, 0x10);
            this.label13.TabIndex = 0x4f;
            this.label13.Text = "Estado: ";
            this.label14.AutoSize = true;
            this.label14.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label14.Location = new Point(0x1d, 0x6d);
            this.label14.Name = "label14";
            this.label14.Size = new Size(0x4d, 0x10);
            this.label14.TabIndex = 0x4e;
            this.label14.Text = "Colegiatura:";
            this.label18.AutoSize = true;
            this.label18.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label18.Location = new Point(0x1d, 0x42);
            this.label18.Name = "label18";
            this.label18.Size = new Size(0x3b, 0x10);
            this.label18.TabIndex = 0x4a;
            this.label18.Text = "Nombre:";
            this.CampEspecialidad.AutoSize = true;
            this.CampEspecialidad.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampEspecialidad.Location = new Point(0x77, 0x98);
            this.CampEspecialidad.Name = "CampEspecialidad";
            this.CampEspecialidad.Size = new Size(40, 0x10);
            this.CampEspecialidad.TabIndex = 0x7f;
            this.CampEspecialidad.Text = "Alexis";
            this.label5.AutoSize = true;
            this.label5.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label5.Location = new Point(0x1d, 0x98);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x51, 0x10);
            this.label5.TabIndex = 0x7e;
            this.label5.Text = "Especialidad:";
            this.BtnPerfilEditar.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.BtnPerfilEditar.FlatAppearance.BorderColor = Color.DimGray;
            this.BtnPerfilEditar.FlatAppearance.BorderSize = 0;
            this.BtnPerfilEditar.FlatStyle = FlatStyle.Flat;
            this.BtnPerfilEditar.Font = new Font("Futura Bk BT", 8.25f);
            this.BtnPerfilEditar.ForeColor = SystemColors.Window;
           // this.BtnPerfilEditar.Image = Resources.icon_edit;
            this.BtnPerfilEditar.Location = new Point(0x3f1, 12);
            this.BtnPerfilEditar.Margin = new Padding(0);
            this.BtnPerfilEditar.Name = "BtnPerfilEditar";
            this.BtnPerfilEditar.Padding = new Padding(5);
            this.BtnPerfilEditar.Size = new Size(20, 20);
            this.BtnPerfilEditar.TabIndex = 0x85;
            this.BtnPerfilEditar.TextAlign = ContentAlignment.MiddleLeft;
            this.BtnPerfilEditar.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.BtnPerfilEditar.UseVisualStyleBackColor = false;
            this.BtnPerfilEditar.Click += new EventHandler(this.BtnEdit_Click);
            this.BtnPerfilCerrar.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.BtnPerfilCerrar.FlatAppearance.BorderColor = Color.DimGray;
            this.BtnPerfilCerrar.FlatAppearance.BorderSize = 0;
            this.BtnPerfilCerrar.FlatStyle = FlatStyle.Flat;
            this.BtnPerfilCerrar.Font = new Font("Futura Bk BT", 8.25f);
            this.BtnPerfilCerrar.ForeColor = SystemColors.Window;
            //this.BtnPerfilCerrar.Image = Resources.icon_cerrar;
            this.BtnPerfilCerrar.Location = new Point(0x412, 12);
            this.BtnPerfilCerrar.Margin = new Padding(0);
            this.BtnPerfilCerrar.Name = "BtnPerfilCerrar";
            this.BtnPerfilCerrar.Padding = new Padding(5);
            this.BtnPerfilCerrar.Size = new Size(20, 20);
            this.BtnPerfilCerrar.TabIndex = 0x84;
            this.BtnPerfilCerrar.TextAlign = ContentAlignment.MiddleLeft;
            this.BtnPerfilCerrar.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.BtnPerfilCerrar.UseVisualStyleBackColor = false;
            this.BtnPerfilCerrar.Click += new EventHandler(this.BtnCerrar_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = SystemColors.Window;
            base.Controls.Add(this.BtnPerfilEditar);
            base.Controls.Add(this.BtnPerfilCerrar);
            base.Controls.Add(this.CampEspecialidad);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.PanelBarTable);
            base.Controls.Add(this.CampHabil);
            base.Controls.Add(this.CampColegiatura);
            base.Controls.Add(this.CampNombre);
            base.Controls.Add(this.DGVExamen);
            base.Controls.Add(this.label11);
            base.Controls.Add(this.label12);
            base.Controls.Add(this.label13);
            base.Controls.Add(this.label14);
            base.Controls.Add(this.label18);
            base.Name = "PanelMedicoPerfil";
            base.Size = new Size(0x435, 0x228);
            this.PanelBarTable.ResumeLayout(false);
            this.PanelBarTable.PerformLayout();
            ((ISupportInitialize)this.DGVExamen).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion

        private Button BtnPerfilCerrar;
        private Button BtnPerfilEditar;
        private Button BtnPerfilPrintExamen;
        private Label CampColegiatura;
        private Label CampEspecialidad;
        private Label CampHabil;
        private Label CampNombre;
        private ComboBox ComboEstado;
        private DataGridViewTextBoxColumn dataGridViewComboBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridView DGVExamen;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn IdOrden;
        private Label label1;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label18;
        private Label label2;
        private Label label3;
        private Label label5;
        private DataGridViewTextBoxColumn lastModif;
        private Panel PanelBarTable;
        private DateTimePicker PickerEnd;
        private DateTimePicker PickerInit;

    }
}
