using LabDesk.Code.Base;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Actors.Medico
{
    partial class PanelMedicoEditar
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(PanelMedicoEditar));
            this.CheckBoxHabil = new CheckBox();
            this.label9 = new Label();
            this.CampColegiatura = new TextBox();
            this.label6 = new Label();
            this.CampEspecialidad = new TextBox();
            this.panel1 = new Panel();
            this.panel2 = new Panel();
            this.label13 = new Label();
            this.label1 = new Label();
            this.label12 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.CampNombre = new TextBox();
            this.label11 = new Label();
            this.Campapellido2erno = new TextBox();
            this.Campapellido1erno = new TextBox();
            this.BtnUIMedicoEditar3 = new ButtonUI();
            this.BtnPerfilEditarCerrar = new Button();
            this.BtnPerfilEditarGuardar = new Button();
            this.label19 = new Label();
            this.label16 = new Label();
            this.label17 = new Label();
            this.label15 = new Label();
            this.label14 = new Label();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.CheckBoxHabil.AutoSize = true;
            this.CheckBoxHabil.Font = new Font("Futura Bk BT", 9.25f);
            this.CheckBoxHabil.Location = new Point(0x18a, 0x4b);
            this.CheckBoxHabil.Name = "CheckBoxHabil";
            this.CheckBoxHabil.RightToLeft = RightToLeft.Yes;
            this.CheckBoxHabil.Size = new Size(60, 20);
            this.CheckBoxHabil.TabIndex = 7;
            this.CheckBoxHabil.Text = ":Habil";
            this.CheckBoxHabil.TextAlign = ContentAlignment.MiddleRight;
            this.CheckBoxHabil.UseVisualStyleBackColor = true;
            this.label9.AutoSize = true;
            this.label9.Font = new Font("Futura Bk BT", 9.75f);
            this.label9.Location = new Point(0x1d, 0x4c);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x4d, 0x10);
            this.label9.TabIndex = 0xa1;
            this.label9.Text = "Colegiatura:";
            this.CampColegiatura.Font = new Font("Futura Bk BT", 9.75f);
            this.CampColegiatura.Location = new Point(180, 0x49);
            this.CampColegiatura.MaxLength = 10;
            this.CampColegiatura.Name = "CampColegiatura";
            this.CampColegiatura.Size = new Size(0x95, 0x17);
            this.CampColegiatura.TabIndex = 1;
            this.label6.AutoSize = true;
            this.label6.Font = new Font("Futura Bk BT", 9.75f);
            this.label6.Location = new Point(0x1d, 0xec);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x51, 0x10);
            this.label6.TabIndex = 160;
            this.label6.Text = "Especialidad:";
            this.CampEspecialidad.Font = new Font("Futura Bk BT", 9.75f);
            this.CampEspecialidad.Location = new Point(180, 0xe9);
            this.CampEspecialidad.MaxLength = 50;
            this.CampEspecialidad.Name = "CampEspecialidad";
            this.CampEspecialidad.Size = new Size(0x176, 0x17);
            this.CampEspecialidad.TabIndex = 5;
            this.panel1.Anchor = AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
            this.panel1.BorderStyle = BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new Point(0x323, 0x49);
            this.panel1.Margin = new Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0xf2, 0x1bd);
            this.panel1.TabIndex = 0x9d;
            this.panel2.BackColor = SystemColors.InactiveCaption;
            this.panel2.Location = new Point(0x12f, 0x36);
            this.panel2.Margin = new Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(0x19, 0x19);
            this.panel2.TabIndex = 0xa4;
            this.label13.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.label13.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label13.Location = new Point(0x13, 50);
            this.label13.Name = "label13";
            this.label13.Size = new Size(0xcd, 0xcc);
            this.label13.TabIndex = 0x7d;
            //            this.label13.Text = manager.GetString("label13.Text");
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.Location = new Point(0x13, 0x13);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0xac, 0x13);
            this.label1.TabIndex = 0x7b;
            this.label1.Text = "Indicaciones Generales";
            this.label12.AutoSize = true;
            this.label12.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label12.Location = new Point(0x1c, 0x1c);
            this.label12.Name = "label12";
            this.label12.Size = new Size(0x9f, 0x13);
            this.label12.TabIndex = 0x9c;
            this.label12.Text = "Informaci\x00f3n Personal";
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Futura Bk BT", 9.75f);
            this.label2.Location = new Point(0x1d, 0x73);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x3b, 0x10);
            this.label2.TabIndex = 0x99;
            this.label2.Text = "Nombre:";
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Futura Bk BT", 9.75f);
            this.label3.Location = new Point(0x1d, 0xc1);
            this.label3.Name = "label3";
            this.label3.Size = new Size(110, 0x10);
            this.label3.TabIndex = 0x9b;
            this.label3.Text = "Segundo Apellido:";
            this.CampNombre.Font = new Font("Futura Bk BT", 9.75f);
            this.CampNombre.Location = new Point(180, 0x70);
            this.CampNombre.MaxLength = 100;
            this.CampNombre.Name = "CampNombre";
            this.CampNombre.Size = new Size(0x176, 0x17);
            this.CampNombre.TabIndex = 2;
            this.label11.AutoSize = true;
            this.label11.Font = new Font("Futura Bk BT", 9.75f);
            this.label11.Location = new Point(0x1d, 0x9a);
            this.label11.Name = "label11";
            this.label11.Size = new Size(0x63, 0x10);
            this.label11.TabIndex = 0x9a;
            this.label11.Text = "Primer Apellido:";
            this.Campapellido2erno.Font = new Font("Futura Bk BT", 9.75f);
            this.Campapellido2erno.Location = new Point(180, 190);
            this.Campapellido2erno.MaxLength = 100;
            this.Campapellido2erno.Name = "Campapellido2erno";
            this.Campapellido2erno.Size = new Size(0x176, 0x17);
            this.Campapellido2erno.TabIndex = 4;
            this.Campapellido1erno.Font = new Font("Futura Bk BT", 9.75f);
            this.Campapellido1erno.Location = new Point(180, 0x97);
            this.Campapellido1erno.MaxLength = 100;
            this.Campapellido1erno.Name = "Campapellido1erno";
            this.Campapellido1erno.Size = new Size(0x176, 0x17);
            this.Campapellido1erno.TabIndex = 3;
            this.BtnUIMedicoEditar3.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.BtnUIMedicoEditar3.AutoSize = true;
            this.BtnUIMedicoEditar3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BtnUIMedicoEditar3.BackColor = SystemColors.ActiveCaptionText;
            this.BtnUIMedicoEditar3.Location = new Point(0x19, 0x1e7);
            this.BtnUIMedicoEditar3.Margin = new Padding(0);
            this.BtnUIMedicoEditar3.Name = "BtnUIMedicoEditar3";
            this.BtnUIMedicoEditar3.Size = new Size(0x70, 40);
            this.BtnUIMedicoEditar3.TabIndex = 0xa4;
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
            this.BtnPerfilEditarCerrar.TabIndex = 0xa5;
            this.BtnPerfilEditarCerrar.TextAlign = ContentAlignment.MiddleLeft;
            this.BtnPerfilEditarCerrar.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.BtnPerfilEditarCerrar.UseVisualStyleBackColor = false;
            this.BtnPerfilEditarCerrar.Click += new EventHandler(this.BtnPerfilEdicionCerrar_Click);
            this.BtnPerfilEditarGuardar.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.BtnPerfilEditarGuardar.AutoSize = true;
            this.BtnPerfilEditarGuardar.FlatAppearance.BorderSize = 0;
            this.BtnPerfilEditarGuardar.FlatStyle = FlatStyle.Flat;
            // this.BtnPerfilEditarGuardar.Image = Resources.icon_guardar;
            this.BtnPerfilEditarGuardar.Location = new Point(0x3f5, 11);
            this.BtnPerfilEditarGuardar.Margin = new Padding(3, 4, 3, 4);
            this.BtnPerfilEditarGuardar.Name = "BtnPerfilEditarGuardar";
            this.BtnPerfilEditarGuardar.Size = new Size(0x16, 0x16);
            this.BtnPerfilEditarGuardar.TabIndex = 0xa6;
            this.BtnPerfilEditarGuardar.UseVisualStyleBackColor = true;
            this.BtnPerfilEditarGuardar.Click += new EventHandler(this.BtnPerfilEditarGuardar_Click);
            this.label19.AutoSize = true;
            this.label19.BackColor = Color.Transparent;
            this.label19.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label19.ForeColor = SystemColors.GrayText;
            this.label19.Location = new Point(0x22d, 0xea);
            this.label19.Name = "label19";
            this.label19.Size = new Size(0x1a, 0x13);
            this.label19.TabIndex = 0xe1;
            this.label19.Text = "(*)";
            this.label16.AutoSize = true;
            this.label16.BackColor = Color.Transparent;
            this.label16.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label16.ForeColor = SystemColors.GrayText;
            this.label16.Location = new Point(0x22d, 0xc2);
            this.label16.Name = "label16";
            this.label16.Size = new Size(0x1a, 0x13);
            this.label16.TabIndex = 0xe0;
            this.label16.Text = "(*)";
            this.label17.AutoSize = true;
            this.label17.BackColor = Color.Transparent;
            this.label17.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label17.ForeColor = SystemColors.GrayText;
            this.label17.Location = new Point(0x22d, 0x9a);
            this.label17.Name = "label17";
            this.label17.Size = new Size(0x1a, 0x13);
            this.label17.TabIndex = 0xdf;
            this.label17.Text = "(*)";
            this.label15.AutoSize = true;
            this.label15.BackColor = Color.Transparent;
            this.label15.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label15.ForeColor = SystemColors.GrayText;
            this.label15.Location = new Point(0x22d, 0x72);
            this.label15.Name = "label15";
            this.label15.Size = new Size(0x1a, 0x13);
            this.label15.TabIndex = 0xde;
            this.label15.Text = "(*)";
            this.label14.AutoSize = true;
            this.label14.BackColor = Color.Transparent;
            this.label14.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label14.ForeColor = SystemColors.GrayText;
            this.label14.Location = new Point(0x14f, 0x4a);
            this.label14.Name = "label14";
            this.label14.Size = new Size(0x1a, 0x13);
            this.label14.TabIndex = 0xdd;
            this.label14.Text = "(*)";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = SystemColors.Window;
            base.Controls.Add(this.label19);
            base.Controls.Add(this.label16);
            base.Controls.Add(this.label17);
            base.Controls.Add(this.label15);
            base.Controls.Add(this.label14);
            base.Controls.Add(this.BtnPerfilEditarGuardar);
            base.Controls.Add(this.BtnPerfilEditarCerrar);
            base.Controls.Add(this.BtnUIMedicoEditar3);
            base.Controls.Add(this.CheckBoxHabil);
            base.Controls.Add(this.label9);
            base.Controls.Add(this.CampColegiatura);
            base.Controls.Add(this.label6);
            base.Controls.Add(this.CampEspecialidad);
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.label12);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.CampNombre);
            base.Controls.Add(this.label11);
            base.Controls.Add(this.Campapellido2erno);
            base.Controls.Add(this.Campapellido1erno);
            base.Margin = new Padding(0);
            base.Name = "PanelMedicoEditar";
            base.Size = new Size(0x435, 0x228);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
        #endregion
        private Button BtnPerfilEditarCerrar;
        private Button BtnPerfilEditarGuardar;
        private ButtonUI BtnUIMedicoEditar3;
        private TextBox Campapellido1erno;
        private TextBox Campapellido2erno;
        private TextBox CampColegiatura;
        private TextBox CampEspecialidad;
        private TextBox CampNombre;
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
        private Panel panel2;
    }
}
