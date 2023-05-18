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

namespace MachKalkulatorGUI
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

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void szamol_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double q = double.Parse(torlotxt.Text);
                double p= double.Parse(statikustxt.Text);
                double m = Math.Sqrt(5 * (Math.Pow(q / p + 1, 2 / 7.0) - 1));
                if (m < 1) { eredmeny.Items.Add($"qc={q} p0={p} Ma={m}"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
