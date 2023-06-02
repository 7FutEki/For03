using For03.Models;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;

namespace For03.Forms
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public Service Service { get; set; }
        public AddWindow()
        {
            InitializeComponent();
            Service = new Service();
            DataContext= Service;
            Service.Id = Guid.NewGuid();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            Metods.AddProduct(Service.Id, Service.Name, Service.Price, Service.Descrtiption, Service.Discount);
            ListWindow listWindow = new ListWindow();
            Close();
            listWindow.ShowDialog();
        }

        private void btn_add_im_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            if (openFileDialog.ShowDialog() == true)
            {

                byte[] imageew = File.ReadAllBytes(openFileDialog.FileName);


            

            using (var ms = new MemoryStream(imageew))
                {
                    imagee.Image = new 
                }
            }
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            ListWindow listWindow = new ListWindow();
            Close();
            listWindow.ShowDialog();
        }
    }
}
