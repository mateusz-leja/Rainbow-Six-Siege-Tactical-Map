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

/// <summary>
/// Biblioteki potrzebne do Painta
/// </summary>
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
        /// <value> przyjmuje numer tablicy do rysowania </value>
        /// <returns> zwraca numer tablicy do rysowania </returns>
        public int P { get; set; }
        /// <summary>
        /// Typ logiczny Use
        /// </summary>
        public bool Use { get; set; } /// <summary> przechowuje zmieną logiczną Use  </summary>
        /// <summary>
        /// Strona Startowa
        /// </summary>
        public BorderWindow() /// <summary> konstruktor obiektu okna BorderWindow </summary>
        {
            InitializeComponent(); /// <remarks> Inicjalizuje podstawowe komponenty </remarks>
            Start(); /// <remarks> metoda rozpoczynająca najważniejsze funkcje potrzebne przy starcie okna </remarks>
            /// <summary> rozpoczęcie pracy Painta </summary>
            BrushColorCombo.ItemsSource = typeof(Colors).GetProperties();
            PropertyInfo[] colors = BrushColorCombo.ItemsSource.Cast<PropertyInfo>().ToArray();
            for (int i = 0; i < colors.Length; i++) /// <remarks> pętla for dla wybierania startowego koloru pędzla </remarks>
            {
                if (colors[i].Name == "Red") /// <remarks> wybiera poczatkowy kolor jako czerwony </remarks>
                {
                    BrushColorCombo.SelectedIndex = i;
                    ColorMode = i; /// <remarks> zapisuje kolor dla innych warstw w zmiennej ColorMode </remarks>
                    break;
                }
            }
            var drawingAttributes = Paintings[P].DefaultDrawingAttributes; /// <summary> ustawia atrybuty dla pędzla </summary>
            drawingAttributes.Width = 5; /// <summary> szerokośc pędzla </summary>
            drawingAttributes.Height = 5; /// <summary> wysokość pędzla </summary>
            Paintings[P].EraserShape = new RectangleStylusShape(BrushSlider.Value = 5, BrushSlider.Value = 5); /// <summary> ustawia kształ pędzla </summary>

            // From the help:
            // "If you change the EraserShape, the cursor rendered on the InkCanvas is not updated until the next EditingMode change."
            var previousEditingMode = Paintings[P].EditingMode;
            Paintings[P].EditingMode = InkCanvasEditingMode.None;
            Paintings[P].EditingMode = previousEditingMode;
        }
        /// <summary>
        /// Globalna zmienna ColorMode
        /// </summary>
        /// <value> przyjmuje kolor pędzla </value>
        /// <returns> zwraca kolor pędzla </returns>
        private int ColorMode { get; set; }

        private void setColorMode() /// <summary> ustawia kolor pędzla dla innych Paintings </summary>
        {
            PropertyInfo[] colors = BrushColorCombo.ItemsSource.Cast<PropertyInfo>().ToArray(); /// <remarks> wczytuje dostępne kolory do colors </remarks>
            //BrushColorCombo.SelectedIndex = ColorMode;
            for (int i = 0; i <= ColorMode; i++) /// <remarks> pętla ustawiająca kolor pędzla </remarks>
            {
                BrushColorCombo.SelectedIndex = i; /// <remarks> przypisanie koloru obiektowi </remarks>
            }
        }
        /// <summary>
        /// Tablica tablic do rysowania
        /// </summary>
        private InkCanvas[] Paintings = new InkCanvas[4];
        /// <summary>
        /// czynności potrzebne do wystartowania okna
        /// </summary>
        private void Start()
        {
            P = 1; /// <remarks> ustawienie Paintboard1 do użytku </remarks>
            Paintings[0] = PaintBoard1; /// <remarks> przypisanie PaintBoard1 do tablicy Paintings (zablokowanie zbędnego pola) </remarks>
            Paintings[1] = PaintBoard1; /// <remarks> przypisanie PaintBoard1 do tablicy Paintings </remarks>
            Paintings[2] = PaintBoard2; /// <remarks> przypisanie PaintBoard2 do tablicy Paintings </remarks>
            Paintings[3] = PaintBoard3; /// <remarks> przypisanie PaintBoard3 do tablicy Paintings </remarks>
            Paintings[1].Visibility = Visibility.Visible; /// <remarks> ustawienie PaintBoard1 jako widoczne </remarks>
            Paintings[2].Visibility = Visibility.Hidden;  /// <remarks> schowanie Paintboard2 </remarks>
            Paintings[3].Visibility = Visibility.Hidden;  /// <remarks> schowanie Paintboard3 </remarks>
            MapBoard1.Visibility = Visibility.Visible; /// <remarks> ustawienie pierwszego piętra jako widoczne </remarks>
            MapBoard2.Visibility = Visibility.Hidden;  /// <remarks> ukrycie 2 piętra </remarks>
            MapBoard3.Visibility = Visibility.Hidden;  /// <remarks> ukrycie 3 piętra </remarks>
            Floor1[0] = true; /// <remarks> ukrycie Reinforceów, aby mogły być one użyte wygodnie dla użytkownika </remarks>
            Floor2[0] = true; /// <remarks> ukrycie Reinforceów, aby mogły być one użyte wygodnie dla użytkownika </remarks>
            WallList(); /// <remarks> metoda WallList, która przypisuje obiekry grid o nazwie Wall do tablicy obiektów </remarks>
            FloorsHidding(69); /// <remarks> ukrycie Reinforceów, aby mogły być one użyte wygodnie dla użytkownika </remarks>
        }
        /// <summary>
        /// Stała zmienna która przechowuje liczbe bool w tablicy
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
        private void Hidding(int i) /// <value> przyjmuje numer ściany jako i </value>
        {
            if (WallsFloor[i].Opacity == 100) /// <remarks> warunek ukrycia = 100% opacity </remarks>
            {
                WallsFloor[i].Opacity = 0; /// <remarks> ustawia opacity na 0 jeśli prawda </remarks>
                Floor1[i] = true; /// <remarks> ustawia tablicy wartość true jeśli prawda </remarks>
            }
            else
            {
                WallsFloor[i].Opacity = 100; /// <remarks> ustawia opacity na 100 jeśli fałsz </remarks>
                Floor1[i] = false; /// <remarks> ustawia tablicy wartość false jeśli fałsz </remarks>
            }
        }
        /// <summary>
        /// Lista ścian
        /// </summary>
        private void WallList()
        {
            ///<remarks>
            ///Każdemu polu tablicy przypisuje ścianę odpowiadającą numerowi tablicy
            ///</remarks>
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
        private void FloorsHidding(int x) /// <value> Przyjmuje ilość ścian jako x </value>
        {
            for (int i = 1; i <= x; i++) /// <remarks> pętla ustawiająca opacity każdego obiektu na 0 </remarks>
                WallsFloor[i].Opacity = 0; /// <remarks> ustawia tablicy obiektów oppacity = 0 </remarks>
        }
        /// <summary>
        /// Przycisk 1 piętra
        /// </summary>
        private void Button_Floor1_Click(object sender, RoutedEventArgs e) /// <summary> po kliknięciu wykonuje zmianę piętra oraz inne czynnoście potrzebne do tej czynności </summary>
        {
            P = 1; /// <remarks> ustawia tablice do rysowania na 1 </remarks>
            Use = true; /// <remarks> ustawia Use na true </remarks>
            Paintings[1].Visibility = Visibility.Visible; /// <remarks> pokazuje 1 tablicę do rysowania </remarks>
            Paintings[2].Visibility = Visibility.Hidden; /// <remarks> ukrywa 2 tablicę do rysowania </remarks>
            Paintings[3].Visibility = Visibility.Hidden; /// <remarks> ukrywa 3 tablice do rysowania </remarks>
            MapBoard1.Visibility = Visibility.Visible; /// <remarks> pokazuje 1 piętro </remarks>
            MapBoard2.Visibility = Visibility.Hidden; /// <remarks> ukrywa 2 piętro </remarks>
            MapBoard3.Visibility = Visibility.Hidden; /// <remarks> ukrywa 3 piętro </remarks>
            setBrushMode(); /// <remarks> wczytuje BrushMode ze zmiennej </remarks>
            setShapeMode(); /// <remarks> wczytuje ShapeMode ze zmiennej </remarks>
            setSizeMode(); /// <remarks> wczytuje SizeMode ze zmiennej </remarks>
            setColorMode(); /// <remarks> wczytuje ColorMode ze zmiennej </remarks>
        }
        /// <summary>
        /// Przycisk 2 piętra
        /// </summary>
        private void Button_Floor2_Click(object sender, RoutedEventArgs e)
        {
            P = 2; /// <remarks> ustawia tablice do rysowania na 2 </remarks>
            Use = true; /// <remarks> ustawia Use na true </remarks>
            Paintings[1].Visibility = Visibility.Hidden; /// <remarks> ukrywa 1 tablicę do rysowania </remarks>
            Paintings[2].Visibility = Visibility.Visible; /// <remarks> pokazuje 2 tablice do rysowania </remarks>
            Paintings[3].Visibility = Visibility.Hidden; /// <remarks> ukrywa 3 tablice do rysowania </remarks>
            MapBoard1.Visibility = Visibility.Hidden; /// <remarks> ukrywa 1 piętro </remarks>
            MapBoard2.Visibility = Visibility.Visible; /// <remarks> pokazuje 2 piętro </remarks>
            MapBoard3.Visibility = Visibility.Hidden; /// <remarks> ukrywa 3 piętro </remarks>
            setBrushMode(); /// <remarks> wczytuje BrushMode ze zmiennej </remarks>
            setShapeMode(); /// <remarks> wczytuje ShapeMode ze zmiennej </remarks>
            setSizeMode(); /// <remarks> wczytuje SizeMode ze zmiennej </remarks>
            setColorMode(); /// <remarks> wczytuje ColorMode ze zmiennej </remarks>
        }
        /// <summary>
        /// Przycisk 3 piętra
        /// </summary>
        private void Button_Floor3_Click(object sender, RoutedEventArgs e)
        {
            P = 3; /// <remarks> ustawia tablice do rysowania na 3 </remarks>
            Use = true; /// <remarks> ustawia Use na true </remarks>
            Paintings[1].Visibility = Visibility.Hidden; /// <remarks> ukrywa 1 tablicę do rysowania </remarks>
            Paintings[2].Visibility = Visibility.Hidden; /// <remarks> ukrywa 2 tablice do rysowania </remarks>
            Paintings[3].Visibility = Visibility.Visible; /// <remarks> pokazuje 3 tablicę do rysowania </remarks>
            MapBoard1.Visibility = Visibility.Hidden; /// <remarks> ukrywa 1 piętro </remarks>
            MapBoard2.Visibility = Visibility.Hidden; /// <remarks> ukrywa 2 piętro </remarks>
            MapBoard3.Visibility = Visibility.Visible; /// <remarks> pokazuje 3 piętro </remarks>
            setBrushMode(); /// <remarks> wczytuje BrushMode ze zmiennej </remarks>
            setShapeMode(); /// <remarks> wczytuje ShapeMode ze zmiennej </remarks>
            setSizeMode(); /// <remarks> wczytuje SizeMode ze zmiennej </remarks>
            setColorMode(); /// <remarks> wczytuje ColorMode ze zmiennej </remarks>
        }
        /// <summary>
        /// Ukrywa lub pokazuje tablicę do rysowania
        /// </summary>
        private void ReinforceMode(object sender, RoutedEventArgs e)
        {
            Paintings[1].Visibility = (Paintings[1].Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible; /// <remarks> pokazuje lub ukrywa 1 tablicę do rysowania </remarks>
            Paintings[2].Visibility = (Paintings[2].Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible; /// <remarks> pokazuje lub ukrywa 2 tablice do rysowania </remarks>
            Paintings[3].Visibility = (Paintings[3].Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible; /// <remarks> pokazuje lub ukrywa 3 tablicę do rysowania </remarks>
        }

        /// <summary>
        /// Paint
        /// </summary>
        /// <value> przyjmuje wielkość pędzla </value>
        /// <returns> zwraca wielkość pędzla </returns>
        private double SizeMode { get; set; } /// <summary> zmienna zapisująca wielkość pędzla </summary>
        /// <summary>
        /// Ustawia painta
        /// </summary>
        private void setSizeMode() /// <summary> ustawia wielkość pędzla </summary>
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
        private void BrushSizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) /// <summary> ustawia wartość slidera grubości pędzla </summary>
        {
            /// <returns>
            /// jeśli brak obiektu tablicy do rysowania, zwraca
            /// </returns>
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
        private void BrushColorCombo_SelectionChanged(object sender, SelectionChangedEventArgs e) /// <summary> ustawia wartośc pola radio kolorów </summary>
        {
            Color selectedColor = (Color)(BrushColorCombo.SelectedItem as PropertyInfo).GetValue(null, null);
            Paintings[P].DefaultDrawingAttributes.Color = selectedColor;
        }


        /// <summary>
        /// Pędzel
        /// </summary>
        /// /// <value> przyjmuje tryb pędzla </value>
        /// <returns> zwraca tryb pędzla </returns>
        private int BrushMode { get; set; }
        

        /// <summary>
        /// Ustawienie pędzla
        /// </summary>
        private void setBrushMode()
        {
            switch (BrushMode)
            {
                case 0:
                    Paintings[P].EditingMode = InkCanvasEditingMode.Ink; /// <remarks> utawia typ pędzla na rysowanie </remarks>
                    break;
                case 1:
                    Paintings[P].EditingMode = InkCanvasEditingMode.Select; /// <remarks> ustawia typ pędzla na wskazywanie </remarks>
                    break;
                case 2:
                    Paintings[P].EditingMode = InkCanvasEditingMode.EraseByPoint; /// <remarks> ustawia typ pędzla na zwykłą gumkę </remarks>
                    break;
                case 3:
                    Paintings[P].EditingMode = InkCanvasEditingMode.EraseByStroke; /// <remarks> ustawia typ pędzla na gumką, która usuwa cały linie </remarks>
                    break;
            }
        }
        

        /// <summary>
        /// Zmienia pędzle
        /// </summary>
        private void BrushStateCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /// <returns>
            /// jeśli brak obiektu tablicy do rysowania, zwraca
            /// </returns>
            if (Paintings[P] == null) return; 

            // HACK: This is very hacky. Doing this as I know the order of the ComboBoxItems on the UI.
            // Best way would probably to get the selected item as an enum value.
                switch (BrushStateCombo.SelectedIndex)
                {
                    case 0:
                        Paintings[P].EditingMode = InkCanvasEditingMode.Ink; /// <remarks> ustawia pędzel na malowanie </remarks>
                    BrushMode = 0; // ustawia BrushMode na 0
                        break;
                    case 1:
                        Paintings[P].EditingMode = InkCanvasEditingMode.Select; /// <remarks> usawia pędzel na wskaźnik </remarks>
                    BrushMode = 1; // ustawia BrushMode na 1
                        break;
                    case 2:
                        Paintings[P].EditingMode = InkCanvasEditingMode.EraseByPoint; /// <remarks> ustawia pędzel na zwykłą gumkę </remarks>
                    BrushMode = 2; // ustaiwa BrushMode na 2
                        break;
                    case 3:
                        Paintings[P].EditingMode = InkCanvasEditingMode.EraseByStroke; /// <remarks> ustawia pędzel na gumkę, która usuwa całą linię </remarks>
                    BrushMode = 3; // ustawia BrushMode na 3
                        break;
                }    

        }


        /// <summary>
        /// Kształty pędzla
        /// </summary>
        /// <value> przyjmuje kształ pędzla </value>
        /// <returns> zwraca kształt pędzla </returns>
        private int ShapeMode { get; set; }
        /// <summary>
        /// Ustawianie kształt pędzla
        /// </summary>
        private void setShapeMode()
        {
            switch (ShapeMode)
            {
                case 0:
                    Paintings[P].DefaultDrawingAttributes.StylusTip = StylusTip.Ellipse; /// <remarks> ustawia kształt pędzla na koło </remarks>
                    ShapeMode = 0; // ustawia ShapeMode na 0
                    break;
                case 1:
                    Paintings[P].DefaultDrawingAttributes.StylusTip = StylusTip.Rectangle; /// <remarks> ustawia kształ pędzla na kwadrat </remarks>
                    ShapeMode = 1; // ustawia ShapeMode na 1
                    break;
            }
        }


        /// <summary>
        /// Kształty pędzla
        /// </summary>
        private void BrushShapesCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /// <returns>
            /// jeśli brak obiektu tablicy do rysowania, zwraca
            /// </returns>
            if (Paintings[P] == null) return;

            // HACK: This is very hacky. Doing this as I know the order of the ComboBoxItems on the UI.
            // Best way would probably to get the selected item as an enum value.
            switch (BrushShapesCombo.SelectedIndex)
            {
                case 0:
                    Paintings[P].DefaultDrawingAttributes.StylusTip = StylusTip.Ellipse; /// <remarks> ustawia kształt pędzla na koło </remarks>
                    ShapeMode = 0; // ustawia ShapeMode na 0
                    break;
                case 1:
                    Paintings[P].DefaultDrawingAttributes.StylusTip = StylusTip.Rectangle; /// <remarks> ustawia kształt pędzla na kwadrat </remarks>
                    ShapeMode = 1; // ustawia ShapeMode na 1
                    break;
            }
        }


        /// <summary>
        /// Zamknięcie okna
        /// </summary>
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            MapWindow mw = new MapWindow(); /// <remarks> przypisanie zmiennej mw obiektu MapWindow </remarks>
            mw.ShowDialog(); /// <remarks> otwiera nowe okno </remarks>
            this.Close(); /// <remarks> zamyka stare okno </remarks>
            this.Close();
        }


        /// <summary>
        /// Czynności ścian
        /// </summary>
        private void Wall1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) /// <remarks> zdarzenie dla ściany 1 </remarks>
        {
            Hidding(1); /// <remarks> wywołanie metody ukrycia ściany </remarks>
        }

        private void Wall2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) 
        {
            Hidding(2); // wywołanie metody ukrycia ściany
        }

        private void Wall3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) 
        {
            Hidding(3); // wywołanie metody ukrycia ściany
        }

        private void Wall4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) 
        {                                                                             
            Hidding(4); // wywołanie metody ukrycia ściany                                    
        }                                                                             
                                                                                      
        private void Wall5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) 
        {                                                                             
            Hidding(5); // wywołanie metody ukrycia ściany                                   
        }                                                                             
                                                                                      
        private void Wall6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) 
        {                                                                             
            Hidding(6); // wywołanie metody ukrycia ściany                                   
        }                                                                             
                                                                                      
        private void Wall7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) 
        {                                                                             
            Hidding(7); // wywołanie metody ukrycia ściany                                   
        }                                                                             
                                                                                      
        private void Wall8_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) 
        {
            Hidding(8); // wywołanie metody ukrycia ściany
        }

        private void Wall9_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) 
        {
            Hidding(9); // wywołanie metody ukrycia ściany
        }

        private void Wall10_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(10); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall11_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(11); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall12_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(12); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall13_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(13); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall14_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(14); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall15_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(15); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall16_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(16); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall17_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(17); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall18_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(18); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall19_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(19); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall20_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(20); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall21_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(21); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall22_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(22); // wywołanie metody ukrycia ściany                                                          
        }                                                                             
                                                                                      
        private void Wall23_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(23); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall24_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(24); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall25_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(25); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall26_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(26); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall27_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(27); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall28_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(28); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall29_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(29); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall30_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(30); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall31_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(31); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall32_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(32); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall33_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(33); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall34_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(34); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall35_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(35); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall36_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(36); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall37_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(37); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall38_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(38); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall39_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(39); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall40_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(40); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall41_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(41); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall42_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(42); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall43_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(43); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall44_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(44); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall45_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(45); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall46_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(46); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall47_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(47); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall48_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(48); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall49_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(49); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall50_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(50); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall51_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(51); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall52_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(52); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall53_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(53); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall54_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(54); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall55_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(55); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall56_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(56); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall57_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(57); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall58_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(58); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall59_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(59); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall60_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(60); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall61_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(61); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall62_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(62); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall63_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(63); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall64_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(64); // wywołanie metody ukrycia ściany                                                          
        }                                                                             
                                                                                      
        private void Wall65_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(65); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall66_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(66); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall67_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(67); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall68_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                                                                             
            Hidding(68); // wywołanie metody ukrycia ściany                                                           
        }                                                                             
                                                                                      
        private void Wall69_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hidding(69); // wywołanie metody ukrycia ściany
        }
        
    }
}
