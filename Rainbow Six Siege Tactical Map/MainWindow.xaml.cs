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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace R6
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {/// <summary>
     /// Okno startowe
     /// </summary>
        public MainWindow()
        {
            InitializeComponent(); /// <remarks> inicjalizuje potrzebne komponenty </remarks>
        }


        /// <summary>
        /// Przechodzi do wyboru map
        /// </summary>
        private void Map_Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MapWindow mw = new MapWindow(); /// <remarks> przypisuje zmiennej mw obiekt MapWindow </remarks>
            mw.ShowDialog(); /// <remarks> otwiera okno </remarks>
            this.Close(); /// <remarks> zamyka okno </remarks>
        }


        /// <summary>
        /// Kliknięcie przycisku
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); /// <remarks> zamyka okno </remarks>
        }


    }
}
