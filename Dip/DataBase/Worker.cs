using System;
using System.Collections.Generic;

namespace Dip
{
    public partial class Worker
    {
        public Worker()
        {
            Clients = new HashSet<Client>();
        }

        public int WorkerId { get; set; }
        public string NameWorker { get; set; } = null!;
        public int? Position { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }

        public virtual Position? PositionNavigation { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
    }
}
