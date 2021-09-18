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
        }

        public List<UserResponse> UsersToNotify { get; set; }
    }
}