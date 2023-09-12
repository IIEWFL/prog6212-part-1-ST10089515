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

namespace ModuleApp
{
    /// <summary>
    /// Interaction logic for SemesterDetails.xaml
    /// </summary>
    public partial class SemesterDetails : Window
    {
        public Module module;

        public SemesterDetails()
        {
           module = new Module();   
            InitializeComponent();
        }

        private void back(object sender, RoutedEventArgs e)
        {

            ModuleDetails moduleDetails = new ModuleDetails();  
            this.Visibility = Visibility.Hidden;
            moduleDetails.Show();

        }

        private void save(object sender, RoutedEventArgs e)
        {
            module.numberofWeeks = int.Parse(txtWeeks.Text);

           
            module.date = txtDate.Text;
            var time = DateTime.Parse(module.date);

            string filePath = "modules.txt";

            if (File.Exists(filePath))
            {
                // The file already exists, so open it in append mode
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {

                    writer.WriteLine("SEMESTER DETAILS:");
                    writer.WriteLine("Weeks: " +module.numberofWeeks + ", Date: "+ module.date);
                    writer.WriteLine("====================");
                }
            }
            else
            {
                // The file does not exist, so create a new one
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine($"Weeks:{module.numberofWeeks}, Date: {module.date}");
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
