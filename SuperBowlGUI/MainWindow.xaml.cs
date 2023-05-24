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

namespace SuperBowlGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
     
    class Atvalto
    {
        public static string RomaitoArab(string romai)
        {
            Dictionary<string, string> helper = new Dictionary<string, string>
            {
                {"I", "1"},
                {"II", "2"},
                {"III", "3"},
                {"IV", "4"},
                {"V", "5"},
                {"VI", "6"},
                {"VII", "7"},
                {"VIII", "8"},
                {"IX", "9"},
                {"X", "10"}
            };
            return helper.ContainsKey(romai.ToUpper()) ? helper[romai.ToUpper()] : "Hiba!";
        }
        public static string ArabtoRomai(string arab)
        {
            Dictionary<string, string> helper = new Dictionary<string, string>
            {
                {"1", "I"},
                {"2", "II"},
                {"3", "III"},
                {"4", "IV"},
                {"5", "V"},
                {"6", "VI"},
                {"7", "VII"},
                {"8", "VIII"},
                {"9", "IX"},
                {"10", "X"}
            };
            return helper.ContainsKey(arab) ? helper[arab] : "Hiba!";
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void nyil_Click(object sender, RoutedEventArgs e)
        {

            arabtxt.Text = "";
            romaitxt.Text = "";
            if (arabtxt.IsEnabled == false)
            {
                arabtxt.IsEnabled = true;
                romaitxt.IsEnabled = false;
                nyil.Content = "<---";
            }
            else
            {
                arabtxt.IsEnabled = false;
                romaitxt.IsEnabled = true;
                nyil.Content = "--->";
            }
        }

        private void atvalt_Click(object sender, RoutedEventArgs e)
        {
            if (romaitxt.IsEnabled)
            {
                arabtxt.Text = Atvalto.RomaitoArab(romaitxt.Text);
            }
            else
            {
                romaitxt.Text = Atvalto.ArabtoRomai(arabtxt.Text);
            }
        }
    }
}
