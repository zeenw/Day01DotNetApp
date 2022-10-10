using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace Day05FirstEF_WPF
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Globals.DbContext = new SocietyDbContext(); // FIXME: exceptions
                LvPeople.ItemsSource = Globals.DbContext.People.ToList(); // equivalent of SELECT * FROM People
            }
            catch (SystemException ex)
            {
                MessageBox.Show(this, "Unable to access the database:\n" + ex.Message, "Fatal database error", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(1);
            }
        }

        private void BtnUpdatePerson_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDeletePerson_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAddPerson_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = tbName.Text; // FIXME! validation
                int.TryParse(tbAge.Text, out int age); // FIXME! validation
                Globals.DbContext.People.Add(new Person() { Name = name, Age = age });
                Globals.DbContext.SaveChanges(); // ex
                LvPeople.ItemsSource = Globals.DbContext.People.ToList(); // ex, equivalent of SELECT * FROM People
            }
            catch (SystemException ex)
            {
                MessageBox.Show(this, "Unable to access the database:\n" + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LvPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
