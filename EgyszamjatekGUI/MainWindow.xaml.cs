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

namespace EgyszamjatekGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Adatok> list=new List<Adatok>();
        public MainWindow()
        {
            StreamReader sr = new StreamReader("egyszamjatek2.txt");
            while(!sr.EndOfStream)
            {
                Adatok adatok=new Adatok(sr.ReadLine());
                list.Add(adatok);
            }
            sr.Close();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string tipp=tipptxt.Text;
            int nevdb = list.Where(x => x.nev == nevtxt.Text).ToList().Count;
            if (nevdb != 0)
            {
                MessageBox.Show("Van már ilyen nevű játékos!", "Hiba");
            }
            else if (tipp.Length != 4)
            {
                MessageBox.Show("A tippek száma nem megfelelő!", "Hiba");
            }
            else
            {
                StreamWriter sw = new StreamWriter("egyszamjatek2.txt");
                string s = " ";
                s += nevtxt.Text + " ";
                foreach (var item in tipptxt.Text.Trim().Split(' '))
                {
                    s += item + " ";
                    s = s.Trim() + "\n";
                    sw.Write(s);
                    sw.Close();
                    MessageBox.Show("Az állomány bővítése sikeres volt", "Üzenet");
                }
            }
        }
    }
}
