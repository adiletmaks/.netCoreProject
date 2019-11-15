using System;

namespace myProject.Models
{
    internal class IndexAttribute : Attribute
    {
        public bool IsUnique { get; set; }
    }
}