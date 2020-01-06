using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Teacher
    {
        public int TeacherId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Description { get; set; }
    }
}
