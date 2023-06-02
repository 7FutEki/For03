using For03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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
    /// Логика взаимодействия для AdminWindowLog.xaml
    /// </summary>
    public partial class AdminWindowLog : Window
    {
        public User user { get; set; }
        public AdminWindowLog()
        {
            InitializeComponent();
            user = new User();
            DataContext = user;
            
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Close();
            mainWindow.ShowDialog();
        }

        private void btn_in_Click(object sender, RoutedEventArgs e)
        {
            
                if (user.Login == "FutEki" && user.Password == "senchaaa55")
                {
                    ListWindow listWindow = new ListWindow();
                    Close();
                    listWindow.ShowDialog();
                }
                
                else if (user.Login == "admin" && user.Password == "admin")
                {
                    ListWindow addWindow = new ListWindow();
                    Close();
                    addWindow.ShowDialog();
                }

                else
                {
                    MessageBox.Show("Неправильно введенные данные");
                }
            
        }

        

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
