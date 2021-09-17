using System.Collections.Generic;

#nullable disable

namespace APICore.Data.Model
{
    public partial class Node
    {
        public Node()
        {
            ConnectionConnectionsNodeFromNavigations = new HashSet<Connection>();
            ConnectionConnectionsNodeToNavigations = new HashSet<Connection>();
        }

        public int NodeId { get; set; }
        public int NodeType { get; set; }

        public virtual Channel Channel { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Connection> ConnectionConnectionsNodeFromNavigations { get; set; }

        public virtual ICollection<Connection> ConnectionConnectionsNodeToNavigations { get; set; }
    }
}