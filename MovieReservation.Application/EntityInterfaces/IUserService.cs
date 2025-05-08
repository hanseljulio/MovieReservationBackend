using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieReservation.Shared.RequestResponse;

namespace MovieReservation.ApplicationServices.EntityInterfaces
{
    public interface IUserService
    {
        Task<UserResponse> GetUserInformationAsync(string username);
        Task<SubmissionResponse<object>> PostUserAsync(UserRequest request);
    }
}
