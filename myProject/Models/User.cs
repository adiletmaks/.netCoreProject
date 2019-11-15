using myProject.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace myProject.Models
{
    [CheckPasswordStrength]
    public class User
    {
        public uint Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required]
        public string LastName { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [Column(TypeName = "varchar(255)")]
        [Required]
        public string Password { get; set; }

        [Required]
        public uint RoleId { get; set; }

        public Role Role { get; set; }
    }
}