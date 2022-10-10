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

namespace WpfTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Combo_Status.ItemsSource = System.Enum.GetNames(typeof(ToDo.enumStatus));
            Combo_Status.SelectedIndex = 0;
            ResetFields();

        }

        private void ResetFields()
        {
            cln_DueDate.Text = "";
            //Combo_Status.SelectedIndex = 0;
            Tb_Task.Text = "Task...";
            Slider_difficulty.Value = 2;
            BtnUpdateTask.IsEnabled = false;
            BtnDeleteTask.IsEnabled = false;
            LvToDo.SelectedItem = null;
        }

        private void BtnAddTask_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                DateTime dueDate;
                int difficulty = Convert.ToInt32(Slider_difficulty.Value);
                string status = Combo_Status.Text;
                string task = Tb_Task.Text;

                // validation
                if (cln_DueDate.Text == null || cln_DueDate.Text == "")
                {
                    MessageBox.Show("Due date can not be empty.");
                    return;
                }
                else
                {
                    dueDate = Convert.ToDateTime(cln_DueDate.Text);
                }

                if (status == null || status == "")
                {
                    MessageBox.Show("Status can not be empty.");
                    return;
                }

                if (task == null)
                {
                    MessageBox.Show("Task can not be empty.");
                    return;
                }

                Globals.DbContext.ToDos.Add(new ToDo() { Difficulty = difficulty, DueDate = dueDate, Task = task, Status = status});
                Globals.DbContext.SaveChanges(); // ex
                LvToDo.ItemsSource = Globals.DbContext.ToDos.ToList(); // ex, equivalent of SELECT * FROM todos
                ResetFields();
                LvToDo.SelectedItem = null;
            }
            catch (SystemException ex)
            {
                MessageBox.Show(this, "Unable to access the database:\n" + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnDeleteTask_Click(object sender, RoutedEventArgs e)
        {
            ToDo currSelected = LvToDo.SelectedItem as ToDo;
            if (currSelected == null) return; // nothing selected, nothing to delete
            var result = MessageBox.Show(this, "Are you sure you want to delete this item?", "Confirm deletion", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result != MessageBoxResult.Yes) return;
            try
            {
                Globals.DbContext.ToDos.Remove(currSelected);
                Globals.DbContext.SaveChanges(); // ex
                LvToDo.ItemsSource = Globals.DbContext.ToDos.ToList(); // ex, equivalent of SELECT * FROM todos
                ResetFields();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(this, "Unable to access the database:\n" + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnUpdateTask_Click(object sender, RoutedEventArgs e)
        {
            ToDo currSelected = LvToDo.SelectedItem as ToDo;
            if (currSelected == null) return; // nothing selected, nothing to delete
            try
            {
                DateTime dueDate;
                int difficulty = Convert.ToInt32(Slider_difficulty.Value);
                string status = Combo_Status.Text;
                string task = Tb_Task.Text;

                // validation
                if (cln_DueDate.Text == null || cln_DueDate.Text == "")
                {
                    MessageBox.Show("Due date can not be empty.");
                    return;
                }
                else
                {
                    dueDate = Convert.ToDateTime(cln_DueDate.Text);
                }

                if (status == null || status == "")
                {
                    MessageBox.Show("Status can not be empty.");
                    return;
                }

                if (task == null || task == "")
                {
                    MessageBox.Show("Task can not be empty.");
                    return;
                }

                currSelected.Task = task;
                currSelected.Status = status;
                currSelected.DueDate = dueDate;
                currSelected.Difficulty = difficulty;

                Globals.DbContext.SaveChanges(); // ex
                LvToDo.ItemsSource = Globals.DbContext.ToDos.ToList(); // ex, equivalent of SELECT * FROM todos
                ResetFields();
                LvToDo.SelectedItem = null;
            }
            catch (SystemException ex)
            {
                MessageBox.Show(this, "Unable to access the database:\n" + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LvToDo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ToDo currSelected = LvToDo.SelectedItem as ToDo;
            BtnUpdateTask.IsEnabled = (currSelected != null);
            BtnDeleteTask.IsEnabled = (currSelected != null);
            if (currSelected == null)
            {
                ResetFields();
            }
            else
            {
                cln_DueDate.Text = currSelected.DueDate.ToString();
                Combo_Status.SelectedItem = currSelected.Status;
                Tb_Task.Text = currSelected.Task;
                Slider_difficulty.Value = currSelected.Difficulty;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Globals.DbContext = new SocietyDbContext(); // FIXME: exceptions
                LvToDo.ItemsSource = Globals.DbContext.ToDos.ToList(); // equivalent of SELECT * FROM todos
            }
            catch (SystemException ex)
            {
                MessageBox.Show(this, "Unable to access the database:\n" + ex.Message, "Fatal database error", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(1);
            }
        }

        private void Slider_difficulty_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Lbl_Value.Content = Slider_difficulty.Value.ToString();
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            SaveDataToFile();
        }

        private void SaveDataToFile()
        {
            const string DataFileName = @"..\..\data.txt";
            List<string> lines = new List<string>();
            foreach (ToDo todo in LvToDo.Items)
            {
                lines.Add($"{todo.Difficulty};{todo.Status};{todo.DueDate};{todo.Task}");
            }
            try
            {
                File.WriteAllLines(DataFileName, lines);
            }
            catch (Exception ex) when (ex is IOException || ex is SystemException)
            {
                MessageBox.Show(this, "Error writing to file\n" + ex.Message, "File access error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
