using Entity.Code.Analysis.Templates.Print;
using System.Collections.Generic;

namespace LabServices.Code.PrintingManager
{
    public class PrintBuffer
    {
        private List<TemplatePrint> _templates = new List<TemplatePrint>();
        private int _currentTemplateIndex;
        private int _currentLineIndex;
        private int _currentPageIndex;

        public PrintBuffer(List<TemplatePrint> templates)
        {
            _templates = templates;
            _currentTemplateIndex = -1;
            _currentPageIndex = -1;
            _currentLineIndex = -1;
            _isReadMode = false;
        }

        public bool EmptyTemplates() => 
            (_currentTemplateIndex >= _templates.Count);

        public bool EmptyLines() => 
            (_currentLineIndex >= _templates[_currentTemplateIndex].Pages[_currentPageIndex].Detail.Count);

        public bool EmptyPages() => 
            (_currentPageIndex >= _templates[_currentTemplateIndex].Pages.Count);

        public TemplatePrint GetTemplate()
        {
            if (!EmptyTemplates())
            {
                return _templates[_currentTemplateIndex];
            }
            return null;
        }

        public TemplatePrintPageLine GetLine()
        {
            if ((!EmptyTemplates() && !EmptyPages()) && !EmptyLines())
            {
                return _templates[_currentTemplateIndex].Pages[_currentPageIndex].Detail[_currentLineIndex];
            }
            return null;
        }

        public TemplatePrintPage GetPage()
        {
            if (!EmptyTemplates() && !EmptyPages())
            {
                return _templates[_currentTemplateIndex].Pages[_currentPageIndex];
            }
            return null;
        }

        public bool NextTemplate()
        {
            _currentTemplateIndex++;
            _currentPageIndex = -1;
            _currentLineIndex = -1;
            return !EmptyTemplates();
        }

        public bool NextLine()
        {
            _currentLineIndex++;
            return !EmptyLines();
        }

        public bool NextPage()
        {
            _currentPageIndex++;
            _currentLineIndex = -1;
            return !EmptyPages();
        }

        public bool _isReadMode { get; set; }
    }
}
