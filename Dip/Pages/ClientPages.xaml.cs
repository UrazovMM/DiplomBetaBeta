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
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using System.IO;

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
            IEnumerable<Client> Clients = EfModel.Init().Clients.Include(p => p.WorkerWorker).Where(p => p.NameClient.Contains(Searchtb222.Text)).ToList();
            List.ItemsSource = Clients;

            StopAnimation();


            dgw.ItemsSource = EfModel.Init().Clients.Include(p => p.WorkerWorker).Where(p => p.NameClient.Contains(Searchtb222.Text)).ToList();
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

        private void copyAlltoClipboard()
        {
            dgw.SelectAll();
            Clipboard.SetDataObject(dgw);
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occurred while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        private void btExport_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Documents (*.xls)|*.xlsx";
            saveFileDialog.FileName = ".xls";
            if (saveFileDialog.ShowDialog() == true)
            {
                copyAlltoClipboard();

                object misValue = System.Reflection.Missing.Value;
                Excel.Application ExcelFile = new Excel.Application();

                ExcelFile.DisplayAlerts=true;
                Excel.Workbook workBook = ExcelFile.Workbooks.Add(misValue);
                Excel.Worksheet workSheet = (Excel.Worksheet)workBook.Worksheets.GetEnumerator();

                Excel.Range PasteFromBuffer=(Excel.Range) workSheet.Cells[1,1];
                PasteFromBuffer.Select();
                workSheet.PasteSpecial(PasteFromBuffer, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                workBook.SaveAs(saveFileDialog.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, 
                    misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

                ExcelFile.DisplayAlerts = true;
                workBook.Close(true, misValue, misValue);
                ExcelFile.Quit();

                releaseObject(workBook);
                releaseObject(workSheet);
                releaseObject(ExcelFile);

                Clipboard.Clear();
              
               if(File.Exists(saveFileDialog.FileName))
                    System.Diagnostics.Process.Start(saveFileDialog.FileName);
            }
        }
    }
}

