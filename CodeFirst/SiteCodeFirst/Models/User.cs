using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SiteCodeFirst.ValidationAttributes;

namespace SiteCodeFirst.Models
{
    public partial class User
    {
        private string password;
        private string email;

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required]
        [Password(6,50, ErrorMessage = "Incorrect password")]
        [MinLength(6)]
        [MaxLength(50)]
        public string Password
        {
            get; set;
            #region //Other Validation Method
            //get { return this.password; }
            //set
            //{
            //    if (this.CheckIfDigitIsContained(value) && this.CheckIfLowLetterIsContained(value) && this.CheckIfSpecialSymbolsIsContained(value) && this.CheckIfUpperLetterIsContained(value))
            //    {
            //        this.password = value;
            //    }
            //    else
            //    {
            //      throw new ArgumentException("Password not in correct format");  
            //    }

            //}
            #endregion 
        }

        [Required]
        public string Email
        {
            get { return this.email; }
            set
            {
                if (this.EmailIsValid(value))
                {
                    this.email = value;
                }
                else
                {
                    throw new ArgumentException("Email not in correct format");
                }

            }
        }

        [MaxLength(1024 * 1024)]
        public byte[] ProfilePicture { get; set; }


        public DateTime? RegisteredOn { get; set; }

        public DateTime? LastTimeLoggedIn { get; set; }

        [Range(1, 120)]
        public int Age { get; set; }

        public bool IsDeleted { get; set; }

        public Town BornTown { get; set; }

        public Town CurrentTown { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [NotMapped]
        public string FullName => this.FirstName + " " + this.LastName;
    }
}
