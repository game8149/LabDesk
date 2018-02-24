namespace LabDesk.Code.Components.Laboratory.Prices
{
    partial class FormCopiarTarifario
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
            this.ComboBoxAno = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NumericUDAño = new System.Windows.Forms.NumericUpDown();
            this.CheckBoxVigente = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUDAño)).BeginInit();
            this.SuspendLayout();
            // 
            // ComboBoxAno
            // 
            this.ComboBoxAno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxAno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboBoxAno.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxAno.FormattingEnabled = true;
            this.ComboBoxAno.Location = new System.Drawing.Point(178, 63);
            this.ComboBoxAno.Name = "ComboBoxAno";
            this.ComboBoxAno.Size = new System.Drawing.Size(115, 24);
            this.ComboBoxAno.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(81, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Copia Año:";
            // 
            // BtnSave
            // 
            this.BtnSave.AutoSize = true;
            this.BtnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnSave.FlatAppearance.BorderSize = 0;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSave.Location = new System.Drawing.Point(128, 179);
            this.BtnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(115, 30);
            this.BtnSave.TabIndex = 76;
            this.BtnSave.Text = "Copiar";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Visible = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(278, 16);
            this.label2.TabIndex = 77;
            this.label2.Text = "Seleccione el tarifario según el año de vigencia:\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(81, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 79;
            this.label3.Text = "Nuevo Año:";
            // 
            // NumericUDAño
            // 
            this.NumericUDAño.Cursor = System.Windows.Forms.Cursors.Default;
            this.NumericUDAño.Font = new System.Drawing.Font("Futura Bk BT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericUDAño.Location = new System.Drawing.Point(178, 102);
            this.NumericUDAño.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.NumericUDAño.Minimum = new decimal(new int[] {
            2016,
            0,
            0,
            0});
            this.NumericUDAño.Name = "NumericUDAño";
            this.NumericUDAño.Size = new System.Drawing.Size(115, 25);
            this.NumericUDAño.TabIndex = 83;
            this.NumericUDAño.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumericUDAño.Value = new decimal(new int[] {
            2016,
            0,
            0,
            0});
            // 
            // CheckBoxVigente
            // 
            this.CheckBoxVigente.AutoSize = true;
            this.CheckBoxVigente.Location = new System.Drawing.Point(109, 146);
            this.CheckBoxVigente.Name = "CheckBoxVigente";
            this.CheckBoxVigente.Size = new System.Drawing.Size(153, 17);
            this.CheckBoxVigente.TabIndex = 84;
            this.CheckBoxVigente.Text = "Hacer este tarifario vigente";
            this.CheckBoxVigente.UseVisualStyleBackColor = true;
            // 
            // FormCopiarTarifario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(373, 236);
            this.Controls.Add(this.CheckBoxVigente);
            this.Controls.Add(this.NumericUDAño);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComboBoxAno);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCopiarTarifario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Copia de Tarifario";
            ((System.ComponentModel.ISupportInitialize)(this.NumericUDAño)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboBoxAno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown NumericUDAño;
        private System.Windows.Forms.CheckBox CheckBoxVigente;
    }
}