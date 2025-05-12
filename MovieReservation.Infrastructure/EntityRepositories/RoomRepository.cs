using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieReservation.Domain.Repositories;
using MovieReservation.Infrastructure.Context;
using MovieReservation.Shared.Entities;
using MovieReservation.Shared.RequestResponse;

namespace MovieReservation.Infrastructure.EntityRepositories
{
    public class RoomRepository: IRoomRepository
    {
        private readonly MovieReservationContext dbContext;

        public RoomRepository(MovieReservationContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task PostRoomAsync(Room entity)
        {
            entity.CreatedAt = DateTimeOffset.UtcNow;
            entity.CreatedBy = "DEV";
            entity.ModifiedAt = DateTimeOffset.UtcNow;
            entity.ModifiedBy = "DEV";
            this.dbContext.Room.Add(entity);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<Room> GetRoomAsync(int id)
        {
            var query = await this.dbContext.Room.Where(x => x.Id == id).FirstOrDefaultAsync();

            return query;
        }

        public async Task<List<RoomResponse>> GetAllRoomsListAsync()
        {
            var query = await this.dbContext.Room.ToListAsync();
            List<RoomResponse> result = new List<RoomResponse>();

            if (query is not null)
            {
                foreach (var item in query) {
                    result.Add(new RoomResponse()
                    {
                        Id = item.Id,
                        RoomName = item.RoomName,
                        Capacity = item.Capacity,
                    });
                }
            }

            return result;
        }
    }
}
