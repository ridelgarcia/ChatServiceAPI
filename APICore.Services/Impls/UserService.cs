using APICore.Common.DTO.Request;
using APICore.Common.DTO.Response;
using APICore.Data.Model;
using APICore.Data.UoW;
using APICore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICore.Services.Impls
{
    public class UserService : IUserService
    {
        private IUnitOfWork _uow;

        public UserService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<GetContactListResponse> GetContactList(GetContactListRequest requestData)
        {
            GetContactListResponse response = new GetContactListResponse();
            List<Connection> connections = _uow.ConnectionRepository.FindBy(x => x.ConnectionsNodeFrom == requestData.UserId).ToList();
            foreach (Connection conn in connections)
            {
                List<Connection> contactConnections = _uow.ConnectionRepository.FindAll(x => x.ConnectionsNodeTo == conn.ConnectionsNodeTo && x.ConnectionsNodeFrom != requestData.UserId).ToList();
                foreach (Connection contconn in contactConnections)
                {
                    Node node = _uow.NodeRepository.Find(x => x.NodeId == contconn.ConnectionsNodeTo && x.NodeType == 2);

                    if (node != null)
                    {
                        User user = _uow.UserRepository.Find(x => x.UserId == contconn.ConnectionsNodeFrom);
                        if (user != null)
                        {
                            response.ContactList.Add(MapUserToContactResponse(user));
                        }
                    }
                }
            }
            return await Task.FromResult(response);
        }

        public async Task<ChangeUserStatusResponse> ChanageUserStatus(ChangeUserStatusRequest requestData)
        {
            User user = _uow.UserRepository.Find(x => x.UserId == requestData.UserId);
            ChangeUserStatusResponse response = new ChangeUserStatusResponse();
            if (user != null)
            {
                user.UserStatus = requestData.UserStatus;
                _uow.UserRepository.Update(user);
                await _uow.CommitAsync();
                response.Contact = MapUserToContactResponse(user);
            }
            return await Task.FromResult(response);
        }

        private ContactResponse MapUserToContactResponse(User user)
        {
            var contact = new ContactResponse();
            contact.Id = user.UserId;
            contact.ContactName = user.UserName;
            contact.ContactLastName = user.UserLastName;
            contact.ContactEmail = user.UserEmail;
            contact.ContactAvatarUrl = user.UserAvatarUrl;
            contact.ContactStatus = user.UserStatus;
            return contact;
        }
    }
}