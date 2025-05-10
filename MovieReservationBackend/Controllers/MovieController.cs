using Microsoft.AspNetCore.Mvc;
using MovieReservation.ApplicationServices.EntityImplementations;
using MovieReservation.ApplicationServices.EntityInterfaces;
using MovieReservation.Shared.RequestResponse;

namespace MovieReservationBackend.API.Controllers
{
    [ApiController]
    public class MovieController
    {
        private readonly IMovieService movieService;

        public MovieController(IMovieService movieService) { 
            this.movieService = movieService;
        }

        [HttpPost]
        [Route("/api/movies/post")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> PostMovieAsync(MovieRequest request)
        {
            try
            {
                var response = await movieService.PostMovieAsync(request);

                return new OkObjectResult(response);

            }
            catch (Exception ex)
            {
                return new OkObjectResult(SubmissionResponse<object>.ErrorResponse(ex.Message));
            }
        }
    }
}
