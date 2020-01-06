using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Teacherofsubject
    {
        public int Pk { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
        public string Sincesemester { get; set; }
    }
}
