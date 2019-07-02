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

namespace R6
{
    /// <summary>
    /// Logika interakcji dla klasy MapWindow.xaml
    /// </summary>
    public partial class MapWindow : Window
    {
        /// <summary>
        /// Okno Map
        /// </summary>
        public MapWindow()
        {
            InitializeComponent(); /// <remarks> inicjalizuje potrzebne komponenty </remarks>
        }


        /// <summary>
        /// Kliknięcie przycisku
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow(); /// <remarks> przypisuje zmiennej mw obiekt MainWindow </remarks>
            mw.ShowDialog(); /// <remarks> otwiera okno </remarks>
            this.Close(); /// <remarks> zamyka okno </remarks>
        }


        /// <summary>
        /// Przejście do mapy
        /// </summary>
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BorderWindow bw = new BorderWindow(); /// <remarks> przypisuje zmiennej bw obiekt BorderWindow </remarks>
            bw.ShowDialog(); /// <remarks> otwiera okno </remarks>
            this.Close(); /// <remarks> zamyka okno </remarks>
        }


    }
}
