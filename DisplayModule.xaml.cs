using System;
using System.IO;
using System.Windows;

namespace ModuleApp
{
    public partial class DisplayModule : Window
    {
        private Functions functions;

        public DisplayModule()
        {
            InitializeComponent();
            functions = new Functions();
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
                blkDisplay.Text = "The file does not exist.";
            }

          
        }

        private void back(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Collapsed;
            mainWindow.Show();
        }
    }
}
