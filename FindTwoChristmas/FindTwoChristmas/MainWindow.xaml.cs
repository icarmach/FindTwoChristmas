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

        private void A1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if(premiosPendientes.Count > 0 && A1.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                A1.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                premiosPendientes.RemoveAt(0);
            }
        }

        private void B1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && B1.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                B1.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                premiosPendientes.RemoveAt(0);
            }
        }

        private void C1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && C1.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                C1.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                premiosPendientes.RemoveAt(0);
            }
        }

        private void D1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && D1.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                D1.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                premiosPendientes.RemoveAt(0);
            }
        }

        private void E1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && E1.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                E1.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                premiosPendientes.RemoveAt(0);
            }
        }

        private void F1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && F1.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                F1.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                premiosPendientes.RemoveAt(0);
            }
        }

        private void A2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && A2.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                A2.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                premiosPendientes.RemoveAt(0);
            }
        }

        private void B2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && B2.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                B2.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                premiosPendientes.RemoveAt(0);
            }
        }

        private void C2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && C2.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                C2.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                premiosPendientes.RemoveAt(0);
            }
        }

        private void D2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && D2.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                D2.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                premiosPendientes.RemoveAt(0);
            }
        }

        private void E2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && E2.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                E2.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                premiosPendientes.RemoveAt(0);
            }
        }

        private void F2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && F2.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                F2.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                premiosPendientes.RemoveAt(0);
            }
        }

        private void A3_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && A3.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                A3.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                premiosPendientes.RemoveAt(0);
            }
        }

        private void B3_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && B3.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                B3.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                premiosPendientes.RemoveAt(0);
            }
        }

        private void C3_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && C3.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                C3.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                premiosPendientes.RemoveAt(0);
            }
        }

        private void D3_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && D3.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                D3.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                premiosPendientes.RemoveAt(0);
            }

        }

        private void E3_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && E3.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                E3.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                premiosPendientes.RemoveAt(0);
            }
        }

        private void F3_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && F3.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                F3.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                premiosPendientes.RemoveAt(0);
            }
        }

        private void A4_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && A4.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                A4.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                premiosPendientes.RemoveAt(0);
            }
        }

        private void B4_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && B4.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                B4.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                premiosPendientes.RemoveAt(0);
            }
        }

        private void C4_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && C4.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                C4.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                premiosPendientes.RemoveAt(0);
            }
        }

        private void D4_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && D4.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                D4.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                premiosPendientes.RemoveAt(0);
            }
        }

        private void E4_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && E4.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                E4.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                premiosPendientes.RemoveAt(0);
            }
        }

        private void F4_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && F4.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                F4.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                premiosPendientes.RemoveAt(0);
            }
        }

    }
}
