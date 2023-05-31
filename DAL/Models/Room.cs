using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
   public enum Categories
    {
        Standart,
        Luxe,
        Deluxe
    }
    public partial class Room
    {
        public int ID { get; set; }
        public Categories Category { get; set; }
        public double Day_Price { get; set; }
        public Nullable<int> Status_FK { get; set; }
        public DateTime? DateTo { get; set; }
        [ForeignKey("Status_FK")]
        public virtual Status Status { get; set; }

        public override string ToString()
        {
            return ID + " "+ Category + " " + Day_Price + " " + Status.State + " " + DateTo;
        }
    }
}
