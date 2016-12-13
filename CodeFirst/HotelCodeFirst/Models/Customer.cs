using System.ComponentModel.DataAnnotations;

namespace HotelCodeFirst.Models
{
    public class Customer
    {
        [Key]
        public int AccountNumber { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(60)]
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string EmergencyName { get; set; }

        public string EmergencyNumeber { get; set; }

        [MaxLength(300)]
        public string Notes { get; set; }
    }
}
