using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ModuleApp
{
    public partial class RemainingHours : Window
    {
        private Functions functions;
        private RecordStudy recordStudy;
        private SemesterDetails semesterDetails;
        public DateTime DateValue { get; set; }

        public RemainingHours() {


            InitializeComponent();

        }


        public RemainingHours(RecordStudy recordStudy)
        {
            this.recordStudy = recordStudy;
            InitializeComponent();
           functions = new Functions();
            this.semesterDetails = semesterDetails;
            // DateTime startDate = RecordStudy.date;







        }

        private void back(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Collapsed;
            mainWindow.Show();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            // Implement the logic for recording study hours here
        }

        private void display(object sender, RoutedEventArgs e)
        {
            string searchCode = txtCode.Text;

            // Read all lines from the "modules.txt" file
            string filePath = "modules.txt";
            string[] lines = File.ReadAllLines(filePath);

            bool found = false;
            List<string> moduleLines = new List<string>(); // Store module lines here

            // Iterate through the lines and check for the search code
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains($"Module Code: {searchCode}"))
                {
                    found = true;
                    moduleLines.Add(lines[i]); // Add the line containing the module details

                    // Continue reading lines until the separator "==========" is found
                    i++; // Move to the next line
                    while (i < lines.Length && !lines[i].Contains("=========="))
                    {
                        moduleLines.Add(lines[i]); // Add the line
                        i++; // Move to the next line
                    }

                    break; // Exit the loop once the module is found
                }
            }

            // Display a message based on whether the code was found or not
            if (found)
            {
                // Join the module lines into a single string
                string moduleDetails = string.Join("\n", moduleLines);

                // Extract the remaining hours from the module details
                double remainingHours = ExtractRemainingHours(moduleDetails);

                // Display the remaining hours in a message box
                MessageBox.Show($"Remaining Self-Study Hours for Module {searchCode}:\n{remainingHours} hours");
            }
            else
            {
                MessageBox.Show($"Module Code: {searchCode} not found in the modules file.");
            }
        }

        // Helper method to extract remaining hours from module details
        private double ExtractRemainingHours(string moduleDetails)
        {
            // Split the module details by newline character to get individual lines
            string[] lines = moduleDetails.Split('\n');

            // Loop through the lines to find and extract the remaining hours
            foreach (string line in lines)
            {
                if (line.Contains("Required Self Study Hours:"))
                {
                    // Extract the remaining hours value (assuming it's in the format "Required Self Study Hours: {hours}")
                    string[] parts = line.Split(':');
                    if (parts.Length == 2 && double.TryParse(parts[1].Trim(), out double remainingHours))
                    {
                        string code = txtCode.Text;
                        double hours = double.Parse(txtHours.Text);
                        double final = remainingHours - hours;

                        blkDisplay.Text = "Remaining Hours for:\n"+  code  +"is:\n"+ final;

                        return remainingHours;
                    }
                }
            }

            // Return a default value if remaining hours are not found
            return 0.0;

            MessageBox.Show("WHEN DONE ,PLEASE CLICK ON EXIT!");
        
        }






        private void search(object sender, RoutedEventArgs e)
        {
            string filePath = "modules.txt";
            string searchCode = txtCode.Text;

            

         

               


                string[] lines = File.ReadAllLines(filePath);

                bool found = false;

                // Iterate through the lines and check for the search code
                foreach (string line in lines)
                {
                    if (line.Contains($"Module Code: {searchCode}"))
                    {
                        found = true;
                        break;
                    }
                }

                // Display a message based on whether the code was found or not
                if (found)
                {
                    MessageBox.Show($"Module Code: {searchCode} found in the modules.");










                }
                else
                {
                    MessageBox.Show($"Module Code: {searchCode} not found in the modules file.");
                }
            
           

            // Read all lines from the file
         
        }

        private void save(object sender, RoutedEventArgs e)
        {
           
           



        }
    }
    
}
