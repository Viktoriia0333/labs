using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly Context BD;

        public ContextRepository<Room> Rooms { get; }

        public ContextRepository<Status> Statuses { get; }



        private bool Disposed;

        public UnitOfWork(Context bD, ContextRepository<Room> rooms, ContextRepository<Status> statuses)
        {
            BD = bD;
            Statuses = statuses;
            Rooms = rooms;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Disposed) return;
            if (disposing)
            {
                BD.Dispose();
            }

            Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            bool saveFailed;
            do
            {
                saveFailed = false;

              
                    BD.SaveChanges();
                
             

            } while (saveFailed);
        }


    }
}
