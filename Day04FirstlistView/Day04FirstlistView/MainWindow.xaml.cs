﻿using System;
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

namespace Day04FirstlistView
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

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            // validation
            string name = tbx_name.Text;
            int.TryParse(tbx_age.Text, out int age);
            string str = $"{name} is {age.ToString()} y/o.";
            lvPeople.Items.Add(str);
            // clear the inputs
            tbx_name.Text = "";
            tbx_age.Text = "";
        
        }
    }
}
