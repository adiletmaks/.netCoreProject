using myProject.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace myProject.Models
{
    public class City : IValidatableObject
    {
        public uint Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required]
        public string Name { get; set; }

        [Required]
        public uint CountryId { get; set; }

        public Country Country { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.Name))
            {
                errors.Add(new ValidationResult("Enter city name!"));
            }
            if (BlackList().Contains(this.Name))
            {
                errors.Add(new ValidationResult("Enter other city name!"));
            }
            if (this.CountryId < 1)
            {
                errors.Add(new ValidationResult("Invalid city id!"));
            }

            return errors;
        }

        public List<String> BlackList() {
            List<string> list = new List<string>(new string[] { "City1", "City2", "City3" });

            return list;
        }

    }
}