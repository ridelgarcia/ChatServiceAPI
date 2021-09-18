﻿using System;
using System.Collections.Generic;

#nullable disable

namespace APICore.Data.Model
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserAvatarUrl { get; set; }
        public int UserStatus { get; set; }

        public virtual Node UserNavigation { get; set; }
    }
}
