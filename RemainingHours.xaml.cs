using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ModuleApp
{
    public partial class RemainingHours : Window
    {
        public Module Module;

        public RemainingHours()
        {
            InitializeComponent();
            Module = new Module();
        }

        private void back(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            // Implement the logic for recording study hours here
        }

        private void display(object sender, RoutedEventArgs e)
        {    // Calculate and display remaining self-study hours for each module

            DateTime today = DateTime.Today;
            DateTime startOfWeek = today.AddDays(-(int)today.DayOfWeek);

            // Clear the TextBlock before displaying new information
            blkDisplay.Text = "";

            // Loop through each module
            foreach (Module module in Module.modules)
            {
                double recordedHoursThisWeek = 0.0;

                // Calculate total recorded hours for the current week
                foreach (Module.StudyRecord record in module.StudyRecords)
                {
                    if (record.Date >= startOfWeek)
                    {
                        recordedHoursThisWeek += record.Hours;
                    }
                }

                // Calculate remaining self-study hours for the current week
                double remainingHoursThisWeek = (module.Credits * 10.0) - recordedHoursThisWeek;

                // Display information in the TextBlock
                blkDisplay.Text += $"Module Code: {module.Code}, Name: {module.Name}, Remaining self-study hours this week: {remainingHoursThisWeek}\n";
            }
        } 
    }
    
}
