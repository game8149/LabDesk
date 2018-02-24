using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.Base
{
    partial class PanelUIControl
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
            this.label1 = new Label();
            this.panel4 = new Panel();
            this.LabelExamen = new Label();
            this.panel4.SuspendLayout();
            base.SuspendLayout();
            this.label1.BackColor = Color.FromArgb(0x40, 0x40, 0x40);
            this.label1.Dock = DockStyle.Top;
            this.label1.Font = new Font("Futura Bk BT", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.ForeColor = SystemColors.ControlLightLight;
            this.label1.ImageAlign = ContentAlignment.MiddleLeft;
            this.label1.Location = new Point(0, 0);
            this.label1.Margin = new Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new Padding(10, 5, 5, 5);
            this.label1.Size = new Size(0x444, 0x26);
            this.label1.TabIndex = 0x45;
            this.label1.Text = "Gestor de Examen";
            this.label1.TextAlign = ContentAlignment.MiddleLeft;
            this.panel4.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.panel4.BackColor = Color.FromArgb(0x40, 0x40, 0x40);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.LabelExamen);
            this.panel4.Location = new Point(0, 0);
            this.panel4.Margin = new Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new Size(0x444, 0x27);
            this.panel4.TabIndex = 0x67;
            this.LabelExamen.Font = new Font("Futura Md BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.LabelExamen.ForeColor = SystemColors.ControlLightLight;
            this.LabelExamen.ImageAlign = ContentAlignment.MiddleLeft;
            this.LabelExamen.Location = new Point(10, 0);
            this.LabelExamen.MaximumSize = new Size(450, 0);
            this.LabelExamen.Name = "LabelExamen";
            this.LabelExamen.Size = new Size(0x83, 0);
            this.LabelExamen.TabIndex = 0x4c;
            this.LabelExamen.Text = "Gestor de Examenes";
            this.LabelExamen.TextAlign = ContentAlignment.MiddleLeft;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.AutoScroll = true;
            base.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            base.Controls.Add(this.panel4);
            base.Margin = new Padding(0);
            base.Name = "PanelUIControl";
            base.Size = new Size(0x444, 0x27);
            this.panel4.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        #endregion


        private Label label1;
        private Label LabelExamen;
        private Panel panel4;
    }
}
