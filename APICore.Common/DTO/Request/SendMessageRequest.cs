using System;
using System.Collections.Generic;
using System.Text;

namespace APICore.Common.DTO.Request
{
    public class SendMessageRequest
    {
        public int UserId { get; set; }
        public int ChannelId { get; set; }
        public string Content { get; set; }
    }
}