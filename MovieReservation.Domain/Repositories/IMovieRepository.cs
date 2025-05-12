using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieReservation.Shared.Entities;

namespace MovieReservation.Domain.Repositories
{
    public interface IMovieRepository
    {
        Task PostMovieAsync(Movies entity);
        Task<Movies> GetMovieByIdAsync(int id);
    }
}
