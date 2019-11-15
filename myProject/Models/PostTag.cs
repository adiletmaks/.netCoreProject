using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myProject.Models
{
    public class PostTag
    {
        public uint PostId { get; set; }
        public Post Post { get; set; }

        public uint TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
