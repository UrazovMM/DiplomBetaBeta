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

namespace Dip
{
    /// <summary>
    /// Логика взаимодействия для fefw.xaml
    /// </summary>
    public partial class fefw : Page
    {
        public fefw()
        {
            InitializeComponent();
            UPdate();
        }
        public void UPdate()
        {
            List.ItemsSource = EfModel.Init().Clients.Where(p => p.NameClient.Contains(Searchtb222.Text)).ToList();

        }

        private void searchtestnaxui(object sender, TextChangedEventArgs e)
        {
            UPdate();
        }
    }
}
