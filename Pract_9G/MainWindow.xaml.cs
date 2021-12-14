using System;
using System.Collections.Generic;
using System.Data;
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

namespace Pract_9G
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private Baggage[] stuff = new Baggage[10];
        public int Counter;

        private void AddStuff_Click(object sender, RoutedEventArgs e)
        {
            stuff[Counter] = new Baggage(int.Parse(countThings.Text), double.Parse(weidth.Text));
            Counter++;
            dataGrid.ItemsSource = ToDataTable(stuff).DefaultView;
        }

        private void FindStuff_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.ItemsSource != null)
            {
                int enumerable = 0; double avg;
                int stuffCount = 0; double totalAverage;
                double totalWeight = 0;
                for (int i = 0; i < stuff.Length; i++)
                {
                    totalWeight += stuff[i].Weight;
                    stuffCount += stuff[i].numberOfThing;
                }

                totalAverage = totalWeight / stuffCount;

                for (int j = 0; j < stuff.Length; j++)
                {
                    avg = stuff[j].Weight / stuff[j].numberOfThing;

                    if (avg + 0.3 >= totalAverage || avg - 0.3 <= totalAverage)
                    {
                        enumerable = j;
                    }
                }
                MessageBox.Show($"Индекс багажа  {enumerable}");
            }
            else
            {
                MessageBox.Show("Заполните информацию о багаже!");
            }
           
        }

        private static DataTable ToDataTable(Baggage[] stuff)
        {
            var res = new DataTable();

            res.Columns.Add("Кол-во вещей", typeof(int));
            res.Columns.Add("Вес", typeof(int));
           
            for (int i = 0; i < stuff.Length; i++)
            {
                var row = res.NewRow();
                row.ItemArray = new object[] { stuff[i].numberOfThing, stuff[i].Weight};
                res.Rows.Add(row);
            }
            return res;
        }

        private void Information_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Выполнил Дроздов Г. ИСП-34", "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
