using System;
using System.Collections.Generic;

namespace Dip
{
    public partial class Client
    {
        public Client()
        {
            Notes = new HashSet<Note>();
        }

        public int ClientId { get; set; }
        public string? NameClient { get; set; }
        public string? NameOrganisation { get; set; }
        public DateTime DateCreate { get; set; }
        public long Phone { get; set; }
        public string? Mail { get; set; }
        public int? WorkerWorkerId { get; set; }

        public virtual Worker? WorkerWorker { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
