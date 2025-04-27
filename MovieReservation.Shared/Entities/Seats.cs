using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservation.Shared.Entities
{
    public class Seats
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string Row { get; set; }
        public int SeatNumber { get; set; }
        public int SeatStatus { get; set; } // 0 clear, 1 on hold, 2 taken
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset ModifiedAt { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
