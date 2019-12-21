using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace myProject.Models
{
    public class Category
    {
        public uint Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "varchar(30)")]
        [Required]
        public string Slug { get; set; }
    }
}