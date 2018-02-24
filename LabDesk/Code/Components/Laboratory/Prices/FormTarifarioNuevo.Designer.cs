
using LabDesk.Code.Base;
using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Laboratory.Prices
{
    partial class FormTarifarioNuevo
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
            this.label2 = new Label();
            this.label1 = new Label();
            this.NumericUDAño = new NumericUpDown();
            this.CheckBoxVigente = new CheckBox();
            this.label12 = new Label();
            this.BtnUITarifarioNuevo1 = new ButtonUI();
            this.NumericUDAño.BeginInit();
            base.SuspendLayout();
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.Location = new Point(0x1d, 0x43);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x6f, 0x10);
            this.label2.TabIndex = 0x51;
            this.label2.Text = "Seleccione el a\x00f1o:\r\n";
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.Location = new Point(0x1d, 0x69);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x22, 0x10);
            this.label1.TabIndex = 0x4f;
            this.label1.Text = "A\x00f1o:";
            this.NumericUDAño.BorderStyle = BorderStyle.FixedSingle;
            this.NumericUDAño.Cursor = Cursors.Default;
            this.NumericUDAño.Font = new Font("Futura Bk BT", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.NumericUDAño.Location = new Point(80, 0x65);
            int[] bits = new int[4];
            bits[0] = 0x834;
            this.NumericUDAño.Maximum = new decimal(bits);
            int[] numArray2 = new int[4];
            numArray2[0] = 0x7e0;
            this.NumericUDAño.Minimum = new decimal(numArray2);
            this.NumericUDAño.Name = "NumericUDA\x00f1o";
            this.NumericUDAño.Size = new Size(0x73, 0x19);
            this.NumericUDAño.TabIndex = 0x52;
            this.NumericUDAño.TextAlign = HorizontalAlignment.Center;
            int[] numArray3 = new int[4];
            numArray3[0] = 0x7e0;
            this.NumericUDAño.Value = new decimal(numArray3);
            this.CheckBoxVigente.AutoSize = true;
            this.CheckBoxVigente.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CheckBoxVigente.Location = new Point(0x1d, 0x89);
            this.CheckBoxVigente.Name = "CheckBoxVigente";
            this.CheckBoxVigente.RightToLeft = RightToLeft.Yes;
            this.CheckBoxVigente.Size = new Size(0xb3, 20);
            this.CheckBoxVigente.TabIndex = 0x53;
            this.CheckBoxVigente.Text = "Hacer este tarifario vigente";
            this.CheckBoxVigente.UseVisualStyleBackColor = true;
            this.label12.AutoSize = true;
            this.label12.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label12.Location = new Point(0x1c, 0x1a);
            this.label12.Name = "label12";
            this.label12.Size = new Size(0x9c, 0x13);
            this.label12.TabIndex = 0xd9;
            this.label12.Text = "Informaci\x00f3n General";
            this.BtnUITarifarioNuevo1.AutoSize = true;
            this.BtnUITarifarioNuevo1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BtnUITarifarioNuevo1.BackColor = SystemColors.ActiveCaptionText;
            this.BtnUITarifarioNuevo1.Location = new Point(0x155, 0xe0);
            this.BtnUITarifarioNuevo1.Margin = new Padding(0);
            this.BtnUITarifarioNuevo1.Name = "BtnUITarifarioNuevo1";
            this.BtnUITarifarioNuevo1.Size = new Size(0x70, 40);
            this.BtnUITarifarioNuevo1.TabIndex = 0xda;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = SystemColors.Window;
            base.ClientSize = new Size(0x1df, 290);
            base.Controls.Add(this.BtnUITarifarioNuevo1);
            base.Controls.Add(this.label12);
            base.Controls.Add(this.CheckBoxVigente);
            base.Controls.Add(this.NumericUDAño);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Name = "FormTarifarioNuevo";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Nuevo Tarifario";
            this.NumericUDAño.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }


        #endregion

        private ButtonUI BtnUITarifarioNuevo1;
        private CheckBox CheckBoxVigente;
        private Label label1;
        private Label label12;
        private Label label2;
        private NumericUpDown NumericUDAño;
    }
}