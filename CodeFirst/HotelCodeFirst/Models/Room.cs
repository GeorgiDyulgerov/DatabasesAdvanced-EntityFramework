using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelCodeFirst.Models
{
    public enum BedType
    {
        Single,
        Double,
        KingSize
    }

    public class Room
    {
        [Key]
        public int RoomNumber { get; set; }

        [Column("RoomType")]
        public RoomType TypeOfRoom { get; set; }

        [Column("BedType")]
        public BedType TypeOfBed { get; set; }

        [Range(0,10)]
        public int Rate { get; set; }

        [Column("RoomStatus")]
        public RoomStatus StatusOfRoom { get; set; }

        [MaxLength(300)]
        public string Notes { get; set; }
    }
}
