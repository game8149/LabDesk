using System.Drawing;
using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace LabDesk.Code.Components.Laboratory.Prices
{
    partial class FormTarifario
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FormTarifario));
            this.DGVTar = new DataGridView();
            this.id = new DataGridViewTextBoxColumn();
            this.examen = new DataGridViewTextBoxColumn();
            this.precio = new DataGridViewTextBoxColumn();
            this.label2 = new Label();
            this.PanelBarTable = new Panel();
            this.CampRegistro = new Label();
            this.CheckBoxTarifarioVigente = new CheckBox();
            this.label1 = new Label();
            this.BtnPrint = new Button();
            this.ComboBoxAno = new ComboBox();
            this.label7 = new Label();
            this.label12 = new Label();
            this.menuStrip1 = new MenuStrip();
            this.archivoToolStripMenuItem = new ToolStripMenuItem();
            this.nuevoTarifarioToolStripMenuItem = new ToolStripMenuItem();
            this.transferirTarifarioToolStripMenuItem = new ToolStripMenuItem();
            this.BtnTarifarioModificar = new Button();
            this.BtnTarifarioSave = new Button();
            this.BtnCerrar = new Button();
            this.label3 = new Label();
            this.panel5 = new Panel();
            ((ISupportInitialize)this.DGVTar).BeginInit();
            this.PanelBarTable.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            base.SuspendLayout();
            this.DGVTar.AllowUserToAddRows = false;
            this.DGVTar.AllowUserToDeleteRows = false;
            this.DGVTar.BorderStyle = BorderStyle.None;
            this.DGVTar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewColumn[] dataGridViewColumns = new DataGridViewColumn[] { this.id, this.examen, this.precio };
            this.DGVTar.Columns.AddRange(dataGridViewColumns);
            this.DGVTar.Location = new Point(0x113, 0x68);
            this.DGVTar.Margin = new Padding(0);
            this.DGVTar.Name = "DGVTar";
            this.DGVTar.Size = new Size(0x195, 0x198);
            this.DGVTar.TabIndex = 0;
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            this.examen.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.examen.HeaderText = "Examen";
            this.examen.Name = "examen";
            this.precio.HeaderText = "Precio";
            this.precio.Name = "precio";
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Futura Bk BT", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.Location = new Point(0x110, 0x20d);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0xfe, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nota: Sea prudente al manipular esta informaci\x00f3n. ";
            this.PanelBarTable.BackColor = Color.SteelBlue;
            this.PanelBarTable.BorderStyle = BorderStyle.FixedSingle;
            this.PanelBarTable.Controls.Add(this.CampRegistro);
            this.PanelBarTable.Controls.Add(this.CheckBoxTarifarioVigente);
            this.PanelBarTable.Controls.Add(this.label1);
            this.PanelBarTable.Controls.Add(this.BtnPrint);
            this.PanelBarTable.Location = new Point(0x113, 0x48);
            this.PanelBarTable.Margin = new Padding(0);
            this.PanelBarTable.Name = "PanelBarTable";
            this.PanelBarTable.Size = new Size(0x195, 0x20);
            this.PanelBarTable.TabIndex = 0x67;
            this.CampRegistro.AutoSize = true;
            this.CampRegistro.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampRegistro.ForeColor = SystemColors.ControlLightLight;
            this.CampRegistro.Location = new Point(0x42, 8);
            this.CampRegistro.Name = "CampRegistro";
            this.CampRegistro.Size = new Size(0x3a, 0x10);
            this.CampRegistro.TabIndex = 0x52;
            this.CampRegistro.Text = "--/--/----";
            this.CheckBoxTarifarioVigente.AutoSize = true;
            this.CheckBoxTarifarioVigente.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CheckBoxTarifarioVigente.ForeColor = SystemColors.ControlLightLight;
            this.CheckBoxTarifarioVigente.Location = new Point(0x144, 6);
            this.CheckBoxTarifarioVigente.Name = "CheckBoxTarifarioVigente";
            this.CheckBoxTarifarioVigente.RightToLeft = RightToLeft.Yes;
            this.CheckBoxTarifarioVigente.Size = new Size(0x45, 20);
            this.CheckBoxTarifarioVigente.TabIndex = 0x54;
            this.CheckBoxTarifarioVigente.Text = "Vigente";
            this.CheckBoxTarifarioVigente.UseVisualStyleBackColor = true;
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.ForeColor = SystemColors.ControlLightLight;
            this.label1.Location = new Point(14, 8);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x2e, 0x10);
            this.label1.TabIndex = 0x51;
            this.label1.Text = "Fecha:";
            this.BtnPrint.FlatAppearance.BorderSize = 0;
            this.BtnPrint.FlatAppearance.CheckedBackColor = Color.DeepSkyBlue;
            this.BtnPrint.FlatStyle = FlatStyle.Flat;
            this.BtnPrint.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.BtnPrint.ForeColor = SystemColors.Info;
            //this.BtnPrint.Image = Resources.icon_printer;
            this.BtnPrint.Location = new Point(0x3e4, -1);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new Size(0x21, 0x20);
            this.BtnPrint.TabIndex = 5;
            this.BtnPrint.UseVisualStyleBackColor = false;
            this.BtnPrint.Visible = false;
            this.ComboBoxAno.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ComboBoxAno.FormattingEnabled = true;
            this.ComboBoxAno.Location = new Point(0x40, 0x4e);
            this.ComboBoxAno.Name = "ComboBoxAno";
            this.ComboBoxAno.Size = new Size(0x62, 0x15);
            this.ComboBoxAno.TabIndex = 0x4e;
            this.ComboBoxAno.SelectedIndexChanged += new EventHandler(this.ComboBoxAno_SelectedIndexChanged);
            this.label7.AutoSize = true;
            this.label7.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label7.ForeColor = SystemColors.WindowText;
            this.label7.Location = new Point(0x18, 80);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x22, 0x10);
            this.label7.TabIndex = 0x42;
            this.label7.Text = "A\x00f1o:";
            this.label12.AutoSize = true;
            this.label12.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label12.Location = new Point(0x10f, 0x29);
            this.label12.Name = "label12";
            this.label12.Size = new Size(0x9b, 0x13);
            this.label12.TabIndex = 0xda;
            this.label12.Text = "Listado de Examenes";
            ToolStripItem[] toolStripItems = new ToolStripItem[] { this.archivoToolStripMenuItem };
            this.menuStrip1.Items.AddRange(toolStripItems);
            this.menuStrip1.Location = new Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new Size(0x2ba, 0x18);
            this.menuStrip1.TabIndex = 220;
            this.menuStrip1.Text = "menuStrip1";
            ToolStripItem[] itemArray2 = new ToolStripItem[] { this.nuevoTarifarioToolStripMenuItem, this.transferirTarifarioToolStripMenuItem };
            this.archivoToolStripMenuItem.DropDownItems.AddRange(itemArray2);
            this.archivoToolStripMenuItem.ForeColor = SystemColors.ActiveCaptionText;
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            this.nuevoTarifarioToolStripMenuItem.Name = "nuevoTarifarioToolStripMenuItem";
            this.nuevoTarifarioToolStripMenuItem.Size = new Size(0xa9, 0x16);
            this.nuevoTarifarioToolStripMenuItem.Text = "Nuevo Tarifario";
            this.nuevoTarifarioToolStripMenuItem.Click += new EventHandler(this.nuevoTarifarioToolStripMenuItem_Click);
            this.transferirTarifarioToolStripMenuItem.Name = "transferirTarifarioToolStripMenuItem";
            this.transferirTarifarioToolStripMenuItem.Size = new Size(0xa9, 0x16);
            this.transferirTarifarioToolStripMenuItem.Text = "Transferir Tarifario";
            this.transferirTarifarioToolStripMenuItem.Click += new EventHandler(this.transferirTarifarioToolStripMenuItem_Click);
            this.BtnTarifarioModificar.AutoSize = true;
            this.BtnTarifarioModificar.FlatAppearance.BorderSize = 0;
            this.BtnTarifarioModificar.FlatStyle = FlatStyle.Flat;
           // this.BtnTarifarioModificar.Image = Resources.icon_edit;
            this.BtnTarifarioModificar.Location = new Point(0x289, 0x23);
            this.BtnTarifarioModificar.Margin = new Padding(3, 4, 3, 4);
            this.BtnTarifarioModificar.Name = "BtnTarifarioModificar";
            this.BtnTarifarioModificar.Size = new Size(0x1f, 30);
            this.BtnTarifarioModificar.TabIndex = 0x4c;
            this.BtnTarifarioModificar.UseVisualStyleBackColor = true;
            this.BtnTarifarioModificar.Visible = false;
            this.BtnTarifarioModificar.Click += new EventHandler(this.BtnModificar_Click);
            this.BtnTarifarioSave.AutoSize = true;
            this.BtnTarifarioSave.FlatAppearance.BorderSize = 0;
            this.BtnTarifarioSave.FlatStyle = FlatStyle.Flat;
           // this.BtnTarifarioSave.Image = Resources.icon_guardar;
            this.BtnTarifarioSave.Location = new Point(0x268, 0x23);
            this.BtnTarifarioSave.Margin = new Padding(3, 4, 3, 4);
            this.BtnTarifarioSave.Name = "BtnTarifarioSave";
            this.BtnTarifarioSave.Size = new Size(0x1f, 30);
            this.BtnTarifarioSave.TabIndex = 0x4b;
            this.BtnTarifarioSave.UseVisualStyleBackColor = true;
            this.BtnTarifarioSave.Visible = false;
            this.BtnTarifarioSave.Click += new EventHandler(this.BtnSave_Click);
            this.BtnCerrar.AutoSize = true;
            this.BtnCerrar.FlatAppearance.BorderSize = 0;
            this.BtnCerrar.FlatStyle = FlatStyle.Flat;
            //this.BtnCerrar.Image = Resources.icon_cerrar;
            this.BtnCerrar.Location = new Point(0x289, 0x23);
            this.BtnCerrar.Margin = new Padding(3, 4, 3, 4);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new Size(0x1f, 30);
            this.BtnCerrar.TabIndex = 0x4d;
            this.BtnCerrar.UseVisualStyleBackColor = true;
            this.BtnCerrar.Visible = false;
            this.BtnCerrar.Click += new EventHandler(this.BtnCerrar_Click);
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label3.Location = new Point(0x17, 40);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0xa3, 0x13);
            this.label3.TabIndex = 0xdd;
            this.label3.Text = "Tarifarios Disponibles";
            this.panel5.BackColor = SystemColors.ScrollBar;
            this.panel5.Location = new Point(0xf7, 0x1c);
            this.panel5.Margin = new Padding(3, 4, 3, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new Size(1, 520);
            this.panel5.TabIndex = 0xde;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = SystemColors.Window;
            base.ClientSize = new Size(0x2ba, 0x22b);
            base.Controls.Add(this.panel5);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label12);
            base.Controls.Add(this.PanelBarTable);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.ComboBoxAno);
            base.Controls.Add(this.BtnTarifarioModificar);
            base.Controls.Add(this.label7);
            base.Controls.Add(this.DGVTar);
            base.Controls.Add(this.BtnTarifarioSave);
            base.Controls.Add(this.BtnCerrar);
            base.Controls.Add(this.menuStrip1);
//            base.Icon = (Icon)manager.GetObject("$this.Icon");
            base.MainMenuStrip = this.menuStrip1;
            base.MaximizeBox = false;
            base.Name = "FormTarifario";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Tarifario";
            ((ISupportInitialize)this.DGVTar).EndInit();
            this.PanelBarTable.ResumeLayout(false);
            this.PanelBarTable.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion

        private ToolStripMenuItem archivoToolStripMenuItem;
        private Button BtnCerrar;
        private Button BtnPrint;
        private Button BtnTarifarioModificar;
        private Button BtnTarifarioSave;
        private Label CampRegistro;
        private CheckBox CheckBoxTarifarioVigente;
        private ComboBox ComboBoxAno;
        private DataGridView DGVTar;
        private DataGridViewTextBoxColumn examen;
        private DataGridViewTextBoxColumn id;
        private Label label1;
        private Label label12;
        private Label label2;
        private Label label3;
        private Label label7;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem nuevoTarifarioToolStripMenuItem;
        private Panel panel5;
        private Panel PanelBarTable;
        private ToolStripMenuItem transferirTarifarioToolStripMenuItem;
        private DataGridViewTextBoxColumn precio;
    }
}