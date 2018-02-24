using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace LabDesk.Code.Components.Main.Panels
{
    partial class ControlContabilidad
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(ControlContabilidad));
            this.PanelLateral = new Panel();
            this.label5 = new Label();
            this.LinkLabelTarifario = new LinkLabel();
            this.label2 = new Label();
            this.ComboBoxTipo = new ComboBox();
            this.label7 = new Label();
            this.ComboBoxMes = new ComboBox();
            this.LabelDescEconomico = new Label();
            this.NumericUD = new NumericUpDown();
            this.label4 = new Label();
            this.label3 = new Label();
            this.label8 = new Label();
            this.LabelDescResultado = new Label();
            this.ComboBoxFiltro = new ComboBox();
            this.DialogFolderBuscar = new FolderBrowserDialog();
            this.BtnUIContabilidad1 = new ButtonUI();
            this.PanelLateral.SuspendLayout();
            this.NumericUD.BeginInit();
            base.SuspendLayout();
            this.PanelLateral.Anchor = AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
            this.PanelLateral.BackColor = Color.SlateGray;
            this.PanelLateral.Controls.Add(this.label5);
            this.PanelLateral.Controls.Add(this.LinkLabelTarifario);
            this.PanelLateral.Location = new Point(0x32b, 0);
            this.PanelLateral.Margin = new Padding(0);
            this.PanelLateral.Name = "PanelLateral";
            this.PanelLateral.Size = new Size(0x10a, 0x22a);
            this.PanelLateral.TabIndex = 0xa8;
            this.label5.AutoSize = true;
            this.label5.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label5.ForeColor = SystemColors.ControlLightLight;
            this.label5.Location = new Point(0x16, 0x18);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0xbd, 0x13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Administraci\x00f3n de Tarifas";
            this.LinkLabelTarifario.ActiveLinkColor = Color.White;
            this.LinkLabelTarifario.AutoSize = true;
            this.LinkLabelTarifario.Cursor = Cursors.Hand;
            this.LinkLabelTarifario.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.LinkLabelTarifario.ForeColor = SystemColors.ControlLightLight;
            this.LinkLabelTarifario.LinkColor = Color.White;
            this.LinkLabelTarifario.Location = new Point(0x17, 0x41);
            this.LinkLabelTarifario.Name = "LinkLabelTarifario";
            this.LinkLabelTarifario.Size = new Size(0x9d, 0x10);
            this.LinkLabelTarifario.TabIndex = 0xa3;
            this.LinkLabelTarifario.TabStop = true;
            this.LinkLabelTarifario.Text = "Configuraci\x00f3n de Tarifario";
            this.LinkLabelTarifario.LinkClicked += new LinkLabelLinkClickedEventHandler(this.LinkLabelTarifario_LinkClicked);
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.ForeColor = SystemColors.MenuText;
            this.label2.Location = new Point(0x16, 0x42);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x24, 0x10);
            this.label2.TabIndex = 0xa7;
            this.label2.Text = "Tipo:";
            this.ComboBoxTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ComboBoxTipo.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.ComboBoxTipo.FormattingEnabled = true;
            object[] items = new object[] { "General", "Por Edad", "Por Medico" };
            this.ComboBoxTipo.Items.AddRange(items);
            this.ComboBoxTipo.Location = new Point(0x5f, 0x3e);
            this.ComboBoxTipo.Name = "ComboBoxTipo";
            this.ComboBoxTipo.Size = new Size(0x93, 0x18);
            this.ComboBoxTipo.TabIndex = 0xa6;
            this.ComboBoxTipo.SelectedIndexChanged += new EventHandler(this.ComboBoxTipo_SelectedIndexChanged);
            this.label7.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label7.ForeColor = SystemColors.WindowText;
            this.label7.Location = new Point(0x15, 15);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0xf9, 30);
            this.label7.TabIndex = 0xa5;
            this.label7.Text = "Generador de Reporte";
            this.label7.TextAlign = ContentAlignment.MiddleLeft;
            this.ComboBoxMes.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ComboBoxMes.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.ComboBoxMes.FormattingEnabled = true;
            this.ComboBoxMes.Location = new Point(0x5f, 0xac);
            this.ComboBoxMes.Margin = new Padding(3, 2, 3, 2);
            this.ComboBoxMes.Name = "ComboBoxMes";
            this.ComboBoxMes.Size = new Size(0x93, 0x18);
            this.ComboBoxMes.TabIndex = 0x7d;
            this.LabelDescEconomico.Font = new Font("Futura Bk BT", 9.5f);
            this.LabelDescEconomico.Location = new Point(0x16, 0xf1);
            this.LabelDescEconomico.Name = "LabelDescEconomico";
            this.LabelDescEconomico.Size = new Size(0x2f6, 0xce);
            this.LabelDescEconomico.TabIndex = 150;
//            this.LabelDescEconomico.Text = manager.GetString("LabelDescEconomico.Text");
            this.NumericUD.BorderStyle = BorderStyle.FixedSingle;
            this.NumericUD.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.NumericUD.Location = new Point(0x5f, 0x88);
            int[] bits = new int[4];
            bits[0] = 0x802;
            this.NumericUD.Maximum = new decimal(bits);
            int[] numArray2 = new int[4];
            numArray2[0] = 0x7e0;
            this.NumericUD.Minimum = new decimal(numArray2);
            this.NumericUD.Name = "NumericUD";
            this.NumericUD.Size = new Size(0x93, 0x17);
            this.NumericUD.TabIndex = 0x80;
            this.NumericUD.TextAlign = HorizontalAlignment.Center;
            int[] numArray3 = new int[4];
            numArray3[0] = 0x7e0;
            this.NumericUD.Value = new decimal(numArray3);
            this.label4.AutoSize = true;
            this.label4.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label4.ForeColor = SystemColors.MenuText;
            this.label4.Location = new Point(0x16, 0x8b);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x22, 0x10);
            this.label4.TabIndex = 0x7f;
            this.label4.Text = "A\x00f1o:";
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label3.ForeColor = SystemColors.MenuText;
            this.label3.Location = new Point(0x16, 0xb0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x23, 0x10);
            this.label3.TabIndex = 0x7e;
            this.label3.Text = "Mes:";
            this.label8.AutoSize = true;
            this.label8.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label8.ForeColor = SystemColors.MenuText;
            this.label8.Location = new Point(0x16, 0x67);
            this.label8.Name = "label8";
            this.label8.Size = new Size(40, 0x10);
            this.label8.TabIndex = 140;
            this.label8.Text = "Filtro:";
            this.LabelDescResultado.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.LabelDescResultado.Font = new Font("Futura Bk BT", 9.5f);
            this.LabelDescResultado.Location = new Point(0x16, 0xf1);
            this.LabelDescResultado.Name = "LabelDescResultado";
            this.LabelDescResultado.Size = new Size(0x2f6, 0xce);
            this.LabelDescResultado.TabIndex = 0x97;
//            this.LabelDescResultado.Text = manager.GetString("LabelDescResultado.Text");
            this.ComboBoxFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ComboBoxFiltro.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.ComboBoxFiltro.FormattingEnabled = true;
            object[] objArray2 = new object[] { "General", "Por Edad", "Por Medico" };
            this.ComboBoxFiltro.Items.AddRange(objArray2);
            this.ComboBoxFiltro.Location = new Point(0x5f, 0x63);
            this.ComboBoxFiltro.Name = "ComboBoxFiltro";
            this.ComboBoxFiltro.Size = new Size(0x93, 0x18);
            this.ComboBoxFiltro.TabIndex = 0x8b;
            this.BtnUIContabilidad1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.BtnUIContabilidad1.AutoSize = true;
            this.BtnUIContabilidad1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BtnUIContabilidad1.BackColor = SystemColors.ActiveCaptionText;
            this.BtnUIContabilidad1.Location = new Point(0x29c, 0x1e4);
            this.BtnUIContabilidad1.Margin = new Padding(0);
            this.BtnUIContabilidad1.Name = "BtnUIContabilidad1";
            this.BtnUIContabilidad1.Size = new Size(0x70, 40);
            this.BtnUIContabilidad1.TabIndex = 0xa9;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = SystemColors.Window;
            base.Controls.Add(this.BtnUIContabilidad1);
            base.Controls.Add(this.PanelLateral);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.ComboBoxFiltro);
            base.Controls.Add(this.ComboBoxTipo);
            base.Controls.Add(this.LabelDescResultado);
            base.Controls.Add(this.label7);
            base.Controls.Add(this.label8);
            base.Controls.Add(this.ComboBoxMes);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.LabelDescEconomico);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.NumericUD);
            base.Margin = new Padding(0);
            base.Name = "ControlContabilidad";
            base.Size = new Size(0x435, 0x228);
            base.Load += new EventHandler(this.ControlContabilidad_Load);
            this.PanelLateral.ResumeLayout(false);
            this.PanelLateral.PerformLayout();
            this.NumericUD.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }


        #endregion

        private ButtonUI BtnUIContabilidad1;
        private ComboBox ComboBoxFiltro;
        private ComboBox ComboBoxMes;
        private ComboBox ComboBoxTipo;
        private FolderBrowserDialog DialogFolderBuscar;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label7;
        private Label label8;
        private Label LabelDescEconomico;
        private Label LabelDescResultado;
        private LinkLabel LinkLabelTarifario;
        private NumericUpDown NumericUD;
        private Panel PanelLateral;
    }
}
