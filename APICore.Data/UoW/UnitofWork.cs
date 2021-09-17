using APICore.Data.Model;
using APICore.Data.Repository;
using System;
using System.Threading.Tasks;

namespace APICore.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBContext _context;

        private bool disposed = false;

        public UnitOfWork(DBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            ChannelRepository = ChannelRepository ?? new GenericRepository<Channel>(_context);
            ConnectionRepository = ConnectionRepository ?? new GenericRepository<Connection>(_context);
            ContactTypeRepository = ContactTypeRepository ?? new GenericRepository<ContactType>(_context);
            MessageRepository = MessageRepository ?? new GenericRepository<Message>(_context);
            NodeRepository = NodeRepository ?? new GenericRepository<Node>(_context);
            ReservationRepository = ReservationRepository ?? new GenericRepository<Reservation>(_context);
            UserRepository = UserRepository ?? new GenericRepository<User>(_context);
        }

        public IGenericRepository<Channel> ChannelRepository { get; set; }
        public IGenericRepository<Connection> ConnectionRepository { get; set; }
        public IGenericRepository<ContactType> ContactTypeRepository { get; set; }
        public IGenericRepository<Message> MessageRepository { get; set; }
        public IGenericRepository<Node> NodeRepository { get; set; }
        public IGenericRepository<Reservation> ReservationRepository { get; set; }
        public IGenericRepository<User> UserRepository { get; set; }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}