using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessData.Models;

namespace CourseManagementWeb.Pages.Celendar
{
    public class IndexModel : PageModel
    {
        public List<List<DateTime?>> Calendar { get; set; } = null!;

        public void OnGet()
        {
            Calendar = GenerateCalendar(DateTime.Today.Year, DateTime.Today.Month);
        }

        private List<List<DateTime?>> GenerateCalendar(int year, int month)
        {
            var calendar = new List<List<DateTime?>>();

            DateTime startDate = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);
            int offset = (int)startDate.DayOfWeek;

            var week = new List<DateTime?>();
            for (int i = 0; i < offset; i++)
            {
                week.Add(null);
            }

            for (int day = 1; day <= daysInMonth; day++)
            {
                week.Add(new DateTime(year, month, day));

                if (week.Count == 7)
                {
                    calendar.Add(week);
                    week = new List<DateTime?>();
                }
            }

            if (week.Count > 0)
            {
                while (week.Count < 7)
                {
                    week.Add(null);
                }
                calendar.Add(week);
            }

            return calendar;
        }
    }
}
