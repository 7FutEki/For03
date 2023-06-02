using For03.Models;
using Microsoft.EntityFrameworkCore;
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
using System.Windows.Shapes;

namespace For03.Forms
{
    /// <summary>
    /// Логика взаимодействия для ListWindow.xaml
    /// </summary>
    public partial class ListWindow : Window
    {
        public ObservableCollection<Service> TapService { get; set; }
        public Service Service { get; set; }
        public ListWindow()
        {
            InitializeComponent();
            TapService = new();
            DataContext = this;
            this.Loaded += Sqlite_Loaded;
            ApplicationContext a = new ApplicationContext();
            a.Database.Migrate();
        }
        private void Sqlite_Loaded(object sender, RoutedEventArgs e)
        {
            ApplicationContext db = new ApplicationContext();
            db.Database.Migrate();
            List<Service> services = db.Services.ToList();
            ListService.ItemsSource = services;
            foreach (Service service in services)
            {
                TapService.Add(new Service { Name = service.Name, Price = service.Price, Descrtiption = service.Descrtiption, Discount = service.Discount });
            }
            

            ListService.ItemsSource = TapService;
        }
        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            Forms.AddWindow window_Add = new Forms.AddWindow();
            Close();
            window_Add.ShowDialog();
        }

        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {
            var product = ListService.SelectedItem as Service;

            if (new Forms.EditWindow(product).ShowDialog() == true)
            {
                using (var context = new ApplicationContext())
                {
                    context.Entry(product).State = EntityState.Modified;
                    context.SaveChanges();

                }
                ListService.Items.Refresh();
            }
            MainWindow mainWindow = new MainWindow();
            Close();
            mainWindow.ShowDialog();
        }

        private void btn_dlt_Click(object sender, RoutedEventArgs e)
        {
            if (Service != null)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Вы уверены?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    var product = ListService.SelectedItem as Service;
                    using (var context = new ApplicationContext())
                    {
                        context.Services.Remove(product);
                        context.SaveChanges();
                        ListService.ItemsSource = context.Services.ToList();
                    }
                }

            }
           
            ListWindow listWindow = new ListWindow();
            Close();
            listWindow.ShowDialog();
            
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Close();
            mainWindow.ShowDialog();
        }
    }
}
