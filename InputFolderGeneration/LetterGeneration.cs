using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StudentFiles.Data;
using StudentFiles.Models;

namespace inputfoldergeneration
{
    // LetterGeneration class performs the function of generating letters. It finds all letters with admission or scholarship;
    // if letters found, folders will be generated, and the letters then are generated.
    public class LetterGeneration
    {
        private readonly StudentFilesContext _context;
        private readonly string _basePath;

        public LetterGeneration(StudentFilesContext context, string basePath)
        {
            _context = context;
            _basePath = basePath;
        }

        public void LocateStudents(DateTime targetDate, string type)
        {
            List<Student> students;
            // Find students with admission on that date
            if (type == "Admission")
            {
                students = _context.Student.Where(s => s.ReleaseDate.Date == targetDate.Date && s.HasAdmissionLetter).ToList();
            }
            else 
            {
                students = _context.Student.Where(s => s.ReleaseDate.Date == targetDate.Date && s.HasScholarshipLetter).ToList();
            }

            if (students.Count == 0)
            {
                Console.WriteLine($"No {type.ToLower()} student to be found on that date");
            }
            else
            {
                // create scholar dated folder
                string subfolderPath = Path.Combine(_basePath, "Input", type, targetDate.ToString("MMddyyyy"));
                Directory.CreateDirectory(subfolderPath);

                foreach (var student in students)
                {
                    var filePath = Path.Combine(subfolderPath, $"{type}-{student.StudentId}.txt");

                    using (var streamWriter = new StreamWriter(filePath))
                    {
                        streamWriter.WriteLine($"Hello, {student.Name}");
                        streamWriter.WriteLine($"Student ID: {student.StudentId}");
                        streamWriter.WriteLine($"Congratulation on your scholarship! You should receive your {type} letter in mail soon.");
                        streamWriter.WriteLine($"Release Date: {student.ReleaseDate}");
                    }
                }
            }
        }
    }
}