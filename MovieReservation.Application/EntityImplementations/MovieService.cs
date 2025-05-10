using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieReservation.ApplicationServices.EntityInterfaces;
using MovieReservation.Domain.Repositories;
using MovieReservation.Infrastructure.EntityRepositories;
using MovieReservation.Shared.Entities;
using MovieReservation.Shared.RequestResponse;

namespace MovieReservation.ApplicationServices.EntityImplementations
{
    public class MovieService: IMovieService
    {
        private readonly IMovieRepository movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public async Task<SubmissionResponse<object>> PostMovieAsync(MovieRequest request)
        {
            try
            {
                Movies newMovie = new Movies()
                {
                    Title = request.Title,
                    Description = request.Description,
                    DurationMins = request.DurationMins,
                    IsActive = true
                };

                await movieRepository.PostMovieAsync(newMovie);

                return SubmissionResponse<object>.SuccessResponse("Movie successfully added");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
