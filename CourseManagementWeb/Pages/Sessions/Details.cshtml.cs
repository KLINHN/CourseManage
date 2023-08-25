using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessData.Models;

namespace CourseManagementWeb.Pages.Sessions
{
    public class DetailsModel : PageModel
    {
        private readonly BusinessData.Models.CourseManageContext _context;

        public DetailsModel(BusinessData.Models.CourseManageContext context)
        {
            _context = context;
        }

      public Session Session { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sessions == null)
            {
                return NotFound();
            }

            var session = await _context.Sessions.FirstOrDefaultAsync(m => m.Id == id);
            if (session == null)
            {
                return NotFound();
            }
            else 
            {
                Session = session;
            }
            return Page();
        }
    }
}
