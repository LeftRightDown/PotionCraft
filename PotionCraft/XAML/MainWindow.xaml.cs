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
using static PotionCraft.Utility;

namespace PotionCraft
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CraftedItems Crafting = new CraftedItems();
        Player player = new Player("Anon", 20000);
        public MainWindow()
        {
            InitializeComponent();
            GameSetup();
            DisplayInventory("Vendor");
            
            Title = "Potion Craft Academy";
        }

        #region "Setup"
        private void GameSetup()
        {
            Vendor.SetupVendor(Material.Ingredients);
            //Crafting.SetUpItems();

        }

        private void DisplayInventory(string input)
        {
            if (input == "Vendor")
            {
                PrintSide(DisplayList(Vendor.VendorInventory));
            }
            else if (input == "Player")
            {
                //PrintMain(Crafting.ListDictionary(CraftedItems.DataBaseItems));
                System.Diagnostics.Debug.WriteLine("Crafted Items are here" + Crafting.ListDictionary(CraftedItems.DataBaseItems));
            }

        }
        #endregion

        #region "Button Inputs"
        private void MainMenuNavigation_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
           
            switch (button.Name)
            {
                case "ButtonOne":
                    //Start
                    ChangeButton();
                    break;
                case "ButtonTwo":
                    //Credits
                    
                    MessageBox.Show
                    (
                    @"
                     Designed and Programed By: Zachary Tan
                     Debugging & Structural Assistance from: Mack,Pearson-Muggli
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

        private void ChangeButton()
        {
            ButtonOne.Visibility = Visibility.Hidden;
            ButtonTwo.Visibility = Visibility.Hidden;
            ButtonThree.Visibility = Visibility.Hidden;

            ButtonFour.Visibility = Visibility.Visible;
            ButtonFive.Visibility = Visibility.Visible;
            ButtonSix.Visibility = Visibility.Visible;

        }


        private void NavigationButton_Click(object sender, RoutedEventArgs e)
        {
            string PlayerInput = "";
            Button button = (Button)sender;

            switch (button.Name)
            {
                case "ButtonFour":
                    //Craft
                   
                    break;
                case "ButtonFive":
                    //Trader
                    DisplayInventory("Vendor");
                    SideBarTitle.Content = "Trader Inventory";
                  
                    break;
                case "ButtonSix":
                    //Inventory
                    DisplayInventory("Player");
                    SideBarTitle.Content = "Player Inventory";
                    break;
                case "SubmitButton":
                    Input.Text = PlayerInput;
                    PrintMain(player.Craft(PlayerInput));
                    break;
            }
        }
        #endregion
    }
}
