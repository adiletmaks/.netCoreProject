using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace myProject.Models
{
    public class Post
    {
        public uint Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Title { get; set; }
        [Column(TypeName = "text")]
        public string Text { get; set; }
        public User User { get; set; }
        public Category Category { get; set; }
        public ICollection<PostTag> PostTags { get; } = new List<PostTag>();
        public ICollection<Comment> Comments { get; set; }
    }
}