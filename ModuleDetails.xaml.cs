using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace ModuleApp
{
    public partial class ModuleDetails : Window
    {
        private Functions functions;
        public string ModuleCode { get; private set; }
        public int ModuleCredits { get; private set; }
        public int ModuleClassHours { get; private set; }

        public string ModuleName { get; private set; }  

        public ModuleDetails()
        {
            InitializeComponent();
            functions = new Functions();
        }

        private void next(object sender, RoutedEventArgs e)
        {



            string code = txtCode.Text;
             functions.module.Code= code;
            string name = txtName.Text;
             functions.module.Name = name;
            int credits = int.Parse(txtCredits.Text);
           functions.module.Credits = credits;
            int classHours = int.Parse(txtHours.Text);
           functions.module.ClassHoursPerWeek = classHours;

            // Add the module to the modules list using the AddModule method
            functions.module.AddModule(name, code, credits, classHours);

            ModuleCode = code;
            ModuleName = name;
            ModuleCredits = credits;
            ModuleClassHours = classHours;









            string filePath = "modules.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("MODULE DETAILS:");
                writer.WriteLine("Module Code: " + code + ", Name: " + name + ", Credits: " + credits + ", Class Hours: " + classHours);
               // writer.WriteLine("=====================================================================================================");

            }



            // Clear the StudyHoursPerDay list (assuming this is your intention)
            functions.module.StudyHoursPerDay = new List<double>();

            MessageBox.Show("Module Added!");

            // Optionally, navigate to the next window
            SemesterDetails details = new SemesterDetails(this);
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
