using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieReservation.Domain.Repositories;
using MovieReservation.Infrastructure.Context;
using MovieReservation.Shared.Entities;

namespace MovieReservation.Infrastructure.EntityRepositories
{
    public class MovieRepository: IMovieRepository
    {
        private readonly MovieReservationContext dbContext;

        public MovieRepository(MovieReservationContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task PostMovieAsync(Movies entity)
        {
            entity.CreatedAt = DateTimeOffset.UtcNow;
            entity.CreatedBy = "DEV";
            entity.ModifiedAt = DateTimeOffset.UtcNow;
            entity.ModifiedBy = "DEV";
            this.dbContext.Movies.Add(entity);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<Movies> GetMovieByIdAsync(int id)
        {
            var query = await this.dbContext.Movies.Where(x => x.Id == id && x.IsActive == true).FirstOrDefaultAsync().ConfigureAwait(false);

            return query;
        }
    }
}
