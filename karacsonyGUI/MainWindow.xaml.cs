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

namespace karacsonyGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 1; i <= 40; i++)
            {
                napszam.Items.Add(i);
            }
            napszam.SelectedIndex = 0;
        }

        private void hozzaad_Click(object sender, RoutedEventArgs e)
        {
            int eladott = int.Parse(eladotttxt.Text);
            int elkeszitett=int.Parse(elkeszitetttxt.Text);
            string hiba = "";
            int eredmeny = elkeszitett - eladott;
            if (eladott > elkeszitett)
            {
                hiba = "Túl sok az eladott angyalka!";
            }
            else if(eladott<0 || elkeszitett<0)
            {
                hiba = "Negatív számot nem adhat meg!";
            }
            else
            {
                richtextbox.Document.Blocks.Add(new Paragraph(new Run($"{napszam.SelectedIndex}.nap: +{elkeszitett} -{eladott} = {eredmeny}")));
                eladott = 0;
                eladott = 0;
                napszam.SelectedIndex = napszam.SelectedIndex+1;
            }
            hibauzitxt.Content = hiba;
        }
    }
}
