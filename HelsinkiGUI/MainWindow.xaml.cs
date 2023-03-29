using System;
using System.Collections.Generic;
using System.IO;
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

namespace HelsinkiGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Adatok> list =new List<Adatok>();
        public MainWindow()
        {
            StreamReader sr = new StreamReader("helsinki.txt");
            while(!sr.EndOfStream)
            {
                Adatok adatok = new Adatok(sr.ReadLine());
                list.Add(adatok);
            }
            InitializeComponent();
            datagrid.ItemsSource = list;
        }

        private void dsq_Click(object sender, RoutedEventArgs e)
        {
            if(datagrid.SelectedItem is null)
            {
                MessageBox.Show("Nincs kiválasztott elem!");
            }
            else
            {
                list.Remove(datagrid.SelectedItem as Adatok);
                datagrid.Items.Refresh();
            }
        }

        private void mentes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter("helsinki2.txt", false, encoding: Encoding.UTF8);
                foreach (var item in list)
                {
                    sw.WriteLine($"{item.helyezes} {item.sporotolok} {item.sportag} {item.sportszam}");
                }
                MessageBox.Show("Sikeres mentés!");
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba!" + ex.Message);
            }
        }
    }
}
