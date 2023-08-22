using System;
using System.Collections.Generic;

namespace BusinessData.Models
{
    public partial class Attendance
    {
        public Attendance()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int? AbsentCount { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
