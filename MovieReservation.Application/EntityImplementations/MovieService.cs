using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieReservation.ApplicationServices.EntityInterfaces;
using MovieReservation.Domain.Repositories;
using MovieReservation.Domain.SeedWork;
using MovieReservation.Infrastructure.EntityRepositories;
using MovieReservation.Shared.Entities;
using MovieReservation.Shared.RequestResponse;

namespace MovieReservation.ApplicationServices.EntityImplementations
{
    public class MovieService: IMovieService
    {
        private readonly IMovieRepository movieRepository;
        private readonly IUnitOfWork unitOfWork;

        public MovieService(IMovieRepository movieRepository, IUnitOfWork unitOfWork)
        {
            this.movieRepository = movieRepository;
            this.unitOfWork = unitOfWork;
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

        public async Task<SubmissionResponse<object>> UpdateMovieAsync(MovieRequest request)
        {
            try
            {
                if (request.Id == 0)
                {
                    return SubmissionResponse<object>.ErrorResponse("Movie ID is required");
                }

                var originalMovie = await movieRepository.GetMovieByIdAsync(request.Id);

                if (originalMovie is null)
                {
                    return SubmissionResponse<object>.ErrorResponse("Movie not found");
                }

                originalMovie.Title = request.Title;
                originalMovie.Description = request.Description;
                originalMovie.DurationMins = request.DurationMins;
                originalMovie.ModifiedAt = DateTimeOffset.UtcNow;
                originalMovie.ModifiedBy = "DEV";


                await this.unitOfWork.CommitAsync().ConfigureAwait(false);

                return SubmissionResponse<object>.SuccessResponse("Movie successfully updated");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
