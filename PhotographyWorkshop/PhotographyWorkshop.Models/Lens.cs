using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PhotographyWorkshop.Models
{
    public class Lens
    {
        private float maxAperture;

        public int Id { get; set; }

        public string Make { get; set; }

        public int FocalLength { get; set; }

       
        public float MaxAperture { get; set;
            //get { return this.maxAperture; }
            //set
            //{
            //    string regularExpressinString = @"\d{1}.\d{1}";
            //    Regex regex = new Regex(regularExpressinString);
            //    if (regex.IsMatch(value.ToString()))
            //    {
            //        this.maxAperture = value;
            //    }

            //    throw new ValidationException("Max Aperture can't have more than 1 decimal places");

            //}
        }


        public string CompatibleWith { get; set; }

        public virtual Photographer Owner { get; set; }


    }
}
