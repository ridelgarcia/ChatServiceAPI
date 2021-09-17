using System.Collections.Generic;
using System.Text;

#nullable disable

namespace APICore.Data.Model
{
    public partial class Channel
    {
        public Channel()
        {
            Messages = new HashSet<Message>();
        }

        public int ChannelId { get; set; }
        public int ChannelType { get; set; }

        public virtual Node ChannelNavigation { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}