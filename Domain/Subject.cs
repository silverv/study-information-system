using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Ects { get; set; }
    }
}
