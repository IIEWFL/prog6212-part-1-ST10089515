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

             ModuleCode = txtCode.Text;
             ModuleName = txtName.Text;
            ModuleCredits = int.Parse(txtCredits.Text);
            ModuleClassHours = int.Parse(txtHours.Text);

            // Add the module to the functions.module
            functions.module.AddModule(ModuleName, ModuleCode, ModuleCredits, ModuleClassHours);




              






            string filePath = "modules.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("MODULE DETAILS:");
                writer.WriteLine("Module Code: " + ModuleCode + ", Name: " + ModuleName + ", Credits: " + ModuleCredits + ", Class Hours: " + ModuleClassHours);
               
            }



            // Clear the StudyHoursPerDay list (assuming this is your intention)
            functions.module.StudyHoursPerDay = new List<double>();

        

            MessageBox.Show("Module Added!");

            // Optionally, navigate to the next window
            SemesterDetails details = new SemesterDetails(this);
            this.Visibility = Visibility.Collapsed;
            details.Show();



        }

        private void back(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Collapsed;
            mainWindow.Show();
        }
    }
}
