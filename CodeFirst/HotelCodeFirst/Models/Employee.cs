using System.ComponentModel.DataAnnotations;

namespace HotelCodeFirst.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(60)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(300)]
        public string Notes { get; set; }   

    }
}
