using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieReservation.Domain.SeedWork;
using MovieReservation.Infrastructure.Context;

namespace MovieReservation.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed = false;

        public void Dispose()
        {
            this.Dispose(true);
        }

        public MovieReservationContext DatabaseContext { get; }

        public UnitOfWork(MovieReservationContext context)
        {
            this.DatabaseContext = context;
        }

        public async Task<int> CommitAsync()
        {
            return await this.DatabaseContext.SaveChangesAsync().ConfigureAwait(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                this.DatabaseContext?.Dispose();
                this.disposed = true;
            }
        }
    }
}
