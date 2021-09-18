using System;
using System.Collections.Generic;

#nullable disable

namespace APICore.Data.Model
{
    public partial class Node
    {
        public int NodeId { get; set; }
        public int NodeType { get; set; }

        public virtual Channel Channel { get; set; }
        public virtual User User { get; set; }
    }
}
