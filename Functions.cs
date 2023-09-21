using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static ModuleApp.Functions;

namespace ModuleApp
{
    internal class Functions
    {
        public Module module;

        public Semester semester;
        public class Module
        {

            // Properties for Module class
            public string Code { get; set; }
            public string Name { get; set; }
            public int Credits { get; set; }
            public int ClassHoursPerWeek { get; set; }
            public List<double> StudyHoursPerDay { get; set; }
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


            }



            public class StudyRecord
            {
                public double Hours { get; set; }
                public DateTime Date { get; set; }
            }


            public class Remaining  {
            

            
            
            
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


        public class Semester // Corrected the class name
        {
            public int numberofModules { get; set; }
            public DateTime time { get; set; }
            public int numberofWeeks { get; set; }


            public List<Semester> semester { get; set; } = new List<Semester>();


            public Semester(DateTime time , int NumberofWeeks) {

              
               this.time = time;
                numberofWeeks =NumberofWeeks;
                semester = new List<Semester>();




            }
            public void AddSemester(DateTime Date, int NumberofWeeks)
            {
                semester.Add(new Semester( time,  NumberofWeeks));
            }

            public Semester()
            {
                semester = new List<Semester>()  ;
            }

        
        }


        public Functions()
        {
            module = new Module(); // Initialize the module instance
            semester = new Semester(); // Initialize the semester instance
        }
    }
}
