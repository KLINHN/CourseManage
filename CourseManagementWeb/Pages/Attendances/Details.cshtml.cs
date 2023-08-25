using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessData.Models;

namespace CourseManagementWeb.Pages.Attendances
{
    public class DetailsModel : PageModel
    {
        private readonly BusinessData.Models.CourseManageContext _context;

        public DetailsModel(BusinessData.Models.CourseManageContext context)
        {
            _context = context;
        }

      public Attendance Attendance { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Attendances == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendances.FirstOrDefaultAsync(m => m.Id == id);
            if (attendance == null)
            {
                return NotFound();
            }
            else 
            {
                Attendance = attendance;
            }
            return Page();
        }
    }
}
