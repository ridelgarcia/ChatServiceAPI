using System;
using System.Collections.Generic;
using System.Text;

namespace APICore.Common.DTO.Response
{
    public class ContactTypeResponse
    {
        public int Id { get; set; }

        public string ContactTypeName { get; set; }
    }
    public class GetAllContactTypeResponse
    {
        public GetAllContactTypeResponse()
        { 
        
        }
        public List<ContactTypeResponse> ContactTypeList { get; set; }
    }
}
