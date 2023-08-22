using System;
using System.Collections.Generic;

namespace BusinessData.Models
{
    public partial class Session
    {
        public Session()
        {
            Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }
        public int? SlotId { get; set; }
        public int? RoomId { get; set; }

        public virtual Slot? Slot { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
