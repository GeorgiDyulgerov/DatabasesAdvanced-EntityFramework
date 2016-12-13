using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelCodeFirst.Models
{
    //public enum Type
    //{
    //    Small,
    //    Medium,
    //    Large,
    //    President
    //}

    public class RoomType
    {
        [Key]
        [Column("Type")]
        public string TypeOfRoom { get; set; }

        [MaxLength(300)]
        public string Notes { get; set; }
    }
}
