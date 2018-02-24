using LabDesk.Code.Base;
using LabDesk.Code.PresentationLayer.ComponenteGeneral;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Main
{
    partial class Principal
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
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(Principal));
            this.Temporizador = new Timer(this.components);
            this.PanelPrincipal = new Panel();
            this.PanelOpcion = new Panel();
            this.CheckBoxMenu = new CheckBox();
            this.BtnUIMain1 = new ButtonUI();
            this.BtnUIMain2 = new ButtonUI();
            this.BtnUIMain3 = new ButtonUI();
            this.BtnUIMain4 = new ButtonUI();
            this.BtnUIMain7 = new ButtonUI();
            this.BtnUIMain5 = new ButtonUI();
            this.BtnUIMain8 = new ButtonUI();
            this.BtnUIMain6 = new ButtonUI();
            this.panelUIControl1 = new PanelUIControl();
            this.PanelOpcion.SuspendLayout();
            base.SuspendLayout();
            this.PanelPrincipal.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.PanelPrincipal.BackColor = Color.FloralWhite;
            this.PanelPrincipal.BorderStyle = BorderStyle.FixedSingle;
            this.PanelPrincipal.Location = new Point(0x37, 0x27);
            this.PanelPrincipal.Margin = new Padding(0);
            this.PanelPrincipal.Name = "PanelPrincipal";
            this.PanelPrincipal.Size = new Size(0x435, 0x227);
            this.PanelPrincipal.TabIndex = 4;
            this.PanelPrincipal.Paint += new PaintEventHandler(this.panelPrincipal_Paint);
            this.PanelOpcion.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.PanelOpcion.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.PanelOpcion.BackColor = Color.FromArgb(0x40, 0x40, 0x40);
            this.PanelOpcion.BorderStyle = BorderStyle.FixedSingle;
            this.PanelOpcion.Controls.Add(this.CheckBoxMenu);
            this.PanelOpcion.Controls.Add(this.BtnUIMain1);
            this.PanelOpcion.Controls.Add(this.BtnUIMain2);
            this.PanelOpcion.Controls.Add(this.BtnUIMain3);
            this.PanelOpcion.Controls.Add(this.BtnUIMain4);
            this.PanelOpcion.Controls.Add(this.BtnUIMain7);
            this.PanelOpcion.Controls.Add(this.BtnUIMain5);
            this.PanelOpcion.Controls.Add(this.BtnUIMain8);
            this.PanelOpcion.Controls.Add(this.BtnUIMain6);
            this.PanelOpcion.Location = new Point(0, 0);
            this.PanelOpcion.Margin = new Padding(0);
            this.PanelOpcion.Name = "PanelOpcion";
            this.PanelOpcion.Size = new Size(0x37, 590);
            this.PanelOpcion.TabIndex = 0;
            this.CheckBoxMenu.Appearance = Appearance.Button;
            this.CheckBoxMenu.Cursor = Cursors.Hand;
            this.CheckBoxMenu.FlatAppearance.BorderSize = 0;
            this.CheckBoxMenu.FlatStyle = FlatStyle.Flat;
            //this.CheckBoxMenu.Image = Resources.icon_menu;
            this.CheckBoxMenu.Location = new Point(0, 0);
            this.CheckBoxMenu.Margin = new Padding(0);
            this.CheckBoxMenu.Name = "CheckBoxMenu";
            this.CheckBoxMenu.Size = new Size(0x36, 0x26);
            this.CheckBoxMenu.TabIndex = 0x1d;
            this.CheckBoxMenu.UseVisualStyleBackColor = true;
            this.CheckBoxMenu.CheckedChanged += new EventHandler(this.checkBox1_CheckedChanged);
            this.BtnUIMain1.AutoSize = true;
            this.BtnUIMain1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BtnUIMain1.BackColor = SystemColors.ActiveCaptionText;
            this.BtnUIMain1.Location = new Point(0, 0x26);
            this.BtnUIMain1.Margin = new Padding(0);
            this.BtnUIMain1.Name = "BtnUIMain1";
            this.BtnUIMain1.Size = new Size(0x70, 40);
            this.BtnUIMain1.TabIndex = 5;
            this.BtnUIMain2.AutoSize = true;
            this.BtnUIMain2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BtnUIMain2.BackColor = SystemColors.ActiveCaptionText;
            this.BtnUIMain2.Location = new Point(0, 0x60);
            this.BtnUIMain2.Margin = new Padding(0);
            this.BtnUIMain2.Name = "BtnUIMain2";
            this.BtnUIMain2.Size = new Size(0x70, 40);
            this.BtnUIMain2.TabIndex = 4;
            this.BtnUIMain3.AutoSize = true;
            this.BtnUIMain3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BtnUIMain3.BackColor = SystemColors.ActiveCaptionText;
            this.BtnUIMain3.Location = new Point(0, 0x9a);
            this.BtnUIMain3.Margin = new Padding(0);
            this.BtnUIMain3.Name = "BtnUIMain3";
            this.BtnUIMain3.Size = new Size(0x70, 40);
            this.BtnUIMain3.TabIndex = 0;
            this.BtnUIMain4.AutoSize = true;
            this.BtnUIMain4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BtnUIMain4.BackColor = SystemColors.ActiveCaptionText;
            this.BtnUIMain4.Location = new Point(0, 0xd4);
            this.BtnUIMain4.Margin = new Padding(0);
            this.BtnUIMain4.Name = "BtnUIMain4";
            this.BtnUIMain4.Size = new Size(0x70, 40);
            this.BtnUIMain4.TabIndex = 1;
            this.BtnUIMain7.Anchor = AnchorStyles.Bottom;
            this.BtnUIMain7.AutoSize = true;
            this.BtnUIMain7.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BtnUIMain7.BackColor = SystemColors.ActiveCaptionText;
            this.BtnUIMain7.Location = new Point(0, 0x1b4);
            this.BtnUIMain7.Margin = new Padding(0);
            this.BtnUIMain7.Name = "BtnUIMain7";
            this.BtnUIMain7.Size = new Size(0x70, 40);
            this.BtnUIMain7.TabIndex = 7;
            this.BtnUIMain5.AutoSize = true;
            this.BtnUIMain5.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BtnUIMain5.BackColor = SystemColors.ActiveCaptionText;
            this.BtnUIMain5.Location = new Point(0, 270);
            this.BtnUIMain5.Margin = new Padding(0);
            this.BtnUIMain5.Name = "BtnUIMain5";
            this.BtnUIMain5.Size = new Size(0x70, 40);
            this.BtnUIMain5.TabIndex = 3;
            this.BtnUIMain8.Anchor = AnchorStyles.Bottom;
            this.BtnUIMain8.AutoSize = true;
            this.BtnUIMain8.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BtnUIMain8.BackColor = SystemColors.ActiveCaptionText;
            this.BtnUIMain8.Location = new Point(0, 490);
            this.BtnUIMain8.Margin = new Padding(0);
            this.BtnUIMain8.Name = "BtnUIMain8";
            this.BtnUIMain8.Size = new Size(0x70, 40);
            this.BtnUIMain8.TabIndex = 6;
            this.BtnUIMain6.AutoSize = true;
            this.BtnUIMain6.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BtnUIMain6.BackColor = SystemColors.ActiveCaptionText;
            this.BtnUIMain6.Location = new Point(0, 0x148);
            this.BtnUIMain6.Margin = new Padding(0);
            this.BtnUIMain6.Name = "BtnUIMain6";
            this.BtnUIMain6.Size = new Size(0x70, 40);
            this.BtnUIMain6.TabIndex = 2;
            this.panelUIControl1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.panelUIControl1.AutoScroll = true;
            this.panelUIControl1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.panelUIControl1.BackColor = Color.DimGray;
            this.panelUIControl1.Location = new Point(0x37, 0);
            this.panelUIControl1.Margin = new Padding(0);
            this.panelUIControl1.Name = "panelUIControl1";
            this.panelUIControl1.Size = new Size(0x435, 0x27);
            this.panelUIControl1.TabIndex = 5;
            this.panelUIControl1.Tipo = PanelUIControl.PanelUITipo.Default;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            base.ClientSize = new Size(0x46c, 590);
            base.Controls.Add(this.PanelOpcion);
            base.Controls.Add(this.PanelPrincipal);
            base.Controls.Add(this.panelUIControl1);
//            base.Icon = (Icon)manager.GetObject("$this.Icon");
            this.MaximumSize = new Size(0x3b9aca10, 0x3b9ac9e7);
            this.MinimumSize = new Size(0x47c, 0x275);
            base.Name = "Principal";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Wichanzao";
            base.WindowState = FormWindowState.Maximized;
            this.PanelOpcion.ResumeLayout(false);
            this.PanelOpcion.PerformLayout();
            base.ResumeLayout(false);
        }

        #endregion

        private ButtonUI BtnUIMain1;
        private ButtonUI BtnUIMain2;
        private ButtonUI BtnUIMain3;
        private ButtonUI BtnUIMain4;
        private ButtonUI BtnUIMain5;
        private ButtonUI BtnUIMain6;
        private ButtonUI BtnUIMain7;
        private ButtonUI BtnUIMain8;
        private CheckBox CheckBoxMenu;
        private LabelUI labelMod1;
        private Panel PanelOpcion;
        private Panel PanelPrincipal;
        private PanelUIControl panelUIControl1;
    }
}