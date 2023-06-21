using System;
using System.Collections.Generic;

namespace Dip
{
    public partial class Position
    {
        public Position()
        {
            Workers = new HashSet<Worker>();
        }

        public int IdPosition { get; set; }
        public string? NamePosition { get; set; }

        public virtual ICollection<Worker> Workers { get; set; }
    }
}
