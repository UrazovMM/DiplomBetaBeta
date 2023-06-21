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
        public Auth()
        {
            InitializeComponent();
        }


        private void btAauth_Click(object sender, RoutedEventArgs e)
        {

            if (tbLogin.Text == null || tbPass.Text == null)
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
            else
            {
                Worker worker = EfModel.Init().Workers.FirstOrDefault(u => u.Login == tbLogin.Text && u.Password == tbPass.Text);
                if (worker != null)
                {
                    if (worker.Position == 1)
                    {
                        MessageBox.Show("Здраствуйте");
                        AddWorkerID.Worker(worker.WorkerId);
                        new MainWindow().Show();
                    }
                    if (worker.Position == 2)
                    {

                        AddWorkerID.Worker(worker.WorkerId);
                        new MainWindow().Show();
                    }
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
        }
    }
}

