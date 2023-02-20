using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentFiles.Data;
using StudentFiles.Models;

namespace StudentFiles.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly StudentFiles.Data.StudentFilesContext _context;

        public CreateModel(StudentFiles.Data.StudentFilesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Student == null || Student == null)
            {
                return Page();
            }
          // tryout
            if (Student.ReleaseDate == DateTime.MinValue)
            {
                Student.ReleaseDate = DateTime.Today;
            }


            _context.Student.Add(Student);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
