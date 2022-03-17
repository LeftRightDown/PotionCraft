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
        public static Customer customer = new Customer("Bender", 100f);
        public static Player player = new Player("Anon", 5f);
        public static Vendor vendor = new Vendor("Butch the Guy", 20000f);
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
                PrintMain(DisplayList(vendor.VendorInventory));
            }
            else if (input == "Player")
            {
                PrintMain(DisplayList(player.PlayerInventory));
            }

        }

        private void SetupMenu(string menuType)
        {
            HideAllComboBox();
            if (menuType == "Craft")
            {
             CraftInput.Visibility = Visibility.Visible;
             CraftButton.Visibility = Visibility.Visible;
            }
            else if (menuType == "Trader")
            {
              BuyInput.Visibility = Visibility.Visible;
              BuyButton.Visibility = Visibility.Visible;
              
            }
            else if(menuType == "Sell")
            {
               SellInput.Visibility = Visibility.Visible;
              SellButton.Visibility = Visibility.Visible;
              
            }
            
        }

        private void HideAllComboBox()
        {
            CraftButton.Visibility = Visibility.Hidden;
            CraftInput.Visibility = Visibility.Hidden;
            BuyButton.Visibility = Visibility.Hidden;
            BuyInput.Visibility = Visibility.Hidden;
            SellButton.Visibility = Visibility.Hidden;
            SellInput.Visibility = Visibility.Hidden;
        }
        #endregion

        #region "Button Inputs" 
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

        private void NavigationButton_Click(object sender, RoutedEventArgs e)
        {   
            Button button = (Button)sender;

            switch (button.Name)
            {
                case "ButtonFour":
                    //Craft
                    SetupMenu("Craft");
                    
                    break;
                case "ButtonFive":
                    //Trader
                    SetupMenu("Trader");
                    DisplayInventory("Vendor");
                    Titlebar.Content = "Supplier Shop";

                    break;
                case "ButtonSix":
                    //Inventory 
                    HideAllComboBox();
                    DisplayInventory("Player");
                    PrintMain($"{player.Currency.ToString("C")}");
                    Titlebar.Content = "Player Inventory";
                break;
                case "ButtonSeven":
                    //Sell
                    SetupMenu("Sell");
                    Titlebar.Content = "Player Shop";
                    break;
              
            }
        }   
        //Submit Button to Iniate various Methods depending on Combobox
        private void ComboBoxButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            switch (button.Name)
            {
                case "CraftButton":

                    break;
                case "BuyButton":
                    string Input;
                    
                    Input = BuyInput.SelectedItem.ToString();
                    System.Diagnostics.Debug.WriteLine("BEFORE BUY " + Input + "" + player.PlayerInventory.Count);
                    vendor.BuyandSell(Input, vendor.VendorInventory,player.PlayerInventory);

                    System.Diagnostics.Debug.WriteLine("AFTER BUY " + Input + "" + player.PlayerInventory.Count);
                    break;
                case "SellButton":
                    Input = SellInput.SelectedItem.ToString();
                    System.Diagnostics.Debug.WriteLine("BEFORE SELL " + Input + "" +customer.BoughtItems.Count);
                    player.BuyandSell(Input, player.PlayerInventory, customer.BoughtItems);
                    System.Diagnostics.Debug.WriteLine("AFTER SELL " + Input + "" + customer.BoughtItems.Count);

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

        private void BuyInput_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> VendorItems = new List<string>();
            foreach (Item x in vendor.VendorInventory)
            {
                VendorItems.Add(x.Name);
                System.Diagnostics.Debug.WriteLine("VENDOR DROPDOWN " + VendorItems.Count + x.Name);
            }

           var combo = sender as ComboBox;
            combo.ItemsSource = VendorItems;
            combo.SelectedIndex = -1;
        }


        private void ComboBoxInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectedInputItems = sender as ComboBox;
            name = SelectedInputItems.SelectedItem as string;
            System.Diagnostics.Debug.WriteLine("SELECTED ITEM " + name );
        }


        #endregion

        private void SellInput_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> StoreItems = new List<string>();
            foreach (Item x in player.PlayerInventory)
            {
                StoreItems.Add(x.Name);
                System.Diagnostics.Debug.WriteLine("PLAYER DROPDOWN " + StoreItems.Count + x.Name);
            }
            var combo = sender as ComboBox;
            combo.ItemsSource = StoreItems;
            combo.SelectedIndex = -1;
        }

    }
}
