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

namespace BukkMaraton2019GUI
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

        private void szamol_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ComboBoxItem cbi = (ComboBoxItem)tavcb.SelectedItem;
                int tavKm = int.Parse((string)cbi.Tag);
                string[] m = idotxt.Text.Split(':');
                int ora = int.Parse(m[0]);
                int perc = int.Parse(m[1]);
                int mp = int.Parse(m[2]);
                TimeSpan ido = new TimeSpan(ora, perc, mp);
                atlagkm.Content = $"Átlagsebesség [km/h]: {tavKm / ido.TotalHours:F2}";
                atlagm.Content = $"Átlagsebesség [m/s]: {1000 * tavKm / ido.TotalSeconds:F2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
