using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessData.Models;

namespace CourseManagementWeb.Pages.Majors
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
            return Page();
        }

        [BindProperty]
        public Major Major { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Majors == null || Major == null)
            {
                return Page();
            }

            _context.Majors.Add(Major);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
