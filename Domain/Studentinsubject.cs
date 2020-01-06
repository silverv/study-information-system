using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Studentinsubject
    {
        public Studentinsubject()
        {
            GradeNavigation = new HashSet<Grade>();
        }

        public int Pk { get; set; }
        public int SubjectId { get; set; }
        public bool? Pass { get; set; }
        public int? Grade { get; set; }
        public int? Semesteryear { get; set; }
        public bool? Autumnsemester { get; set; }
        public bool? Springsemester { get; set; }
        public DateTime? Timeregistered { get; set; }
        public bool? Confirmed { get; set; }
        public int StudentId { get; set; }

        public virtual ICollection<Grade> GradeNavigation { get; set; }
    }
}
