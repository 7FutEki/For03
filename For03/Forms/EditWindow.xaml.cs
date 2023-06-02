using For03.Models;
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
using System.Windows.Shapes;

namespace For03.Forms
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public Service Service { get; set; }
        public EditWindow(Service service)
        {
            InitializeComponent();
            Service = service;
            DataContext = Service;
        }

        private void btn_add_im_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            ListWindow listWindow = new ListWindow();
            Close();
            listWindow.ShowDialog();
        }
    }
}
