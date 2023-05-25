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

namespace OrvosiNobeldijasokGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void mentes_Click(object sender, RoutedEventArgs e)
        {
            if (evtxt.Text!="" && nevtxt.Text!="" && szhtxt.Text!="" && orszagtxt.Text!="")
            {
                if (int.Parse(evtxt.Text) <= 1989)
                {
                    MessageBox.Show("Az évszám nem megfelelő!", "Mentés");
                    return;
                }
                try
                {
                    StreamWriter sw = new StreamWriter("uj_dijazott.txt", false, Encoding.UTF8);
                    sw.WriteLine("Év;Név;SzületésHalálozás;Országkód");
                    sw.WriteLine($"{evtxt.Text};{nevtxt.Text};{szhtxt.Text};{orszagtxt.Text}");
                    sw.Close();
                    MessageBox.Show("Sikeres mentés!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Hiba az állomány írásánál!");
                }
            }
            else
            {
                MessageBox.Show("Töltsön ki minden mezőt!", "Mentés");
            }
        }
    }
}
