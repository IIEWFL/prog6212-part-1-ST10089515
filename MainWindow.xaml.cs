using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace ModuleApp
{
    

    public partial class MainWindow : Window
    {
         // Initialize the module instance

        public MainWindow()
        {
            InitializeComponent();
            // Example usage: Initialize the module instance with sample values
           
        }

        private void enter(object sender, RoutedEventArgs e)
        {


            ModuleDetails moduleDetails = new ModuleDetails();
           // moduleDetails.module = this.module; // Pass the existing module instance
            this.Visibility = Visibility.Hidden;
            moduleDetails.Show();
            // module.numberofModules = int.Parse(txtNumber.Text);

            //ModuleDetails moduleDetails = new ModuleDetails(); // Pass the existing module instance
            //this.Visibility = Visibility.Hidden;
            //moduleDetails.Show();

            // Move the check here, after showing the ModuleDetails window
            // if (module.modules.Count == module.numberofModules)
            //{
            // SemesterDetails details = new SemesterDetails(); // Pass the existing module instance
            //this.Visibility = Visibility.Hidden;
            //details.Show();
            //}
        }

        private void enterModule(object sender, RoutedEventArgs e)
        {
            ModuleDetails module = new ModuleDetails();
            this.Visibility = Visibility.Hidden;
            module.Show();
        }



        private void dur(object sender, RoutedEventArgs e)
        {
            SemesterDetails semesterDetails = new SemesterDetails();
            this.Visibility = Visibility.Hidden;    
            semesterDetails.Show();
            MessageBox.Show("NB!,ENTER DATE IN FORMAT YYYY-MM-DD!");
        }

        private void date(object sender, RoutedEventArgs e)
        {

        }

        private void display(object sender, RoutedEventArgs e)
        {
            DisplayModule display  = new DisplayModule();
            this.Visibility = Visibility.Hidden;
            display.Show(); 

        }

        private void study(object sender, RoutedEventArgs e)
        {
            RecordStudy recordStudy = new RecordStudy();
            this.Visibility = Visibility.Hidden;
            recordStudy.Show();

        }

        private void remaining(object sender, RoutedEventArgs e)
        {


            RemainingHours remainingHours = new RemainingHours();   
            this.Visibility = Visibility.Hidden;    
            remainingHours.Show();
        }

        private void exit(object sender, RoutedEventArgs e)
        {
            // Delete the "modules.txt" file
            string modulesFilePath = "modules.txt";
            if (File.Exists(modulesFilePath))
            {
                File.Delete(modulesFilePath);
            }

            // Delete the "semester.txt" file
            string semesterFilePath = "semester.txt";
            if (File.Exists(semesterFilePath))
            {
                File.Delete(semesterFilePath);
            }

            // Optionally, show a message to indicate that the files have been deleted
            MessageBox.Show("Files have been deleted.");
            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWindow.Close();
        }

        private void print(object sender, RoutedEventArgs e)
        {
           // module.PrintModules();

        }

        private void clear(object sender, RoutedEventArgs e)
        {
           

        }

        private void enterSemester(object sender, RoutedEventArgs e)
        {
            SemesterDetails details = new SemesterDetails();
            this.Visibility = Visibility.Hidden;
            details.Show();
        }
    }
}
