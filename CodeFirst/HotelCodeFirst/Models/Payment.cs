using System;
using System.ComponentModel.DataAnnotations;

namespace HotelCodeFirst.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        public DateTime PaymentDate { get; set; }

        public int AccountNumber { get; set; }

        public DateTime FirstDateOccupied { get; set; }

        public DateTime LastDateOccupied { get; set; }

        public int TotalDays { get; set; }

        public decimal AmountCharged { get; set; }

        public int TaxRate { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal PaymentTotal { get; set; }

        [MaxLength(300)]
        public string Notes { get; set; }
        
    }
}
