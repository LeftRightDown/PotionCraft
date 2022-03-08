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

namespace PotionCraft
{
    /// <summary>
    /// Interaction logic for Start.xaml
    /// </summary>
    public partial class Start : Page
    {
        public Start()
        {
            InitializeComponent();
            TitleBar.Content = "Potion Craft Academy";

        }
        #region "Button Inputs"
        private void NavigationButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Name)
            {
                case "ButtonOne":
                    //Start
                    NavigationService.Navigate(new Uri("Quest.xaml", UriKind.Relative));
                    break;
                case "ButtonTwo":
                    //Credits
                    MessageBox.Show
                    (

                    @"
                     Designed and Programed By: Zachary Tan
                     Debugging & Structural Assistance from: Mack, Pearson-Muggli
                     Additional Code reused from in class group demos.
                    ",
                    "CREDITS"
                    );
                    break;
                case "ButtonThree":
                    //Exit
                    Environment.Exit(0);
                    break;
            }
        }
        #endregion
    }
}
