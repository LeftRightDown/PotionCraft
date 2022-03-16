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
        
         string name;
        public MainWindow()
        {
            InitializeComponent();
            GameSetup();
            

            Title = "Potion Craft Academy";
        }

        #region "Setup"
        private void GameSetup()
        {
            SetUpCharacters("Player",Material.StarterIngredients);
            SetUpCharacters("Vendor",Material.Ingredients);
            CraftedItems.SetUpItems();
            

        }

        private void DisplayInventory(string input)
        {
            MainText.Text = ""; 
            Titlebar.Name = "";
            if (input == "Vendor")
            {   
                PrintMain(DisplayList(Vendor.VendorInventory));
            }
            else if (input == "Player")
            {
                PrintMain(DisplayList(Player.PlayerInventory));
            }

        }

        private void SetupCraft()
        {
            CraftInput.Visibility = Visibility.Visible;
            SubmitButton.Visibility = Visibility.Visible;
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
                    ChangeScene();
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

        private void ChangeScene()
        {
            //Main Menu
            ButtonOne.Visibility = Visibility.Hidden;
            ButtonTwo.Visibility = Visibility.Hidden;
            ButtonThree.Visibility = Visibility.Hidden;
            


            //Game Menu
            ButtonFour.Visibility = Visibility.Visible;
            ButtonFive.Visibility = Visibility.Visible;
            ButtonSix.Visibility = Visibility.Visible;
            ButtonSeven.Visibility = Visibility.Visible;
           

        }


        private void NavigationButton_Click(object sender, RoutedEventArgs e)
        {   
            string PlayerInput = "";
            Button button = (Button)sender;

            switch (button.Name)
            {
                case "ButtonFour":
                    //Craft
                    SetupCraft();
                    
                    break;
                case "ButtonFive":
                    //Trader
                    DisplayInventory("Vendor");
                    Titlebar.Content = "Trader Inventory";

                    break;
                case "ButtonSix":
                    //Inventory
                    DisplayInventory("Player");
                    PrintMain($"{Player.Currency.ToString("C")}");
                    Titlebar.Content = "Player Inventory";
                break;
              
            }
        }
        #endregion


        #region "Craft"

        private void CraftInput_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> Item = new List<string>();
            foreach (Item x in CraftedItems.DataBaseItems.Keys)
            {
                Item.Add(x.Name);
                System.Diagnostics.Debug.WriteLine("HERE IS THE ITEMS ADDED TO THE DROPDOWN " + Item.Count + "" + x.Name);
            }

            var combo = sender as ComboBox;
            combo.ItemsSource = Item;
            combo.SelectedIndex = -1;

        }


        private void CraftInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectedInputItems = sender as ComboBox;

            name = SelectedInputItems.SelectedItem as string;
            MessageBox.Show(name);

        }

        //search database items for a key that matches name

        //get value which is a list of items
        //look through player inventory for items in correct measurments
        //if true item is crafted
        //remove ingredients from player inventory

        #endregion

        #region "Trade"

        private void TradeInput_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> TradeItem = new List<string>();
            foreach (Item x in Vendor.VendorInventory)
            {
                TradeItem.Add(x.Name);
                System.Diagnostics.Debug.WriteLine("HERE IS THE ITEMS ADDED TO THE DROPDOWN" + TradeItem.Count + x.Name);
            }

           var combo = sender as ComboBox;
            combo.ItemsSource = TradeItem;
            combo.SelectedIndex = -1;
        }


        private void TradeInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectedInputItems = sender as ComboBox;
            name = SelectedInputItems.SelectedItem as string;
             System.Diagnostics.Debug.WriteLine("SELECTED ITEM " + name );
        }



        #endregion

        //Submit Button to Iniate various Methods depending on Combobox
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string Input;
            Item i = new Item();
            Input = TradeInput.SelectedItem as string;
            //Vendor.Buy(Input,Player.PlayerInventory );
           
            
            Player.CurrencyAdd(i.Price);
            
            System.Diagnostics.Debug.WriteLine("SUBMIT APPLICATION TO CHECK " + Input );
        }
    }
}
