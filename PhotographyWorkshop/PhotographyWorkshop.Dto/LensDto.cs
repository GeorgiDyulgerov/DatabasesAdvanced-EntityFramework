using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyWorkshop.Dto
{
    public class LensDto
    {
        public string Make { get; set; }

        public int? FocalLength { get; set; }

        public float? MaxAperture { get; set; }

        public string CompatibleWith { get; set; }
    }
}
