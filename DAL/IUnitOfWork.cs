using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUnitOfWork
    {
        ContextRepository<Room> Rooms { get; }

        ContextRepository<Status> Statuses { get; }


        void Save();
        void Dispose();
    }
}
