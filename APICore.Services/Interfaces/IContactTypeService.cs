using APICore.Common.DTO.Response;
using APICore.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APICore.Services.Interfaces
{
    public interface IContactTypeService
    {
        Task<GetAllContactTypeResponse> GetAllContactTypes();
    }
}
