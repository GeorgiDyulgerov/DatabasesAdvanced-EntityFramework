using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesCodeFirst.Models
{
    public class Product
    {
        public Product()
        {
            this.SalesOfProducts = new List<Sale>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public double Quantity { get; set; }

        public decimal Price { get; set; }

        public ICollection<Sale> SalesOfProducts { get; set; }

    }
}
