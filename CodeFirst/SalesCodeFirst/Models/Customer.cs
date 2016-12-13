using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SalesCodeFirst.Models
{
    public class Customer
    {
        private string email;

        public Customer()
        {
            this.SalesForCustomer = new List<Sale>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email
        {
            get { return this.email; }
            set
            {
                string regularExpressinString = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
                Regex regex = new Regex(regularExpressinString);
                if (regex.IsMatch(value))
                {
                    this.email = value;
                }
                else
                {
                    throw new ArgumentException("Email not in correct format.");
                }
                
            }
        }

        public string CreditCardNumber { get; set; }

        public ICollection<Sale> SalesForCustomer { get; set; }


    }
}
