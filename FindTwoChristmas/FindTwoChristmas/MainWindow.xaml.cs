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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FindTwoChristmas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> premiosPendientes;
        private List<string> premiosEntregados;

        public MainWindow()
        {
            InitializeComponent();

            premiosPendientes = new List<string>();
            premiosEntregados = new List<string>();

            premiosPendientes.Add("1");
            premiosPendientes.Add("1");
            premiosPendientes.Add("2");
            premiosPendientes.Add("2");
            premiosPendientes.Add("3");
            premiosPendientes.Add("3");
            premiosPendientes.Add("4");
            premiosPendientes.Add("4");
            premiosPendientes.Add("5");
            premiosPendientes.Add("5");
            premiosPendientes.Add("6");
            premiosPendientes.Add("6");
            premiosPendientes.Add("7");
            premiosPendientes.Add("7");
            premiosPendientes.Add("8");
            premiosPendientes.Add("8");
            premiosPendientes.Add("special");
            premiosPendientes.Add("ghost");
            premiosPendientes.Add("ghost");
            premiosPendientes.Add("car");
            premiosPendientes.Add("car");

            RandomizePrizes();
        }

        public void RandomizePrizes()
        {
            Random rng = new Random();
            int n = premiosPendientes.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = premiosPendientes[k];
                premiosPendientes[k] = premiosPendientes[n];
                premiosPendientes[n] = value;
            }  
        }

        private void FlipA1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RandomizePrizes();

            FlipA1.BackSide = 
        }
    }
}
