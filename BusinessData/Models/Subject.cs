using System;
using System.Collections.Generic;

namespace BusinessData.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Semesters = new HashSet<Semester>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? MajorId { get; set; }
        public int? CourseId { get; set; }
        public int? StudentId { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Major? Major { get; set; }
        public virtual ICollection<Semester> Semesters { get; set; }
    }
}
