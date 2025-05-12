using Microsoft.AspNetCore.Mvc;
using MovieReservation.ApplicationServices.EntityImplementations;
using MovieReservation.ApplicationServices.EntityInterfaces;
using MovieReservation.Shared.RequestResponse;

namespace MovieReservationBackend.API.Controllers
{
    [ApiController]
    public class RoomController
    {
        private readonly IRoomService roomService;

        public RoomController(IRoomService roomService) { 
            this.roomService = roomService;
        }


        [HttpPost]
        [Route("/api/room/post")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> PostRoomAsync(RoomRequest request)
        {
            try
            {
                var response = await roomService.PostRoomAsync(request);

                return new OkObjectResult(response);

            }
            catch (Exception ex)
            {
                return new OkObjectResult(SubmissionResponse<object>.ErrorResponse(ex.Message));
            }
        }

        [HttpGet]
        [Route("/api/room/list")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllRoomsListAsync()
        {
            try
            {
                var response = await roomService.GetAllRoomsListAsync();

                return new OkObjectResult(response);

            }
            catch (Exception ex)
            {
                return new OkObjectResult(SubmissionResponse<object>.ErrorResponse(ex.Message));
            }
        }

        [HttpPut]
        [Route("/api/room/update")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateRoomAsync(RoomRequest request)
        {
            try
            {
                var response = await roomService.UpdateRoomAsync(request);

                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                return new OkObjectResult(SubmissionResponse<object>.ErrorResponse(ex.Message));
            }
        }
    }
}
