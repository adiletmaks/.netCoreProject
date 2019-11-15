using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace myProject.Models
{
    public class Role
    {
        public uint Id { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Slug { get; set; }
    }
}