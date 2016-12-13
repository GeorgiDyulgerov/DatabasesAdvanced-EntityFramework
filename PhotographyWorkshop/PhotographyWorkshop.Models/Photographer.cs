using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PhotographyWorkshop.Models.Attributes;

namespace PhotographyWorkshop.Models
{
    public class Photographer
    {
        public Photographer()
        {
            this.Lenses = new HashSet<Lens>();
            this.Accessories = new HashSet<Accessory>();
            this.WorkshopsTrainer = new HashSet<Workshop>();
            this.WorkshopsParticipant = new HashSet<Workshop>();
        }

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [MinLength(2)]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Attributes.Phone]
        public string Phone { get; set; }

        [Required]
        public virtual Camera PrimaryCamera { get; set; }
               
        [Required]
        public virtual Camera SecondaryCamera { get; set; }
               
        public virtual ICollection<Lens> Lenses { get; set; }
               
        public virtual ICollection<Accessory> Accessories { get; set; }

        public virtual ICollection<Workshop> WorkshopsTrainer { get; set; }

        public virtual ICollection<Workshop> WorkshopsParticipant { get; set; }

    }
}
