namespace LabDesk.Code.Components.Laboratory.Prices
{
    partial class FormCrearTarifario
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
            this.label2 = new System.Windows.Forms.Label();
            this.BtnCrear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NumericUDAño = new System.Windows.Forms.NumericUpDown();
            this.CheckBoxVigente = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUDAño)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 16);
            this.label2.TabIndex = 81;
            this.label2.Text = "Seleccione el año:\r\n";
            // 
            // BtnCrear
            // 
            this.BtnCrear.AutoSize = true;
            this.BtnCrear.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnCrear.FlatAppearance.BorderSize = 0;
            this.BtnCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCrear.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCrear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnCrear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCrear.Location = new System.Drawing.Point(126, 150);
            this.BtnCrear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnCrear.Name = "BtnCrear";
            this.BtnCrear.Size = new System.Drawing.Size(115, 30);
            this.BtnCrear.TabIndex = 80;
            this.BtnCrear.Text = "Crear";
            this.BtnCrear.UseVisualStyleBackColor = false;
            this.BtnCrear.Visible = false;
            this.BtnCrear.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(83, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 79;
            this.label1.Text = "Nuevo Año:";
            // 
            // NumericUDAño
            // 
            this.NumericUDAño.Cursor = System.Windows.Forms.Cursors.Default;
            this.NumericUDAño.Font = new System.Drawing.Font("Futura Bk BT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericUDAño.Location = new System.Drawing.Point(180, 64);
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
            this.NumericUDAño.TabIndex = 82;
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
            this.CheckBoxVigente.Location = new System.Drawing.Point(110, 108);
            this.CheckBoxVigente.Name = "CheckBoxVigente";
            this.CheckBoxVigente.Size = new System.Drawing.Size(153, 17);
            this.CheckBoxVigente.TabIndex = 83;
            this.CheckBoxVigente.Text = "Hacer este tarifario vigente";
            this.CheckBoxVigente.UseVisualStyleBackColor = true;
            // 
            // FormCrearTarifario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(373, 209);
            this.Controls.Add(this.CheckBoxVigente);
            this.Controls.Add(this.NumericUDAño);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnCrear);
            this.Controls.Add(this.label1);
            this.Name = "FormCrearTarifario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Creacion de Tarifario";
            ((System.ComponentModel.ISupportInitialize)(this.NumericUDAño)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnCrear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NumericUDAño;
        private System.Windows.Forms.CheckBox CheckBoxVigente;
    }
}