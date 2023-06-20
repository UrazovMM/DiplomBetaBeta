using System;
using System.Collections.Generic;

namespace Dip
{
    public partial class Note
    {
        public int IdNote { get; set; }
        public string? Notes { get; set; }
        public int? ClientClientId { get; set; }

        public virtual Client? ClientClient { get; set; }
    }
}
