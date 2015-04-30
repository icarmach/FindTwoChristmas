using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        private List<string> prizeCards;
        private List<string> peopleCards;
        private List<string> premiosPendientes;
        private List<string> premiosEntregados;
        private List<string> premiosTemp;

        public MainWindow()
        {
            InitializeComponent();

            prizeCards = new List<string>();
            prizeCards.Add("1");
            prizeCards.Add("1");
            prizeCards.Add("1");
            prizeCards.Add("2");
            prizeCards.Add("2");
            prizeCards.Add("2");
            prizeCards.Add("3");
            prizeCards.Add("3");
            prizeCards.Add("3");
            prizeCards.Add("4");
            prizeCards.Add("4");
            prizeCards.Add("4");
            prizeCards.Add("5");
            prizeCards.Add("5");
            prizeCards.Add("5");
            prizeCards.Add("1");
            prizeCards.Add("1");
            prizeCards.Add("1");
            prizeCards.Add("2");
            prizeCards.Add("2");
            prizeCards.Add("2");
            prizeCards.Add("3");
            prizeCards.Add("3");
            prizeCards.Add("3");
            prizeCards.Add("4");
            prizeCards.Add("4");
            prizeCards.Add("4");
            prizeCards.Add("5");
            prizeCards.Add("5");
            prizeCards.Add("5");
            prizeCards.Add("special");
            prizeCards.Add("special");
            prizeCards.Add("special");
            prizeCards.Add("special");
            prizeCards.Add("special");
            prizeCards.Add("special");
            prizeCards.Add("special");
            prizeCards.Add("special");
            prizeCards.Add("special");
            prizeCards.Add("devil");
            prizeCards.Add("devil");
            prizeCards.Add("devil");
            prizeCards.Add("devil");
            prizeCards.Add("devil");
            prizeCards.Add("devil");
            prizeCards.Add("devil");
            prizeCards.Add("devil");
            prizeCards.Add("devil");
            prizeCards.Add("devil");
            prizeCards.Add("devil");
            prizeCards.Add("devil");

            peopleCards = new List<string>();
            peopleCards.Add("abuela");
            peopleCards.Add("abuela2");
            peopleCards.Add("andres");
            peopleCards.Add("antonia");
            peopleCards.Add("carmach");
            peopleCards.Add("chano");
            peopleCards.Add("cristian");
            peopleCards.Add("diego");
            peopleCards.Add("fena");
            peopleCards.Add("genny");
            peopleCards.Add("ignacia");
            peopleCards.Add("ignacio");
            peopleCards.Add("javier");
            peopleCards.Add("jeanette");
            peopleCards.Add("jo");
            peopleCards.Add("jp");
            peopleCards.Add("juane");
            peopleCards.Add("karin");
            peopleCards.Add("kuky");
            peopleCards.Add("kuky2");
            peopleCards.Add("laura");
            peopleCards.Add("lorena");
            peopleCards.Add("manuela");
            peopleCards.Add("marisol");
            peopleCards.Add("martin");
            peopleCards.Add("mati");
            peopleCards.Add("natalia");
            peopleCards.Add("nicolas");
            peopleCards.Add("paula");
            peopleCards.Add("pepe");
            peopleCards.Add("pernil");
            peopleCards.Add("roberta");
            peopleCards.Add("titi");
            peopleCards.Add("tomas");
            peopleCards.Add("vicentela");
            peopleCards.Add("wilo");

            premiosPendientes = new List<string>();
            premiosEntregados = new List<string>();
            premiosTemp = new List<string>();

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

        public void RandomizePeople()
        {
            Random rng = new Random();
            int n = peopleCards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = peopleCards[k];
                peopleCards[k] = peopleCards[n];
                peopleCards[n] = value;
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
                    WinDialog wd = new WinDialog("Felicidades!", "Ganaste un Premio Sorpresa.");
                    wd.ShowDialog();

                    prizeCards.Remove("special");
                    prizeCards.Remove("special");
                    prizeCards.Remove("special");

                    RestartGame();
                }
                
                //If someone gets a devil card, every card of this type is taken out of the game
                else if (premiosTemp.Last().Equals("devil") && timesFound == 3)
                {
                    DevilWindow devilWindow = new DevilWindow();
                    devilWindow.ShowDialog();

                    WinDialog wd = new WinDialog("Uh! Mala suerte.", "Pierdes todo...");
                    wd.ShowDialog();

                    prizeCards.Remove("devil");
                    prizeCards.Remove("devil");
                    prizeCards.Remove("devil");

                    RestartGame();
                }

                else if (timesFound == 3 && !premiosTemp.Last().Equals("special") && !premiosTemp.Last().Equals("devil"))
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
                WinDialog wd = new WinDialog("Felicidades!", "Ganaste un iPad Air de 16 GB.");
                wd.ShowDialog();
            }

            else if (premiosEntregados.Last().Equals("2"))
            {
                WinDialog wd = new WinDialog("Felicidades!", "Ganaste unos Audífonos Sony.");
                wd.ShowDialog();
            }

            else if (premiosEntregados.Last().Equals("3"))
            {
                WinDialog wd = new WinDialog("Felicidades!", "Ganaste unos Chocolates.");
                wd.ShowDialog();
            }

            else if (premiosEntregados.Last().Equals("4"))
            {
                WinDialog wd = new WinDialog("Felicidades!", "Ganaste un Disco Duro de 1 TB.");
                wd.ShowDialog();
            }

            else if (premiosEntregados.Last().Equals("5"))
            {
                WinDialog wd = new WinDialog("Felicidades!", "Ganaste un  Set de Vinos y Licores.");
                wd.ShowDialog();
            }
            /*
            else if (premiosEntregados.Last().Equals("6"))
            {
                WinDialog wd = new WinDialog("Felicidades!", "Ganaste 500 Dólares.");
                wd.ShowDialog();
            }

            else if (premiosEntregados.Last().Equals("7"))
            {
                WinDialog wd = new WinDialog("Felicidades!", "Ganaste un Set de Vinos y Licores.");
                wd.ShowDialog();
            }

            else if (premiosEntregados.Last().Equals("8"))
            {
                WinDialog wd = new WinDialog("Felicidades!", "Ganaste 70.000 KM LanPass.");
                wd.ShowDialog();
            }
            */
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

        public void RestartGame()
        {
            premiosTemp.Clear();
            premiosPendientes.Clear();

            //delivered prizes are deleted
            foreach (string prize in premiosEntregados)
            {
                for (int i = 0; i < prizeCards.Count; i++)
                {
                    prizeCards.Remove(prize);
                }
            }

            //add every prize to premiosPendientes
            //probabilities are the same for every prize and 2/3 a normal probability for the devil
            for (int i = 0; i < prizeCards.Count; i++)
            {
                premiosPendientes.Add(prizeCards[i]);
            }

            RandomizePeople();
            RandomizePeople();
            RandomizePrizes();
            RandomizePrizes();

            //reset pictures
            A1.Source = new BitmapImage(new Uri("People/" + peopleCards[0] + ".png", UriKind.Relative));
            B1.Source = new BitmapImage(new Uri("People/" + peopleCards[1] + ".png", UriKind.Relative));
            C1.Source = new BitmapImage(new Uri("People/" + peopleCards[2] + ".png", UriKind.Relative));
            D1.Source = new BitmapImage(new Uri("People/" + peopleCards[3] + ".png", UriKind.Relative));
            E1.Source = new BitmapImage(new Uri("People/" + peopleCards[4] + ".png", UriKind.Relative));
            F1.Source = new BitmapImage(new Uri("People/" + peopleCards[5] + ".png", UriKind.Relative));
            A2.Source = new BitmapImage(new Uri("People/" + peopleCards[6] + ".png", UriKind.Relative));
            B2.Source = new BitmapImage(new Uri("People/" + peopleCards[7] + ".png", UriKind.Relative));
            C2.Source = new BitmapImage(new Uri("People/" + peopleCards[8] + ".png", UriKind.Relative));
            D2.Source = new BitmapImage(new Uri("People/" + peopleCards[9] + ".png", UriKind.Relative));
            E2.Source = new BitmapImage(new Uri("People/" + peopleCards[10] + ".png", UriKind.Relative));
            F2.Source = new BitmapImage(new Uri("People/" + peopleCards[11] + ".png", UriKind.Relative));
            A3.Source = new BitmapImage(new Uri("People/" + peopleCards[12] + ".png", UriKind.Relative));
            B3.Source = new BitmapImage(new Uri("People/" + peopleCards[13] + ".png", UriKind.Relative));
            C3.Source = new BitmapImage(new Uri("People/" + peopleCards[14] + ".png", UriKind.Relative));
            D3.Source = new BitmapImage(new Uri("People/" + peopleCards[15] + ".png", UriKind.Relative));
            E3.Source = new BitmapImage(new Uri("People/" + peopleCards[16] + ".png", UriKind.Relative));
            F3.Source = new BitmapImage(new Uri("People/" + peopleCards[17] + ".png", UriKind.Relative));
            A4.Source = new BitmapImage(new Uri("People/" + peopleCards[18] + ".png", UriKind.Relative));
            B4.Source = new BitmapImage(new Uri("People/" + peopleCards[19] + ".png", UriKind.Relative));
            C4.Source = new BitmapImage(new Uri("People/" + peopleCards[20] + ".png", UriKind.Relative));
            D4.Source = new BitmapImage(new Uri("People/" + peopleCards[21] + ".png", UriKind.Relative));
            E4.Source = new BitmapImage(new Uri("People/" + peopleCards[22] + ".png", UriKind.Relative));
            F4.Source = new BitmapImage(new Uri("People/" + peopleCards[23] + ".png", UriKind.Relative));
        }

        private void A1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && A1.Source.ToString().Contains("People"))
            {
                RandomizePrizes();

                A1.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void B1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && B1.Source.ToString().Contains("People"))
            {
                RandomizePrizes();

                B1.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void C1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && C1.Source.ToString().Contains("People"))
            {
                RandomizePrizes();

                C1.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void D1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && D1.Source.ToString().Contains("People"))
            {
                RandomizePrizes();

                D1.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void E1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && E1.Source.ToString().Contains("People"))
            {
                RandomizePrizes();

                E1.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void F1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && F1.Source.ToString().Contains("People"))
            {
                RandomizePrizes();

                F1.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void A2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && A2.Source.ToString().Contains("People"))
            {
                RandomizePrizes();

                A2.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void B2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && B2.Source.ToString().Contains("People"))
            {
                RandomizePrizes();

                B2.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void C2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && C2.Source.ToString().Contains("People"))
            {
                RandomizePrizes();

                C2.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void D2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && D2.Source.ToString().Contains("People"))
            {
                RandomizePrizes();

                D2.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void E2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && E2.Source.ToString().Contains("People"))
            {
                RandomizePrizes();

                E2.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void F2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && F2.Source.ToString().Contains("People"))
            {
                RandomizePrizes();

                F2.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void A3_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && A3.Source.ToString().Contains("People"))
            {
                RandomizePrizes();

                A3.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void B3_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && B3.Source.ToString().Contains("People"))
            {
                RandomizePrizes();

                B3.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void C3_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && C3.Source.ToString().Contains("People"))
            {
                RandomizePrizes();

                C3.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void D3_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && D3.Source.ToString().Contains("People"))
            {
                RandomizePrizes();

                D3.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }

        }

        private void E3_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && E3.Source.ToString().Contains("People"))
            {
                RandomizePrizes();

                E3.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void F3_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && F3.Source.ToString().Contains("People"))
            {
                RandomizePrizes();

                F3.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void A4_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && A4.Source.ToString().Contains("People"))
            {
                RandomizePrizes();

                A4.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void B4_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && B4.Source.ToString().Contains("People"))
            {
                RandomizePrizes();

                B4.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void C4_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && C4.Source.ToString().Contains("People"))
            {
                RandomizePrizes();

                C4.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void D4_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && D4.Source.ToString().Contains("People"))
            {
                RandomizePrizes();

                D4.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void E4_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && E4.Source.ToString().Contains("People"))
            {
                RandomizePrizes();

                E4.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

        private void F4_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (premiosPendientes.Count > 0 && F4.Source.ToString().Contains("People"))
            {
                RandomizePrizes();

                F4.Source = new BitmapImage(new Uri("Prizes/" + premiosPendientes[0] + ".png", UriKind.Relative));
                CheckGameStatus();
            }
        }

    }
}
