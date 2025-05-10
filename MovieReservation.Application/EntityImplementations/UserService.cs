using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieReservation.ApplicationServices.EntityInterfaces;
using MovieReservation.Domain.Repositories;
using MovieReservation.Domain.SeedWork;
using MovieReservation.Shared.Entities;
using MovieReservation.Shared.RequestResponse;

namespace MovieReservation.ApplicationServices.EntityImplementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
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

        public async Task<SubmissionResponse<object>> UpdateUserAsync(UserRequest request)
        {
            try
            {
                var originalUser = await userRepository.GetUserAsync(request.UserName).ConfigureAwait(false);

                if (originalUser is null)
                {
                    return SubmissionResponse<object>.ErrorResponse("User not found");
                }

                if (!string.Equals(originalUser.UserName, request.UserName, StringComparison.OrdinalIgnoreCase))
                {
                    return SubmissionResponse<object>.ErrorResponse("Unable to change username");
                }

                if (originalUser.Role != 0 && originalUser.Role != request.Role)
                {
                    return SubmissionResponse<object>.ErrorResponse("Unable to change role");
                }

                originalUser.FullName = request.FullName;
                originalUser.Email = request.Email;
                originalUser.PhoneNumber = request.PhoneNumber;
                originalUser.Password = request.Password;
                originalUser.ModifiedAt = DateTimeOffset.UtcNow;
                originalUser.ModifiedBy = request.ModifiedBy;


                await this.unitOfWork.CommitAsync().ConfigureAwait(false);

                return SubmissionResponse<object>.SuccessResponse("User successfully updated");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
