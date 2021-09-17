﻿using System.Collections.Generic;

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

    public class GetContactListResponse
    {
        public GetContactListResponse()
        {
            ContactList = new List<ContactResponse>();
        }

        public List<ContactResponse> ContactList { get; set; }
    }
}