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
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace Dip.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientPages.xaml
    /// </summary>
    public partial class ClientPages : Page
    {
        public ClientPages()
        {
            InitializeComponent();
            //((Storyboard)CircleLoading.Resources["CircleLoad"]).RepeatBehavior = RepeatBehavior.Forever;
            //((Storyboard)CircleLoading.Resources["CircleLoad"]).SpeedRatio = 8;
            //((Storyboard)CircleLoading.Resources["CircleLoad"]).Begin();
            UpdateData();
          


        }
        private void StartAnimation()
        {

            ((Storyboard)CircleLoading.Resources["CircleLoad"]).RepeatBehavior = RepeatBehavior.Forever;
            ((Storyboard)CircleLoading.Resources["CircleLoad"]).SpeedRatio = 8;
            ((Storyboard)CircleLoading.Resources["CircleLoad"]).Begin();
        }

        private void StopAnimation()
        {
            ((Storyboard)CircleLoading.Resources["CircleLoad"]).Stop();
            CircleLoading.Visibility = Visibility.Hidden;
        }



        //2:75 
        private void LoadData()
        {
            Thread LoadingData = new Thread(UpdateData);
            LoadingData.Start(UpdateData);

        }
        public void UpdateData()
        {
            IEnumerable<Client> Clients = EfModel.Init().Clients.Include(p=>p.WorkerWorker).Where(p => p.NameClient.Contains(Searchtb222.Text)).ToList();
            List.ItemsSource = Clients;

            StopAnimation();
        }


        //// 2:89 time
        //public async Task UpdateData()
        //{

        //    await Task.Run(() =>
        //    {
        //        IEnumerable<Client> clients = EfModel.Init().Clients.ToList();
        //        Dispatcher.Invoke(() =>
        //        {
        //            List.ItemsSource = clients;
        //            Task.Delay(10);
        //            StopAnimation();
        //        });
        //    });
        //}


        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            new Windows.Add(new Client()).Show();
        }

        private void Card_Open(object sender, MouseButtonEventArgs e)
        {
            Client client = (sender as TextBlock).DataContext as Client;
            new Windows.Card(client).ShowDialog();
        }

        private void UpdateChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            UpdateData();
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            Client delete_client = (sender as Button).DataContext as Client;
            if (MessageBox.Show("Вы действительно хотите удалить клиента", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                EfModel.Init().Clients.Remove(delete_client);
                EfModel.Init().SaveChanges();
            }
            UpdateData();
        }

        private void Search(object sender, TextChangedEventArgs e)
        {
            UpdateData(); 
        }
    }
}

