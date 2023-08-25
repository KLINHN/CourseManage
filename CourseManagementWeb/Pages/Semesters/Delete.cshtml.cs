using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessData.Models;

namespace CourseManagementWeb.Pages.Semesters
{
    public class DeleteModel : PageModel
    {
        private readonly BusinessData.Models.CourseManageContext _context;

        public DeleteModel(BusinessData.Models.CourseManageContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Semester Semester { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Semesters == null)
            {
                return NotFound();
            }

            var semester = await _context.Semesters.FirstOrDefaultAsync(m => m.Id == id);

            if (semester == null)
            {
                return NotFound();
            }
            else 
            {
                Semester = semester;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Semesters == null)
            {
                return NotFound();
            }
            var semester = await _context.Semesters.FindAsync(id);

            if (semester != null)
            {
                Semester = semester;
                _context.Semesters.Remove(Semester);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
