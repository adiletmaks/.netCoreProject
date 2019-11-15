using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace myProject.Models
{
    public class Comment
    {
        public uint Id { get; set; }
        [Column(TypeName = "text")]
        public string Text { get; set; }
        public Post Post { get; set; }
        public User User { get; set; }
    }
}