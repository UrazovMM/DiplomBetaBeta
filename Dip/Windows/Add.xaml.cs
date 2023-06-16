﻿using System;
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

namespace Dip.Windows
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        Client Client;
        public Add(Client client)
        {
            this.Client= client;
            DataContext = Client;

            InitializeComponent();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            EfModel.Init().Clients.Add(Client);
            EfModel.Init().SaveChanges();
            Close();
        }
    }
}
