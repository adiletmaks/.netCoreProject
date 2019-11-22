using myProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myProject.Validations
{
    public class CheckPasswordStrengthAttribute : ValidationAttribute
    {
        public CheckPasswordStrengthAttribute()
        {
            ErrorMessage = "Password should not contains First name, last name!";
        }
        public override bool IsValid(object value)
        {
            User u = value as User;
            if(u is null)
            {
                return true;
            }
            if (u.Password.Contains(u.FirstName) || u.Password.Contains(u.LastName))
            {
                return false;
            }

            return true;
        }
    }
}
