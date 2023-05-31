using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public enum Stat
    {
        Free,
        Booked,
        Busy
    }

    public partial class Status
    {
        [Key]
        public int Id { get; set; }
        public Stat State { get; set; }
    }
}
