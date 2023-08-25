using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessData.Models;

namespace CourseManagementWeb.Pages.Semesters
{
    public class CreateModel : PageModel
    {
        private readonly BusinessData.Models.CourseManageContext _context;

        public CreateModel(BusinessData.Models.CourseManageContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Semester Semester { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Semesters == null || Semester == null)
            {
                return Page();
            }

            _context.Semesters.Add(Semester);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
