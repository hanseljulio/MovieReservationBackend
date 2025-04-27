using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservation.Shared.Entities
{
    public class Showtime
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int RoomId { get; set; }
        public bool IsActive { get; set; }
        public TimeOnly StartTime { get; set; }
        public int Status { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset ModifiedAt { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
