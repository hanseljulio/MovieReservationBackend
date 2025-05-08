using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieReservation.ApplicationServices.EntityInterfaces;
using MovieReservation.Domain.Repositories;
using MovieReservation.Shared.Entities;
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

        public async Task<SubmissionResponse<object>> PostUserAsync(UserRequest request)
        {
            try
            {
                Users newUser = new Users()
                {
                    UserName = request.UserName,
                    FullName = request.FullName,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    Password = request.Password,
                    Role = request.Role,
                    IsActive = true,
                    FailedAttempts = 0,
                    LastFailedAt = null,
                    LockedUntil = null
                };

                await userRepository.PostUserAsync(newUser);

                return SubmissionResponse<object>.SuccessResponse("User successfully created");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
