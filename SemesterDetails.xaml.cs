using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace ModuleApp
{
    /// <summary>
    /// Interaction logic for SemesterDetails.xaml
    /// </summary>
    public partial class SemesterDetails : Window
    {

        private Functions functions;
        private ModuleDetails moduleDetails;

        public SemesterDetails()
        {
            InitializeComponent();
        }

        public SemesterDetails(ModuleDetails moduleDetails)
        {

            this.moduleDetails = moduleDetails;
            functions = new Functions();   
            InitializeComponent();
            string code = moduleDetails.ModuleCode;
            string name = moduleDetails.Name;
            int credits = moduleDetails.ModuleCredits;
            int classHours = moduleDetails.ModuleClassHours;
        }

        private void back(object sender, RoutedEventArgs e)
        {

            ModuleDetails moduleDetails = new ModuleDetails();  
            this.Visibility = Visibility.Hidden;
            moduleDetails.Show();

        }

        private void save(object sender, RoutedEventArgs e)
        {

            int weeks = int.Parse(txtWeeks.Text);
           weeks = functions.semester.numberofWeeks ;


              DateTime dateString = DateTime.Parse(txtDate.Text);

             functions.semester.time = dateString; // Assuming functions.semester.date is a string
                                                           //
                                                           //DateTime time = DateTime.Parse(functions.semester.time); // Assuming functions.semester.time is a DateTime

         

            functions.semester.AddSemester( dateString, weeks);

            double remaining = (moduleDetails.ModuleCredits * 10.0) / weeks - moduleDetails.ModuleClassHours;
            //MessageBox.Show($"Remaining Self-Study Hours: {remaining}");




            string filePath = "modules.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
               // writer.WriteLine("MODULE DETAILS:");
               // writer.WriteLine("Module Code: " + moduleDetails.ModuleCode + ", Name: " + moduleDetails.Name + ", Credits: " + moduleDetails.ModuleCredits + ", Class Hours: " + moduleDetails.ModuleClassHours);
                writer.WriteLine("Required Self Study Hours:" + remaining);
                writer.WriteLine("=====================================================================================================");

            }











            // MessageBox.Show($"Self-Study Hours Per Week: {selfStudyHours}");



            string filePath2 = "semester.txt";

            if (File.Exists(filePath2))
            {
                // The file already exists, so open it in append mode
                using (StreamWriter writer = new StreamWriter(filePath2, true))
                {

                    writer.WriteLine("SEMESTER DETAILS:");
                    writer.WriteLine("Weeks: " +functions.semester.numberofWeeks + ", Date: "+ functions.semester.time);
                   // writer.WriteLine("RemainingHours:" + remaining  );
                    writer.WriteLine("====================");
                }
            }
            else
            {
                // The file does not exist, so create a new one
                using (StreamWriter writer = new StreamWriter(filePath2))
                {
                    writer.WriteLine($"Weeks:{functions.semester.numberofWeeks}, Date: {functions.semester.time}");
                    writer.WriteLine("RemainingHours:" + remaining);
                    writer.WriteLine("====================");
                }
            }
            MessageBox.Show("Weeks and Time Added!");


            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWindow.Show();

        }
    }
}
