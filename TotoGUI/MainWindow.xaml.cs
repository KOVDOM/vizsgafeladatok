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

namespace TotoGUI
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

        private void beviteltxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void beviteltxt_KeyDown(object sender, KeyEventArgs e)
        {
            string bevitel=beviteltxt.Text;
            if (bevitel.Length!=14)
            {
                nemmeg.IsChecked = true;
            }
            else
            {
                nemmeg.IsChecked=false;
            }
            hosszlbl.Content = $"({bevitel.Length})";

            string hibas = "";
            foreach (var item in bevitel)
            {
                if (item != '1' && item != '2' && item != 'X')
                {
                    hibas += item+";";
                }
            }
            if (hibas.Length>0)
            {
                nemmeg.IsChecked = false;
            }
            else
            {
                nemmeg.IsChecked=true;
            }
            rosszkarlbl.Content = $"({hibas})";
        }
    }
}
