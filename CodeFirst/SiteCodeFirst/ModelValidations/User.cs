using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SiteCodeFirst.Models
{
    partial class User
    {
        private bool EmailIsValid(string email)
        {
            string regularExpressinString = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
            Regex regex = new Regex(regularExpressinString);
            if (regex.IsMatch(email))
            {
                return true;
            }

            return false;
        }

        private bool CheckIfDigitIsContained(string value)
        {
            string regularExpressinString = @"[0-9]";
            Regex regex = new Regex(regularExpressinString);
            if (regex.IsMatch(value))
            {
                return true;
            }

            return false;
        }

        private bool CheckIfSpecialSymbolsIsContained(string value)
        {
            string regularExpressinString = @"[(!@#$%^&*()_+<>?]";
            Regex regex = new Regex(regularExpressinString);
            if (regex.IsMatch(value))
            {
                return true;
            }

            return false;
        }

        private bool CheckIfUpperLetterIsContained(string value)
        {
            string regularExpressinString = @"[A-Z]";
            Regex regex = new Regex(regularExpressinString);
            if (regex.IsMatch(value))
            {
                return true;
            }

            return false;
        }

        private bool CheckIfLowLetterIsContained(string value)
        {
            string regularExpressinString = @"[a-z]";
            Regex regex = new Regex(regularExpressinString);
            if (regex.IsMatch(value))
            {
                return true;
            }

            return false;
        }
    }
}
