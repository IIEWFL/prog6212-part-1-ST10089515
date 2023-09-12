using System;
using System.IO;
using System.Windows;

namespace ModuleApp
{
    public partial class DisplayModule : Window
    {
        public Module Module;

        public DisplayModule()
        {
            InitializeComponent();
            Module = new Module();
        }

        private void display(object sender, RoutedEventArgs e)
        {



            string filePath = "modules.txt";

            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Read the contents of the file
                string fileContents = File.ReadAllText(filePath);

                // Set the file contents as the text of the TextBlock
                blkDisplay.Text = fileContents;
            }
            else
            {
                // If the file does not exist, display a message
                blkDisplay.Text = "The 'modules.txt' file does not exist.";
            }

            //MessageBox.Show("Display button clicked!");
            //// Clear the existing text
            //blkDisplay.Text = "";

            //foreach (Module module in Module.modules)
            //{
            //    double selfStudyHours = module.SelfStudyHoursPerWeek(module.numberofWeeks);
            //    blkDisplay.Text += $"Module Code: {module.Code}, Self-Study Hours: {selfStudyHours}\n";
            //}
        }

        private void back(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Collapsed;
            mainWindow.Show();
        }
    }
}
