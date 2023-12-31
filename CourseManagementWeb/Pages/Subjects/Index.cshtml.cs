﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessData.Models;

namespace CourseManagementWeb.Pages.Subjects
{
    public class IndexModel : PageModel
    {
        private readonly BusinessData.Models.CourseManageContext _context;

        public IndexModel(BusinessData.Models.CourseManageContext context)
        {
            _context = context;
        }

        public IList<Subject> Subject { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Subjects != null)
            {
                Subject = await _context.Subjects
                .Include(s => s.Course)
                .Include(s => s.Major).ToListAsync();
            }
        }
    }
}
