using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Arch_2._2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Context db = new Context())
            {

                Status s1 = new Status { State = Stat.Free };
                Status s2 = new Status { State = Stat.Booked };
                Status s3 = new Status { State = Stat.Busy };
                db.Statuses.Add(s1);
                db.Statuses.Add(s2);
                db.Statuses.Add(s3);

                db.SaveChanges();

             
                Console.ReadKey();
            }
        }
    }
}
