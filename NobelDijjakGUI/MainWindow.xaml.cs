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

namespace NobelDijjakGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Adatok> list=new List<Adatok>();
        public MainWindow()
        {
            StreamReader sr = new StreamReader("orvosi_nobeldijak.txt");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                Adatok adatok = new Adatok(sr.ReadLine());
                list.Add(adatok);
            }
            sr.Close();
            InitializeComponent();
        }

        private void mentes_Click(object sender, RoutedEventArgs e)
        {
            var evasdf = int.Parse(ev.Text);
            if (ev.Text=="" || nev.Text == "" || szh.Text == "" || orszag.Text == "")
            {
                MessageBox.Show("Töltsön ki minden mezőt!");
            }
            else if(evasdf<=1989)
            {
                MessageBox.Show("Hiba! Az évszám nem megfelelő!");
            }
            else
            {
                try
                {
                    string irando = "";
                    StreamWriter sw = new StreamWriter("uj_dijazott.txt", false, Encoding.UTF8);
                    sw.WriteLine("Év;Név;SzületésHalálozás;Országkód");
                    foreach (var item in list)
                    {
                        irando=$"{evasdf};{nev.Text};{szh.Text};{orszag.Text}";
                    }
                    sw.WriteLine(irando);
                    sw.Close();
                    MessageBox.Show("Mentés sikeres!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
