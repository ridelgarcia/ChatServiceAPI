using System;
using System.Collections.Generic;
using System.Text;

namespace APICore.Common.DTO.Response
{
    public class ChangeUserStatusResponse
    {
        public ChangeUserStatusResponse()
        {
            Contact = new ContactResponse();
        }

        public ContactResponse Contact { get; set; }
    }
}