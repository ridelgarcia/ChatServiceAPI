using APICore.Common.DTO.Request;
using APICore.Common.DTO.Response;
using APICore.Data.UoW;
using APICore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using APICore.Data.Model;

namespace APICore.Services.Impls
{
    public class ChannelService : IChannelService
    {
        private IUnitOfWork _uow;

        public ChannelService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<AddChannelResponse> AddChannel(AddChannelRequest requestData)
        {
            User user1 = _uow.UserRepository.Find(x => x.UserId == requestData.User1Id);
            User user2 = _uow.UserRepository.Find(y => y.UserId == requestData.User2Id);
            var response = new AddChannelResponse();
            if (user1 != null && user2 != null)
            {
                Node channelNode = new Node();
                channelNode.NodeType = 1;
                await _uow.NodeRepository.AddAsync(channelNode);
                await _uow.CommitAsync();
                Channel channel = new Channel();
                channel.ChannelId = channelNode.NodeId;
                channel.ChannelType = 0;
                await _uow.ChannelRepository.AddAsync(channel);
                await _uow.CommitAsync();
                Connection conn1 = new Connection();
                Connection conn2 = new Connection();
                conn1.ConnectionsNodeFrom = requestData.User1Id;
                conn1.ConnectionsNodeTo = channel.ChannelId;
                conn2.ConnectionsNodeFrom = requestData.User2Id;
                conn2.ConnectionsNodeTo = channel.ChannelId;
                await _uow.ConnectionRepository.AddAsync(conn1);
                await _uow.ConnectionRepository.AddAsync(conn2);
                await _uow.CommitAsync();
                response.ChannelId = channel.ChannelId;
                response.ChannelType = channel.ChannelType;
            }
            else
            {
                throw new Exception("The users are not valid");
            }
            return await Task.FromResult(response);
        }
    }
}