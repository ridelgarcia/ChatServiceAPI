using APICore.Data.Model;
using APICore.Data.Repository;
using System;
using System.Threading.Tasks;

namespace APICore.Data.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Channel> ChannelRepository { get; set; }
        IGenericRepository<Connection> ConnectionRepository { get; set; }
        IGenericRepository<ContactType> ContactTypeRepository { get; set; }
        IGenericRepository<Message> MessageRepository { get; set; }
        IGenericRepository<Node> NodeRepository { get; set; }
        IGenericRepository<Reservation> ReservationRepository { get; set; }
        IGenericRepository<User> UserRepository { get; set; }

        Task<int> CommitAsync();
    }
}