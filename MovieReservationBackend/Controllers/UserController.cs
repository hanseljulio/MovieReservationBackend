using Microsoft.AspNetCore.Mvc;
using MovieReservation.ApplicationServices.EntityInterfaces;
using MovieReservation.Shared.RequestResponse;

namespace MovieReservationBackend.API.Controllers
{
    [ApiController]
    public class UserController
    {
        private readonly IUserService userService;
        public UserController(IUserService userService) { 
            this.userService = userService;
        }
        

        [HttpGet]
        [Route("/api/users/information/{username}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetUserInformationAsync(string username)
        {
            try
            {
                var response = await userService.GetUserInformationAsync(username);

                return new OkObjectResult(response);

            } catch (Exception ex)
            {
                return new OkObjectResult(SubmissionResponse<object>.ErrorResponse(ex.Message));
            }
        }

        [HttpPost]
        [Route("/api/users/post")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> PostUserAsync(UserRequest request)
        {
            try
            {
                var response = await userService.PostUserAsync(request);

                return new OkObjectResult(response);

            }
            catch (Exception ex)
            {
                return new OkObjectResult(SubmissionResponse<object>.ErrorResponse(ex.Message));
            }
        }
    }
}
