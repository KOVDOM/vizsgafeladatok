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
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace vizsgatesztWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<haromszog> list=new List<haromszog>();
        public MainWindow()
        {
            InitializeComponent();
            StreamReader sr = new StreamReader("haromszogek.csv");
            while(!sr.EndOfStream)
            {
                haromszog haromszogek=new haromszog(sr.ReadLine());
                list.Add(haromszogek);
            }
            sr.Close();
            datagrid.ItemsSource = list;
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void hozzaad_Click(object sender, RoutedEventArgs e)
        {
            var texta=int.Parse(textboxa.Text);
            var textb = int.Parse(textboxb.Text);
            var textc = int.Parse(textboxc.Text);
            if (texta < textb && textb< textc)
            {
                haromszog newHaromszog = new haromszog($"{texta} {textb} {textc}");
                list.Add(newHaromszog);
                datagrid.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Nem megfelelő értékek");
            }
        }

        private void mentes_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sw=new StreamWriter("haromszogek2.txt",false, Encoding.UTF8);
            foreach(var item in list) 
            { 
                sw.WriteLine($"{item.a} {item.b} {item.c}");
            }
            MessageBox.Show("Sikeres mentés!");
            sw.Close();
        }
    }
}
