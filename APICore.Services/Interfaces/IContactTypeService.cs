using APICore.Common.DTO.Response;
using System.Threading.Tasks;

namespace APICore.Services.Interfaces
{
    public interface IContactTypeService
    {
        Task<GetAllContactTypeResponse> GetAllContactTypes();
    }
}