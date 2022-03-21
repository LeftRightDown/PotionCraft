/* PROG 201 Craft Project
 * Your Name:  Zachary Tan
 * Date: 3/20/2022
 * Credits:  
 *     Mack,Pearson-Muggli (Tutor),
 *     Janell Baxter (Tutor)
 *     
 *     Additional Code reused from in class group demos such as WPF print method.
 *     
 * */
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
        //Instances of Persons
        public static Customer customer = new Customer("Bender", 100f);
        public static Player player = new Player("Anon", 0f);
        public static Vendor vendor = new Vendor("Bucky", 20000f);

        //Declaration
       public delegate void BuyAndSell(string itemName, Person Seller, Person Buyer, List<Item> SellerList, List<Item> BuyerList);

        string name;
        public MainWindow()
        {
            InitializeComponent();
            ItemSetUp();
            WelcomeText();
           
            //Testing Selling Items with this inventory
            player.test();       
            Title = "Potion Craft Academy";
            
           
        }
        //Contains Setup methods
        #region "Setup"
        //Prints Welcome Text
        private void WelcomeText()
        {
            string welcome = LoadData.LoadTextFromFile("../../../data/Welcome.txt");
            PrintMain(welcome);
        }
     
        //Sets up Items for both Player and Vendor
        private void ItemSetUp()
        {

            CraftedItems.SetUpItems();
            SetUpCharacters("Player",Material.StarterIngredients);
            SetUpCharacters("Vendor",Material.Ingredients);
            

        }
        //Dispalys Inventory for both Player and Vendor
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
            else if (input == "Store")
            {
                
                PrintMain(DisplayList(player.StoreCraftedItems));
            }

        }
        //Displays Comboboxes based on menu button pressed
        private void MenuSetUp(string menuType)
        {
            HideAllComboBox();
            if (menuType == "Craft")
            {
             CraftInput.Visibility = Visibility.Visible;
             CraftButton.Visibility = Visibility.Visible;
               MainText.Text = "";
            }
            else if (menuType == "Trader")
            {
              BuyInput.Visibility = Visibility.Visible;
              BuyButton.Visibility = Visibility.Visible;
                MainText.Text = "";

            }
            else if(menuType == "Sell")
            {
              SellInput.Visibility = Visibility.Visible;
              SellButton.Visibility = Visibility.Visible;
                MainText.Text = "";

            }
            
        }
        //Hides Comboboxes based on menu button pressed
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
        //Contains Methods related to Buttons
        #region "Button Inputs" 
        //Changes the Menu buttons after Start button is pressed.
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
        //Fist Switch statment for when a specific button in the Main Menu is pressed.
        private void MainMenuNavigation_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
           
            switch (button.Name)
            {
                case "ButtonOne":
                    //Start
                    ChangeScene();
                    MainText.Text = "";

                    break;
                case "ButtonTwo":
                    //Credits
                    
                    MessageBox.Show
                    (
                    @"
                     Designed and Programed By: Zachary Tan
                     Debugging & Structural Assistance from: Mack,Pearson-Muggli && Janell Baxter
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
        //Secound Switch statment for when a specific button in the Game is pressed.
        private void NavigationButton_Click(object sender, RoutedEventArgs e)
        {   
            Button button = (Button)sender;

            switch (button.Name)
            {
                case "ButtonFour":
                    //Craft
                    MenuSetUp("Craft");
                    PrintMain(CraftedItems.ListDictionary());
                    CurrencyText.Visibility = Visibility.Hidden;
                    Titlebar.Content = "Crafting Table";
                    break;
                case "ButtonFive":
                    //Trader
                    MenuSetUp("Trader");
                    DisplayInventory("Vendor");
                    Titlebar.Content = $"{vendor.Name}'s Shop";
                    CurrencyUpdate();
                    CurrencyText.Visibility = Visibility.Visible;

                    break;
                case "ButtonSix":
                    //Inventory 
                    HideAllComboBox();
                    DisplayInventory("Player");
                    Titlebar.Content = "Player Inventory";
                    CurrencyUpdate();
                    CurrencyText.Visibility = Visibility.Visible;

                    
                break;
                case "ButtonSeven":
                    //Sell
                    MenuSetUp("Sell");
                    DisplayInventory("Store");
                    Titlebar.Content = $"{player.Name}'s Shop";
                    CurrencyUpdate();
                    CurrencyText.Visibility = Visibility.Visible;
                    break;
              
            }
        }   

        //Submit Button to Iniate various Methods depending on Combobox
        private void ComboBoxButton_Click(object sender, RoutedEventArgs e)
        {
            BuyAndSell VendorBuy = vendor.Buy;
            BuyAndSell PlayerSell = player.Sell;
            Button button = (Button)sender;
            switch (button.Name)
            {
                case "CraftButton":

                    break;
                case "BuyButton":
                    string Input;
                    
                    Input = BuyInput.SelectedItem.ToString();
                    System.Diagnostics.Debug.WriteLine("BEFORE BUY " + Input + "" + player.PlayerInventory.Count);
                    VendorBuy(Input, vendor, player,vendor.VendorInventory,player.PlayerInventory);

                    System.Diagnostics.Debug.WriteLine("AFTER BUY " + Input + "" + player.PlayerInventory.Count);
                    break;
                case "SellButton":
                    Input = SellInput.SelectedItem.ToString();
                    System.Diagnostics.Debug.WriteLine("BEFORE SELL " + Input + "" +customer.BoughtItems.Count);
                    PlayerSell(Input, player, customer, player.StoreCraftedItems, customer.BoughtItems);
                    System.Diagnostics.Debug.WriteLine("AFTER SELL " + Input + "" + customer.BoughtItems.Count);
                    break;
            }
        }
        #endregion
        //Contains methods related to crafting
        #region "Craft"
        //Loads the Combobox list with items able to be crafted 
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

        //New Item is selected when combobox is changed.
        private void CraftInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectedInputItems = sender as ComboBox;
            name = SelectedInputItems.SelectedItem as string;
            

        }



        #endregion
        //Contains methods related to market
        #region "Buy and Sell"
        //Loads the Combobox list with items able to be bought
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
        //Loads the Combobox list with items able to be sold
        private void SellInput_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> StoreItems = new List<string>();
            System.Diagnostics.Debug.WriteLine("ITEMS " + player.StoreCraftedItems.Count);
            foreach (Item x in player.StoreCraftedItems)
            {
                StoreItems.Add(x.Name);
                System.Diagnostics.Debug.WriteLine("STORE DROPDOWN " + StoreItems.Count + x.Name);
            }
            var combo = sender as ComboBox;
            combo.ItemsSource = StoreItems;
            combo.SelectedIndex = -1;
        }
        //New Item is slected when combobox is changed
        private void ComboBoxInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectedInputItems = sender as ComboBox;
            name = SelectedInputItems.SelectedItem as string;
            System.Diagnostics.Debug.WriteLine("SELECTED ITEM " + name );
        }
        //Currency Text is changed based on players current amount
        private void CurrencyUpdate()
        {
            CurrencyText.Text = $"Cash:{Environment.NewLine}{player.Currency.ToString("C")}";
        }

        #endregion
        
    }
}
