using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace myProject.Models
{
    public class City
    {
        public uint Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
        public Country Country { get; set; }
    }
}