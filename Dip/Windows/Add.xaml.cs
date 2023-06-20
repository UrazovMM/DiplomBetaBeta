using Dip.Class;
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
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
       DateTime dateAdd=DateTime.Now;
        public Add()
        {
            InitializeComponent();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {


            Client client = new Client()
            {
                DateCreate = dateAdd,
                NameClient = tbNameClient.Text,
                NameOrganisation = tbNameOrganisation.Text,
                WorkerWorkerId = Auth.autorizeID
            };
            EfModel.Init().Clients.Add(client);
            EfModel.Init().SaveChanges();
            Close();
        }
    }
}
