using System;
using System.Collections.Generic;

namespace BusinessData.Models
{
    public partial class Semester
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? SubjectId { get; set; }
        public int? MajorId { get; set; }

        public virtual Subject? Subject { get; set; }
    }
}
