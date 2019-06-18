using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

//Biblioteki potrzebne do Painta
using System.Windows.Ink;
using System.Windows.Navigation;
using System.Reflection;

namespace R6
{
    /// <summary>
    /// Logika interakcji dla klasy BorderWindow.xaml
    /// </summary>
    public partial class BorderWindow : Window
    {
        /// <summary>
        /// Zmienna globalna P
        /// </summary>
        public int P { get; set; }
        /// <summary>
        /// Typ logiczny Use
        /// </summary>
        public bool Use { get; set; }
        /// <summary>
        /// Strona Startowa
        /// </summary>
        public BorderWindow()
        {
            InitializeComponent();
            Start();
            //Paint start
            BrushColorCombo.ItemsSource = typeof(Colors).GetProperties();
            PropertyInfo[] colors = BrushColorCombo.ItemsSource.Cast<PropertyInfo>().ToArray();
            for (int i = 0; i < colors.Length; i++)
            {
                if (colors[i].Name == "Red")
                {
                    BrushColorCombo.SelectedIndex = i;
                    ColorMode = i;
                    break;
                }
            }
            var drawingAttributes = Paintings[P].DefaultDrawingAttributes;
            drawingAttributes.Width = 5;
            drawingAttributes.Height = 5;
            Paintings[P].EraserShape = new RectangleStylusShape(BrushSlider.Value = 5, BrushSlider.Value = 5);

            // From the help:
            // "If you change the EraserShape, the cursor rendered on the InkCanvas is not updated until the next EditingMode change."
            var previousEditingMode = Paintings[P].EditingMode;
            Paintings[P].EditingMode = InkCanvasEditingMode.None;
            Paintings[P].EditingMode = previousEditingMode;
        }
        /// <summary>
        /// Globalna zmienna
        /// </summary>
        private int ColorMode { get; set; }
        /// <summary>
        /// Ustawia Kolor
        /// </summary>
        private void setColorMode()
        {
            PropertyInfo[] colors = BrushColorCombo.ItemsSource.Cast<PropertyInfo>().ToArray();
            //BrushColorCombo.SelectedIndex = ColorMode;
            for (int i = 0; i <= ColorMode; i++)
            {
                    BrushColorCombo.SelectedIndex = i;
            }
        }
        /// <summary>
        /// Tablica tablic do rysowania
        /// </summary>
        private InkCanvas[] Paintings = new InkCanvas[4];
        /// <summary>
        /// Wszystkie rzeczy które mają się wykonać
        /// </summary>
        private void Start()
        {
            P = 1;
            Paintings[0] = PaintBoard1;
            Paintings[1] = PaintBoard1;
            Paintings[2] = PaintBoard2;
            Paintings[3] = PaintBoard3;
            Paintings[1].Visibility = Visibility.Visible;
            Paintings[2].Visibility = Visibility.Hidden;
            Paintings[3].Visibility = Visibility.Hidden;
            MapBoard1.Visibility = Visibility.Visible;
            MapBoard2.Visibility = Visibility.Hidden;
            MapBoard3.Visibility = Visibility.Hidden;
            Floor1[0] = true;
            Floor2[0] = true;
            WallList();
            FloorsHidding(69);
        }
        /// <summary>
        /// Stałą zmienna która przechowuje liczbe bool w tablicy
        /// </summary>
        const int wf1 = 70;
        /// <summary>
        /// Typ Logiczny piętra 1
        /// </summary>
        private bool[] Floor1 = new bool[wf1];
        /// <summary>
        /// Typ logiczny piętra 2
        /// </summary>
        private bool[] Floor2 = new bool[35];
        /// <summary>
        /// Tablica ścian
        /// </summary>
        private Grid[] WallsFloor = new Grid[wf1];
        /// <summary>
        /// Ukrywa wszystkie ściany w trakcie startu
        /// </summary>
        private void Hidding(int i)
        {
            if (WallsFloor[i].Opacity == 100)
            {
                WallsFloor[i].Opacity = 0;
                Floor1[i] = true;
            }
            else
            {
                WallsFloor[i].Opacity = 100;
                Floor1[i] = false;
            }
        }
        /// <summary>
        /// Lista ścian
        /// </summary>
        private void WallList()
        {
            WallsFloor[1] = Wall1;
            WallsFloor[2] = Wall2;
            WallsFloor[3] = Wall3;
            WallsFloor[4] = Wall4;
            WallsFloor[5] = Wall5;
            WallsFloor[6] = Wall6;
            WallsFloor[7] = Wall7;
            WallsFloor[8] = Wall8;
            WallsFloor[9] = Wall9;
            WallsFloor[10] = Wall10;
            WallsFloor[11] = Wall11;
            WallsFloor[12] = Wall12;
            WallsFloor[13] = Wall13;
            WallsFloor[14] = Wall14;
            WallsFloor[15] = Wall15;
            WallsFloor[16] = Wall16;
            WallsFloor[17] = Wall17;
            WallsFloor[18] = Wall18;
            WallsFloor[19] = Wall19;
            WallsFloor[20] = Wall20;
            WallsFloor[21] = Wall21;
            WallsFloor[22] = Wall22;
            WallsFloor[23] = Wall23;
            WallsFloor[24] = Wall24;
            WallsFloor[25] = Wall25;
            WallsFloor[26] = Wall26;
            WallsFloor[27] = Wall27;
            WallsFloor[28] = Wall28;
            WallsFloor[29] = Wall29;
            WallsFloor[30] = Wall30;
            WallsFloor[31] = Wall31;
            WallsFloor[32] = Wall32;
            WallsFloor[33] = Wall33;
            WallsFloor[34] = Wall34;
            WallsFloor[35] = Wall35;
            WallsFloor[36] = Wall36;
            WallsFloor[37] = Wall37;
            WallsFloor[38] = Wall38;
            WallsFloor[39] = Wall39;
            WallsFloor[40] = Wall40;
            WallsFloor[41] = Wall41;
            WallsFloor[42] = Wall42;
            WallsFloor[43] = Wall43;
            WallsFloor[44] = Wall44;
            WallsFloor[45] = Wall45;
            WallsFloor[46] = Wall46;
            WallsFloor[47] = Wall47;
            WallsFloor[48] = Wall48;
            WallsFloor[49] = Wall49;
            WallsFloor[50] = Wall50;
            WallsFloor[51] = Wall51;
            WallsFloor[52] = Wall52;
            WallsFloor[53] = Wall53;
            WallsFloor[54] = Wall54;
            WallsFloor[55] = Wall55;
            WallsFloor[56] = Wall56;
            WallsFloor[57] = Wall57;
            WallsFloor[58] = Wall58;
            WallsFloor[59] = Wall59;
            WallsFloor[60] = Wall60;
            WallsFloor[61] = Wall61;
            WallsFloor[62] = Wall62;
            WallsFloor[63] = Wall63;
            WallsFloor[64] = Wall64;
            WallsFloor[65] = Wall65;
            WallsFloor[66] = Wall66;
            WallsFloor[67] = Wall67;
            WallsFloor[68] = Wall68;
            WallsFloor[69] = Wall69;
        }
        /// <summary>
        /// Ukrywa podłogę
        /// </summary>
        private void FloorsHidding(int x)
        {
            for (int i = 1; i <= x; i++)
                WallsFloor[i].Opacity = 0;
        }
        /// <summary>
        /// Przycisk 1 piętra
        /// </summary>
        private void Button_Floor1_Click(object sender, RoutedEventArgs e)
        {
            P = 1;
            Use = true;
            Paintings[1].Visibility = Visibility.Visible;
            Paintings[2].Visibility = Visibility.Hidden;
            Paintings[3].Visibility = Visibility.Hidden;
            MapBoard1.Visibility = Visibility.Visible;
            MapBoard2.Visibility = Visibility.Hidden;
            MapBoard3.Visibility = Visibility.Hidden;
            setBrushMode();
            setShapeMode();
            setSizeMode();
            setColorMode();
        }
        /// <summary>
        /// Przycisk 2 piętra
        /// </summary>
        private void Button_Floor2_Click(object sender, RoutedEventArgs e)
        {
            P = 2;
            Use = true;
            Paintings[1].Visibility = Visibility.Hidden;
            Paintings[2].Visibility = Visibility.Visible;
            Paintings[3].Visibility = Visibility.Hidden;
            MapBoard1.Visibility = Visibility.Hidden;
            MapBoard2.Visibility = Visibility.Visible;
            MapBoard3.Visibility = Visibility.Hidden;
            setBrushMode();
            setShapeMode();
            setSizeMode();
            setColorMode();
        }
        /// <summary>
        /// Przycisk 3 piętra
        /// </summary>
        private void Button_Floor3_Click(object sender, RoutedEventArgs e)
        {
            P = 3;
            Use = true;
            Paintings[1].Visibility = Visibility.Hidden;
            Paintings[2].Visibility = Visibility.Hidden;
            Paintings[3].Visibility = Visibility.Visible;
            MapBoard1.Visibility = Visibility.Hidden;
            MapBoard2.Visibility = Visibility.Hidden;
            MapBoard3.Visibility = Visibility.Visible;
            setBrushMode();
            setShapeMode();
            setSizeMode();
            setColorMode();
        }
        /// <summary>
        /// Ukrywa rysunek lub pokazuje
        /// </summary>
        private void ReinforceMode(object sender, RoutedEventArgs e)
        {
            Paintings[1].Visibility = (Paintings[1].Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
            Paintings[2].Visibility = (Paintings[2].Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
            Paintings[3].Visibility = (Paintings[3].Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
        }

        /// <summary>
        /// Paint
        /// </summary>
        private double SizeMode { get; set; }
        /// <summary>
        /// Ustawia painta
        /// </summary>
        private void setSizeMode()
        {
            var drawingAttributes = Paintings[P].DefaultDrawingAttributes;
            drawingAttributes.Width = SizeMode;
            drawingAttributes.Height = SizeMode;
            Paintings[P].EraserShape = new RectangleStylusShape(BrushSlider.Value, BrushSlider.Value);

            // From the help:
            // "If you change the EraserShape, the cursor rendered on the InkCanvas is not updated until the next EditingMode change."
            var previousEditingMode = Paintings[P].EditingMode;
            Paintings[P].EditingMode = InkCanvasEditingMode.None;
            Paintings[P].EditingMode = previousEditingMode;
        }
        /// <summary>
        /// Przesuwak do rozmiaru pędzla
        /// </summary>
        private void BrushSizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Paintings[P] == null) return;

            var drawingAttributes = Paintings[P].DefaultDrawingAttributes;
            drawingAttributes.Width = BrushSlider.Value;
            drawingAttributes.Height = BrushSlider.Value;
            Paintings[P].EraserShape = new RectangleStylusShape(BrushSlider.Value, BrushSlider.Value);
            SizeMode = BrushSlider.Value;

            // From the help:
            // "If you change the EraserShape, the cursor rendered on the InkCanvas is not updated until the next EditingMode change."
            var previousEditingMode = Paintings[P].EditingMode;
            Paintings[P].EditingMode = InkCanvasEditingMode.None;
            Paintings[P].EditingMode = previousEditingMode;
        }
        /// <summary>
        /// Kolory pędzla
        /// </summary>
        private void BrushColorCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Color selectedColor = (Color)(BrushColorCombo.SelectedItem as PropertyInfo).GetValue(null, null);
            Paintings[P].DefaultDrawingAttributes.Color = selectedColor;
        }
        /// <summary>
        /// Pędzel
        /// </summary>
        private int BrushMode { get; set; }
        /// <summary>
        /// Ustawienie pędzla
        /// </summary>
        private void setBrushMode()
        {
            switch (BrushMode)
            {
                case 0:
                    Paintings[P].EditingMode = InkCanvasEditingMode.Ink;
                    break;
                case 1:
                    Paintings[P].EditingMode = InkCanvasEditingMode.Select;
                    break;
                case 2:
                    Paintings[P].EditingMode = InkCanvasEditingMode.EraseByPoint;
                    break;
                case 3:
                    Paintings[P].EditingMode = InkCanvasEditingMode.EraseByStroke;
                    break;
            }
        }
        /// <summary>
        /// Zmienia pędzle
        /// </summary>
        private void BrushStateCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Paintings[P] == null) return;

            // HACK: This is very hacky. Doing this as I know the order of the ComboBoxItems on the UI.
            // Best way would probably to get the selected item as an enum value.
                switch (BrushStateCombo.SelectedIndex)
                {
                    case 0:
                        Paintings[P].EditingMode = InkCanvasEditingMode.Ink;
                        BrushMode = 0;
                        break;
                    case 1:
                        Paintings[P].EditingMode = InkCanvasEditingMode.Select;
                        BrushMode = 1;
                        break;
                    case 2:
                        Paintings[P].EditingMode = InkCanvasEditingMode.EraseByPoint;
                        BrushMode = 2;
                        break;
                    case 3:
                        Paintings[P].EditingMode = InkCanvasEditingMode.EraseByStroke;
                        BrushMode = 3;
                        break;
                }

        }
        /// <summary>
        /// Kształty pędzla
        /// </summary>
        private int ShapeMode { get; set; }
        /// <summary>
        /// Ustawianie kształtów pędzla
        /// </summary>
        private void setShapeMode()
        {
            switch (ShapeMode)
            {
                case 0:
                    Paintings[P].DefaultDrawingAttributes.StylusTip = StylusTip.Ellipse;
                    ShapeMode = 0;
                    break;
                case 1:
                    Paintings[P].DefaultDrawingAttributes.StylusTip = StylusTip.Rectangle;
                    ShapeMode = 1;
                    break;
            }
        }
        /// <summary>
        /// Kształty pędzla
        /// </summary>
        private void BrushShapesCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Paintings[P] == null) return;

            // HACK: This is very hacky. Doing this as I know the order of the ComboBoxItems on the UI.
            // Best way would probably to get the selected item as an enum value.
            switch (BrushShapesCombo.SelectedIndex)
            {
                case 0:
                    Paintings[P].DefaultDrawingAttributes.StylusTip = StylusTip.Ellipse;
                    ShapeMode = 0;
                    break;
                case 1:
                    Paintings[P].DefaultDrawingAttributes.StylusTip = StylusTip.Rectangle;
                    ShapeMode = 1;
                    break;
            }
        }
        /// <summary>
        /// Zamknięcie
        /// </summary>
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            MapWindow mw = new MapWindow();
            mw.ShowDialog();
            this.Close();
            this.Close();
        }
        /// <summary>
        /// Czynności ścian
        /// </summary>
        private void Wall1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(1);
        }

        private void Wall2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(2);
        }

        private void Wall3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(3);
        }

        private void Wall4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(4);
        }

        private void Wall5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(5);
        }

        private void Wall6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(6);
        }

        private void Wall7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(7);
        }

        private void Wall8_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(8);
        }

        private void Wall9_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(9);
        }

        private void Wall10_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(10);
        }

        private void Wall11_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(11);
        }

        private void Wall12_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(12);
        }

        private void Wall13_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(13);
        }

        private void Wall14_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(14);
        }

        private void Wall15_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(15);
        }

        private void Wall16_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(16);
        }

        private void Wall17_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(17);
        }

        private void Wall18_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(18);
        }

        private void Wall19_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(19);
        }

        private void Wall20_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(20);
        }

        private void Wall21_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(21);
        }

        private void Wall22_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(22);
        }

        private void Wall23_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(23);
        }

        private void Wall24_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(24);
        }

        private void Wall25_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(25);
        }

        private void Wall26_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(26);
        }

        private void Wall27_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(27);
        }

        private void Wall28_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(28);
        }

        private void Wall29_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(29);
        }

        private void Wall30_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(30);
        }

        private void Wall31_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(31);
        }

        private void Wall32_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(32);
        }

        private void Wall33_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(33);
        }

        private void Wall34_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(34);
        }

        private void Wall35_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(35);
        }

        private void Wall36_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(36);
        }

        private void Wall37_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(37);
        }

        private void Wall38_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(38);
        }

        private void Wall39_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(39);
        }

        private void Wall40_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(40);
        }

        private void Wall41_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(41);
        }

        private void Wall42_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(42);
        }

        private void Wall43_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(43);
        }

        private void Wall44_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(44);
        }

        private void Wall45_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(45);
        }

        private void Wall46_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(46);
        }

        private void Wall47_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(47);
        }

        private void Wall48_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(48);
        }

        private void Wall49_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(49);
        }

        private void Wall50_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(50);
        }

        private void Wall51_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(51);
        }

        private void Wall52_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(52);
        }

        private void Wall53_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(53);
        }

        private void Wall54_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(54);
        }

        private void Wall55_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(55);
        }

        private void Wall56_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(56);
        }

        private void Wall57_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(57);
        }

        private void Wall58_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(58);
        }

        private void Wall59_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(59);
        }

        private void Wall60_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(60);
        }

        private void Wall61_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(61);
        }

        private void Wall62_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(62);
        }

        private void Wall63_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(63);
        }

        private void Wall64_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(64);
        }

        private void Wall65_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(65);
        }

        private void Wall66_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(66);
        }

        private void Wall67_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(67);
        }

        private void Wall68_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(68);
        }
        /// <summary>
        /// Koniec czynności ścian
        /// </summary>
        private void Wall69_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(69);
        }
    }
}
