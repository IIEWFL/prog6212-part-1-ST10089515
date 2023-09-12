using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace ModuleApp
{
    public partial class ModuleDetails : Window
    {
        public Module module;

        public ModuleDetails()
        {
            InitializeComponent();
            module = new Module();
        }

        private void next(object sender, RoutedEventArgs e)
        {



            string code = txtCode.Text;
            string name = txtName.Text;
            int credits = int.Parse(txtCredits.Text);
            int classHours = int.Parse(txtHours.Text);

            // Add the module to the modules list using the AddModule method
            module.AddModule(name, code, credits, classHours);
            string filePath = "modules.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("MODULE DETAILS:");
                writer.WriteLine("Module Code: " + code + ", Name: " + name + ", Credits: " + credits + ", Class Hours: " + classHours);

            }



            // Clear the StudyHoursPerDay list (assuming this is your intention)
            module.StudyHoursPerDay = new List<double>();

            MessageBox.Show("Module Added!");

            // Optionally, navigate to the next window
            SemesterDetails details = new SemesterDetails();
            this.Visibility = Visibility.Hidden;
            details.Show();



        }

        private void back(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWindow.Show();
        }
    }
}
