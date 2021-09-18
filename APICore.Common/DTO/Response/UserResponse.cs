using System;
using System.Collections.Generic;
using System.Text;

namespace APICore.Common.DTO.Response
{
    public class UserResponse
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string UserLastName { get; set; }

        public string UserEmail { get; set; }

        public string UserAvatarUrl { get; set; }

        public int UserStatus { get; set; }
    }
}