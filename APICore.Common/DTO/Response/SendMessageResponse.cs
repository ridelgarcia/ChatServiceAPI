using System;
using System.Collections.Generic;
using System.Text;

namespace APICore.Common.DTO.Response
{
    public class SendMessageResponse
    {
        public SendMessageResponse()
        {
            UsersToNotify = new List<UserResponse>();
            Message = new MessageResponse();
        }

        public List<UserResponse> UsersToNotify { get; set; }

        public MessageResponse Message { get; set; }
    }
}