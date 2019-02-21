using System.Configuration;
using System.Windows.Controls;
using System.Windows.Input;

namespace LabDeskWPF.ModelViews.Base
{
    public class DocumentationLink
    {
        public DocumentationLink(DocumentationLinkType type, string url) : this(type, url, null)
        {
        }

        public DocumentationLink(DocumentationLinkType type, string url, string label)
        {
            Label = label ?? type.ToString();
            Url = url;
            Type = type;
            Open = new AnotherCommandImplementation(Execute);
        }        

        public static DocumentationLink WikiLink(string page, string label)
        {
            return new DocumentationLink(DocumentationLinkType.Wiki,
                $"test/wiki/" + page, label);
        }

        public static DocumentationLink StyleLink(string nameChunk)
        {            
            return new DocumentationLink(
                DocumentationLinkType.StyleSource,
                $"test/blob/master/MaterialDesignThemes.Wpf/Themes/MaterialDesignTheme.{nameChunk}.xaml",
                nameChunk);
        }

        public static DocumentationLink ApiLink<TClass>(string subNamespace)
        {
            var typeName = typeof(TClass).Name;

            return new DocumentationLink(
                DocumentationLinkType.ControlSource,
                $"test/blob/master/MaterialDesignThemes.Wpf/{subNamespace}/{typeName}.cs",
                typeName);
        }


        public static DocumentationLink ApiLink<TClass>()
        {
            var typeName = typeof(TClass).Name;

            return new DocumentationLink(
                DocumentationLinkType.ControlSource,
                $"test/blob/master/MaterialDesignThemes.Wpf/{typeName}.cs",
                typeName);
        }

        public static DocumentationLink DemoPageLink<TDemoPage>()
        {
            return DemoPageLink<TDemoPage>(null);
        }

        public static DocumentationLink DemoPageLink<TDemoPage>(string label)
        {
            return DemoPageLink<TDemoPage>(label, null);
        }

        public static DocumentationLink DemoPageLink<TDemoPage>(string label, string nameSpace)
        {
            var ext = typeof(UserControl).IsAssignableFrom(typeof(TDemoPage))
                ? "xaml"
                : "cs";


            return new DocumentationLink(
                DocumentationLinkType.DemoPageSource,
                $"test/blob/master/MainDemo.Wpf/{(string.IsNullOrWhiteSpace(nameSpace) ? "" : ("/" + nameSpace + "/" ))}{typeof(TDemoPage).Name}.{ext}",
                label ?? typeof(TDemoPage).Name);
        }

        public string Label { get; }

        public string Url { get; }

        public DocumentationLinkType Type { get; }        

        public ICommand Open { get; }

        private void Execute(object o)
        {
            System.Diagnostics.Process.Start(Url);
        }
    }
}