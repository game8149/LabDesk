using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace LabDesk.Code.StyleManager
{
    internal class StyleUIPalette
    {
        private Dictionary<StyleUI.StyleTipe, StyleUI> estilos;
        private static StyleUIPalette obj;

        public StyleUI GetStyle(StyleUI.StyleTipe tipo) => 
            this.estilos[tipo];

        public void Init()
        {
            this.estilos = new Dictionary<StyleUI.StyleTipe, StyleUI>();
            StyleUI eui = new StyleUI {
                ButtonOK = { 
                    Size = new Size(0x70, 40),
                    BackGroundBack = Color.FromArgb(0x33, 0x66, 0xff),
                    BackGroundOver = Color.FromArgb(0x47, 0x73, 0xff),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0x33, 0x66, 0xff),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0x33, 0x66, 0xff),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand,
                    BackGroundSelect = Color.FromArgb(0x33, 0x66, 0xff)
                },
                ButtonCancel = { 
                    Size = new Size(0x70, 40),
                    BackGroundBack = Color.FromArgb(0x6f, 0x6b, 0x6b),
                    BackGroundOver = Color.FromArgb(0x75, 0x71, 0x71),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0x4c, 0x4a, 0x4a),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0x80, 0x80, 0x80),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand,
                    BackGroundSelect = Color.FromArgb(0x33, 0x66, 0xff)
                },
                ButtonNext = { 
                    Size = new Size(0x70, 40),
                    BackGroundBack = Color.FromArgb(0x6f, 0x6b, 0x6b),
                    BackGroundOver = Color.FromArgb(0x75, 0x71, 0x71),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0x4c, 0x4a, 0x4a),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0x80, 0x80, 0x80),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand,
                    BackGroundSelect = Color.FromArgb(0x33, 0x66, 0xff)
                },
                ButtonDelete = { 
                    Size = new Size(0x70, 40),
                    BackGroundBack = Color.FromArgb(0x8b, 0x13, 0x13),
                    BackGroundOver = Color.FromArgb(0xb7, 0x19, 0x19),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0x8b, 0x13, 0x13),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0xd6, 0x1c, 0x1c),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand,
                    BackGroundSelect = Color.FromArgb(0x33, 0x66, 0xff)
                },
                ButtonItem = { 
                    Size = new Size(0xa2, 0x3a),
                    BackGroundBack = Color.FromArgb(0x33, 0x66, 0xff),
                    BackGroundOver = Color.FromArgb(0x47, 0x73, 0xff),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0x33, 0x66, 0xff),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0x33, 0x66, 0xff),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Cursor = Cursors.Hand,
                    BackGroundSelect = Color.FromArgb(0x33, 0x66, 0xff)
                },
                ButtonItemLow = { 
                    Size = new Size(0xa2, 0x3a),
                    BackGroundBack = Color.FromArgb(0x3a, 0x38, 0x38),
                    BackGroundOver = Color.FromArgb(0x4c, 0x4a, 0x4a),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0x4c, 0x4a, 0x4a),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0x63, 0x61, 0x5c),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Cursor = Cursors.Hand,
                    BackGroundSelect = Color.FromArgb(0x7a, 120, 120)
                },
                ButtonDefault = { 
                    Size = new Size(0x70, 40),
                    BackGroundBack = Color.FromArgb(0x33, 0x66, 0xff),
                    BackGroundOver = Color.FromArgb(0x47, 0x73, 0xff),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0x33, 0x66, 0xff),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0x33, 0x66, 0xff),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand,
                    BackGroundSelect = Color.FromArgb(0x33, 0x66, 0xff)
                },
                ButtonItemLight = { 
                    Size = new Size(0xa2, 0x3a),
                    BackGroundBack = Color.FromArgb(0x3a, 0x38, 0x38),
                    BackGroundOver = Color.FromArgb(0x4c, 0x4a, 0x4a),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0x4c, 0x4a, 0x4a),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0x63, 0x61, 0x5c),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand,
                    BackGroundSelect = Color.FromArgb(0x33, 0x66, 0xff)
                },
                PanelLateralControl = { 
                    Size = new Size(0x70, 40),
                    BackGroundBack = Color.FromArgb(0x27, 0x6c, 0xab),
                    BackGroundOver = Color.FromArgb(0x47, 0x73, 0xff),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0x27, 0x6c, 0xab),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0x33, 0x66, 0xff),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Arrow,
                    BackGroundSelect = Color.FromArgb(0x33, 0x66, 0xff)
                },
                PanelBarTable = { 
                    Size = new Size(0x70, 40),
                    BackGroundBack = Color.FromArgb(0x27, 0x6c, 0xab),
                    BackGroundOver = Color.FromArgb(0x47, 0x73, 0xff),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0x27, 0x6c, 0xab),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0x33, 0x66, 0xff),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Arrow,
                    BackGroundSelect = Color.FromArgb(0x33, 0x66, 0xff)
                }
            };
            this.estilos.Add(StyleUI.StyleTipe.Default, eui);
            eui = new StyleUI {
                ButtonOK = { 
                    Size = new Size(0x70, 40),
                    BackGroundBack = Color.FromArgb(0x80, 0, 0x80),
                    BackGroundOver = Color.FromArgb(0x92, 0, 0x92),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0x80, 0, 0x80),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0xb0, 0, 0xb0),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand,
                    BackGroundSelect = Color.FromArgb(0x80, 0, 0x80)
                },
                ButtonCancel = { 
                    Size = new Size(0x70, 40),
                    BackGroundBack = Color.FromArgb(0x6f, 0x6b, 0x6b),
                    BackGroundOver = Color.FromArgb(0x75, 0x71, 0x71),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0x4c, 0x4a, 0x4a),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0x80, 0x80, 0x80),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand,
                    BackGroundSelect = Color.FromArgb(0x80, 0, 0x80)
                },
                ButtonDelete = { 
                    Size = new Size(0x70, 40),
                    BackGroundBack = Color.FromArgb(0x8b, 0x13, 0x13),
                    BackGroundOver = Color.FromArgb(0xb7, 0x19, 0x19),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0x8b, 0x13, 0x13),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0xd6, 0x1c, 0x1c),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand,
                    BackGroundSelect = Color.FromArgb(0x80, 0, 0x80)
                },
                ButtonNext = { 
                    Size = new Size(0x70, 40),
                    BackGroundBack = Color.FromArgb(0x6f, 0x6b, 0x6b),
                    BackGroundOver = Color.FromArgb(0x75, 0x71, 0x71),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0x4c, 0x4a, 0x4a),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0x80, 0x80, 0x80),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand,
                    BackGroundSelect = Color.FromArgb(0x80, 0, 0x80)
                },
                ButtonItem = { 
                    Size = new Size(0xa2, 0x3a),
                    BackGroundBack = Color.FromArgb(0x80, 0, 0x80),
                    BackGroundOver = Color.FromArgb(0x92, 0, 0x92),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0x80, 0, 0x80),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0xb0, 0, 0xb0),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Cursor = Cursors.Hand,
                    BackGroundSelect = Color.FromArgb(0x80, 0, 0x80)
                },
                ButtonItemLow = { 
                    Size = new Size(0xa2, 0x3a),
                    BackGroundBack = Color.FromArgb(0x3a, 0x38, 0x38),
                    BackGroundOver = Color.FromArgb(0x4c, 0x4a, 0x4a),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0x4c, 0x4a, 0x4a),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0x63, 0x61, 0x5c),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Cursor = Cursors.Hand,
                    BackGroundSelect = Color.FromArgb(0x7a, 120, 120)
                },
                ButtonDefault = { 
                    Size = new Size(0x70, 40),
                    BackGroundBack = Color.FromArgb(0x80, 0, 0x80),
                    BackGroundOver = Color.FromArgb(0x92, 0, 0x92),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0x80, 0, 0x80),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0xb0, 0, 0xb0),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand,
                    BackGroundSelect = Color.FromArgb(0x80, 0, 0x80)
                },
                ButtonItemLight = { 
                    Size = new Size(0xa2, 0x3a),
                    BackGroundBack = Color.FromArgb(0x3a, 0x38, 0x38),
                    BackGroundOver = Color.FromArgb(0x4c, 0x4a, 0x4a),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0x4c, 0x4a, 0x4a),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0x63, 0x61, 0x5c),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand,
                    BackGroundSelect = Color.FromArgb(0x80, 0, 0x80)
                },
                PanelLateralControl = { 
                    Size = new Size(0x70, 40),
                    BackGroundBack = Color.FromArgb(0x5e, 0x18, 0x59),
                    BackGroundOver = Color.FromArgb(0x5e, 0x18, 0x59),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0x5e, 0x18, 0x59),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0x5e, 0x18, 0x59),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand,
                    BackGroundSelect = Color.FromArgb(0x5e, 0x18, 0x59)
                },
                PanelBarTable = { 
                    Size = new Size(0x70, 40),
                    BackGroundBack = Color.FromArgb(0x5e, 0x18, 0x59),
                    BackGroundOver = Color.FromArgb(0x5e, 0x18, 0x59),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0x5e, 0x18, 0x59),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0x5e, 0x18, 0x59),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand,
                    BackGroundSelect = Color.FromArgb(0x5e, 0x18, 0x59)
                }
            };
            this.estilos.Add(StyleUI.StyleTipe.Morado, eui);
            eui = new StyleUI {
                ButtonOK = { 
                    Size = new Size(0x70, 40),
                    BackGroundBack = Color.FromArgb(100, 30, 0x41),
                    BackGroundOver = Color.FromArgb(0x89, 0x43, 0x57),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(100, 30, 0x41),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0x89, 0x43, 0x57),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand,
                    BackGroundSelect = Color.FromArgb(100, 30, 0x41)
                },
                ButtonCancel = { 
                    Size = new Size(0x70, 40),
                    BackGroundBack = Color.FromArgb(0x6f, 0x6b, 0x6b),
                    BackGroundOver = Color.FromArgb(0x75, 0x71, 0x71),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0x4c, 0x4a, 0x4a),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0x80, 0x80, 0x80),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand,
                    BackGroundSelect = Color.FromArgb(100, 30, 0x41)
                },
                ButtonDelete = { 
                    Size = new Size(0x70, 40),
                    BackGroundBack = Color.FromArgb(0xc0, 0, 0),
                    BackGroundOver = Color.FromArgb(210, 0, 0),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0xc0, 0, 0),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0xff, 0, 0),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand,
                    BackGroundSelect = Color.FromArgb(100, 30, 0x41)
                },
                ButtonNext = { 
                    Size = new Size(0x70, 40),
                    BackGroundBack = Color.FromArgb(0x6f, 0x6b, 0x6b),
                    BackGroundOver = Color.FromArgb(0x75, 0x71, 0x71),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0x4c, 0x4a, 0x4a),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0x80, 0x80, 0x80),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand,
                    BackGroundSelect = Color.FromArgb(100, 30, 0x41)
                },
                ButtonItem = { 
                    Size = new Size(0xa2, 0x3a),
                    BackGroundBack = Color.FromArgb(100, 30, 0x41),
                    BackGroundOver = Color.FromArgb(0x89, 0x43, 0x57),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(100, 30, 0x41),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0x89, 0x43, 0x57),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Cursor = Cursors.Hand,
                    BackGroundSelect = Color.FromArgb(100, 30, 0x41)
                },
                ButtonItemLow = { 
                    Size = new Size(0xa2, 0x3a),
                    BackGroundBack = Color.FromArgb(0x3a, 0x38, 0x38),
                    BackGroundOver = Color.FromArgb(0x4c, 0x4a, 0x4a),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0x4c, 0x4a, 0x4a),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0x63, 0x61, 0x5c),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Cursor = Cursors.Hand,
                    BackGroundSelect = Color.FromArgb(0x7a, 120, 120)
                },
                ButtonDefault = { 
                    Size = new Size(0x70, 40),
                    BackGroundBack = Color.FromArgb(100, 30, 0x41),
                    BackGroundOver = Color.FromArgb(0x89, 0x43, 0x57),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(100, 30, 0x41),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0x89, 0x43, 0x57),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand,
                    BackGroundSelect = Color.FromArgb(100, 30, 0x41)
                },
                ButtonItemLight = { 
                    Size = new Size(0xa2, 0x3a),
                    BackGroundBack = Color.FromArgb(0x3a, 0x38, 0x38),
                    BackGroundOver = Color.FromArgb(0x4c, 0x4a, 0x4a),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0x4c, 0x4a, 0x4a),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0x63, 0x61, 0x5c),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand,
                    BackGroundSelect = Color.FromArgb(100, 30, 0x41)
                },
                PanelLateralControl = { 
                    Size = new Size(0x70, 40),
                    BackGroundBack = Color.FromArgb(0x89, 0x43, 0x57),
                    BackGroundOver = Color.FromArgb(0x89, 0x43, 0x57),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0x89, 0x43, 0x57),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0x89, 0x43, 0x57),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand,
                    BackGroundSelect = Color.FromArgb(0x89, 0x43, 0x57)
                },
                PanelBarTable = { 
                    Size = new Size(0x70, 40),
                    BackGroundBack = Color.FromArgb(0x89, 0x43, 0x57),
                    BackGroundOver = Color.FromArgb(0x89, 0x43, 0x57),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0x89, 0x43, 0x57),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0x89, 0x43, 0x57),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand,
                    BackGroundSelect = Color.FromArgb(0x89, 0x43, 0x57)
                }
            };
            this.estilos.Add(StyleUI.StyleTipe.MoradoDaltonic, eui);
            eui = new StyleUI {
                ButtonOK = { 
                    Size = new Size(0x70, 40),
                    BackGroundBack = Color.FromArgb(0x33, 0x66, 0xff),
                    BackGroundOver = Color.FromArgb(0x47, 0x73, 0xff),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0x33, 0x66, 0xff),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0x33, 0x66, 0xff),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand,
                    BackGroundSelect = Color.FromArgb(0x33, 0x66, 0xff)
                },
                ButtonCancel = { 
                    Size = new Size(0x70, 40),
                    BackGroundBack = Color.FromArgb(0x6f, 0x6b, 0x6b),
                    BackGroundOver = Color.FromArgb(0x75, 0x71, 0x71),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0x4c, 0x4a, 0x4a),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0x80, 0x80, 0x80),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand,
                    BackGroundSelect = Color.FromArgb(0x33, 0x66, 0xff)
                },
                ButtonNext = { 
                    Size = new Size(0x70, 40),
                    BackGroundBack = Color.FromArgb(0x6f, 0x6b, 0x6b),
                    BackGroundOver = Color.FromArgb(0x75, 0x71, 0x71),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0x4c, 0x4a, 0x4a),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0x80, 0x80, 0x80),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand,
                    BackGroundSelect = Color.FromArgb(0x33, 0x66, 0xff)
                },
                ButtonDelete = { 
                    Size = new Size(0x70, 40),
                    BackGroundBack = Color.FromArgb(0xc0, 0, 0),
                    BackGroundOver = Color.FromArgb(210, 0, 0),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0xc0, 0, 0),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0xff, 0, 0),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand,
                    BackGroundSelect = Color.FromArgb(0xb6, 0x6a, 0x80)
                },
                ButtonItem = { 
                    Size = new Size(0xa2, 0x3a),
                    BackGroundBack = Color.FromArgb(0x33, 0x66, 0xff),
                    BackGroundOver = Color.FromArgb(0x47, 0x73, 0xff),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0x33, 0x66, 0xff),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0x33, 0x66, 0xff),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Cursor = Cursors.Hand,
                    BackGroundSelect = Color.FromArgb(0x33, 0x66, 0xff)
                },
                ButtonItemLow = { 
                    Size = new Size(0xa2, 0x3a),
                    BackGroundBack = Color.FromArgb(0x3a, 0x38, 0x38),
                    BackGroundOver = Color.FromArgb(0x4c, 0x4a, 0x4a),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0x4c, 0x4a, 0x4a),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0x63, 0x61, 0x5c),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Cursor = Cursors.Hand,
                    BackGroundSelect = Color.FromArgb(0x7a, 120, 120)
                },
                ButtonDefault = { 
                    Size = new Size(0x70, 40),
                    BackGroundBack = Color.FromArgb(0x33, 0x66, 0xff),
                    BackGroundOver = Color.FromArgb(0x47, 0x73, 0xff),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0x33, 0x66, 0xff),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0x33, 0x66, 0xff),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand,
                    BackGroundSelect = Color.FromArgb(0x33, 0x66, 0xff)
                },
                ButtonItemLight = { 
                    Size = new Size(0xa2, 0x3a),
                    BackGroundBack = Color.FromArgb(0x3a, 0x38, 0x38),
                    BackGroundOver = Color.FromArgb(0x4c, 0x4a, 0x4a),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0x4c, 0x4a, 0x4a),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0x63, 0x61, 0x5c),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand,
                    BackGroundSelect = Color.FromArgb(0x33, 0x66, 0xff)
                },
                PanelLateralControl = { 
                    Size = new Size(0x70, 40),
                    BackGroundBack = Color.FromArgb(0x27, 0x6c, 0xab),
                    BackGroundOver = Color.FromArgb(0x47, 0x73, 0xff),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0x27, 0x6c, 0xab),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0x33, 0x66, 0xff),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Arrow,
                    BackGroundSelect = Color.FromArgb(0x33, 0x66, 0xff)
                },
                PanelBarTable = { 
                    Size = new Size(0x70, 40),
                    BackGroundBack = Color.FromArgb(0x27, 0x6c, 0xab),
                    BackGroundOver = Color.FromArgb(0x47, 0x73, 0xff),
                    FontColor = Color.FromArgb(0xff, 0xff, 0xff),
                    FontSize = 10,
                    BordeColor = Color.FromArgb(0x27, 0x6c, 0xab),
                    BordeSize = 1,
                    BackGroundDown = Color.FromArgb(0x33, 0x66, 0xff),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Arrow,
                    BackGroundSelect = Color.FromArgb(0x33, 0x66, 0xff)
                }
            };
            this.estilos.Add(StyleUI.StyleTipe.DefaultDaltonic, eui);
        }

        public static StyleUIPalette Instance()
        {
            if (obj == null)
            {
                obj = new StyleUIPalette();
                obj.Init();
            }
            return obj;
        }
    }
}
