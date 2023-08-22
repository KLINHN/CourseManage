using System;
using System.Collections.Generic;

namespace BusinessData.Models
{
    public partial class Major
    {
        public Major()
        {
            Students = new HashSet<Student>();
            Subjects = new HashSet<Subject>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? SubjectId { get; set; }
        public int? StudentId { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
