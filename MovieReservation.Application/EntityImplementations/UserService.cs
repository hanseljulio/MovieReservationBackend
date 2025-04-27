using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieReservation.ApplicationServices.EntityInterfaces;
using MovieReservation.Domain.Repositories;
using MovieReservation.Shared.RequestResponse;

namespace MovieReservation.ApplicationServices.EntityImplementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<UserResponse> GetUserInformationAsync(string username)
        {
            return await userRepository.GetUserInformationAsync(username);
        }
    }
}
