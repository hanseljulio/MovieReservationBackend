using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservation.Shared.Entities
{
    public class Payments
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Guid TransactionId { get; set; }
        public int PaymentMethod { get; set; } // 0 Onsite, 1 Debit/Credit card
        public int Amount { get; set; }
        public DateTimeOffset PaymentDate { get; set; }
        public int PaymentStatus { get; set; } // 0 = on hold, 1 = failed, 2 = success
        public bool UserDeleted { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset ModifiedAt { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
