using System;
using System.Collections.Generic;

#nullable disable

namespace APICore.Data.Model
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public int MessageChannelId { get; set; }
        public int MessageUserId { get; set; }
        public string MessageContent { get; set; }
        public DateTime? MessageTimestamp { get; set; }
    }
}
