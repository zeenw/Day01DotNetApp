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

namespace Day2TempConv
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            float f_v = 0;
            float c_v = 0;
            string f_value = tbx_f.Text;
            string c_value = tbx_c.Text;

            // (0°C × 9/5) + 32 = 32°F
            // (32°F − 32) × 5/9 = 0°C

            bool success_f = float.TryParse(f_value, out f_v);
            bool success_c = float.TryParse(c_value, out c_v);
            if (success_f)
            {
                float rs = (f_v - 32) * 5 / 9;
                tbx_c.Text = Math.Round(rs, 2).ToString();
            }
            else if(success_c)
            {
                float rs = (c_v * 9 / 5) + 32;
                tbx_f.Text = Math.Round(rs, 2).ToString();
            }
            else
            {
                MessageBox.Show("Check the value you entered.");
            }


        }
    }
}
