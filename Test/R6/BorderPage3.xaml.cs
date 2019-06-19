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
    /// Logika interakcji dla klasy BorderPage3.xaml
    /// </summary>
    public partial class BorderPage3 : Page
    {
        public BorderPage3()
        {
            InitializeComponent();
            //Wypełnienie niepotrzebnych pól tablicy
            Floor1[0] = true;
            Floor2[0] = true;
            //Metoda z tablicą obiektów
            WallList();
        }

        //Liczba ścian na piętrze
        const int wf1 = 2;
        //Tablica zapisująca ściany
        private bool[] Floor1 = new bool[wf1];
        private bool[] Floor2 = new bool[35];
        //Tablica obiektów
        private Grid[] WallsFloor1 = new Grid[35];

        //Metoda z tablicą obiektów
        private void WallList()
        {
            WallsFloor1[1] = Wall1;
        }

        //Ładowanie 1 piętra
        private void Floor1Load()
        {
            for (int i = 1; i < wf1; i++)
            {
                WallsFloor1[i].Visibility = (Floor1[1] == true) ? Visibility.Hidden : Visibility.Visible;
            }
        }

        //Chowanie 1 piętra
        private void Floor1Hidding()
        {
            for (int i = 1; i < wf1; i++)
                WallsFloor1[i].Visibility = Visibility.Hidden;
        }

        //Metoda ukrywająca ścianę
        private void Hidding(int i)
        {
            if (WallsFloor1[i].Opacity == 100)
            {
                WallsFloor1[i].Opacity = 0;
                Floor1[i] = true;
            }
            else
            {
                WallsFloor1[i].Opacity = 100;
                Floor1[i] = false;
            }
        }

        private void Wall1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}