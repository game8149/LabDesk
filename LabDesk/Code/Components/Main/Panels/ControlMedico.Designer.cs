
using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Main.Panels
{
    partial class ControlMedico
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.PanelTrabajo = new Panel();
            this.PanelLateral = new Panel();
            this.LinkAbrirPerfil = new LinkLabel();
            this.label4 = new Label();
            this.LinkNuevoPerfil = new LinkLabel();
            this.PanelTrabajo.SuspendLayout();
            this.PanelLateral.SuspendLayout();
            base.SuspendLayout();
            this.PanelTrabajo.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.PanelTrabajo.Controls.Add(this.PanelLateral);
            this.PanelTrabajo.Location = new Point(0, 0);
            this.PanelTrabajo.Margin = new Padding(0);
            this.PanelTrabajo.Name = "PanelTrabajo";
            this.PanelTrabajo.Size = new Size(0x435, 0x228);
            this.PanelTrabajo.TabIndex = 0x60;
            this.PanelTrabajo.Paint += new PaintEventHandler(this.PanelTrabajo_Paint);
            this.PanelLateral.Anchor = AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
            this.PanelLateral.BackColor = Color.DarkCyan;
            this.PanelLateral.Controls.Add(this.LinkAbrirPerfil);
            this.PanelLateral.Controls.Add(this.label4);
            this.PanelLateral.Controls.Add(this.LinkNuevoPerfil);
            this.PanelLateral.Location = new Point(0x32b, 0);
            this.PanelLateral.Margin = new Padding(0);
            this.PanelLateral.Name = "PanelLateral";
            this.PanelLateral.Size = new Size(0x10a, 0x22a);
            this.PanelLateral.TabIndex = 0x7f;
            this.LinkAbrirPerfil.ActiveLinkColor = Color.White;
            this.LinkAbrirPerfil.AutoSize = true;
            this.LinkAbrirPerfil.BackColor = Color.Transparent;
            this.LinkAbrirPerfil.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.LinkAbrirPerfil.ForeColor = SystemColors.ControlLightLight;
            this.LinkAbrirPerfil.LinkColor = Color.White;
            this.LinkAbrirPerfil.Location = new Point(0x17, 100);
            this.LinkAbrirPerfil.Name = "LinkAbrirPerfil";
            this.LinkAbrirPerfil.Size = new Size(0x45, 0x10);
            this.LinkAbrirPerfil.TabIndex = 9;
            this.LinkAbrirPerfil.TabStop = true;
            this.LinkAbrirPerfil.Text = "Abrir Perfil";
            this.LinkAbrirPerfil.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            this.label4.AutoSize = true;
            this.label4.BackColor = Color.Transparent;
            this.label4.Font = new Font("Futura Bk BT", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label4.ForeColor = SystemColors.ControlLightLight;
            this.label4.Location = new Point(0x16, 0x19);
            this.label4.Name = "label4";
            this.label4.Size = new Size(70, 0x13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Acciones";
            this.LinkNuevoPerfil.ActiveLinkColor = Color.White;
            this.LinkNuevoPerfil.AutoSize = true;
            this.LinkNuevoPerfil.BackColor = Color.Transparent;
            this.LinkNuevoPerfil.Font = new Font("Futura Bk BT", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.LinkNuevoPerfil.ForeColor = SystemColors.ControlLightLight;
            this.LinkNuevoPerfil.LinkColor = Color.White;
            this.LinkNuevoPerfil.Location = new Point(0x17, 0x43);
            this.LinkNuevoPerfil.Name = "LinkNuevoPerfil";
            this.LinkNuevoPerfil.Size = new Size(0x4e, 0x10);
            this.LinkNuevoPerfil.TabIndex = 4;
            this.LinkNuevoPerfil.TabStop = true;
            this.LinkNuevoPerfil.Text = "Nuevo Perfil";
            this.LinkNuevoPerfil.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = SystemColors.Window;
            base.Controls.Add(this.PanelTrabajo);
            this.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            base.Name = "ControlMedico";
            base.Size = new Size(0x435, 0x228);
            this.PanelTrabajo.ResumeLayout(false);
            this.PanelLateral.ResumeLayout(false);
            this.PanelLateral.PerformLayout();
            base.ResumeLayout(false);
        }

        #endregion



        private Label label4;
        private LinkLabel LinkAbrirPerfil;
        private LinkLabel LinkNuevoPerfil;
        private Panel PanelLateral;
        private Panel PanelTrabajo;

    }
}
