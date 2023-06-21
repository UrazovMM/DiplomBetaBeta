using Microsoft.EntityFrameworkCore;
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
            Cb_worker.ItemsSource = EfModel.Init().Workers.ToList();
            UpdateNote();


           
        }
        public void UpdateNote()
        {
            LvNOte.ItemsSource = EfModel.Init().Notes.Where(p => p.ClientClientId == client.ClientId).ToList();
        }
        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            Note note = new Note()
            {
                Notes = tbNote.Text,
                ClientClientId = client.ClientId,
            };
            if (note.IdNote == 0)
            {
                EfModel.Init().Add(note);
                EfModel.Init().SaveChanges();
                UpdateNote();
            }
        }

        private void SelectionNote(object sender, SelectionChangedEventArgs e)
        {
            if (LvNOte.SelectedItems != null)
            {

                string Note = LvNOte.SelectedItem.ToString();
                tbNote.Text = Note;
            }

        }

        private void BtSaveClient_Click(object sender, RoutedEventArgs e)
        {
            
            EfModel.Init().SaveChanges();
        }
    }
}
