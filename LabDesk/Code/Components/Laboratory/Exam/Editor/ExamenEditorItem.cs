using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Laboratory.Exam.Editor
{
    public class ExamenEditorItem : Panel
    {
        private int alto_campoTexto = 50;
        private int alto_etiqueta = 0x19;
        private int alto_unidad = 0x19;
        private int ancho_campo;
        private int ancho_etiqueta;
        private int ancho_unidad;
        private ComboBox comboList;
        private Dictionary<int, string> diccionario;
        private int id;
        private int margeDer = 15;
        private Label nombre;
        private DateTimePicker pickerDate;
        private string regex;
        private TextBox texBoxInput;
        private TextBox texBoxTexto;
        private bool tieneUnidad;
        private TipoCampo tipoCampo;
        private TipoDato tipoDato;
        private Label unidad;
        private Regex validador;

        public ExamenEditorItem(int Ancho, int Alto, bool tieneUnidad)
        {
            base.Height = Alto;
            base.Width = Ancho;
            this.tieneUnidad = tieneUnidad;
            if (this.tieneUnidad)
            {
                this.ancho_campo = (((Ancho / 2) - this.margeDer) * 7) / 10;
                this.ancho_unidad = (((Ancho / 2) - this.margeDer) * 3) / 10;
                this.ancho_etiqueta = Ancho / 2;
            }
            else
            {
                this.ancho_campo = (Ancho / 2) - this.margeDer;
                this.ancho_etiqueta = Ancho / 2;
            }
            this.InicializarComponentes();
            this.DoubleBuffered = true;
            this.comboList.SelectedIndexChanged += new EventHandler(this.ComboList_SelectedIndexChanged);
            this.texBoxInput.KeyPress += new KeyPressEventHandler(this.TexBoxInput_KeyPress);
            this.texBoxTexto.KeyPress += new KeyPressEventHandler(this.TexBoxTexto_KeyPress);
        }

        private void ComboList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ConfiguracionExamen.GetInstance().Loading)
            {
                ConfiguracionExamen.GetInstance().Changed = true;
            }
        }

        public static string DoFormat(double myNumber)
        {
            string str = $"{myNumber:0.000}";
            if (str.EndsWith("00"))
            {
                int num = (int) myNumber;
                return num.ToString();
            }
            return str;
        }

        private void InicializarComponentes()
        {
            this.nombre = new Label();
            this.texBoxInput = new TextBox();
            this.texBoxTexto = new TextBox();
            this.pickerDate = new DateTimePicker();
            this.comboList = new ComboBox();
            this.unidad = new Label();
            this.texBoxInput.TextChanged += new EventHandler(this.TexBoxInput_TextChanged);
            this.texBoxInput.MaxLength = 10;
            this.texBoxTexto.MaxLength = 100;
            this.texBoxTexto.Multiline = true;
            this.comboList.Size = new Size(this.ancho_campo, base.Height);
            this.texBoxInput.Size = new Size(this.ancho_campo, base.Height);
            this.pickerDate.Size = new Size(this.ancho_campo, base.Height);
            this.pickerDate.Format = DateTimePickerFormat.Short;
            this.texBoxTexto.Size = new Size(base.Width, this.alto_campoTexto);
            this.texBoxInput.TextAlign = HorizontalAlignment.Center;
            this.unidad.TextAlign = ContentAlignment.MiddleLeft;
            this.nombre.Location = new Point(0, 0);
            this.nombre.Size = new Size(this.ancho_etiqueta, base.Height - 2);
            this.nombre.TextAlign = ContentAlignment.MiddleLeft;
            if (this.tieneUnidad)
            {
                this.unidad.Size = new Size(this.ancho_unidad, this.alto_unidad);
                this.unidad.Location = new Point((5 + this.ancho_etiqueta) + this.ancho_campo, 0);
                base.Controls.Add(this.unidad);
            }
            base.Controls.Add(this.nombre);
        }

        public void redimensionarWidth(int Ancho)
        {
            Point point;
            base.Width = Ancho;
            if (this.tieneUnidad)
            {
                this.ancho_campo = (((Ancho / 2) - this.margeDer) * 7) / 10;
                this.ancho_unidad = (((Ancho / 2) - this.margeDer) * 3) / 10;
                this.ancho_etiqueta = Ancho / 2;
            }
            else
            {
                this.ancho_campo = (base.Width / 2) - this.margeDer;
                this.ancho_etiqueta = base.Width / 2;
            }
            this.comboList.Size = new Size(this.ancho_campo, this.alto_etiqueta);
            this.texBoxInput.Size = new Size(this.ancho_campo, this.alto_etiqueta);
            this.nombre.Location = new Point(0, 0);
            this.nombre.Size = new Size(this.ancho_etiqueta, this.alto_etiqueta);
            switch (this.tipoCampo)
            {
                case LabDesk.Code.ControlSistemaInterno.TipoCampo.Input:
                    this.texBoxInput.Name = "textBox";
                    point = new Point(this.ancho_etiqueta, 0);
                    this.texBoxInput.Location = point;
                    break;

                case LabDesk.Code.ControlSistemaInterno.TipoCampo.Lista:
                    this.comboList.Name = "comboBox";
                    point = new Point(this.ancho_etiqueta, 0);
                    this.comboList.Location = point;
                    break;

                case LabDesk.Code.ControlSistemaInterno.TipoCampo.Texto:
                    this.texBoxTexto.Name = "textBoxT";
                    point = new Point(0, this.alto_etiqueta + 5);
                    this.texBoxTexto.Width = base.Width - 10;
                    break;

                case LabDesk.Code.ControlSistemaInterno.TipoCampo.Fecha:
                    this.pickerDate.Name = "picker";
                    point = new Point(this.ancho_etiqueta, 0);
                    this.pickerDate.Format = DateTimePickerFormat.Short;
                    this.pickerDate.Location = point;
                    break;
            }
            if (this.tieneUnidad)
            {
                this.unidad.Location = new Point((5 + this.ancho_etiqueta) + this.ancho_campo, 0);
                this.unidad.Size = new Size(this.ancho_unidad, this.alto_unidad);
            }
        }

        private void TexBoxInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!ConfiguracionExamen.GetInstance().Loading)
            {
                ConfiguracionExamen.GetInstance().Changed = true;
            }
        }

        private void TexBoxInput_TextChanged(object sender, EventArgs e)
        {
            if (this.validador != null)
            {
                if (!this.validador.IsMatch(this.texBoxInput.Text))
                {
                    if (this.texBoxInput.TextLength > 0)
                    {
                        this.texBoxInput.Text.Remove(this.texBoxInput.TextLength - 1);
                    }
                }
                else if (this.TipoDato == LabDesk.Code.ControlSistemaInterno.TipoDato.Decimal)
                {
                    this.texBoxInput.Text = DoFormat(Convert.ToDouble(this.texBoxInput.Text));
                }
            }
        }

        private void TexBoxTexto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!ConfiguracionExamen.GetInstance().Loading)
            {
                ConfiguracionExamen.GetInstance().Changed = true;
            }
        }

        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                System.Windows.Forms.CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x2000000;
                return createParams;
            }
        }

        public int IdItem
        {
            get => 
                this.id;
            set
            {
                this.id = value;
            }
        }

        public string Nombre
        {
            get => 
                this.nombre.Text;
            set
            {
                this.nombre.Text = value;
            }
        }

        public Dictionary<int, string> Opciones
        {
            set
            {
                this.diccionario = value;
                this.comboList.DataSource = new BindingSource(this.diccionario, null);
                ((BindingSource) this.comboList.DataSource).Position = 0;
                this.comboList.DisplayMember = "Value";
                this.comboList.ValueMember = "Key";
                this.comboList.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        public string RegEx
        {
            set
            {
                this.regex = value;
                this.validador = new Regex(this.regex);
            }
        }

        public LabDesk.Code.ControlSistemaInterno.TipoCampo TipoCampo
        {
            get => 
                this.tipoCampo;
            set
            {
                Point point;
                this.tipoCampo = value;
                switch (this.tipoCampo)
                {
                    case LabDesk.Code.ControlSistemaInterno.TipoCampo.Input:
                        point = new Point(this.ancho_etiqueta, 0);
                        this.texBoxInput.Name = "textBox";
                        this.texBoxInput.Location = point;
                        base.Controls.Add(this.texBoxInput);
                        return;

                    case LabDesk.Code.ControlSistemaInterno.TipoCampo.Lista:
                        point = new Point(this.ancho_etiqueta, 0);
                        this.comboList.Name = "comboBox";
                        this.comboList.Location = point;
                        base.Controls.Add(this.comboList);
                        return;

                    case LabDesk.Code.ControlSistemaInterno.TipoCampo.Texto:
                        point = new Point(0, this.nombre.Height + 5);
                        this.texBoxTexto.Name = "texBoxTexto";
                        this.texBoxTexto.Location = point;
                        base.Controls.Add(this.texBoxTexto);
                        return;

                    case LabDesk.Code.ControlSistemaInterno.TipoCampo.Fecha:
                        this.pickerDate.Name = "picker";
                        point = new Point(this.ancho_etiqueta, 0);
                        this.pickerDate.Location = point;
                        base.Controls.Add(this.pickerDate);
                        return;
                }
            }
        }

        public LabDesk.Code.ControlSistemaInterno.TipoDato TipoDato
        {
            get => 
                this.tipoDato;
            set
            {
                this.tipoDato = value;
            }
        }

        public string Unidad
        {
            get => 
                this.unidad.Text;
            set
            {
                this.unidad.Text = value;
            }
        }

        public string Value
        {
            get
            {
                if (this.TipoCampo == LabDesk.Code.ControlSistemaInterno.TipoCampo.Input)
                {
                    return this.texBoxInput.Text;
                }
                if (this.TipoCampo == LabDesk.Code.ControlSistemaInterno.TipoCampo.Lista)
                {
                    return Convert.ToString(this.comboList.SelectedIndex);
                }
                if (this.TipoCampo == LabDesk.Code.ControlSistemaInterno.TipoCampo.Texto)
                {
                    return this.texBoxTexto.Text;
                }
                if (this.TipoCampo == LabDesk.Code.ControlSistemaInterno.TipoCampo.Fecha)
                {
                    return this.pickerDate.Value.ToShortDateString();
                }
                return "";
            }
            set
            {
                if (this.TipoCampo == LabDesk.Code.ControlSistemaInterno.TipoCampo.Input)
                {
                    this.texBoxInput.Text = value;
                }
                else if (this.TipoCampo == LabDesk.Code.ControlSistemaInterno.TipoCampo.Lista)
                {
                    ((BindingSource) this.comboList.DataSource).Position = Convert.ToInt32(value);
                }
                else if (this.TipoCampo == LabDesk.Code.ControlSistemaInterno.TipoCampo.Texto)
                {
                    this.texBoxTexto.Text = value;
                }
                else if (this.TipoCampo == LabDesk.Code.ControlSistemaInterno.TipoCampo.Fecha)
                {
                    this.pickerDate.Value = DateTime.Parse(value);
                }
            }
        }
    }
}
