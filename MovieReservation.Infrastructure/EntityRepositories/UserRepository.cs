using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieReservation.Domain.Repositories;
using MovieReservation.Infrastructure.Context;
using MovieReservation.Shared.RequestResponse;

namespace MovieReservation.Infrastructure.EntityRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MovieReservationContext dbContext;

        public UserRepository(MovieReservationContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<UserResponse> GetUserInformationAsync(string username)
        {
            var query = await this.dbContext.Users.Where(x => x.UserName.ToLower() == username.ToLower() && x.IsActive == true)
                    .FirstOrDefaultAsync().ConfigureAwait(false);

            if (query is not null)
            {
                var result = new UserResponse()
                {
                    Id = query.Id,
                    UserName = query.UserName,
                    FullName = query.FullName,
                    Email = query.Email,
                    PhoneNumber = query.PhoneNumber,
                    Role = query.Role,
                };

                return result;
            }

            return new UserResponse() { Id = 0 };
        }
    }
}
