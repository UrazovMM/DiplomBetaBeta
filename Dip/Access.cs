using System;
using System.Collections.Generic;

namespace Dip
{
    public partial class Access
    {
        public int IdAccess { get; set; }
        public bool? ViewClient { get; set; }
        public bool? ViewWorker { get; set; }
        public bool? Adding { get; set; }
        public bool? Editing { get; set; }
        public bool? Deleting { get; set; }
    }
}
