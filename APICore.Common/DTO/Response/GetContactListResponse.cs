using System.Collections.Generic;

namespace APICore.Common.DTO.Response
{
    public class GetContactListResponse
    {
        public GetContactListResponse()
        {
            ContactList = new List<ContactResponse>();
        }

        public List<ContactResponse> ContactList { get; set; }
    }
}