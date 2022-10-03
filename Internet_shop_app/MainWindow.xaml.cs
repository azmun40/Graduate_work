using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Internet_shop_app.Models;
using Microsoft.EntityFrameworkCore;
using CloudIpspSDK;
using CloudIpspSDK.Checkout;

namespace Internet_shop_app
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AppDBContext _db = new AppDBContext();
        private List<Item> cartItems = new List<Item>();
        private List<int> ListItemsId = new List<int>();
        private int sumOrder = 0;

        public MainWindow()
        {
            InitializeComponent();
            ObservableCollection<Item> items = new ObservableCollection<Item>();

            List<Item> itemvis = _db.items.ToList();
            foreach (Item el in itemvis)

                items.Add(el);


            ListItems.ItemsSource = items;

            
        }
        
        
      
       

        private void PayBtn_Click(object sender, RoutedEventArgs e)
        {
            Config.MerchantId = 1396424;
            Config.SecretKey = "test";
            if(sumOrder == 0)
            {
                MessageBox.Show("Ваша корзина пуста");
                return;
            }

            var req = new CheckoutRequest
            {
                order_id = Guid.NewGuid().ToString("N"),
                amount = sumOrder * 100,
                order_desc = "checkout json demo",
                currency = "USD"
            };
            var resp = new Url().Post(req);
            if (resp.Error == null)
            {
                string url = resp.checkout_url;
                System.Diagnostics.Process.Start(url);
            }

            
        }
        
        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            int itemId = int.Parse(((Button)sender).Tag.ToString());
            ListItemsId.Add(itemId);
            
            cartItems = _db.items.Where(x => ListItemsId.Contains(x.Id)).ToList();
            sumOrder = cartItems.Sum(x => x.price * ListItemsId.Count(el => el == x.Id));
            string sumItems = $"{sumOrder} $";
             if(cartItems.Count > 0)
            {
                ValueInCart.Content = "В корзине есть товары";
                Value.Content = $"Количество: {ListItemsId.Count} шт.";
                Value.Visibility = Visibility.Visible;
                SumItems.Content = "Общая сумма: " + sumItems;
                SumItems.Visibility = Visibility.Visible;
            }
            


        }
    }
}
