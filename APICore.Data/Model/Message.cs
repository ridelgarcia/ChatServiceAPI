#nullable disable

namespace APICore.Data.Model
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public int MessageChannelId { get; set; }
        public int MessageUserId { get; set; }
        public string MessageContent { get; set; }
        public byte[] MessageTimestamp { get; set; }

        public virtual Channel MessageChannel { get; set; }
        public virtual User MessageUser { get; set; }
    }
}