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
            UpdateDate();
        }
        DispatcherTimer timer = new DispatcherTimer();
        private void Timer_Go(object sender, EventArgs e)
        {
            if (List.Items.Count>0)
                timer.Stop();
        }
        private void StartLoad()
        {
            CircleLoading.Visibility = Visibility.Visible;
            if (List.Items.Count>0)
                timer.Tick -= Timer_Go;
            timer.Interval = TimeSpan.FromMilliseconds(150);
            timer.Tick += Timer_Go;
            timer.Start();
        }
        private void StopLoad()
        {
            if (List.Items.Count>0)
                timer.Tick -= Timer_Go;
            timer.Stop();
            CircleLoading.Visibility = Visibility.Collapsed;
        }
        private void StartAnimation()
        {
            ((Storyboard)CircleLoading.Resources["CircleLoad"]).Begin();
        }

        private void StopAnimation()
        {
            ((Storyboard)CircleLoading.Resources["CircleLoad"]).Stop();
        }
        public async Task UpdateDate()
        {
            IEnumerable<Client> clients = await Task.Run(() => EfModel.Init().Clients.ToList());


            List.ItemsSource = clients;
        }

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
            UpdateDate();
        }

        private void Loading_Pages(object sender, RoutedEventArgs e)
        {
            StartLoad();
            StartAnimation();
            StopLoad();
            StopAnimation();
        }
    }
}
