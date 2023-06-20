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
using Dip.Class;
using System.Diagnostics;

namespace Dip.Windows
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public static int autorizeID;
        public Auth()
        {
            InitializeComponent();
        }

        public async Task<bool> AutorizeAsync(string UserLogin, string UserPasssword)
        {
            var user = await Task.Run(() =>
            EfModel.Init().Workers.FirstOrDefaultAsync(p => p.Login == UserLogin && p.Password == UserPasssword));
            return user != null;
            
            
        }
        private void btAauth_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AutorizeAsync(tbLogin.Text, tbPass.Text);
                MessageBox.Show("");
                new MainWindow().Show();
            }
            catch
            {
                MessageBox.Show("неверный логин или пароль");
            }
        }
    }
}
