using System;
using System.ComponentModel.DataAnnotations;

namespace GringottsDB.Models
{
    public class WizardDeposit
    {
        private int age;

        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(60)]
        public string LastName { get; set; }

        [MaxLength(1000)]
        public string Notes { get; set; }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value<0)
                {
                    throw new ArgumentException("The age can not be negative.");
                }

                this.age = value;
            }
        }

        [MaxLength(100)]
        public string MagicWandCreator { get; set; }

        public int MagicWandSize { get; set; }

        [MaxLength(20)]
        public string DepositGroup { get; set; }

        public DateTime DepositStartDate { get; set; }

        public decimal DepositAmount { get; set; }

        public double DepositInterest { get; set; }

        public double DepositCharge { get; set; }

        public DateTime DepositExpirationDate { get; set; }

        public bool IsDepositExpired { get; set; }
    }
}
