using System;
using System.Collections.Generic;

namespace BusinessData.Models
{
    public partial class Room
    {
        public int Id { get; set; }
        public bool? Status { get; set; }
        public int? CourseId { get; set; }
        public int? SessionId { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Session? Session { get; set; }
    }
}
