﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessData.Models;

namespace CourseManagementWeb.Pages.Calender
{
    public class IndexModel : PageModel
    {
        private readonly BusinessData.Models.CourseManageContext _context;

        public IndexModel(BusinessData.Models.CourseManageContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Students != null)
            {
                Student = await _context.Students
                .Include(s => s.Attendance)
                .Include(s => s.Major).ToListAsync();
            }
        }
    }
}
