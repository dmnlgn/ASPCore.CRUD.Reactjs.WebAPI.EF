using ReservationService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservationService.Models;
using ReservationService.DAL;
using System.Data.SqlClient;

namespace ReservationService
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var context = new DbReservations())
            //{
            //    SqlConnection.ClearAllPools();
            //    Database.SetInitializer<DbReservations>(new DataSeed());

            //    var stdQuery = (from d in context.Reservations select new { Id = d.ReservationCode });

            //    foreach (var q in stdQuery)
            //    {
            //        Console.WriteLine("ID : " + q.Id);
            //    }

            //    Console.ReadKey();
            //}
        }

    }
}
