using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Packaging;
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

namespace Day04ListGridViewPeople
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string PATH = @"..\..\people.txt";
        List<Person> persons = new List<Person>();

        public MainWindow()
        {
            InitializeComponent();
            lvPeople.ItemsSource = persons;
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {

            string name = tbx_name.Text;
            if (!int.TryParse(tbx_age.Text, out int age))
            {
                MessageBox.Show("Age balabala");
                return;
            }

            Person p = new Person();

            if (!p.IsNameValid(name))
            {
                MessageBox.Show("Name balabala");
            }
            else if (!p.IsAgeValid(age))
            {
                MessageBox.Show("age balabala");
            } else
            {
                Person person = new Person(name, age);
                persons.Add(person);
            }

            lvPeople.Items.Refresh();
            ResetFields();
        }

        private void btn_del_Click(object sender, RoutedEventArgs e)
        {
            if (System.Windows.MessageBox.Show("Are you sure?", "Confirm", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                Person person = lvPeople.SelectedValue as Person;
                persons.Remove(person);
                lvPeople.Items.Refresh();
                btn_update.IsEnabled = false;
                btn_del.IsEnabled = false;
            }


        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            Person selectedPerson = lvPeople.SelectedItem as Person;

            string name = tbx_name.Text;
            if (!int.TryParse(tbx_age.Text, out int age))
            {
                MessageBox.Show("Age balabala");
                return;
            }

            Person p = new Person();

            if (!p.IsNameValid(name))
            {
                MessageBox.Show("Name balabala");
            }
            else if (!p.IsAgeValid(age))
            {
                MessageBox.Show("age balabala");
            }
            else
            {
                selectedPerson.Name = name;
                selectedPerson.Age = age;

            }

            lvPeople.Items.Refresh();
            ResetFields();
        }

        private void ResetFields()
        {
            tbx_age.Text = "";
            tbx_name.Text = "";
        }

        private void lvPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btn_update.IsEnabled = true;
            btn_del.IsEnabled = true;
            Person selectedPerson = lvPeople.SelectedItem as Person;
            //Person slced = lvPeople.SelectedValue as Person;

            if (selectedPerson == null)
            {
                ResetFields();
            }
            else
            {
                tbx_age.Text = selectedPerson.Age.ToString();
                tbx_name.Text = selectedPerson.Name;
            }

        }

        private void DataWindow_Closing(object sender, CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Quit?", "Asking", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                saveFile();
                e.Cancel = false;
            }

            if (result == MessageBoxResult.No)
                e.Cancel = true;
        }

        private void saveFile()
        {
            try
            {
                //if (!File.Exists(PATH)) return;
                using StreamWriter file = new(PATH);

                foreach (Person p in persons)
                {
                    file.WriteLine(p.ToString("save"));
                }
            }
            catch (Exception ex) when (ex is IOException || ex is SystemException)
            {
                Console.WriteLine(
                    "{0}: The write operation could not " +
                    "be performed because the specified " +
                    "part of the file is locked.",
                    ex.GetType().Name);
            }

        }

        private void LoadDataFromFile()
        {
            List<string> errs = new List<string>;
            try
            {
                if (!File.Exists(PATH)) return;
                string[] linesArray = File.ReadAllLines(PATH);

                foreach (string line in linesArray)
                {
                    var data = line.Split(";");
                    if(data.Length != 2)
                    {
                        errs.Add("error!");
                        continue;
                    }
                }
            }
            catch (Exception ex) when (ex is IOException || ex is SystemException)
            {
                Console.WriteLine(
                    "{0}: The write operation could not " +
                    "be performed because the specified " +
                    "part of the file is locked.",
                    ex.GetType().Name);
            }
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            saveFile();
        }
    }
}
