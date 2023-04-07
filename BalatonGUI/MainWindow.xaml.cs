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
using System.Xml.Linq;

namespace BalatonGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Adatok> list=new List<Adatok>();
        static int adoA = 0;
        static int adoB = 0;
        static int adoC = 0;
        public MainWindow()
        {
            StreamReader sr = new StreamReader("utca.txt");
            var elsosor = sr.ReadLine();
            var splitValues = elsosor.Split(' ');
            adoA = int.Parse(splitValues[0]);
            adoB = int.Parse(splitValues[1]);
            adoC = int.Parse(splitValues[2]);
            while (!sr.EndOfStream)
            {
                Adatok adatok = new Adatok(sr.ReadLine());
                list.Add(adatok);
            }
            InitializeComponent();
            datagrid.ItemsSource = list;
            List<string> uniqueList = new List<string>();

            foreach (var item in list)
            {
                uniqueList.Add(item.adosav);

            }
            List<string> comboboxvalues = uniqueList.Distinct().ToList();

            combobox.ItemsSource = comboboxvalues;
        }

        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Ellenőrizzük, hogy van-e kiválasztott elem
            if (datagrid.SelectedItem != null)
            {
                // Elérjük a kiválasztott sorban található oszlop értékét
                var selectedColumnValue = ((Adatok)datagrid.SelectedItem).adosav;

                // Beállítjuk a ComboBox SelectedValue tulajdonságát a kiválasztott oszlop értékére
                combobox.SelectedValue = selectedColumnValue;
            }
        }

        private void modosit_Click(object sender, RoutedEventArgs e)
        {
            if (datagrid.SelectedItem != null)
            {
                // Keresés a kijelölt sor indexét
                int selectedIndex = datagrid.SelectedIndex;

                // Keresés a ComboBox kiválasztott elemét
                string newValue = combobox.SelectedItem.ToString();

                // Az Items tulajdonságból kérjük le az adatsorunkat.
                Adatok selectedRow = (Adatok)datagrid.SelectedItem;

                // Módosítjuk az adatot
                selectedRow.SetTaxchar(newValue);
                datagrid.Items.Refresh();
            }
        }

        private void mentes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter("modositottadatok.txt", false, encoding: Encoding.UTF8);
                foreach (var item in list)
                {
                    sw.WriteLine($"{item.adoszam} {item.utcaneve} {item.hazszam} {item.adosav} {item.alapterulet}");
                }
                sw.Close();
                MessageBox.Show("Sikeres mentés!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba!" + ex.Message);
            }
        }
    }
}
