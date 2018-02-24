
using LabDesk.Code.Base;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace LabDesk.Code.Components.Main.Panels
{
    partial class ControlExamen
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
            DataGridViewCellStyle style4 = new DataGridViewCellStyle();
            this.DGVOrden = new DataGridView();
            this.codigo = new DataGridViewTextBoxColumn();
            this.Dni = new DataGridViewTextBoxColumn();
            this.Column1 = new DataGridViewTextBoxColumn();
            this.descripcion = new DataGridViewTextBoxColumn();
            this.fecha = new DataGridViewTextBoxColumn();
            this.comprobante = new DataGridViewTextBoxColumn();
            this.Estado = new DataGridViewTextBoxColumn();
            this.label8 = new Label();
            this.label7 = new Label();
            this.PickerInit = new DateTimePicker();
            this.PickerEnd = new DateTimePicker();
            this.label2 = new Label();
            this.ComboEstado = new ComboBox();
            this.PanelBarTable = new Panel();
            this.BtnPrint = new Button();
            this.label3 = new Label();
            this.BtnUIExamen1 = new ButtonUI();
            ((ISupportInitialize)this.DGVOrden).BeginInit();
            this.PanelBarTable.SuspendLayout();
            base.SuspendLayout();
            this.DGVOrden.AllowUserToAddRows = false;
            this.DGVOrden.AllowUserToDeleteRows = false;
            this.DGVOrden.BackgroundColor = SystemColors.ScrollBar;
            this.DGVOrden.BorderStyle = BorderStyle.None;
            style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style.BackColor = SystemColors.Control;
            style.Font = new Font("Futura Bk BT", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            style.ForeColor = SystemColors.WindowText;
            style.SelectionBackColor = SystemColors.Highlight;
            style.SelectionForeColor = SystemColors.HighlightText;
            style.WrapMode = DataGridViewTriState.True;
            this.DGVOrden.ColumnHeadersDefaultCellStyle = style;
            this.DGVOrden.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewColumn[] dataGridViewColumns = new DataGridViewColumn[] { this.codigo, this.Dni, this.Column1, this.descripcion, this.fecha, this.comprobante, this.Estado };
            this.DGVOrden.Columns.AddRange(dataGridViewColumns);
            style2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style2.BackColor = SystemColors.Window;
            style2.Font = new Font("Futura Bk BT", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            style2.ForeColor = SystemColors.ControlText;
            style2.Padding = new Padding(2, 0, 2, 0);
            style2.SelectionBackColor = SystemColors.Highlight;
            style2.SelectionForeColor = SystemColors.HighlightText;
            style2.WrapMode = DataGridViewTriState.False;
            this.DGVOrden.DefaultCellStyle = style2;
            this.DGVOrden.Location = new Point(0x19, 0x59);
            this.DGVOrden.Margin = new Padding(0);
            this.DGVOrden.Name = "DGVOrden";
            this.DGVOrden.ReadOnly = true;
            style3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style3.BackColor = SystemColors.Control;
            style3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            style3.ForeColor = SystemColors.WindowText;
            style3.SelectionBackColor = SystemColors.Highlight;
            style3.SelectionForeColor = SystemColors.HighlightText;
            style3.WrapMode = DataGridViewTriState.False;
            this.DGVOrden.RowHeadersDefaultCellStyle = style3;
            style4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.DGVOrden.RowsDefaultCellStyle = style4;
            this.DGVOrden.Size = new Size(0x403, 390);
            this.DGVOrden.TabIndex = 4;
            this.codigo.Frozen = true;
            this.codigo.HeaderText = "Codigo";
            this.codigo.MinimumWidth = 100;
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.Resizable = DataGridViewTriState.False;
            this.codigo.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.Dni.HeaderText = "DNI";
            this.Dni.Name = "Dni";
            this.Dni.ReadOnly = true;
            this.Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Paciente";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = DataGridViewTriState.False;
            this.Column1.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.descripcion.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.descripcion.HeaderText = "Descripci\x00f3n";
            this.descripcion.MinimumWidth = 260;
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.fecha.HeaderText = "Registro";
            this.fecha.MinimumWidth = 130;
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Width = 130;
            this.comprobante.HeaderText = "Boleta";
            this.comprobante.MinimumWidth = 100;
            this.comprobante.Name = "comprobante";
            this.comprobante.ReadOnly = true;
            this.Estado.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.Estado.HeaderText = "Estado";
            this.Estado.MinimumWidth = 100;
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Resizable = DataGridViewTriState.False;
            this.Estado.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.label8.AutoSize = true;
            this.label8.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label8.ForeColor = SystemColors.Window;
            this.label8.Location = new Point(0xa4, 6);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x25, 0x10);
            this.label8.TabIndex = 0x43;
            this.label8.Text = "hasta";
            this.label7.AutoSize = true;
            this.label7.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label7.ForeColor = SystemColors.Window;
            this.label7.Location = new Point(9, 6);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x2f, 0x10);
            this.label7.TabIndex = 0x42;
            this.label7.Text = "Desde ";
            this.PickerInit.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.PickerInit.Format = DateTimePickerFormat.Short;
            this.PickerInit.Location = new Point(0x39, 4);
            this.PickerInit.MaxDate = new DateTime(0x83e, 12, 0x1f, 0, 0, 0, 0);
            this.PickerInit.MinDate = new DateTime(0x7de, 1, 1, 0, 0, 0, 0);
            this.PickerInit.Name = "PickerInit";
            this.PickerInit.Size = new Size(0x62, 0x17);
            this.PickerInit.TabIndex = 1;
            this.PickerInit.Value = new DateTime(0x7e0, 11, 7, 0, 0, 0, 0);
            this.PickerInit.ValueChanged += new EventHandler(this.PickerInit_ValueChanged);
            this.PickerEnd.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.PickerEnd.Format = DateTimePickerFormat.Short;
            this.PickerEnd.Location = new Point(0xce, 4);
            this.PickerEnd.MaxDate = new DateTime(0x83e, 12, 0x1f, 0, 0, 0, 0);
            this.PickerEnd.MinDate = new DateTime(0x7df, 1, 1, 0, 0, 0, 0);
            this.PickerEnd.Name = "PickerEnd";
            this.PickerEnd.Size = new Size(0x61, 0x17);
            this.PickerEnd.TabIndex = 2;
            this.PickerEnd.ValueChanged += new EventHandler(this.PickerEnd_ValueChanged);
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.ForeColor = SystemColors.Window;
            this.label2.Location = new Point(0x15c, 6);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x30, 0x10);
            this.label2.TabIndex = 0x44;
            this.label2.Text = "Estado:";
            this.ComboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ComboEstado.FlatStyle = FlatStyle.Flat;
            this.ComboEstado.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.ComboEstado.FormattingEnabled = true;
            this.ComboEstado.Location = new Point(0x19c, 3);
            this.ComboEstado.Name = "ComboEstado";
            this.ComboEstado.Size = new Size(0x88, 0x18);
            this.ComboEstado.TabIndex = 3;
            this.ComboEstado.SelectedIndexChanged += new EventHandler(this.ComboEstado_SelectedIndexChanged);
            this.PanelBarTable.BackColor = Color.SteelBlue;
            this.PanelBarTable.BorderStyle = BorderStyle.FixedSingle;
            this.PanelBarTable.Controls.Add(this.ComboEstado);
            this.PanelBarTable.Controls.Add(this.BtnPrint);
            this.PanelBarTable.Controls.Add(this.PickerEnd);
            this.PanelBarTable.Controls.Add(this.PickerInit);
            this.PanelBarTable.Controls.Add(this.label7);
            this.PanelBarTable.Controls.Add(this.label2);
            this.PanelBarTable.Controls.Add(this.label8);
            this.PanelBarTable.Location = new Point(0x19, 0x39);
            this.PanelBarTable.Margin = new Padding(0);
            this.PanelBarTable.Name = "PanelBarTable";
            this.PanelBarTable.Size = new Size(0x403, 0x20);
            this.PanelBarTable.TabIndex = 0x48;
            this.BtnPrint.Anchor = AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
            this.BtnPrint.FlatAppearance.BorderSize = 0;
            this.BtnPrint.FlatAppearance.CheckedBackColor = Color.DeepSkyBlue;
            this.BtnPrint.FlatStyle = FlatStyle.Flat;
            this.BtnPrint.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.BtnPrint.ForeColor = SystemColors.Info;
           // this.BtnPrint.Image = Resources.icon_printer;
            this.BtnPrint.Location = new Point(0x3d7, 0);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new Size(0x21, 0x20);
            this.BtnPrint.TabIndex = 5;
            this.BtnPrint.UseVisualStyleBackColor = false;
            this.BtnPrint.Visible = false;
            this.BtnPrint.Click += new EventHandler(this.BtnPrint_Click);
            this.label3.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label3.ForeColor = SystemColors.WindowText;
            this.label3.Location = new Point(0x15, 15);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0xf9, 30);
            this.label3.TabIndex = 0x67;
            this.label3.Text = "Historia General";
            this.label3.TextAlign = ContentAlignment.MiddleLeft;
            this.BtnUIExamen1.AutoSize = true;
            this.BtnUIExamen1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BtnUIExamen1.BackColor = SystemColors.ActiveCaptionText;
            this.BtnUIExamen1.Location = new Point(940, 0x1ec);
            this.BtnUIExamen1.Margin = new Padding(0);
            this.BtnUIExamen1.Name = "BtnUIExamen1";
            this.BtnUIExamen1.Size = new Size(0x70, 40);
            this.BtnUIExamen1.TabIndex = 0x68;
            base.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = SystemColors.Window;
            base.Controls.Add(this.BtnUIExamen1);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.PanelBarTable);
            base.Controls.Add(this.DGVOrden);
            base.Margin = new Padding(0);
            base.Name = "ControlExamen";
            base.Size = new Size(0x435, 0x228);
            base.Load += new EventHandler(this.ControlExamen_Load);
            ((ISupportInitialize)this.DGVOrden).EndInit();
            this.PanelBarTable.ResumeLayout(false);
            this.PanelBarTable.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }


        

        #endregion

        private Button BtnPrint;
        private ButtonUI BtnUIExamen1;
        private DataGridViewTextBoxColumn codigo;
        private DataGridViewTextBoxColumn Column1;
        private ComboBox ComboEstado;
        private DataGridViewTextBoxColumn comprobante;
        private DataGridViewTextBoxColumn descripcion;
        private DataGridView DGVOrden;
        private DataGridViewTextBoxColumn Dni;
        private DataGridViewTextBoxColumn Estado;
        private DataGridViewTextBoxColumn fecha;
        private Label label2;
        private Label label3;
        private Label label7;
        private Label label8;
        private Panel PanelBarTable;
        private DateTimePicker PickerEnd;
        private DateTimePicker PickerInit;
    }
}
