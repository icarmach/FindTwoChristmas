using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace FlipControl
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class FlipControl : UserControl
    {
        public FlipControl()
        {
            InitializeComponent();
        }

        public Visual FrontSide
        {
            get
            {
                return Side1.Visual;
            }
            set
            {
                UIElement Elem;
                Storyboard Animation;

                Side1.Visual = value;
                Elem = Side1.Visual as UIElement;

                if (Elem != null)
                {
                    Elem.MouseUp += (sender, e) =>
                    {
                        Animation = this.Resources["StoryFlip"] as Storyboard;

                        if (Animation != null)
                        {
                            Animation.Begin();
                        }
                    };
                }
                
            }
        }

        public Visual BackSide
        {
            get
            {
                return Side2.Visual;
            }
            set
            {
                UIElement Elem;
                Storyboard Animation;

                Side2.Visual = value;
                Elem = Side2.Visual as UIElement;

                if (Elem != null)
                {
                    /*
                    Elem.MouseUp += (sender, e) =>
                    {
                        Animation = this.Resources["StoryFlipBack"] as Storyboard;

                        if (Animation != null)
                        {
                            Animation.Begin();
                        }
                    };
                    */
                }

            }
        }
    }
}
