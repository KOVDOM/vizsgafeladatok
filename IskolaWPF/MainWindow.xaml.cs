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

namespace IskolaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Tanulok> list=new List<Tanulok>();
        public MainWindow()
        {
            StreamReader sr=new StreamReader("nevek.txt", Encoding.UTF8);
            while(!sr.EndOfStream)
            {
                Tanulok tanulok = new Tanulok(sr.ReadLine());
                list.Add(tanulok);
            }
            sr.Close();
            InitializeComponent();
            datagrid.ItemsSource = list;
        }

        private void torles_Click(object sender, RoutedEventArgs e)
        {
            if (datagrid.SelectedItem is null)
            {
                MessageBox.Show("Nincs kiválasztott elem!");
            }
            else
            {
                list.Remove(datagrid.SelectedItem as Tanulok);
                datagrid.Items.Refresh();
            }
        }

        private void mentes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            StreamWriter sw = new StreamWriter("nevek2.txt", false, encoding: Encoding.UTF8);
            foreach (var item in list)
            {
                sw.WriteLine($"{item.kezdEv} {item.osztaly} {item.nev}");
            }
            sw.Close();
            MessageBox.Show("Sikres Mentés!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba az állomány mentésénél!" + ex.Message);
            }
        }
    }
}
