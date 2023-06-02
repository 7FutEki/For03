using For03.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;

namespace For03
{
    public class Metods
    {
        

        public static string AddProduct(Guid id, string name, double price, string description, string discount)
        {

            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.Migrate();
                bool check = db.Services.Any(el => el.Name == name && el.Price == price && el.Descrtiption == description && el.Discount == discount);
                if (!check)
                {
                    Service newservice = new Service
                    {
                        Id = id,
                        Name = name,
                        Price = price,
                        Descrtiption = description,
                        Discount= discount
                    };
                    db.Services.Add(newservice);
                    db.SaveChanges();
                    result = "Сделано";
                }
                return result;
            }
        }
        public static bool Sign_Up(string login, string password)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.Migrate();
                bool check = db.Users.Any(el => el.Login == login  && el.Password == password);
                if (!check)
                {
                    User newuser = new User
                    {

                        Login = login,
                        Password = password
                    };
                    db.Users.Add(newuser);
                    db.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
        }


        public static bool Sign_In(string login, string password)
        {
            User auth = null;
            using (ApplicationContext db = new ApplicationContext())
            {
                auth = db.Users.Where(x => x.Login == login && x.Password == password).FirstOrDefault();
                if (auth != null)
                {
                    return true;
                }
                else
                    MessageBox.Show("Неправильно введеныe данные");
                return false;

            }
        }






    }
}
