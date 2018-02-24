
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Analisis.Orden
{
    partial class PanelOrdenPerfil
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
            this.label3 = new Label();
            this.label1 = new Label();
            this.CampUbicacion = new Label();
            this.label12 = new Label();
            this.label9 = new Label();
            this.CampHistoria = new Label();
            this.CampDni = new Label();
            this.CampNombre = new Label();
            this.dataGridView = new DataGridView();
            this.id = new DataGridViewTextBoxColumn();
            this.codigo = new DataGridViewTextBoxColumn();
            this.nombre = new DataGridViewTextBoxColumn();
            this.cobertura = new DataGridViewComboBoxColumn();
            this.idUnique = new DataGridViewTextBoxColumn();
            this.label10 = new Label();
            this.label8 = new Label();
            this.label4 = new Label();
            this.CampBoleta = new Label();
            this.PickerTime = new Label();
            this.label5 = new Label();
            this.CampSexo = new Label();
            this.CampGestacion = new Label();
            this.LabelGestacion = new Label();
            this.CampMedico = new Label();
            this.label14 = new Label();
            this.CampConsultorio = new Label();
            this.label16 = new Label();
            this.label2 = new Label();
            this.BtnCerrar = new Button();
            this.BtnEdit = new Button();
            ((ISupportInitialize)this.dataGridView).BeginInit();
            base.SuspendLayout();
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label3.Location = new Point(0x20d, 0xd3);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x38, 0x10);
            this.label3.TabIndex = 0x7f;
            this.label3.Text = "Registro:";
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.Location = new Point(0x181, 0xd3);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x2e, 0x10);
            this.label1.TabIndex = 130;
            this.label1.Text = "Boleta:";
            this.CampUbicacion.AutoSize = true;
            this.CampUbicacion.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampUbicacion.Location = new Point(110, 0x89);
            this.CampUbicacion.Name = "CampUbicacion";
            this.CampUbicacion.Size = new Size(0x1b, 0x10);
            this.CampUbicacion.TabIndex = 0x88;
            this.CampUbicacion.Text = "asd";
            this.label12.AutoSize = true;
            this.label12.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label12.Location = new Point(0x1c, 0x1c);
            this.label12.Name = "label12";
            this.label12.Size = new Size(0x9c, 0x13);
            this.label12.TabIndex = 0x80;
            this.label12.Text = "Informaci\x00f3n General";
            this.label9.AutoSize = true;
            this.label9.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label9.Location = new Point(0x1d, 0x89);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x41, 0x10);
            this.label9.TabIndex = 0x87;
            this.label9.Text = "Direcci\x00f3n:";
            this.CampHistoria.AutoSize = true;
            this.CampHistoria.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampHistoria.Location = new Point(0x119, 0x63);
            this.CampHistoria.Name = "CampHistoria";
            this.CampHistoria.Size = new Size(0x33, 0x10);
            this.CampHistoria.TabIndex = 0x86;
            this.CampHistoria.Text = "label11";
            this.CampDni.AutoSize = true;
            this.CampDni.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampDni.Location = new Point(110, 100);
            this.CampDni.Name = "CampDni";
            this.CampDni.Size = new Size(0x2b, 0x10);
            this.CampDni.TabIndex = 0x85;
            this.CampDni.Text = "label9";
            this.CampNombre.AutoSize = true;
            this.CampNombre.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampNombre.Location = new Point(110, 0x3f);
            this.CampNombre.Name = "CampNombre";
            this.CampNombre.Size = new Size(0x2b, 0x10);
            this.CampNombre.TabIndex = 0x84;
            this.CampNombre.Text = "label7";
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.dataGridView.BackgroundColor = SystemColors.ScrollBar;
            this.dataGridView.BorderStyle = BorderStyle.None;
            this.dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
            this.dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style.BackColor = SystemColors.Control;
            style.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            style.ForeColor = SystemColors.WindowText;
            style.SelectionBackColor = SystemColors.GrayText;
            style.SelectionForeColor = SystemColors.HighlightText;
            style.WrapMode = DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = style;
            this.dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewColumn[] dataGridViewColumns = new DataGridViewColumn[] { this.id, this.codigo, this.nombre, this.cobertura, this.idUnique };
            this.dataGridView.Columns.AddRange(dataGridViewColumns);
            this.dataGridView.Location = new Point(0x20, 0x11d);
            this.dataGridView.Margin = new Padding(0);
            this.dataGridView.Name = "dataGridView";
            style2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style2.BackColor = SystemColors.Control;
            style2.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            style2.ForeColor = SystemColors.WindowText;
            style2.SelectionBackColor = SystemColors.Highlight;
            style2.SelectionForeColor = SystemColors.HighlightText;
            style2.WrapMode = DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = style2;
            this.dataGridView.Size = new Size(0x3f5, 0xf2);
            this.dataGridView.TabIndex = 0x83;
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.Visible = false;
            this.codigo.HeaderText = "Codigo";
            this.codigo.Name = "codigo";
            this.nombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.cobertura.HeaderText = "Cobertura";
            this.cobertura.Name = "cobertura";
            this.cobertura.Resizable = DataGridViewTriState.True;
            this.cobertura.SortMode = DataGridViewColumnSortMode.Automatic;
            this.idUnique.HeaderText = "idUnique";
            this.idUnique.Name = "idUnique";
            this.idUnique.Visible = false;
            this.label10.AutoSize = true;
            this.label10.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label10.Location = new Point(0xdd, 0x63);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x36, 0x10);
            this.label10.TabIndex = 0x7e;
            this.label10.Text = "Historia:";
            this.label8.AutoSize = true;
            this.label8.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label8.Location = new Point(0x1d, 100);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x22, 0x10);
            this.label8.TabIndex = 0x7d;
            this.label8.Text = "DNI:";
            this.label4.AutoSize = true;
            this.label4.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label4.Location = new Point(0x1d, 0x3f);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x3b, 0x10);
            this.label4.TabIndex = 0x7c;
            this.label4.Text = "Nombre:";
            this.CampBoleta.AutoSize = true;
            this.CampBoleta.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampBoleta.Location = new Point(0x1bd, 0xd3);
            this.CampBoleta.Name = "CampBoleta";
            this.CampBoleta.Size = new Size(0x1b, 0x10);
            this.CampBoleta.TabIndex = 0x8f;
            this.CampBoleta.Text = "asd";
            this.PickerTime.AutoSize = true;
            this.PickerTime.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.PickerTime.Location = new Point(0x265, 0xd3);
            this.PickerTime.Name = "PickerTime";
            this.PickerTime.Size = new Size(0x1b, 0x10);
            this.PickerTime.TabIndex = 0x90;
            this.PickerTime.Text = "asd";
            this.label5.AutoSize = true;
            this.label5.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label5.Location = new Point(0x181, 0x63);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x27, 0x10);
            this.label5.TabIndex = 0x91;
            this.label5.Text = "Sexo:";
            this.CampSexo.AutoSize = true;
            this.CampSexo.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampSexo.Location = new Point(0x1bd, 0x63);
            this.CampSexo.Name = "CampSexo";
            this.CampSexo.Size = new Size(0x33, 0x10);
            this.CampSexo.TabIndex = 0x92;
            this.CampSexo.Text = "label11";
            this.CampGestacion.AutoSize = true;
            this.CampGestacion.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampGestacion.Location = new Point(0x265, 0x63);
            this.CampGestacion.Name = "CampGestacion";
            this.CampGestacion.Size = new Size(0x33, 0x10);
            this.CampGestacion.TabIndex = 0x94;
            this.CampGestacion.Text = "label11";
            this.LabelGestacion.AutoSize = true;
            this.LabelGestacion.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.LabelGestacion.Location = new Point(0x20d, 0x63);
            this.LabelGestacion.Name = "LabelGestacion";
            this.LabelGestacion.Size = new Size(0x52, 0x10);
            this.LabelGestacion.TabIndex = 0x93;
            this.LabelGestacion.Text = "En gestacion:";
            this.CampMedico.AutoSize = true;
            this.CampMedico.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampMedico.Location = new Point(110, 0xae);
            this.CampMedico.Name = "CampMedico";
            this.CampMedico.Size = new Size(0x1b, 0x10);
            this.CampMedico.TabIndex = 150;
            this.CampMedico.Text = "asd";
            this.label14.AutoSize = true;
            this.label14.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label14.Location = new Point(0x1d, 0xae);
            this.label14.Name = "label14";
            this.label14.Size = new Size(0x35, 0x10);
            this.label14.TabIndex = 0x95;
            this.label14.Text = "Medico:";
            this.CampConsultorio.AutoSize = true;
            this.CampConsultorio.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampConsultorio.Location = new Point(110, 0xd3);
            this.CampConsultorio.Name = "CampConsultorio";
            this.CampConsultorio.Size = new Size(0x1b, 0x10);
            this.CampConsultorio.TabIndex = 0x98;
            this.CampConsultorio.Text = "asd";
            this.label16.AutoSize = true;
            this.label16.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label16.Location = new Point(0x1d, 0xd3);
            this.label16.Name = "label16";
            this.label16.Size = new Size(0x4b, 0x10);
            this.label16.TabIndex = 0x97;
            this.label16.Text = "Consultorio:";
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.Location = new Point(0x1c, 0xfb);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x9e, 0x13);
            this.label2.TabIndex = 0xc5;
            this.label2.Text = "Examenes Solicitados";
            this.BtnCerrar.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.BtnCerrar.FlatAppearance.BorderColor = Color.DimGray;
            this.BtnCerrar.FlatAppearance.BorderSize = 0;
            this.BtnCerrar.FlatStyle = FlatStyle.Flat;
            this.BtnCerrar.Font = new Font("Futura Bk BT", 8.25f);
            this.BtnCerrar.ForeColor = SystemColors.Window;
           // this.BtnCerrar.Image = Resources.icon_cerrar;
            this.BtnCerrar.Location = new Point(0x412, 12);
            this.BtnCerrar.Margin = new Padding(0);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Padding = new Padding(5);
            this.BtnCerrar.Size = new Size(20, 20);
            this.BtnCerrar.TabIndex = 0xc9;
            this.BtnCerrar.TextAlign = ContentAlignment.MiddleLeft;
            this.BtnCerrar.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.BtnCerrar.UseVisualStyleBackColor = false;
            this.BtnCerrar.Click += new EventHandler(this.BtnCerrar_Click);
            this.BtnEdit.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.BtnEdit.FlatAppearance.BorderColor = Color.DimGray;
            this.BtnEdit.FlatAppearance.BorderSize = 0;
            this.BtnEdit.FlatStyle = FlatStyle.Flat;
            this.BtnEdit.Font = new Font("Futura Bk BT", 8.25f);
            this.BtnEdit.ForeColor = SystemColors.Window;
          //this.BtnEdit.Image = Resources.icon_edit;
            this.BtnEdit.Location = new Point(0x3f5, 12);
            this.BtnEdit.Margin = new Padding(0);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Padding = new Padding(5);
            this.BtnEdit.Size = new Size(20, 20);
            this.BtnEdit.TabIndex = 0xca;
            this.BtnEdit.TextAlign = ContentAlignment.MiddleLeft;
            this.BtnEdit.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.BtnEdit.UseVisualStyleBackColor = false;
            this.BtnEdit.Click += new EventHandler(this.BtnEdit_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = SystemColors.Window;
            base.Controls.Add(this.BtnEdit);
            base.Controls.Add(this.BtnCerrar);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.CampConsultorio);
            base.Controls.Add(this.label16);
            base.Controls.Add(this.CampMedico);
            base.Controls.Add(this.label14);
            base.Controls.Add(this.CampGestacion);
            base.Controls.Add(this.LabelGestacion);
            base.Controls.Add(this.CampSexo);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.PickerTime);
            base.Controls.Add(this.CampBoleta);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.CampUbicacion);
            base.Controls.Add(this.label12);
            base.Controls.Add(this.label9);
            base.Controls.Add(this.CampHistoria);
            base.Controls.Add(this.CampDni);
            base.Controls.Add(this.CampNombre);
            base.Controls.Add(this.dataGridView);
            base.Controls.Add(this.label10);
            base.Controls.Add(this.label8);
            base.Controls.Add(this.label4);
            base.Name = "PanelOrdenPerfil";
            base.Size = new Size(0x435, 0x228);
            ((ISupportInitialize)this.dataGridView).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }



        #endregion

        private Button BtnCerrar;
        private Button BtnEdit;
        private Label CampBoleta;
        private Label CampConsultorio;
        private Label CampDni;
        private Label CampGestacion;
        private Label CampHistoria;
        private Label CampMedico;
        private Label CampNombre;
        private Label CampSexo;
        private Label CampUbicacion;
        private DataGridViewComboBoxColumn cobertura;
        private DataGridViewTextBoxColumn codigo;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn idUnique;
        private Label label1;
        private Label label10;
        private Label label12;
        private Label label14;
        private Label label16;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label8;
        private Label label9;
        private Label LabelGestacion;
        private DataGridViewTextBoxColumn nombre;
        private Label PickerTime;

    }
}
