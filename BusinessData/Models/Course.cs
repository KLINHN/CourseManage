using System;
using System.Collections.Generic;

namespace BusinessData.Models
{
    public partial class Course
    {
        public Course()
        {
            Rooms = new HashSet<Room>();
            Subjects = new HashSet<Subject>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? SubjectId { get; set; }
        public int? StudentInCourse { get; set; }
        public int? RoomId { get; set; }
        public int? SessionId { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
