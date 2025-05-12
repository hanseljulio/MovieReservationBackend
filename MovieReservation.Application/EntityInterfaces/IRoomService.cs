using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieReservation.Shared.RequestResponse;

namespace MovieReservation.ApplicationServices.EntityInterfaces
{
    public interface IRoomService
    {
        Task<SubmissionResponse<object>> PostRoomAsync(RoomRequest request);
        Task<List<RoomResponse>> GetAllRoomsListAsync();
        Task<SubmissionResponse<object>> UpdateRoomAsync(RoomRequest request);
    }
}
