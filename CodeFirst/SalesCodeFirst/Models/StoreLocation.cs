using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesCodeFirst.Models
{
    public class StoreLocation
    {
        public StoreLocation()
        {
            this.SalesInStore = new List<Sale>();
        }

        [Key]
        public int Id { get; set; }

        public string LocationName { get; set; }

        public ICollection<Sale> SalesInStore { get; set; }


    }
}
