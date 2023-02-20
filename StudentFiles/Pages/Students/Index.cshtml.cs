using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentFiles.Data;
using StudentFiles.Models;

namespace StudentFiles.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly StudentFiles.Data.StudentFilesContext _context;

        public IndexModel(StudentFiles.Data.StudentFilesContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        // Add search by name function
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public async Task OnGetAsync()
        {
            var students = from m in _context.Student
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                students = students.Where(s => s.Name.Contains(SearchString));
            }

            Student = await students.ToListAsync();
        }
    }
}
