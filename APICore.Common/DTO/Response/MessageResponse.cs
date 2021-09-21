using System;
using System.Collections.Generic;
using System.Text;

namespace APICore.Common.DTO.Response
{
    public class MessageResponse
    {
        public int MessageId { get; set; }

        public int UserId { get; set; }

        public int ChannelId { get; set; }

        public string MessageContent { get; set; }

        public DateTime MessageTimeStamp { get; set; }
    }
}