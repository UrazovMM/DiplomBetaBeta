﻿using Microsoft.EntityFrameworkCore;
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

namespace Dip.Windows
{
    /// <summary>
    /// Логика взаимодействия для Card.xaml
    /// </summary>
    public partial class Card : Window
    {
        Client client;
        public Card(Client client)
        {
            this.client = client;
            InitializeComponent();
            DataContext = client;
           Cb_worker.ItemsSource =EfModel.Init().Clients.Include(p=>p.WorkerWorker).Where(p=>p.WorkerWorkerId==client.WorkerWorkerId).ToList();
          
        }
    }
}
