using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
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

namespace FindTwoChristmas
{
    /// <summary>
    /// Interaction logic for DevilWindow.xaml
    /// </summary>
    public partial class DevilWindow : Window
    {
        SoundPlayer player;

        public DevilWindow()
        {
            InitializeComponent();

            player = new SoundPlayer();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists("Audio/devilLaugh.wav"))
            {
                player.SoundLocation = "Audio/devilLaugh.wav";
                player.Play();
            }
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            player.Stop();
        }
    }
}
