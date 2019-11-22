using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace myProject.Models
{
    public class PostVM
    {
        public Post Post { get; set; }
        public IEnumerable<SelectListItem> TagsList { set; get; }
        public IEnumerable<uint> SelectedTags { get; set; }
    }
}