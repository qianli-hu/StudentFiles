using Microsoft.EntityFrameworkCore;
using StudentFiles.Data;

namespace StudentFiles.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new StudentFilesContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<StudentFilesContext>>()))
        {
            if (context == null || context.Student == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.
            if (context.Student.Any())
            {
                return;   // DB has been seeded
            }

            context.Student.AddRange(
                new Student
                {
                    Name = "Harry Potter",
                    ReleaseDate = DateTime.Parse("2023-2-12"),
                    HasAdmissionLetter = true,
                    HasScholarshipLetter = false,
                    GPA = 3.1M,
                    StudentId = "00000123"
                },

                new Student
                {
                    Name = "Harry Cane",
                    ReleaseDate = DateTime.Parse("2023-2-11"),
                    HasAdmissionLetter = false,
                    HasScholarshipLetter = false,
                    GPA = 2.1M,
                    StudentId = "00000101"
                },
                new Student
                {
                    Name = "Hawky Honky",
                    ReleaseDate = DateTime.Parse("2023-2-12"),
                    HasAdmissionLetter = true,
                    HasScholarshipLetter = true,
                    GPA = 3.6M,
                    StudentId = "01230123"
                }



            );
            context.SaveChanges();
        }
    }
}