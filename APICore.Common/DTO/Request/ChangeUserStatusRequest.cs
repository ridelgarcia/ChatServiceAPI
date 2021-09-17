using System;
using System.Collections.Generic;
using System.Text;

namespace APICore.Common.DTO.Request
{
    public class ChangeUserStatusRequest
    {
        public int UserId { get; set; }

        public int UserStatus { get; set; }
    }
}