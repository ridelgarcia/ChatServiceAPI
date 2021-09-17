using APICore.Common.DTO.Request;
using APICore.Common.DTO.Response;
using System.Threading.Tasks;

namespace APICore.Services.Interfaces
{
    public interface IUserService
    {
        public Task<GetContactListResponse> GetContactList(GetContactListRequest requestData);

        public Task<ChangeUserStatusResponse> ChanageUserStatus(ChangeUserStatusRequest requestData);
    }
}