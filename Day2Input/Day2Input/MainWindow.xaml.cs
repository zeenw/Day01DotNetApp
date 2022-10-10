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

namespace Day2Input
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int age = 1;
        string[] pets = {"cat", "dog", "other"};

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string semicolon = ";";
            string comma = ",";
            string name = txt_name.Text;
            string line = name + semicolon + age + semicolon + pets[0] + comma + pets[1] + comma + pets[2];



            if (name == "")
            {
                MessageBox.Show( this, "Name must not be empty", "Input error", MessageBoxButton.OK, MessageBoxImage.Error );
            }

            MessageBox.Show("Information saved!");
            File.WriteAllText("file.txt", line);
        }


        private void rb1_Checked(object sender, RoutedEventArgs e)
        {
            age = 1;
        }

        private void rb2_Checked(object sender, RoutedEventArgs e)
        {
            age = 2;
        }

        private void rb3_Checked(object sender, RoutedEventArgs e)
        {
            age = 3;
        }

        private void ck1_Checked(object sender, RoutedEventArgs e)
        {
            pets[0] = "cat";
        }


        private void ck2_Checked(object sender, RoutedEventArgs e)
        {
            pets[1] = "dog";

        }

        private void ck3_Checked(object sender, RoutedEventArgs e)
        {
            pets[2] = "other";
        }
    }
}
