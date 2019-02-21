 
using MaterialDesignThemes.Wpf; 
using System.Windows.Controls;
using System; 

namespace LabDeskWPF.ModelViews.Base
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel(ISnackbarMessageQueue snackbarMessageQueue)
        {
            if (snackbarMessageQueue == null) throw new ArgumentNullException(nameof(snackbarMessageQueue));

            DemoItems = new[]
            {
                new DemoItem("HomeOutline",null, null
                ),
                new DemoItem("PaletteAdvanced", null, null),
                new DemoItem("ChevronRightCircleOutline",null, null)
                    {
                        VerticalScrollBarVisibilityRequirement = ScrollBarVisibility.Auto
                    },
                new DemoItem("Fields", null, null)
                    {
                        VerticalScrollBarVisibilityRequirement = ScrollBarVisibility.Auto
                    },
                new DemoItem("Pickers", null, null),
                new DemoItem("Sliders", null, null),
                new DemoItem("Chips", null, null),
                new DemoItem("Typography",null, null)
                    {
                        VerticalScrollBarVisibilityRequirement = ScrollBarVisibility.Auto,
                        HorizontalScrollBarVisibilityRequirement = ScrollBarVisibility.Auto
                    },
                new DemoItem("Cards", null, null)
                {
                    VerticalScrollBarVisibilityRequirement = ScrollBarVisibility.Auto
                },
                new DemoItem("Icon Pack", null, null),
                new DemoItem("Colour Zones", null, null),
                new DemoItem("Lists", null, null)
                {
                    VerticalScrollBarVisibilityRequirement = ScrollBarVisibility.Auto
                },
                new DemoItem("Trees", null, null),
                new DemoItem("Grids", null, null),
                new DemoItem("Expander", new Expander(),
                    new []
                    {
                        DocumentationLink.DemoPageLink<Expander>(),
                        DocumentationLink.StyleLink("Expander")
                    }),
                new DemoItem("Group Boxes", null, null)  
            };
        }

        public DemoItem[] DemoItems { get; }
    }
}