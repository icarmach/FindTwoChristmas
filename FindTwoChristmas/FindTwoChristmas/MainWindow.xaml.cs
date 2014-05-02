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
        private List<string> premiosTemp;

        public MainWindow()
        {
            InitializeComponent();

            premiosPendientes = new List<string>();
            premiosEntregados = new List<string>();
            premiosTemp = new List<string>();

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

        public void CheckGameStatus()
        {
            if (!premiosPendientes[0].Equals("car") && !premiosPendientes[0].Equals("ghost"))
            {
                premiosTemp.Add(premiosPendientes[0]);
            }

            if (CheckPrize())
            {
                WinDialog();
            }

            else
            {
                premiosPendientes.RemoveAt(0);
            }
        }

        public bool CheckPrize()
        {
            if(premiosTemp.Count > 1)
            {
                for (int i = 0; i < premiosTemp.Count; i++)
                {
                    for (int j = 0; j < premiosTemp.Count; j++)
                    {
                        if (premiosTemp[i].Equals(premiosTemp[j]) && i != j)
                        {
                            premiosEntregados.Add(premiosTemp[i]);
                            UpdatePremiosEntregados();

                            return true;
                        }
                    }
                }
            }
            

            return false;
        }

        public void WinDialog()
        {
            if (premiosPendientes[0].Equals("1"))
            {
                MessageBox.Show("Felicidades! Ganaste un iPad Air de 16 GB");
            }

            else if (premiosPendientes[0].Equals("2"))
            {
                MessageBox.Show("Felicidades! Ganaste un iPhone 5 de 16 GB");
            }

            else if (premiosPendientes[0].Equals("3"))
            {
                MessageBox.Show("Felicidades! Ganaste una TV LG Led de 42 pulgadas");
            }

            else if (premiosPendientes[0].Equals("4"))
            {
                MessageBox.Show("Felicidades! Ganaste un Disco Duro Passport Ultra de 2 TB");
            }

            else if (premiosPendientes[0].Equals("5"))
            {
                MessageBox.Show("Felicidades! Ganaste un Fin de Semana en Puerto Varas");
            }

            else if (premiosPendientes[0].Equals("6"))
            {
                MessageBox.Show("Felicidades! Ganaste $200.000");
            }

            else if (premiosPendientes[0].Equals("7"))
            {
                MessageBox.Show("Felicidades! Ganaste un Set de Cocina Gourmet");
            }

            else if (premiosPendientes[0].Equals("8"))
            {
                MessageBox.Show("Felicidades! Ganaste 70.000 KM Lanpass");
            }

            premiosTemp.Clear();
            premiosPendientes.Clear();

            //add left prizes to premiosPendientes
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

            foreach(string prize in premiosEntregados)
            {
                premiosPendientes.Remove(prize);
                premiosPendientes.Remove(prize);
            }

            RandomizePrizes();

            //reset pictures
            A1.Source = new BitmapImage(new Uri("Prizes/closed.png", UriKind.Relative));
            B1.Source = new BitmapImage(new Uri("Prizes/closed.png", UriKind.Relative));
            C1.Source = new BitmapImage(new Uri("Prizes/closed.png", UriKind.Relative));
            D1.Source = new BitmapImage(new Uri("Prizes/closed.png", UriKind.Relative));
            E1.Source = new BitmapImage(new Uri("Prizes/closed.png", UriKind.Relative));
            F1.Source = new BitmapImage(new Uri("Prizes/closed.png", UriKind.Relative));
            A2.Source = new BitmapImage(new Uri("Prizes/closed.png", UriKind.Relative));
            B2.Source = new BitmapImage(new Uri("Prizes/closed.png", UriKind.Relative));
            C2.Source = new BitmapImage(new Uri("Prizes/closed.png", UriKind.Relative));
            D2.Source = new BitmapImage(new Uri("Prizes/closed.png", UriKind.Relative));
            E2.Source = new BitmapImage(new Uri("Prizes/closed.png", UriKind.Relative));
            F2.Source = new BitmapImage(new Uri("Prizes/closed.png", UriKind.Relative));
            A3.Source = new BitmapImage(new Uri("Prizes/closed.png", UriKind.Relative));
            B3.Source = new BitmapImage(new Uri("Prizes/closed.png", UriKind.Relative));
            C3.Source = new BitmapImage(new Uri("Prizes/closed.png", UriKind.Relative));
            D3.Source = new BitmapImage(new Uri("Prizes/closed.png", UriKind.Relative));
            E3.Source = new BitmapImage(new Uri("Prizes/closed.png", UriKind.Relative));
            F3.Source = new BitmapImage(new Uri("Prizes/closed.png", UriKind.Relative));
            A4.Source = new BitmapImage(new Uri("Prizes/closed.png", UriKind.Relative));
            B4.Source = new BitmapImage(new Uri("Prizes/closed.png", UriKind.Relative));
            C4.Source = new BitmapImage(new Uri("Prizes/closed.png", UriKind.Relative));
            D4.Source = new BitmapImage(new Uri("Prizes/closed.png", UriKind.Relative));
            E4.Source = new BitmapImage(new Uri("Prizes/closed.png", UriKind.Relative));
            F4.Source = new BitmapImage(new Uri("Prizes/closed.png", UriKind.Relative));
        }

        public void UpdatePremiosEntregados()
        {
            if(premiosEntregados.Count == 1)
            {
                Prize1.Source = new BitmapImage(new Uri("Prizes/" + premiosEntregados[0] + ".png", UriKind.Relative));
            }

            else if(premiosEntregados.Count == 2)
            {
                Prize1.Source = new BitmapImage(new Uri("Prizes/" + premiosEntregados[0] + ".png", UriKind.Relative));
                Prize2.Source = new BitmapImage(new Uri("Prizes/" + premiosEntregados[1] + ".png", UriKind.Relative));
            }

            else if (premiosEntregados.Count == 3)
            {
                Prize1.Source = new BitmapImage(new Uri("Prizes/" + premiosEntregados[0] + ".png", UriKind.Relative));
                Prize2.Source = new BitmapImage(new Uri("Prizes/" + premiosEntregados[1] + ".png", UriKind.Relative));
                Prize3.Source = new BitmapImage(new Uri("Prizes/" + premiosEntregados[2] + ".png", UriKind.Relative));
            }

            else if (premiosEntregados.Count == 4)
            {
                Prize1.Source = new BitmapImage(new Uri("Prizes/" + premiosEntregados[0] + ".png", UriKind.Relative));
                Prize2.Source = new BitmapImage(new Uri("Prizes/" + premiosEntregados[1] + ".png", UriKind.Relative));
                Prize3.Source = new BitmapImage(new Uri("Prizes/" + premiosEntregados[2] + ".png", UriKind.Relative));
                Prize4.Source = new BitmapImage(new Uri("Prizes/" + premiosEntregados[3] + ".png", UriKind.Relative));
            }

            else if (premiosEntregados.Count == 5)
            {
                Prize1.Source = new BitmapImage(new Uri("Prizes/" + premiosEntregados[0] + ".png", UriKind.Relative));
                Prize2.Source = new BitmapImage(new Uri("Prizes/" + premiosEntregados[1] + ".png", UriKind.Relative));
                Prize3.Source = new BitmapImage(new Uri("Prizes/" + premiosEntregados[2] + ".png", UriKind.Relative));
                Prize4.Source = new BitmapImage(new Uri("Prizes/" + premiosEntregados[3] + ".png", UriKind.Relative));
                Prize5.Source = new BitmapImage(new Uri("Prizes/" + premiosEntregados[4] + ".png", UriKind.Relative));
            }

            else if (premiosEntregados.Count == 6)
            {
                Prize1.Source = new BitmapImage(new Uri("Prizes/" + premiosEntregados[0] + ".png", UriKind.Relative));
                Prize2.Source = new BitmapImage(new Uri("Prizes/" + premiosEntregados[1] + ".png", UriKind.Relative));
                Prize3.Source = new BitmapImage(new Uri("Prizes/" + premiosEntregados[2] + ".png", UriKind.Relative));
                Prize4.Source = new BitmapImage(new Uri("Prizes/" + premiosEntregados[3] + ".png", UriKind.Relative));
                Prize5.Source = new BitmapImage(new Uri("Prizes/" + premiosEntregados[4] + ".png", UriKind.Relative));
                Prize6.Source = new BitmapImage(new Uri("Prizes/" + premiosEntregados[5] + ".png", UriKind.Relative));
            }

            else if (premiosEntregados.Count == 7)
            {
                Prize1.Source = new BitmapImage(new Uri("Prizes/" + premiosEntregados[0] + ".png", UriKind.Relative));
                Prize2.Source = new BitmapImage(new Uri("Prizes/" + premiosEntregados[1] + ".png", UriKind.Relative));
                Prize3.Source = new BitmapImage(new Uri("Prizes/" + premiosEntregados[2] + ".png", UriKind.Relative));
                Prize4.Source = new BitmapImage(new Uri("Prizes/" + premiosEntregados[3] + ".png", UriKind.Relative));
                Prize5.Source = new BitmapImage(new Uri("Prizes/" + premiosEntregados[4] + ".png", UriKind.Relative));
                Prize6.Source = new BitmapImage(new Uri("Prizes/" + premiosEntregados[5] + ".png", UriKind.Relative));
                Prize7.Source = new BitmapImage(new Uri("Prizes/" + premiosEntregados[6] + ".png", UriKind.Relative));
            }

            else if (premiosEntregados.Count == 8)
            {
                Prize1.Source = new BitmapImage(new Uri("Prizes/" + premiosEntregados[0] + ".png", UriKind.Relative));
                Prize2.Source = new BitmapImage(new Uri("Prizes/" + premiosEntregados[1] + ".png", UriKind.Relative));
                Prize3.Source = new BitmapImage(new Uri("Prizes/" + premiosEntregados[2] + ".png", UriKind.Relative));
                Prize4.Source = new BitmapImage(new Uri("Prizes/" + premiosEntregados[3] + ".png", UriKind.Relative));
                Prize5.Source = new BitmapImage(new Uri("Prizes/" + premiosEntregados[4] + ".png", UriKind.Relative));
                Prize6.Source = new BitmapImage(new Uri("Prizes/" + premiosEntregados[5] + ".png", UriKind.Relative));
                Prize7.Source = new BitmapImage(new Uri("Prizes/" + premiosEntregados[6] + ".png", UriKind.Relative));
                Prize8.Source = new BitmapImage(new Uri("Prizes/" + premiosEntregados[7] + ".png", UriKind.Relative));
            }
        }

        private void A1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if(premiosPendientes.Count > 0 && A1.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                A1.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void B1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && B1.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                B1.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void C1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && C1.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                C1.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void D1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && D1.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                D1.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void E1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && E1.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                E1.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void F1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && F1.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                F1.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void A2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && A2.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                A2.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void B2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && B2.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                B2.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void C2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && C2.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                C2.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void D2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && D2.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                D2.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void E2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && E2.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                E2.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void F2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && F2.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                F2.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void A3_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && A3.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                A3.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void B3_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && B3.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                B3.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void C3_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && C3.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                C3.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void D3_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && D3.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                D3.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }

        }

        private void E3_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && E3.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                E3.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void F3_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && F3.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                F3.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void A4_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && A4.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                A4.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void B4_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && B4.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                B4.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void C4_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && C4.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                C4.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void D4_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && D4.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                D4.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void E4_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && E4.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                E4.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void F4_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && F4.Source.ToString().Equals("pack://application:,,,/FindTwoChristmas;component/Prizes/closed.png"))
            {
                RandomizePrizes();

                F4.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

    }
}
