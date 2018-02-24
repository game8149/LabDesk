using System;
using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.Base
{
    partial class ButtonUI
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
            this.button1 = new Button();
            base.SuspendLayout();
            this.button1.FlatStyle = FlatStyle.Flat;
            this.button1.ImageAlign = ContentAlignment.MiddleLeft;
            this.button1.Location = new Point(0, 0);
            this.button1.Margin = new Padding(0);
            this.button1.Name = "button1";
            this.button1.Padding = new Padding(5);
            this.button1.Size = new Size(0x70, 40);
            this.button1.TabIndex = 0;
            this.button1.TextAlign = ContentAlignment.MiddleLeft;
            this.button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.BackColor = SystemColors.ActiveCaptionText;
            base.Controls.Add(this.button1);
            base.Margin = new Padding(0);
            base.Name = "ButtonUI";
            base.Size = new Size(0x70, 40);
            base.Load += new EventHandler(this.ButtonUI_Load);
            base.ResumeLayout(false);
        }

        #endregion

        private Button button1;
    }
}
