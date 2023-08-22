using System;
using System.Collections.Generic;

namespace BusinessData.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? MajorId { get; set; }
        public int? AttendanceId { get; set; }
        public int? SubjectId { get; set; }

        public virtual Attendance? Attendance { get; set; }
        public virtual Major? Major { get; set; }
    }
}
