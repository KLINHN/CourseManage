using System;
using System.Collections.Generic;

namespace BusinessData.Models
{
    public partial class Slot
    {
        public Slot()
        {
            Sessions = new HashSet<Session>();
        }

        public int Id { get; set; }
        public string? TimeEnd { get; set; }
        public string? TimeStart { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
