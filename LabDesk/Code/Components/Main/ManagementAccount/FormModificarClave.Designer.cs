using LabDesk.Code.Base;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Main.ManagementAccount
{
    partial class FormModificarClave
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FormModificarClave));
            this.label1 = new Label();
            this.CampNueva = new TextBox();
            this.label3 = new Label();
            this.CampAntigua = new TextBox();
            this.BtnUIUsuarioClave2 = new ButtonUI();
            this.BtnUIUsuarioClave1 = new ButtonUI();
            this.label12 = new Label();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.Location = new Point(20, 0x79);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x52, 0x10);
            this.label1.TabIndex = 2;
            this.label1.Text = "Actual Clave:";
            this.CampNueva.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampNueva.Location = new Point(0xac, 0x4d);
            this.CampNueva.MaxLength = 8;
            this.CampNueva.Name = "CampNueva";
            this.CampNueva.Size = new Size(0xd0, 0x17);
            this.CampNueva.TabIndex = 1;
            this.CampNueva.TextAlign = HorizontalAlignment.Center;
            this.CampNueva.UseSystemPasswordChar = true;
            this.label3.AutoSize = true;
            this.label3.FlatStyle = FlatStyle.Flat;
            this.label3.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label3.Location = new Point(20, 0x51);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x55, 0x10);
            this.label3.TabIndex = 15;
            this.label3.Text = "Nueva Clave:";
            this.CampAntigua.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CampAntigua.Location = new Point(0xac, 0x75);
            this.CampAntigua.Name = "CampAntigua";
            this.CampAntigua.Size = new Size(0xd0, 0x17);
            this.CampAntigua.TabIndex = 2;
            this.CampAntigua.TextAlign = HorizontalAlignment.Center;
            this.CampAntigua.UseSystemPasswordChar = true;
            this.BtnUIUsuarioClave2.AutoSize = true;
            this.BtnUIUsuarioClave2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BtnUIUsuarioClave2.BackColor = SystemColors.ActiveCaptionText;
            this.BtnUIUsuarioClave2.Location = new Point(0x88, 0xc2);
            this.BtnUIUsuarioClave2.Margin = new Padding(0);
            this.BtnUIUsuarioClave2.Name = "BtnUIUsuarioClave2";
            this.BtnUIUsuarioClave2.Size = new Size(0x70, 40);
            this.BtnUIUsuarioClave2.TabIndex = 4;
            this.BtnUIUsuarioClave1.AutoSize = true;
            this.BtnUIUsuarioClave1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BtnUIUsuarioClave1.BackColor = SystemColors.ActiveCaptionText;
            this.BtnUIUsuarioClave1.Location = new Point(0x10c, 0xc2);
            this.BtnUIUsuarioClave1.Margin = new Padding(0);
            this.BtnUIUsuarioClave1.Name = "BtnUIUsuarioClave1";
            this.BtnUIUsuarioClave1.Size = new Size(0x70, 40);
            this.BtnUIUsuarioClave1.TabIndex = 3;
            this.label12.AutoSize = true;
            this.label12.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label12.Location = new Point(0x13, 0x1a);
            this.label12.Name = "label12";
            this.label12.Size = new Size(0xb1, 0x13);
            this.label12.TabIndex = 0x58;
            this.label12.Text = "Informaci\x00f3n Restringida";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = SystemColors.Window;
            base.ClientSize = new Size(0x197, 0x105);
            base.Controls.Add(this.label12);
            base.Controls.Add(this.BtnUIUsuarioClave2);
            base.Controls.Add(this.BtnUIUsuarioClave1);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.CampNueva);
            base.Controls.Add(this.CampAntigua);
            base.Controls.Add(this.label3);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
//            base.Icon = (Icon)manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.Name = "FormModificarClave";
            this.RightToLeftLayout = true;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Cambiar Clave";
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion



        private ButtonUI BtnUIUsuarioClave1;
        private ButtonUI BtnUIUsuarioClave2;
        private TextBox CampAntigua;
        private TextBox CampNueva;
        private Label label1;
        private Label label12;
        private Label label3;
    }
}