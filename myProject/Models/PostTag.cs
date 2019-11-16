using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace myProject.Models
{
    public class PostTag
    {
        [Required]
        public uint PostId { get; set; }
        public Post Post { get; set; }

        [Required]
        public uint TagId { get; set; }
        public Tag Tag { get; set; }
    }
}