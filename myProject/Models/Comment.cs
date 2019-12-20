using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace myProject.Models
{
    public class Comment
    {
        public uint Id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Text { get; set; }

        [Required]
        public uint PostId { get; set; }

        public Post Post { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}