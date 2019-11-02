using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myProject.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public User User { get; set; }
        public Category Category { get; set; }

        public ICollection<PostTag> PostTags { get; } = new List<PostTag>();

        public ICollection<Comment> Comments { get; set; }
    }
}