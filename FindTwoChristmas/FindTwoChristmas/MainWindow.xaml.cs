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
        private List<string> originalDeck;
        private List<string> premiosPendientes;
        private List<string> premiosEntregados;
        private List<string> premiosTemp;

        public MainWindow()
        {
            InitializeComponent();

            originalDeck = new List<string>();
            originalDeck.Add("1");
            originalDeck.Add("1");
            originalDeck.Add("2");
            originalDeck.Add("2");
            originalDeck.Add("3");
            originalDeck.Add("3");
            originalDeck.Add("4");
            originalDeck.Add("4");
            originalDeck.Add("5");
            originalDeck.Add("5");
            originalDeck.Add("6");
            originalDeck.Add("6");
            originalDeck.Add("7");
            originalDeck.Add("7");
            originalDeck.Add("8");
            originalDeck.Add("8");
            originalDeck.Add("special");
            originalDeck.Add("special");
            originalDeck.Add("special");
            originalDeck.Add("1");
            originalDeck.Add("1");
            originalDeck.Add("2");
            originalDeck.Add("2");
            originalDeck.Add("3");
            originalDeck.Add("3");
            originalDeck.Add("4");
            originalDeck.Add("4");
            originalDeck.Add("5");
            originalDeck.Add("5");
            originalDeck.Add("6");
            originalDeck.Add("6");
            originalDeck.Add("7");
            originalDeck.Add("7");
            originalDeck.Add("8");
            originalDeck.Add("8");
            originalDeck.Add("special");
            originalDeck.Add("special");
            originalDeck.Add("special");
            originalDeck.Add("1");
            originalDeck.Add("1");
            originalDeck.Add("2");
            originalDeck.Add("2");
            originalDeck.Add("3");
            originalDeck.Add("3");
            originalDeck.Add("4");
            originalDeck.Add("4");
            originalDeck.Add("5");
            originalDeck.Add("5");
            originalDeck.Add("6");
            originalDeck.Add("6");
            originalDeck.Add("7");
            originalDeck.Add("7");
            originalDeck.Add("8");
            originalDeck.Add("8");
            originalDeck.Add("special");
            originalDeck.Add("special");
            originalDeck.Add("special");
            originalDeck.Add("ghost");
            originalDeck.Add("ghost");
            originalDeck.Add("ghost");
            originalDeck.Add("ghost");
            originalDeck.Add("ghost");
            originalDeck.Add("ghost");

            premiosPendientes = new List<string>();
            premiosEntregados = new List<string>();
            premiosTemp = new List<string>();

            RandomizePrizes();
            RestartGame();
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
            premiosTemp.Add(premiosPendientes[0]);

            if (CheckPrize())
            {
                WinDialog();
            }
        }

        public bool CheckPrize()
        {
            if(premiosTemp.Count > 1)
            {
                int timesFound = 1;

                for (int i = 0; i < premiosTemp.Count - 1; i++)
                {
                    if (premiosTemp[i].Equals(premiosTemp.Last()))
                    {
                        timesFound++;
                    }
                }

                //Each time someone gets a special prize, 3 cards of them are taken out of the game, so it is harder to get one
                if (premiosTemp.Last().Equals("special") && timesFound == 3)
                {
                    MessageBox.Show("TATA WILY");

                    originalDeck.Remove("special");
                    originalDeck.Remove("special");
                    originalDeck.Remove("special");

                    RestartGame();
                }
                
                //If someone gets a ghost card, every card of this type is taken out of the game
                else if (premiosTemp.Last().Equals("ghost") && timesFound == 3)
                {
                    MessageBox.Show("Chacal");

                    originalDeck.Remove("ghost");
                    originalDeck.Remove("ghost");
                    originalDeck.Remove("ghost");
                    originalDeck.Remove("ghost");
                    originalDeck.Remove("ghost");
                    originalDeck.Remove("ghost");

                    RestartGame();
                }

                else if (timesFound == 2 && !premiosTemp.Last().Equals("special") && !premiosTemp.Last().Equals("ghost"))
                {
                    premiosEntregados.Add(premiosTemp.Last());
                    UpdatePremiosEntregados();

                    return true;
                }
            }

            return false;
        }

        public void WinDialog()
        {
            if (premiosEntregados.Last().Equals("1"))
            {
                MessageBox.Show("Felicidades! Ganaste un iPad Air de 16 GB");
            }

            else if (premiosEntregados.Last().Equals("2"))
            {
                MessageBox.Show("Felicidades! Ganaste un iPhone 5 de 16 GB");
            }

            else if (premiosEntregados.Last().Equals("3"))
            {
                MessageBox.Show("Felicidades! Ganaste una TV LG Led de 42 pulgadas");
            }

            else if (premiosEntregados.Last().Equals("4"))
            {
                MessageBox.Show("Felicidades! Ganaste un Disco Duro Passport Ultra de 2 TB");
            }

            else if (premiosEntregados.Last().Equals("5"))
            {
                MessageBox.Show("Felicidades! Ganaste un Fin de Semana en Puerto Varas");
            }

            else if (premiosEntregados.Last().Equals("6"))
            {
                MessageBox.Show("Felicidades! Ganaste $200.000");
            }

            else if (premiosEntregados.Last().Equals("7"))
            {
                MessageBox.Show("Felicidades! Ganaste un Set de Cocina Gourmet");
            }

            else if (premiosEntregados.Last().Equals("8"))
            {
                MessageBox.Show("Felicidades! Ganaste 70.000 KM Lanpass");
            }

            RestartGame();
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

        public void RestartGame()
        {
            premiosTemp.Clear();
            premiosPendientes.Clear();

            //delivered prizes are deleted
            foreach (string prize in premiosEntregados)
            {
                for (int i = 0; i < originalDeck.Count; i++)
                {
                    originalDeck.Remove(prize);
                }
            }

            //add every prize to premiosPendientes
            //probabilities are the same for every prize and 2/3 a normal probability for the ghost
            for (int i = 0; i < originalDeck.Count; i++)
            {
                premiosPendientes.Add(originalDeck[i]);
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
