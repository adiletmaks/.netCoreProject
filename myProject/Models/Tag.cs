using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace myProject.Models
{
    public class Tag
    {
        public uint Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
        public ICollection<PostTag> PostTags { get; } = new List<PostTag>();
    }
}