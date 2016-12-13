using System;
using System.ComponentModel.DataAnnotations;

namespace SalesCodeFirst.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }

        public Product Product { get; set; }

        public Customer Customer { get; set; }

        public StoreLocation StoreLocation { get; set; }

        public DateTime Date{ get; set; }

    }
}
