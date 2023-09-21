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

            string Mcode = txtCode.Text;
            string Mname = txtName.Text;
            int Mcredits = int.Parse(txtCredits.Text);
            int MclassHours = int.Parse(txtHours.Text);



            // Add the module to the modules list using the AddModule method
            functions.module.AddModule(Mname, Mcode, Mcredits, MclassHours);

            ModuleCode = Mcode;
            ModuleName = Mname;
            ModuleCredits = Mcredits;
            ModuleClassHours = MclassHours;

            ModuleCode = functions.module.Code;
            ModuleCode = functions.module.Name;
            ModuleCredits = functions.module.Credits;
            ModuleClassHours = functions.module.ClassHoursPerWeek;








            string filePath = "modules.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("MODULE DETAILS:");
                writer.WriteLine("Module Code: " + Mcode + ", Name: " + Mname + ", Credits: " + Mcredits + ", Class Hours: " + MclassHours);
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
