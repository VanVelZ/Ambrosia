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
using Ambrosia.BL;
using Ambrosia.BL.Models;

namespace Ambrosia.Admin.WPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        log4net.ILog logger = log4net.LogManager.GetLogger("Utility.Logger");
        List<WorkoutType> workouts;
        WorkoutType workout;

        public MainWindow()
        {
            InitializeComponent();
            workout = new WorkoutType();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
           if (logger.IsWarnEnabled) logger.Warn(txtWorkoutName.Text);

            workout.Name = txtWorkoutName.Text;
            workout.CaloriesPerMinute = Int32.Parse(txtWorkoutCalories.Text);
            int result = WorkoutTypeManager.Insert(workout);
            Reload();
            if(result == 1)
                MessageBox.Show("Success!");
            else
                MessageBox.Show("Failure");
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (logger.IsWarnEnabled) logger.Warn(txtWorkoutName.Text);
            int result = 0;
            workout = (WorkoutType)dgWorkouts.SelectedItem;
            if(workout!= null)
            {
                workout.Name = txtWorkoutName.Text;
                workout.CaloriesPerMinute = Int32.Parse(txtWorkoutCalories.Text);
                result = WorkoutTypeManager.Update(workout);
            }
            Reload();
            if (result == 1)
                MessageBox.Show("Success!");
            else
                MessageBox.Show("Failure");
        }

        private void Reload()
        {
            workouts = WorkoutTypeManager.Load();
            dgWorkouts.ItemsSource = null;
            dgWorkouts.ItemsSource = workouts;

            dgWorkouts.Columns[0].Visibility = Visibility.Hidden;
            dgWorkouts.Columns[2].Header = "Calories Per Minute";
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (logger.IsWarnEnabled) logger.Warn(txtWorkoutName.Text);

            int result = 0;
            workout = (WorkoutType)dgWorkouts.SelectedItem;
            if(workout != null)
            {
                result = WorkoutTypeManager.Delete(workout);
            }
            Reload();
            if (result == 1)
                MessageBox.Show("Success!");
            else
                MessageBox.Show("Failure");
        }

        private void dgWorkouts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (logger.IsWarnEnabled) logger.Warn(txtWorkoutName.Text);


            if (dgWorkouts.SelectedItem != null)
            {
                workout = (WorkoutType)dgWorkouts.SelectedItem;
                txtWorkoutName.Text = workout.Name;
                txtWorkoutCalories.Text = workout.CaloriesPerMinute.ToString();
            }

        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            Reload();
        }
    }
}
