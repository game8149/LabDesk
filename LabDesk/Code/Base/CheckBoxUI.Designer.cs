using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.Base
{
    partial class CheckBoxUI
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
            this.checkBox1 = new CheckBox();
            base.SuspendLayout();
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new Point(3, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new Size(80, 0x11);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.checkBox1);
            base.Name = "CheckBoxUI";
            base.Size = new Size(0x91, 0x1f);
            base.ResumeLayout(false);
            base.PerformLayout();
        }
        #endregion


        private CheckBox checkBox1;
    }
}
