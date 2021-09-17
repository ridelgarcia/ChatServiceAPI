using System;
using System.Collections.Generic;
using System.Text;

namespace APICore.Common.DTO.Response
{
    public class ContactResponse
    {
        public int Id { get; set; }

        public string ContactName { get; set; }

        public string ContactLastName { get; set; }

        public string ContactEmail { get; set; }

        public string ContactAvatarUrl { get; set; }

        public int ContactStatus { get; set; }
    }
}