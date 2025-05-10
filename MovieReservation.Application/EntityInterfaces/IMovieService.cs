using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieReservation.Shared.RequestResponse;

namespace MovieReservation.ApplicationServices.EntityInterfaces
{
    public interface IMovieService
    {
        Task<SubmissionResponse<object>> PostMovieAsync(MovieRequest request);
    }
}
