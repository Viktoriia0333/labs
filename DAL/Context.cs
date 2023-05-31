using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{
   public class Context : DbContext
    {
        public Context() : base("Arch_2.2_3")
        {

        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Status> Statuses { get; set; }
    }
}
