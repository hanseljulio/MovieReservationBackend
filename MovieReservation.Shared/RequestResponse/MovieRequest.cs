using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservation.Shared.RequestResponse
{
    public class MovieRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int DurationMins { get; set; }
    }
}
