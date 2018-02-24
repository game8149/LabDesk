using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Actors.Medico
{
    partial class PanelMedicoNuevo
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(PanelMedicoNuevo));
            this.CheckBoxHabil = new CheckBox();
            this.label12 = new Label();
            this.panel1 = new Panel();
            this.label13 = new Label();
            this.label1 = new Label();
            this.label9 = new Label();
            this.CampColegiatura = new TextBox();
            this.label6 = new Label();
            this.label2 = new Label();
            this.CampEspecialidad = new TextBox();
            this.label3 = new Label();
            this.campNombre = new TextBox();
            this.label11 = new Label();
            this.CampSegundoApellido = new TextBox();
            this.CampPrimerApellido = new TextBox();
            this.BtnPerfilCrearCerrar = new Button();
            this.label19 = new Label();
            this.label16 = new Label();
            this.label17 = new Label();
            this.label15 = new Label();
            this.label14 = new Label();
            this.BtnUIMedicoNuevo1 = new ButtonUI();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.CheckBoxHabil.AutoSize = true;
            this.CheckBoxHabil.Font = new Font("Futura Bk BT", 9.25f);
            this.CheckBoxHabil.Location = new Point(0x18a, 0x4b);
            this.CheckBoxHabil.Name = "CheckBoxHabil";
            this.CheckBoxHabil.RightToLeft = RightToLeft.Yes;
            this.CheckBoxHabil.Size = new Size(60, 20);
            this.CheckBoxHabil.TabIndex = 6;
            this.CheckBoxHabil.Text = ":Habil";
            this.CheckBoxHabil.TextAlign = ContentAlignment.MiddleRight;
            this.CheckBoxHabil.UseVisualStyleBackColor = true;
            this.label12.AutoSize = true;
            this.label12.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label12.Location = new Point(0x1c, 0x1c);
            this.label12.Name = "label12";
            this.label12.Size = new Size(0x9f, 0x13);
            this.label12.TabIndex = 0x98;
            this.label12.Text = "Informaci\x00f3n Personal";
            this.panel1.Anchor = AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
            this.panel1.BorderStyle = BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new Point(0x323, 0x49);
            this.panel1.Margin = new Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0xf2, 0x183);
            this.panel1.TabIndex = 0x99;
            this.label13.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.label13.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label13.Location = new Point(0x13, 50);
            this.label13.Name = "label13";
            this.label13.Size = new Size(0xcd, 0xcc);
            this.label13.TabIndex = 0x7e;
//            this.label13.Text = manager.GetString("label13.Text");
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.Location = new Point(0x13, 0x13);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0xac, 0x13);
            this.label1.TabIndex = 0x7b;
            this.label1.Text = "Indicaciones Generales";
            this.label9.AutoSize = true;
            this.label9.Font = new Font("Futura Bk BT", 9.75f);
            this.label9.Location = new Point(0x1d, 0x4c);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x4d, 0x10);
            this.label9.TabIndex = 0x97;
            this.label9.Text = "Colegiatura:";
            this.CampColegiatura.Font = new Font("Futura Bk BT", 9.75f);
            this.CampColegiatura.Location = new Point(180, 0x49);
            this.CampColegiatura.MaxLength = 10;
            this.CampColegiatura.Name = "CampColegiatura";
            this.CampColegiatura.Size = new Size(0x95, 0x17);
            this.CampColegiatura.TabIndex = 1;
            this.CampColegiatura.TextChanged += new EventHandler(this.CampColegiatura_TextChanged);
            this.label6.AutoSize = true;
            this.label6.Font = new Font("Futura Bk BT", 9.75f);
            this.label6.Location = new Point(0x1d, 0xec);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x51, 0x10);
            this.label6.TabIndex = 150;
            this.label6.Text = "Especialidad:";
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Futura Bk BT", 9.75f);
            this.label2.Location = new Point(0x1d, 0x74);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x3b, 0x10);
            this.label2.TabIndex = 0x93;
            this.label2.Text = "Nombre:";
            this.CampEspecialidad.Font = new Font("Futura Bk BT", 9.75f);
            this.CampEspecialidad.Location = new Point(0xaf, 0xe9);
            this.CampEspecialidad.MaxLength = 50;
            this.CampEspecialidad.Name = "CampEspecialidad";
            this.CampEspecialidad.Size = new Size(0x176, 0x17);
            this.CampEspecialidad.TabIndex = 5;
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Futura Bk BT", 9.75f);
            this.label3.Location = new Point(0x1d, 0xc4);
            this.label3.Name = "label3";
            this.label3.Size = new Size(110, 0x10);
            this.label3.TabIndex = 0x95;
            this.label3.Text = "Segundo Apellido:";
            this.campNombre.Font = new Font("Futura Bk BT", 9.75f);
            this.campNombre.Location = new Point(0xaf, 0x71);
            this.campNombre.MaxLength = 100;
            this.campNombre.Name = "campNombre";
            this.campNombre.Size = new Size(0x176, 0x17);
            this.campNombre.TabIndex = 2;
            this.label11.AutoSize = true;
            this.label11.Font = new Font("Futura Bk BT", 9.75f);
            this.label11.Location = new Point(0x1d, 0x9c);
            this.label11.Name = "label11";
            this.label11.Size = new Size(0x63, 0x10);
            this.label11.TabIndex = 0x94;
            this.label11.Text = "Primer Apellido:";
            this.CampSegundoApellido.Font = new Font("Futura Bk BT", 9.75f);
            this.CampSegundoApellido.Location = new Point(0xaf, 0xc1);
            this.CampSegundoApellido.MaxLength = 100;
            this.CampSegundoApellido.Name = "CampSegundoApellido";
            this.CampSegundoApellido.Size = new Size(0x176, 0x17);
            this.CampSegundoApellido.TabIndex = 4;
            this.CampPrimerApellido.Font = new Font("Futura Bk BT", 9.75f);
            this.CampPrimerApellido.Location = new Point(0xaf, 0x99);
            this.CampPrimerApellido.MaxLength = 100;
            this.CampPrimerApellido.Name = "CampPrimerApellido";
            this.CampPrimerApellido.Size = new Size(0x176, 0x17);
            this.CampPrimerApellido.TabIndex = 3;
            this.BtnPerfilCrearCerrar.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.BtnPerfilCrearCerrar.FlatAppearance.BorderColor = Color.DimGray;
            this.BtnPerfilCrearCerrar.FlatAppearance.BorderSize = 0;
            this.BtnPerfilCrearCerrar.FlatStyle = FlatStyle.Flat;
            this.BtnPerfilCrearCerrar.Font = new Font("Futura Bk BT", 8.25f);
            this.BtnPerfilCrearCerrar.ForeColor = SystemColors.Window;
           // this.BtnPerfilCrearCerrar.Image = Resources.icon_cerrar;
            this.BtnPerfilCrearCerrar.Location = new Point(0x412, 12);
            this.BtnPerfilCrearCerrar.Margin = new Padding(0);
            this.BtnPerfilCrearCerrar.Name = "BtnPerfilCrearCerrar";
            this.BtnPerfilCrearCerrar.Padding = new Padding(5);
            this.BtnPerfilCrearCerrar.Size = new Size(20, 20);
            this.BtnPerfilCrearCerrar.TabIndex = 0xa9;
            this.BtnPerfilCrearCerrar.TextAlign = ContentAlignment.MiddleLeft;
            this.BtnPerfilCrearCerrar.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.BtnPerfilCrearCerrar.UseVisualStyleBackColor = false;
            this.BtnPerfilCrearCerrar.Click += new EventHandler(this.BtnPerfilCrearCerrar_Click);
            this.label19.AutoSize = true;
            this.label19.BackColor = Color.Transparent;
            this.label19.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label19.ForeColor = SystemColors.GrayText;
            this.label19.Location = new Point(0x22b, 0xea);
            this.label19.Name = "label19";
            this.label19.Size = new Size(0x1a, 0x13);
            this.label19.TabIndex = 220;
            this.label19.Text = "(*)";
            this.label16.AutoSize = true;
            this.label16.BackColor = Color.Transparent;
            this.label16.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label16.ForeColor = SystemColors.GrayText;
            this.label16.Location = new Point(0x22b, 0xc2);
            this.label16.Name = "label16";
            this.label16.Size = new Size(0x1a, 0x13);
            this.label16.TabIndex = 0xdb;
            this.label16.Text = "(*)";
            this.label17.AutoSize = true;
            this.label17.BackColor = Color.Transparent;
            this.label17.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label17.ForeColor = SystemColors.GrayText;
            this.label17.Location = new Point(0x22b, 0x9a);
            this.label17.Name = "label17";
            this.label17.Size = new Size(0x1a, 0x13);
            this.label17.TabIndex = 0xda;
            this.label17.Text = "(*)";
            this.label15.AutoSize = true;
            this.label15.BackColor = Color.Transparent;
            this.label15.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label15.ForeColor = SystemColors.GrayText;
            this.label15.Location = new Point(0x22b, 0x72);
            this.label15.Name = "label15";
            this.label15.Size = new Size(0x1a, 0x13);
            this.label15.TabIndex = 0xd9;
            this.label15.Text = "(*)";
            this.label14.AutoSize = true;
            this.label14.BackColor = Color.Transparent;
            this.label14.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label14.ForeColor = SystemColors.GrayText;
            this.label14.Location = new Point(0x14f, 0x4a);
            this.label14.Name = "label14";
            this.label14.Size = new Size(0x1a, 0x13);
            this.label14.TabIndex = 0xd8;
            this.label14.Text = "(*)";
            this.BtnUIMedicoNuevo1.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.BtnUIMedicoNuevo1.AutoSize = true;
            this.BtnUIMedicoNuevo1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BtnUIMedicoNuevo1.BackColor = SystemColors.ActiveCaptionText;
            this.BtnUIMedicoNuevo1.Location = new Point(0x3a5, 0x1e7);
            this.BtnUIMedicoNuevo1.Margin = new Padding(0);
            this.BtnUIMedicoNuevo1.Name = "BtnUIMedicoNuevo1";
            this.BtnUIMedicoNuevo1.Size = new Size(0x70, 40);
            this.BtnUIMedicoNuevo1.TabIndex = 0x9a;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = SystemColors.Window;
            base.Controls.Add(this.label19);
            base.Controls.Add(this.label16);
            base.Controls.Add(this.label17);
            base.Controls.Add(this.label15);
            base.Controls.Add(this.label14);
            base.Controls.Add(this.BtnPerfilCrearCerrar);
            base.Controls.Add(this.BtnUIMedicoNuevo1);
            base.Controls.Add(this.CheckBoxHabil);
            base.Controls.Add(this.label12);
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.label9);
            base.Controls.Add(this.CampColegiatura);
            base.Controls.Add(this.label6);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.CampEspecialidad);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.campNombre);
            base.Controls.Add(this.label11);
            base.Controls.Add(this.CampSegundoApellido);
            base.Controls.Add(this.CampPrimerApellido);
            base.Margin = new Padding(0);
            base.Name = "PanelMedicoNuevo";
            base.Size = new Size(0x435, 0x228);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion

        private Button BtnPerfilCrearCerrar;
        private ButtonUI BtnUIMedicoNuevo1;
        private TextBox CampColegiatura;
        private TextBox CampEspecialidad;
        private TextBox campNombre;
        private TextBox CampPrimerApellido;
        private TextBox CampSegundoApellido;
        private CheckBox CheckBoxHabil;
        private Label label1;
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
        private Label label6;
        private Label label9;
        private Panel panel1;
    }
}
