using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StudentFiles.Data;
using StudentFiles.Models;

namespace inputfoldergeneration
{
    class Program
    {
        static void Main(string[] args)
        {

            string date;

            // For testing:
            if (args.Length == 0)
            {
                // If no arguments are provided, assume today's date
                DateTime today = DateTime.Today;
                date = today.ToString("MMddyyyy");
            }
            else if (args[0] == "test")
            {
                // If the first argument is "test", set the target date string to "02122023"
                date = "02122023";
            }
            else
            {
                // If an argument is provided but it's not "test", assume it's a date in the "MMddyyyy" format
                date = args[0];
            }

            Console.WriteLine(date);
            DateTime targetDate = DateTime.ParseExact(date, "MMddyyyy", CultureInfo.InvariantCulture);

            string basePath = Directory.GetCurrentDirectory();

            Console.WriteLine("current directory is " + Directory.GetCurrentDirectory());

            var config = new ConfigurationBuilder()
                            .SetBasePath(basePath)
                            .AddJsonFile("StudentFiles/appsettings.json", optional: false, reloadOnChange: true)
                            .Build();

            var connectionString = config.GetConnectionString("StudentFilesContext");

            Console.WriteLine($"Connection string: {connectionString}");

            var optionsBuilder = new DbContextOptionsBuilder<StudentFilesContext>();
            optionsBuilder.UseSqlServer(connectionString);

            using (var context = new StudentFilesContext(optionsBuilder.Options))
            {
                var lettergeneration = new LetterGeneration(context, basePath);
                lettergeneration.LocateStudents(targetDate, "Admission");
                lettergeneration.LocateStudents(targetDate, "Scholarship");
            }

        }

    }
}


