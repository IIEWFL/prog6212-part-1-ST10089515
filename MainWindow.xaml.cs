using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace ModuleApp
{
    public class Module
    {
        // Properties for Module class
        public string Code { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public int ClassHoursPerWeek { get; set; }
        public List<double> StudyHoursPerDay { get; set; }
        public int numberofModules { get; set; }
        public string date { get; set; }
        public int numberofWeeks { get; set; }
        public List<StudyRecord> StudyRecords { get; set; }


        public DateTime startDate = DateTime.MinValue;



        // List to store multiple modules
        public List<Module> modules { get; set; } = new List<Module>();

        // Constructor to initialize properties
        public Module(string name, string code, int credits, int classHours)
        {
            Name = name;
            Code = code;
            Credits = credits;
            ClassHoursPerWeek = classHours;
            this.StudyHoursPerDay = StudyHoursPerDay;

            modules = new List<Module>();



            //date = startDate.ToString("yyyy-MM-dd"); // Convert DateTime to string in the desired format

        }
        public void AddModule(string name, string code, int credits, int classHours)
        {
            modules.Add(new Module(name, code, credits, classHours));
        }

        public double SelfStudyHoursPerWeek(int numberOfWeeks)
        {
            return (Credits * 10.0) / numberOfWeeks - ClassHoursPerWeek; // Fix the calculation
        }

        public double RemainingSelfStudyHours(int currentWeek)
        {
            if (currentWeek <= StudyHoursPerDay.Count)
            {
                double totalStudyHours = 0;
                for (int i = 0; i < currentWeek; i++)
                {
                    totalStudyHours += StudyHoursPerDay[i];
                }
                return SelfStudyHoursPerWeek(StudyHoursPerDay.Count) - totalStudyHours;
            }
            return 0;
        }

        // Method to add modules to the list
      


        public Module()
        {
            modules = new List<Module>(); // Initialize the list of modules
            StudyRecords = new List<StudyRecord>();
        }

        public class StudyRecord
        {
            public double Hours { get; set; }
            public DateTime Date { get; set; }
        }
        public void SaveModulesToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Module module in modules)
                {
                    writer.WriteLine($"Module Code: {module.Code}, Name: {module.Name}, Credits: {module.Credits}");
                }
            }
        }

        public void PrintModules()
        {
            // Initialize a string to store the module information
            string moduleInfo = "Module List:\n\n";

            foreach (Module module in modules)
            {
                // Append module information to the string
                moduleInfo += $"Module Code: {module.Code}, Name: {module.Name}, Credits: {module.Credits}\n";
                // You can add more properties here as needed
            }

            // Display the module information in a message box
            MessageBox.Show(moduleInfo, "Module List", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }

    public partial class MainWindow : Window
    {
        public Module module ; // Initialize the module instance

        public MainWindow()
        {
            InitializeComponent();
            // Example usage: Initialize the module instance with sample values
            module = new Module();
        }

        private void enter(object sender, RoutedEventArgs e)
        {


            ModuleDetails moduleDetails = new ModuleDetails();
            moduleDetails.module = this.module; // Pass the existing module instance
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
            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWindow.Close();
        }

        private void print(object sender, RoutedEventArgs e)
        {
            module.PrintModules();

        }
    }
}
