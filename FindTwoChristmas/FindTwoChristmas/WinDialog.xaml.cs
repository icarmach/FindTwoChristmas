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

namespace FindTwoChristmas
{
    /// <summary>
    /// Interaction logic for WinDialog.xaml
    /// </summary>
    public partial class WinDialog : Window
    {
        public WinDialog(string title, string prize)
        {
            InitializeComponent();

            prizeTitle.Content = title;
            prizeLabel.Content = prize;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
