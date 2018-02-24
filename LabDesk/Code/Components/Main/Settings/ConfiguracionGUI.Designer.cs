using LabDesk.Code.Base;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Main.Settings
{
    partial class ConfiguracionGUI
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(ConfiguracionGUI));
            this.panelOpciones = new Panel();
            this.BtnUIConfig3 = new ButtonUI();
            this.BtnUIConfig2 = new ButtonUI();
            this.BtnUIConfig1 = new ButtonUI();
            this.PanelPrincipal = new Panel();
            this.PanelGeneral = new Panel();
            this.ComboApariencia = new ComboBox();
            this.label4 = new Label();
            this.label5 = new Label();
            this.PanelSonido = new Panel();
            this.SonidoOpciones = new Panel();
            this.label6 = new Label();
            this.LabelVol = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.TrackBarSound = new TrackBar();
            this.CheckBoxSoundMouse = new CheckBox();
            this.CheckBoxSoundSesion = new CheckBox();
            this.CheckBoxSoundEnabled = new CheckBox();
            this.BtnUIConfig5 = new ButtonUI();
            this.BtnUIConfig4 = new ButtonUI();
            this.BtnUIConfig6 = new ButtonUI();
            this.PanelAccesibilidad = new Panel();
            this.CheckBoxDaltonic = new CheckBox();
            this.label1 = new Label();
            this.button1 = new Button();
            this.BtnAcerca = new Button();
            this.panelOpciones.SuspendLayout();
            this.PanelPrincipal.SuspendLayout();
            this.PanelGeneral.SuspendLayout();
            this.PanelSonido.SuspendLayout();
            this.SonidoOpciones.SuspendLayout();
            this.TrackBarSound.BeginInit();
            this.PanelAccesibilidad.SuspendLayout();
            base.SuspendLayout();
            this.panelOpciones.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.panelOpciones.BackColor = Color.FromArgb(0x40, 0x40, 0x40);
            this.panelOpciones.Controls.Add(this.BtnUIConfig3);
            this.panelOpciones.Controls.Add(this.BtnUIConfig2);
            this.panelOpciones.Controls.Add(this.BtnUIConfig1);
            this.panelOpciones.Controls.Add(this.PanelPrincipal);
            this.panelOpciones.Dock = DockStyle.Fill;
            this.panelOpciones.Location = new Point(0, 0);
            this.panelOpciones.Name = "panelOpciones";
            this.panelOpciones.Size = new Size(0x2b0, 0x204);
            this.panelOpciones.TabIndex = 1;
            this.BtnUIConfig3.BackColor = SystemColors.ActiveCaptionText;
            this.BtnUIConfig3.Location = new Point(0, 110);
            this.BtnUIConfig3.Margin = new Padding(0);
            this.BtnUIConfig3.Name = "BtnUIConfig3";
            this.BtnUIConfig3.Size = new Size(0x70, 40);
            this.BtnUIConfig3.TabIndex = 13;
            this.BtnUIConfig2.BackColor = SystemColors.ActiveCaptionText;
            this.BtnUIConfig2.Location = new Point(0, 0x37);
            this.BtnUIConfig2.Margin = new Padding(0);
            this.BtnUIConfig2.Name = "BtnUIConfig2";
            this.BtnUIConfig2.Size = new Size(0x70, 40);
            this.BtnUIConfig2.TabIndex = 14;
            this.BtnUIConfig1.BackColor = SystemColors.ActiveCaptionText;
            this.BtnUIConfig1.Location = new Point(0, 0);
            this.BtnUIConfig1.Margin = new Padding(0);
            this.BtnUIConfig1.Name = "BtnUIConfig1";
            this.BtnUIConfig1.Size = new Size(0x70, 40);
            this.BtnUIConfig1.TabIndex = 15;
            this.PanelPrincipal.BackColor = Color.White;
            this.PanelPrincipal.BorderStyle = BorderStyle.FixedSingle;
            this.PanelPrincipal.Controls.Add(this.PanelGeneral);
            this.PanelPrincipal.Controls.Add(this.PanelSonido);
            this.PanelPrincipal.Controls.Add(this.BtnUIConfig5);
            this.PanelPrincipal.Controls.Add(this.BtnUIConfig4);
            this.PanelPrincipal.Controls.Add(this.BtnUIConfig6);
            this.PanelPrincipal.Controls.Add(this.PanelAccesibilidad);
            this.PanelPrincipal.Location = new Point(0xa2, 0);
            this.PanelPrincipal.Name = "PanelPrincipal";
            this.PanelPrincipal.Size = new Size(0x20e, 0x204);
            this.PanelPrincipal.TabIndex = 11;
            this.PanelGeneral.Controls.Add(this.ComboApariencia);
            this.PanelGeneral.Controls.Add(this.label4);
            this.PanelGeneral.Controls.Add(this.label5);
            this.PanelGeneral.Location = new Point(3, 0x10);
            this.PanelGeneral.Name = "PanelGeneral";
            this.PanelGeneral.Size = new Size(0x1e4, 0x1b7);
            this.PanelGeneral.TabIndex = 9;
            this.ComboApariencia.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ComboApariencia.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.ComboApariencia.FormattingEnabled = true;
            this.ComboApariencia.Location = new Point(0x84, 0x30);
            this.ComboApariencia.Name = "ComboApariencia";
            this.ComboApariencia.Size = new Size(0x79, 0x18);
            this.ComboApariencia.TabIndex = 3;
            this.label4.AutoSize = true;
            this.label4.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label4.Location = new Point(0x1c, 0x33);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x2c, 0x10);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tema:";
            this.label5.AutoSize = true;
            this.label5.Font = new Font("Futura Bk BT", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label5.Location = new Point(0x1b, 20);
            this.label5.Name = "label5";
            this.label5.Size = new Size(80, 0x12);
            this.label5.TabIndex = 1;
            this.label5.Text = "Apariencia";
            this.PanelSonido.Controls.Add(this.SonidoOpciones);
            this.PanelSonido.Controls.Add(this.CheckBoxSoundEnabled);
            this.PanelSonido.Location = new Point(0x10, 9);
            this.PanelSonido.Name = "PanelSonido";
            this.PanelSonido.Size = new Size(0x1e4, 0x1b7);
            this.PanelSonido.TabIndex = 8;
            this.SonidoOpciones.Controls.Add(this.label6);
            this.SonidoOpciones.Controls.Add(this.LabelVol);
            this.SonidoOpciones.Controls.Add(this.label2);
            this.SonidoOpciones.Controls.Add(this.label3);
            this.SonidoOpciones.Controls.Add(this.TrackBarSound);
            this.SonidoOpciones.Controls.Add(this.CheckBoxSoundMouse);
            this.SonidoOpciones.Controls.Add(this.CheckBoxSoundSesion);
            this.SonidoOpciones.Location = new Point(12, 0x2f);
            this.SonidoOpciones.Name = "SonidoOpciones";
            this.SonidoOpciones.Size = new Size(0x1a0, 0xad);
            this.SonidoOpciones.TabIndex = 9;
            this.label6.AutoSize = true;
            this.label6.Font = new Font("Futura Bk BT", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label6.Location = new Point(14, 15);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x43, 0x12);
            this.label6.TabIndex = 6;
            this.label6.Text = "Volumen";
            this.LabelVol.AutoSize = true;
            this.LabelVol.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.LabelVol.Location = new Point(260, 0x30);
            this.LabelVol.Name = "LabelVol";
            this.LabelVol.Size = new Size(0x20, 0x10);
            this.LabelVol.TabIndex = 8;
            this.LabelVol.Text = "100";
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Futura Bk BT", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.Location = new Point(13, 0x56);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x2e, 0x12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Extras";
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label3.Location = new Point(0x11, 0x30);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x67, 0x10);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nivel de sonido :";
            this.TrackBarSound.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.TrackBarSound.BackColor = Color.White;
            this.TrackBarSound.LargeChange = 20;
            this.TrackBarSound.Location = new Point(0x79, 0x2f);
            this.TrackBarSound.Maximum = 100;
            this.TrackBarSound.Name = "TrackBarSound";
            this.TrackBarSound.Size = new Size(0x85, 0x2d);
            this.TrackBarSound.SmallChange = 10;
            this.TrackBarSound.TabIndex = 3;
            this.TrackBarSound.TickFrequency = 20;
            this.TrackBarSound.Value = 100;
            this.TrackBarSound.Scroll += new EventHandler(this.TrackBarSound_Scroll);
            this.CheckBoxSoundMouse.AutoSize = true;
            this.CheckBoxSoundMouse.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CheckBoxSoundMouse.ImageAlign = ContentAlignment.TopCenter;
            this.CheckBoxSoundMouse.Location = new Point(0x10, 0x74);
            this.CheckBoxSoundMouse.Name = "CheckBoxSoundMouse";
            this.CheckBoxSoundMouse.RightToLeft = RightToLeft.Yes;
            this.CheckBoxSoundMouse.Size = new Size(0xa4, 20);
            this.CheckBoxSoundMouse.TabIndex = 5;
            this.CheckBoxSoundMouse.Text = "Activar sonido de mouse";
            this.CheckBoxSoundMouse.UseVisualStyleBackColor = true;
            this.CheckBoxSoundSesion.AutoSize = true;
            this.CheckBoxSoundSesion.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CheckBoxSoundSesion.ImageAlign = ContentAlignment.TopCenter;
            this.CheckBoxSoundSesion.Location = new Point(0x10, 0x93);
            this.CheckBoxSoundSesion.Name = "CheckBoxSoundSesion";
            this.CheckBoxSoundSesion.RightToLeft = RightToLeft.Yes;
            this.CheckBoxSoundSesion.Size = new Size(0xa1, 20);
            this.CheckBoxSoundSesion.TabIndex = 4;
            this.CheckBoxSoundSesion.Text = "Activar sonido de sesi\x00f3n";
            this.CheckBoxSoundSesion.UseVisualStyleBackColor = true;
            this.CheckBoxSoundEnabled.AutoSize = true;
            this.CheckBoxSoundEnabled.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CheckBoxSoundEnabled.Location = new Point(0x20, 0x15);
            this.CheckBoxSoundEnabled.Name = "CheckBoxSoundEnabled";
            this.CheckBoxSoundEnabled.RightToLeft = RightToLeft.Yes;
            this.CheckBoxSoundEnabled.Size = new Size(0x69, 20);
            this.CheckBoxSoundEnabled.TabIndex = 7;
            this.CheckBoxSoundEnabled.Text = "Activar sonido";
            this.CheckBoxSoundEnabled.UseVisualStyleBackColor = true;
            this.CheckBoxSoundEnabled.CheckedChanged += new EventHandler(this.CheckBoxSoundEnabled_CheckedChanged);
            this.BtnUIConfig5.BackColor = SystemColors.ActiveCaptionText;
            this.BtnUIConfig5.Location = new Point(240, 0x1ca);
            this.BtnUIConfig5.Margin = new Padding(0);
            this.BtnUIConfig5.Name = "BtnUIConfig5";
            this.BtnUIConfig5.Size = new Size(0x70, 40);
            this.BtnUIConfig5.TabIndex = 10;
            this.BtnUIConfig4.BackColor = SystemColors.ActiveCaptionText;
            this.BtnUIConfig4.Location = new Point(0x1c, 0x1ca);
            this.BtnUIConfig4.Margin = new Padding(0);
            this.BtnUIConfig4.Name = "BtnUIConfig4";
            this.BtnUIConfig4.Size = new Size(0x70, 40);
            this.BtnUIConfig4.TabIndex = 12;
            this.BtnUIConfig6.BackColor = SystemColors.ActiveCaptionText;
            this.BtnUIConfig6.Location = new Point(0x17f, 0x1ca);
            this.BtnUIConfig6.Margin = new Padding(0);
            this.BtnUIConfig6.Name = "BtnUIConfig6";
            this.BtnUIConfig6.Size = new Size(0x70, 40);
            this.BtnUIConfig6.TabIndex = 11;
            this.PanelAccesibilidad.Controls.Add(this.CheckBoxDaltonic);
            this.PanelAccesibilidad.Controls.Add(this.label1);
            this.PanelAccesibilidad.Location = new Point(0x16, 12);
            this.PanelAccesibilidad.Name = "PanelAccesibilidad";
            this.PanelAccesibilidad.Size = new Size(0x1e4, 0x1b7);
            this.PanelAccesibilidad.TabIndex = 9;
            this.CheckBoxDaltonic.AutoSize = true;
            this.CheckBoxDaltonic.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CheckBoxDaltonic.Location = new Point(30, 50);
            this.CheckBoxDaltonic.Name = "CheckBoxDaltonic";
            this.CheckBoxDaltonic.RightToLeft = RightToLeft.Yes;
            this.CheckBoxDaltonic.Size = new Size(0x73, 20);
            this.CheckBoxDaltonic.TabIndex = 1;
            this.CheckBoxDaltonic.Text = "Modo Daltonico";
            this.CheckBoxDaltonic.UseVisualStyleBackColor = true;
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Futura Bk BT", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.Location = new Point(0x1b, 20);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x30, 0x12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Visual";
            this.button1.Location = new Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x4b, 0x17);
            this.button1.TabIndex = 0;
            this.BtnAcerca.Location = new Point(0, 0);
            this.BtnAcerca.Name = "BtnAcerca";
            this.BtnAcerca.Size = new Size(0x4b, 0x17);
            this.BtnAcerca.TabIndex = 0;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = SystemColors.Window;
            base.ClientSize = new Size(0x2b0, 0x204);
            base.Controls.Add(this.panelOpciones);
            //            base.Icon = (Icon)manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.Name = "ConfiguracionGUI";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Configuraci\x00f3n";
            this.panelOpciones.ResumeLayout(false);
            this.PanelPrincipal.ResumeLayout(false);
            this.PanelGeneral.ResumeLayout(false);
            this.PanelGeneral.PerformLayout();
            this.PanelSonido.ResumeLayout(false);
            this.PanelSonido.PerformLayout();
            this.SonidoOpciones.ResumeLayout(false);
            this.SonidoOpciones.PerformLayout();
            this.TrackBarSound.EndInit();
            this.PanelAccesibilidad.ResumeLayout(false);
            this.PanelAccesibilidad.PerformLayout();
            base.ResumeLayout(false);
        }


        #endregion

        private Button BtnAcerca;
        private ButtonUI BtnUIConfig1;
        private ButtonUI BtnUIConfig2;
        private ButtonUI BtnUIConfig3;
        private ButtonUI BtnUIConfig4;
        private ButtonUI BtnUIConfig5;
        private ButtonUI BtnUIConfig6;
        private Button button1;
        private CheckBox CheckBoxDaltonic;

        private ComboBox ComboApariencia;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label LabelVol;
        private Panel PanelAccesibilidad;
        private Panel PanelActual;
        private Panel PanelGeneral;
        private Panel panelOpciones;
        private Panel PanelPrincipal;
        private Panel PanelSonido;
        private Panel SonidoOpciones;
        private TrackBar TrackBarSound;

    }
}