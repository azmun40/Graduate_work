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

namespace Internet_shop_app
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AppDBContext _db = new AppDBContext();
        public MainWindow()
        {
            InitializeComponent();

            ObservableCollection<Item> items = new ObservableCollection<Item>();
            List<Item> itemvis = _db.items.ToList();
            foreach (Item el in itemvis)
                items.Add(el);

            ListItems.ItemsSource = items;
        }



    }
}
