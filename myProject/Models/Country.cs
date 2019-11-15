using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace myProject.Models
{
    public class Country
    {
        public uint Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
    }
}