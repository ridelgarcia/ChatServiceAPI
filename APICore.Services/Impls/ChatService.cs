using APICore.Common.DTO.Request;
using APICore.Common.DTO.Response;
using APICore.Data.Model;
using APICore.Data.UoW;
using APICore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APICore.Services.Impls
{
    public class ChatService : IChatService
    {
        private IUnitOfWork _uow;

        public ChatService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<SendMessageResponse> SendMessage(SendMessageRequest requestData)
        {
            var response = new SendMessageResponse();
            var user = _uow.UserRepository.Find(x => x.UserId == requestData.UserId);
            var channel = _uow.ChannelRepository.Find(x => x.ChannelId == requestData.ChannelId);
            var connection = _uow.ConnectionRepository.Find(x => x.ConnectionsNodeFrom == requestData.UserId && x.ConnectionsNodeTo == requestData.ChannelId);
            if (user != null && channel != null && connection != null)
            {
                Message message = new Message();
                message.MessageUserId = user.UserId;
                message.MessageChannelId = channel.ChannelId;
                message.MessageContent = requestData.Content;
                await _uow.MessageRepository.AddAsync(message);
                await _uow.CommitAsync();
                var connectionList = _uow.ConnectionRepository.FindAll(x => x.ConnectionsNodeTo == connection.ConnectionsNodeTo);
                foreach (Connection conn in connectionList)
                {
                    var userToNotify = _uow.UserRepository.Find(x => x.UserId == conn.ConnectionsNodeFrom && x.UserStatus != 0);
                    if (userToNotify != null)
                    {
                        var userResponse = MapUserToUserResponse(userToNotify);
                        response.UsersToNotify.Add(userResponse);
                    }
                }
            }
            else
                throw new Exception("Input Data are invalid");
            return await Task.FromResult(response);
        }

        private UserResponse MapUserToUserResponse(User user)
        {
            UserResponse userResponse = new UserResponse
            {
                UserId = user.UserId,
                UserName = user.UserName,
                UserLastName = user.UserLastName,
                UserEmail = user.UserEmail,
                UserAvatarUrl = user.UserAvatarUrl,
                UserStatus = user.UserStatus
            };
            return userResponse;
        }
    }
}