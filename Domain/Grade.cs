using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Grade
    {
        public int GradeId { get; set; }
        public int GradetypeId { get; set; }
        public string Description { get; set; }
        public DateTime Timegiven { get; set; }
        public int StudentinsubjectId { get; set; }

        public virtual Studentinsubject Studentinsubject { get; set; }
    }
}
