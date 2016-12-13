using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelCodeFirst.Models
{
    //public enum Status
    //{
    //    Clear,
    //    Taken,
    //    Closed

    //}

    public class RoomStatus
    {
        [Key]
        [Column("Status")]
        public string StatusOfRoom { get; set; }

        [MaxLength(300)]
        public string Notes { get; set; }

    }
}
