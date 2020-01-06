using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Gradetype
    {
        public int Pk { get; set; }
        public string Value { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
