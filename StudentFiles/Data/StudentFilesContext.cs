using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentFiles.Models;

namespace StudentFiles.Data
{
    public class StudentFilesContext : DbContext
    {
        public StudentFilesContext (DbContextOptions<StudentFilesContext> options)
            : base(options)
        {
        }

        public DbSet<StudentFiles.Models.Student> Student { get; set; } = default!;
    }
}
