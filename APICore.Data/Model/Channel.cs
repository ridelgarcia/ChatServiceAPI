using System;
using System.Collections.Generic;

#nullable disable

namespace APICore.Data.Model
{
    public partial class Channel
    {
        public int ChannelId { get; set; }
        public int ChannelType { get; set; }

        public virtual Node ChannelNavigation { get; set; }
    }
}
