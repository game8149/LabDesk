using System.Collections.Generic;
using System.Drawing;

namespace Entity.Code.Base.Print
{
    public class TemplatePrint
    {
        private TemplatePrintHead _header;
        private List<TemplatePrintPage> _pages;
        private Size _size;

        public TemplatePrint()
        {
            _header = new TemplatePrintHead();
            _pages = new List<TemplatePrintPage>();
            _size = new Size();
        }

        public int Height
        {
            get { return _size.Height; }
            set { _size.Height = value; }
        }

        public int Width
        {
            get { return _size.Width; }
            set { _size.Width = value; }
        }

        public TemplatePrintHead Cabecera
        {
            get { return _header; }
            set { _header = value; }
        }

        public List<TemplatePrintPage> Pages
        {
            get { return _pages; }
            set { _pages = value; }
        }

        public Size Tamaño
        {
            get { return _size; }
            set { _size = value; }
        }
    }
}
