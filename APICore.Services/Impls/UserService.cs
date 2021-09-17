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

        public Task<GetContactListResponse> GetContactList(GetContactListRequest requestData)
        {
            Console.WriteLine("1.1");
            GetContactListResponse response = new GetContactListResponse();
            Console.WriteLine("1.1.1");
            List<Connection> connections = _uow.ConnectionRepository.FindBy(x => x.ConnectionsNodeFrom == requestData.UserId && _uow.NodeRepository.FindBy(y => y.NodeType == 3 && y.NodeId == x.ConnectionsNodeTo).ToArray().Length > 0).ToList();
            Console.WriteLine("1.2");
            foreach (Connection conn in connections)
            {
                Console.WriteLine("1.3");
                List<Connection> contactConnections = _uow.ConnectionRepository.FindAll(x => x.ConnectionsNodeTo == conn.ConnectionsNodeTo && x.ConnectionsNodeFrom != requestData.UserId).ToList();
                Console.WriteLine("1.4");
                foreach (Connection contconn in contactConnections)
                {
                    Console.WriteLine("1.5");
                    User user = _uow.UserRepository.Find(x => x.UserId == contconn.ConnectionsNodeFrom);
                    if (user != null)
                    {
                        var contact = new ContactResponse();
                        contact.Id = user.UserId;
                        contact.ContactName = user.UserName;
                        contact.ContactLastName = user.UserLastName;
                        contact.ContactEmail = user.UserEmail;
                        contact.ContactAvatarUrl = user.UserAvatarUrl;
                        contact.ContactStatus = user.UserStatus;
                        response.ContactList.Add(contact);
                    }
                }
            }
            return Task.FromResult(response);
        }
    }
}