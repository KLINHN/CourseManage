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
    public class IndexModel : PageModel
    {
        private readonly BusinessData.Models.CourseManageContext _context;

        public IndexModel(BusinessData.Models.CourseManageContext context)
        {
            _context = context;
        }

        public IList<Attendance> Attendance { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Attendances != null)
            {
                Attendance = await _context.Attendances.ToListAsync();
            }
        }
    }
}
