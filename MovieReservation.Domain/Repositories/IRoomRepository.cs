using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieReservation.Shared.Entities;
using MovieReservation.Shared.RequestResponse;

namespace MovieReservation.Domain.Repositories
{
    public interface IRoomRepository
    {
        Task PostRoomAsync(Room entity);
        Task<List<RoomResponse>> GetAllRoomsListAsync();
        Task<Room> GetRoomAsync(int id);
    }
}
