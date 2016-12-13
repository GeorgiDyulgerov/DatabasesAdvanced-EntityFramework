using System;
using System.ComponentModel.DataAnnotations;

namespace HotelCodeFirst.Models
{
    public class Ocupance
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateOccupied { get; set; }

        public int AccountNumber { get; set; }

        public int RoomNumber { get; set; }

        public int RateApplied { get; set; }

        public decimal PhoneCharge { get; set; }

        [MaxLength(300)]
        public string Notes { get; set; }


    }
}
