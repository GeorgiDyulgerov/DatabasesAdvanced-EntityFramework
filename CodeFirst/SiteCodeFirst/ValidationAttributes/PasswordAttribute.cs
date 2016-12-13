using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SiteCodeFirst.ValidationAttributes
{

    [AttributeUsage(AttributeTargets.Property)]
    class PasswordAttribute : ValidationAttribute
    {
        private readonly int _passMinLen;

        private readonly int _passMaxLen;

        public PasswordAttribute(int passworMinLenght = 0, int passwordMaxLenght = 30)
        {
            this._passMinLen = passworMinLenght;
            this._passMaxLen = passwordMaxLenght;
        }

        public bool ShouldContainLowercase { get; set; }

        public bool ShouldContainUpercase { get; set; }

        public bool ShouldContainDigit { get; set; }

        public bool ShouldContaionSpecialSymbol { get; set; }

        public override bool IsValid(object value)
        {
            string passAsString = value as string;

            if (passAsString == null)
            {
                throw new ArgumentException("Property must be of type string.");
            }

            if (passAsString.Length < this._passMinLen | passAsString.Length > this._passMaxLen | this._passMinLen > this._passMaxLen)
            {
                return false;
            }

            if (this.ShouldContainDigit | !this.ContainsDigit(passAsString))
            {
                return false;
            }

            if (this.ShouldContainUpercase | !this.ContainsUppercase(passAsString))
            {
                return false;
            }

            if (this.ShouldContainLowercase | !this.ContainsLowercase(passAsString))
            {
                return false;
            }

            if (this.ShouldContaionSpecialSymbol | !this.ContainsSpecialSymbol(passAsString))
            {
                return false;
            }

            return true;
        }

        private bool ContainsSpecialSymbol(string value)
        {
            string regularExpressinString = @"[(!@#$%^&*()_+<>?]";
            Regex regex = new Regex(regularExpressinString);
            if (regex.IsMatch(value))
            {
                return true;
            }

            return false;
        }

        private bool ContainsLowercase(string value)
        {
            string regularExpressinString = @"[a-z]";
            Regex regex = new Regex(regularExpressinString);
            if (regex.IsMatch(value))
            {
                return true;
            }

            return false;
        }

        private bool ContainsUppercase(string value)
        {
            string regularExpressinString = @"[A-Z]";
            Regex regex = new Regex(regularExpressinString);
            if (regex.IsMatch(value))
            {
                return true;
            }

            return false;
        }

        private bool ContainsDigit(string value)
        {
            string regularExpressinString = @"[0-9]";
            Regex regex = new Regex(regularExpressinString);
            if (regex.IsMatch(value))
            {
                return true;
            }

            return false;
        }
    }
}
