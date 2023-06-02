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
    /// Логика взаимодействия для ServiceWindow.xaml
    /// </summary>
    public partial class ServiceWindow : Window
    {
        public ObservableCollection<Service> TapService { get; set; }
        public Service Service { get; set; }
        public ServiceWindow()
        {
            InitializeComponent();
            TapService = new();
            DataContext = this;
            this.Loaded += Sqlite_Loaded;
        }
        private void Sqlite_Loaded(object sender, RoutedEventArgs e)
        {
            ApplicationContext db = new ApplicationContext();
            db.Database.Migrate();
            List<Service> services = db.Services.ToList();
            ListService.ItemsSource = services;
            foreach (Service service in services)
            {
                TapService.Add(new Service { Name = service.Name, Price = service.Price, Descrtiption = service.Descrtiption });
            }

            ListService.ItemsSource = TapService;

        }
        private void btn_enroll_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы записаны на выбранную вами услугу");
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Close();
            mainWindow.ShowDialog();
        }
    }
}
