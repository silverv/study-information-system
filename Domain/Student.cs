using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string Code { get; set; }
        public string Personalcode { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
