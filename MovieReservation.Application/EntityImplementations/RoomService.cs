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
    public class RoomService: IRoomService
    {
        private readonly IRoomRepository roomRepository;
        private readonly IUnitOfWork unitOfWork;

        public RoomService(IRoomRepository roomRepository, IUnitOfWork unitOfWork) { 
            this.roomRepository = roomRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<SubmissionResponse<object>> PostRoomAsync(RoomRequest request)
        {
            try
            {
                Room newRoom = new Room()
                {
                    RoomName = request.RoomName,
                    Capacity = request.Capacity,
                };

                await roomRepository.PostRoomAsync(newRoom);

                return SubmissionResponse<object>.SuccessResponse("Room successfully added");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<RoomResponse>> GetAllRoomsListAsync()
        {
            return await roomRepository.GetAllRoomsListAsync();
        }

        public async Task<SubmissionResponse<object>> UpdateRoomAsync(RoomRequest request)
        {
            if (request.Id == 0)
            {
                return SubmissionResponse<object>.ErrorResponse("Room ID is required");
            }

            var originalRoom = await roomRepository.GetRoomAsync(request.Id);

            if (originalRoom is null)
            {
                return SubmissionResponse<object>.ErrorResponse("Room not found");
            }

            originalRoom.RoomName = request.RoomName;
            originalRoom.Capacity = request.Capacity;
            originalRoom.ModifiedAt = DateTimeOffset.UtcNow;
            originalRoom.ModifiedBy = "DEV";

            await this.unitOfWork.CommitAsync();

            return SubmissionResponse<object>.SuccessResponse("Room successfully updated");
        }
    }
}
