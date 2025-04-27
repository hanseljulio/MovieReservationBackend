using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieReservation.Shared.RequestResponse;

namespace MovieReservation.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<UserResponse> GetUserInformationAsync(string username);
    }
}
