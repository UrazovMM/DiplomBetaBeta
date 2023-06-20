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
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace Dip.Windows
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();
        }

        //public async Task<bool> AutorizeAsync(string UserLogin, string UserPasssword)
        //{
        //   var user= await Task.Run(() =>
        //      {
        //          if (EfModel.Init().Workers.AnyAsync(p => p.Login == UserLogin && p.Password == UserPasssword))
        //          {
        //              new MainWindow().Show();
        //              Hide();
        //              MessageBox.Show("Добро пожаловать");
        //          }
        //          else
        //          {
        //              MessageBox.Show("Неверный логин или пароль");
        //          }
        //          return user;

        //      });
        //}
        private void btAauth_Click(object sender, RoutedEventArgs e)
        {
           ////AutorizeAsync(tbLogin.Text, tbPass.Text);
        }
    }
}
