# ModuleApp Readme

ModuleApp is a software application that helps you manage academic modules, record study hours, and calculate remaining self-study hours during a semester. This readme provides instructions on how to compile and run the software, as well as details related to the database.

## System Requirements

Before compiling and running ModuleApp, ensure that your system meets the following requirements:

- Operating System: Windows 7 or later
- .NET Framework 4.7.2 or later

## Compilation and Running Instructions

Follow these steps to compile and run ModuleApp:

1. **Clone or Download the Repository**:
   - Clone this GitHub repository to your local machine or download it as a ZIP file and extract it to a folder of your choice.

2. **Open the Project**:
   - Open the Visual Studio IDE (Integrated Development Environment).

3. **Load the Project**:
   - Go to File > Open > Project/Solution.
   - Navigate to the folder where you extracted the repository and select the "ModuleApp.sln" solution file.
   
4. **Build the Project**:
   - Once the project is loaded, go to Build > Build Solution to compile the code. Visual Studio will resolve dependencies and compile the application.

5. **Database Configuration**:
   - ModuleApp uses a file-based database to store module and semester information. The default database file is named "modules.txt" for modules and "semester.txt" for semester details.
   - Ensure that these files exist in the same directory as the compiled application. You can manually create these files with appropriate initial content.

6. **Run the Application**:
   - After successful compilation, press F5 or go to Debug > Start Debugging to run the application.
   
7. **Usage**:
   - Follow the on-screen instructions in the application's user interface to manage modules, record study hours, calculate remaining study hours, and perform other tasks.

## Database Instructions

ModuleApp uses plain text files as its database. Here's how to work with the database files:

- **modules.txt**: This file stores module information.
  - Each module entry is stored as a line in the following format:
    ```
    Module Code: <Code>, Name: <Name>, Credits: <Credits>
    ```
  - You can manually add, edit, or delete module entries in this file. Each module entry should be on a separate line.

- **semester.txt**: This file stores semester details.
  - Each semester entry is stored as a block of lines, including weeks and date information.
    ```
    SEMESTER DETAILS:
    Weeks: <Weeks>, Date: <Date>
    RemainingHours: <RemainingHours>
    ====================
    ```
  - You can manually add, edit, or delete semester entries in this file. Each semester entry should be separated by a line of equal signs (===================).

## Troubleshooting

If you encounter any issues while compiling or running ModuleApp, please refer to the troubleshooting section in the user manual or contact our support team for assistance.

Thank you for using ModuleApp! We hope this readme helps you compile, run, and effectively use the software to manage your academic modules and study hours.

## 
Reference:
Amazon, n.d. What is an Event-Driven Architecture?. [Online] .Available at: https://aws.amazon.com/event-driven-architecture/#:~:text=An%20event%2Ddriven%20architecture%20uses,on%20an%20e%2Dcommerce%20website. [Accessed 2 September 2023].
cassandrad, 2017 . Data Driven vs Event Driven model/architecture?. [Online]. Available at: https://stackoverflow.com/questions/42174856/data-driven-vs-event-driven-model-architecture .[Accessed 1 September 2023].
Fonzi, B., 2023. Choosing between Data and Event-Driven Architecture. [Online]. Available at: https://www.linkedin.com/pulse/choosing-between-data-event-driven-architecture-bruno-fonzi/ .[Accessed 3 September 2023].
Sommerville, I., 2016. Software Engineering. 10th ed. Boston: Pearson Education.
Vaughan, J., n.d. data. [Online]. Available at: https://www.techtarget.com/searchdatamanagement/definition/data#:~:text=In%20computing%2C%20data%20is%20information,subject%20or%20a%20plural%20subject. [Accessed 2 September 2023].

Microsoft. (2022). Azure Virtual Machines documentation. Microsoft Azure. https://docs.microsoft.com/en-us/azure/virtual-machines/ [Accessed 2 September 2023].

 Smith, J. (2021). Best Practices for Azure Blob Storage. Microsoft Azure. https://azure.microsoft.com/en-us/resources/whitepapers/ [Accessed 25 August 2023].




