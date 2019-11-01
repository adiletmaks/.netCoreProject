using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myProject.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
    }
}