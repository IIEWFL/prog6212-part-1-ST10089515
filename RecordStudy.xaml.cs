using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace ModuleApp
{
    public partial class RecordStudy : Window
    {
        public Module Module;

        public RecordStudy()
        {
            InitializeComponent();
            Module = new Module();
        }

        private void search(object sender, RoutedEventArgs e)
        {



            string filePath = "modules.txt";
            string searchValue = txtCode.Text;
            bool found = false;

            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Read the contents of the file
                string fileContents = File.ReadAllText(filePath);

                // Check if the searchValue exists in the file contents
                if (fileContents.Contains(searchValue))
                {
                    found = true;
                }
            }

            // Display the result
            if (found)
            {
                MessageBox.Show($"The value '{searchValue}' was found in the 'modules.txt' file.");
            }
            else
            {
                MessageBox.Show($"The value '{searchValue}' was not found in the 'modules.txt' file.");
            }

            // Display the result


            //    string searchCode = txtCode.Text;
            //    Module foundModule = FindModuleByCode(searchCode);

            //    if (foundModule != null)
            //    {
            //        double recordedHours = double.Parse(txtHours.Text);
            //        DateTime recordDate = DateTime.Parse(txtDate.Text);

            //        foundModule.StudyRecords.Add(new Module.StudyRecord { Hours = recordedHours, Date = recordDate });

            //        MessageBox.Show($"Recorded {recordedHours} hours for Module Code: {foundModule.Code} on {recordDate}");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Module not found.");
            //    }
            //}

            //public Module FindModuleByCode(string code)
            //{
            //    foreach (Module module in Module.modules)
            //    {
            //        if (module.Code == code)
            //        {
            //            return module;
            //        }
            //    }
            //    return null;
        }

        private void back(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWindow.Show();
        }

        private void save(object sender, RoutedEventArgs e)
        {

            string filePath = "modules.txt";
            string codeToUpdate = txtCode.Text;

            string[] lines = File.ReadAllLines(filePath);

            

            var date = DateTime.Parse(txtDate.Text);

            double hours = double.Parse(txtHours.Text);


            bool moduleFound = false;

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains($"Module Code: {codeToUpdate}"))
                {
                    // Module with the specified code found
                    moduleFound = true;

                    // Insert the new information after the module code
                    List<string> updatedLines = new List<string>(lines);
                    updatedLines.Insert(i + 1, $"Date:{date} ");
                    updatedLines.Insert(i + 2, $"Hours: {hours}");

                    // Write the updated lines back to the file
                    File.WriteAllLines(filePath, updatedLines);

                    MessageBox.Show($"Date and Hours added for Module with Code: {codeToUpdate}");
                    break;
                }
            }

            if (!moduleFound)
            {
                MessageBox.Show($"Module with Code: {codeToUpdate} not found in the file.");
            }





        }
    }
}
