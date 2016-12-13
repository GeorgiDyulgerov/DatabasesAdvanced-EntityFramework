using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelCodeFirst.Models;

namespace HotelCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new HotelContext();

            RoomStatus free = new RoomStatus
            {
                StatusOfRoom = "Free",
                Notes = "The room can be booked."
            };

            RoomType small = new RoomType
            {
                TypeOfRoom = "Small",
                Notes = "Small room with bed and TV."
            };

            var room = context.Rooms.First();
            room.StatusOfRoom = free;
            room.TypeOfRoom = small;
            
            context.SaveChanges();

        }
    }
}
