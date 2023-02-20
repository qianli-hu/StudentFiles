# StudentFiles, A student record management system 
**Introduction**  
- This module includes a web application and a console application that interact with a SQL Server Express LocalDB database containing student records. 
The web application provides CRUD operations and a search-by-name method for the existing student data, 
while the console application retrieves student records based on their admission status and generates dated input folders. 
The purpose of this application is to simulate a local pipeline to consider how the design can be improved or enhanced in the future if deployed.  

**Features**  
- A web application that provides CRUD operations for the student records and a search-by-name method.
- A console application that interacts with the database and retrieves student records based on their admission status and generates dated input folders.

**Requirements**
- .NET 7 framework in C#
- Entity Framework Tools
- SQL Server Express LocalDB  

**How to run**
- Download the repository and extract it to your Desktop.
- To set up the database, open the solution named "StudentFiles". In the drop-down toggle, select "StudentFiles".
- In the menu, navigate to Tools -> NuGet Package Manager -> Package Manager Console.
- In the Package Manager Console, type in the command "Add-Migration StudentFilesInitial" (without the quotes) and press enter.
- Then, type in the command "Update-Database" (without the quotes) and press enter.
- The database should now be seeded and ready to be accessed.
- Open the SQL Server Object Explorer, check if a database with keywords "StudentFilesContext" is generated; also, run the app to see if three student records are displayed.
- Next, change the toggle to "InputFolderGeneration". In the debug properties setting, change the working directory to the main master folder: "C:\Users\<userid>\Desktop\StudentFiles-master".
- Run the program.
- Follow the next steps to see if the run is successful.  

**Testing**  
There are two parts of the repository that need to be tested:  
- The web app: 
 - Launch the StudentFiles app to examine if the database has the three records (sometimes the SQL Server Object Explorer can show empty data if right-clicking 
on "dbo.student" to view data, either refresh or close and reopen the SQL Explorer to solve this issue).
 - Check the CRUD functions to see if they work.
- The console app (Since no arg input is provided, the code automatically selects the date to be "02/12/2023" (in MM/dd/yyyy format).): 
 - In the StudentFiles-master folder, check to see if, under the two subfolders, the dated folders are generated. 
 - There should be one letter in the scholarship folder and two in the admission folder.
 - Open the txt file; it should read "Congratulations on your scholarship! You should receive your (type of acceptance) letter in the mail soon." 
