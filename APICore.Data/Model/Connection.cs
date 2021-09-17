using System;
using System.Collections.Generic;

#nullable disable

namespace APICore.Data.Model
{
    public partial class Connection
    {
        public int ConnectionsId { get; set; }
        public int ConnectionsNodeFrom { get; set; }
        public int ConnectionsNodeTo { get; set; }

        public virtual Node ConnectionsNodeFromNavigation { get; set; }
        public virtual Node ConnectionsNodeToNavigation { get; set; }
    }
}
