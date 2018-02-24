using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.Base
{
    partial class PanelSesionUI
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            this.panel1 = new Panel();
            this.label2 = new Label();
            this.label1 = new Label();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.panel1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.panel1.BackColor = SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new Point(0, 0);
            this.panel1.Margin = new Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(330, 110);
            this.panel1.TabIndex = 0;
            this.label2.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.label2.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.ForeColor = SystemColors.Window;
            this.label2.Location = new Point(0, 60);
            this.label2.Name = "label2";
            this.label2.Size = new Size(330, 0x13);
            this.label2.TabIndex = 0x1f;
            this.label2.Text = "Sistema de Laboratorio Cl\x00ednico";
            this.label2.TextAlign = ContentAlignment.MiddleCenter;
            this.label1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.label1.Font = new Font("Futura Md BT", 18f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.ForeColor = SystemColors.Window;
            this.label1.Location = new Point(0, 30);
            this.label1.Name = "label1";
            this.label1.Size = new Size(330, 0x1d);
            this.label1.TabIndex = 0x20;
            this.label1.Text = "Winchanzao";
            this.label1.TextAlign = ContentAlignment.MiddleCenter;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSize = true;
            base.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            base.Controls.Add(this.panel1);
            base.Margin = new Padding(0);
            base.Name = "PanelSesionUI";
            base.Size = new Size(330, 110);
            this.panel1.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Panel panel1;

    }
}
