using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhotographyWorkshop.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    class PhoneAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string passAsString = value as string;
            if (passAsString == null)
            {
                return true;
            }
            else
            {
                string regularExpressinString = @"\(?\+[0-9]{1,3}\)?\/([0-9]{6,10})";
                Regex regex = new Regex(regularExpressinString);
                if (regex.IsMatch(passAsString))
                {
                    return true;
                }
            }


            return false;



        }
    }
}
