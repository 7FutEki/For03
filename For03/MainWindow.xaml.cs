using For03.Forms;
using For03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
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

namespace For03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public User user = new User();
        public MainWindow()
        {
            InitializeComponent();
            ApplicationContext db = new ApplicationContext();
            db.Database.Migrate();
            
            var check = db.Users.Where(x => x.Login == "FutEki" && x.Password == "senchaaa55" || x.Login == "admin" && x.Password == "admin").FirstOrDefault();
            if (check == null)
            {
                Metods.Sign_Up("FutEki", "senchaaa55");
                Metods.Sign_Up("admin", "admin");

            }

        }

        private void btn_admin_Click(object sender, RoutedEventArgs e)
        {
            AdminWindowLog adminWindowLog = new AdminWindowLog();
            Close();
            adminWindowLog.ShowDialog();
        }

        private void btn_client_Click(object sender, RoutedEventArgs e)
        {
            ServiceWindow serviceWindow = new ServiceWindow();
            Close();
            serviceWindow.ShowDialog();
        }
    }
}
