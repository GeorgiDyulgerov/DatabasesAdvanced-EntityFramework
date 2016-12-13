using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhotographyWorkshop.Models
{
    public class Camera
    {
        public Camera()
        {
            this.PhotographersPrimary = new HashSet<Photographer>();
            this.PhotographersSecondary = new HashSet<Photographer>();
        }

         public int Id { get; set; }

        [Required]
         public string Make { get; set; }

        [Required]
        public string Model { get; set; }

         public bool IsFullFrame { get; set; }

        [Required]
        [Range(100,Int32.MaxValue)]
         public int MinIso { get; set; }

         public int MaxIso { get; set; }

        public virtual ICollection<Photographer> PhotographersPrimary { get; set; }

        public virtual ICollection<Photographer> PhotographersSecondary { get; set; }



    }
}
