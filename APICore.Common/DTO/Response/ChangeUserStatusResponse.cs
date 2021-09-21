using System;
using System.Collections.Generic;
using System.Text;

namespace APICore.Common.DTO.Response
{
    public class ChangeUserStatusResponse
    {
        public ChangeUserStatusResponse()
        {
            User = new UserResponse();
        }

        public UserResponse User { get; set; }
    }
}