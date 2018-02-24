using LabDesk.Code.PresentationLayer.ComponenteGeneral;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.PresentationLayer.GUISistema
{
    partial class Test
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
            this.DTPicker = new System.Windows.Forms.DateTimePicker();
            this.CampEdad = new System.Windows.Forms.Label();
            this.LabelImg = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.TB = new System.Windows.Forms.TrackBar();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.BtnUI1 = new LabDesk.Code.PresentationLayer.ComponenteGeneral.ButtonUI();
            this.LblUI2 = new LabDesk.Code.PresentationLayer.ComponenteGeneral.LabelUI();
            this.LblUI1 = new LabDesk.Code.PresentationLayer.ComponenteGeneral.LabelUI();
            ((System.ComponentModel.ISupportInitialize)(this.TB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // DTPicker
            // 
            this.DTPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPicker.Location = new System.Drawing.Point(603, 22);
            this.DTPicker.Name = "DTPicker";
            this.DTPicker.Size = new System.Drawing.Size(91, 20);
            this.DTPicker.TabIndex = 0;
            // 
            // CampEdad
            // 
            this.CampEdad.AutoSize = true;
            this.CampEdad.Location = new System.Drawing.Point(600, 80);
            this.CampEdad.Name = "CampEdad";
            this.CampEdad.Size = new System.Drawing.Size(60, 13);
            this.CampEdad.TabIndex = 2;
            this.CampEdad.Text = "LabelCamp";
            // 
            // LabelImg
            // 
            this.LabelImg.Location = new System.Drawing.Point(600, 172);
            this.LabelImg.Name = "LabelImg";
            this.LabelImg.Size = new System.Drawing.Size(74, 71);
            this.LabelImg.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(443, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TB
            // 
            this.TB.Location = new System.Drawing.Point(590, 110);
            this.TB.Maximum = 500;
            this.TB.Minimum = 20;
            this.TB.Name = "TB";
            this.TB.Size = new System.Drawing.Size(104, 45);
            this.TB.TabIndex = 4;
            this.TB.Value = 20;
            this.TB.Scroll += new System.EventHandler(this.TB_Scroll);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(603, 145);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 8;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.Value = 20;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Location = new System.Drawing.Point(38, 122);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 308);
            this.panel1.TabIndex = 9;
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(372, 276);
            this.trackBar2.Maximum = 100;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(104, 45);
            this.trackBar2.TabIndex = 10;
            this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar2.Value = 20;
            // 
            // BtnUI1
            // 
            this.BtnUI1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnUI1.Location = new System.Drawing.Point(532, 277);
            this.BtnUI1.Margin = new System.Windows.Forms.Padding(0);
            this.BtnUI1.Name = "BtnUI1";
            this.BtnUI1.Size = new System.Drawing.Size(243, 114);
            this.BtnUI1.TabIndex = 7;
            // 
            // LblUI2
            // 
            this.LblUI2.Location = new System.Drawing.Point(38, 80);
            this.LblUI2.Name = "LblUI2";
            this.LblUI2.Size = new System.Drawing.Size(35, 13);
            this.LblUI2.TabIndex = 6;
            // 
            // LblUI1
            // 
            this.LblUI1.Location = new System.Drawing.Point(38, 46);
            this.LblUI1.Name = "LblUI1";
            this.LblUI1.Size = new System.Drawing.Size(35, 13);
            this.LblUI1.TabIndex = 5;
            this.LblUI1.Load += new System.EventHandler(this.labelUI1_Load);
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 741);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.BtnUI1);
            this.Controls.Add(this.LblUI2);
            this.Controls.Add(this.LblUI1);
            this.Controls.Add(this.TB);
            this.Controls.Add(this.LabelImg);
            this.Controls.Add(this.CampEdad);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DTPicker);
            this.Name = "Test";
            this.Text = "Test";
            ((System.ComponentModel.ISupportInitialize)(this.TB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ButtonUI BtnUI1;
        private Button button1;
        private Label CampEdad;
        private DateTimePicker DTPicker;
        private Label LabelImg;
        private LabelUI LblUI1;
        private LabelUI LblUI2;
        private Panel panel1;
        private TrackBar TB;
        private TrackBar trackBar1;
        private TrackBar trackBar2;

    }
}