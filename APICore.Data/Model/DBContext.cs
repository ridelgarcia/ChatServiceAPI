using Microsoft.EntityFrameworkCore;

#nullable disable

namespace APICore.Data.Model
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Channel> Channels { get; set; }
        public virtual DbSet<Connection> Connections { get; set; }
        public virtual DbSet<ContactType> ContactTypes { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Node> Nodes { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=TAURO\\SQLEXPRESS;Database=test;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Channel>(entity =>
            {
                entity.ToTable("Channel");

                entity.Property(e => e.ChannelId)
                    .ValueGeneratedNever()
                    .HasColumnName("channel_id");

                entity.Property(e => e.ChannelType).HasColumnName("channel_type");

                entity.HasOne(d => d.ChannelNavigation)
                    .WithOne(p => p.Channel)
                    .HasForeignKey<Channel>(d => d.ChannelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Channel_Node_Id");
            });

            modelBuilder.Entity<Connection>(entity =>
            {
                entity.HasKey(e => new { e.ConnectionsNodeFrom, e.ConnectionsNodeTo })
                    .IsClustered(false);

                entity.Property(e => e.ConnectionsNodeFrom).HasColumnName("connections_node_from");

                entity.Property(e => e.ConnectionsNodeTo).HasColumnName("connections_node_to");
            });

            modelBuilder.Entity<ContactType>(entity =>
            {
                entity.ToTable("ContactType");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Contacttypename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("contacttypename");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.MessageId)
                    .IsClustered(false);

                entity.ToTable("Message");

                entity.Property(e => e.MessageId).HasColumnName("message_id");

                entity.Property(e => e.MessageChannelId).HasColumnName("message_channel_id");

                entity.Property(e => e.MessageContent)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("message_content");

                entity.Property(e => e.MessageTimestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("message_timestamp")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MessageUserId).HasColumnName("message_user_id");
            });

            modelBuilder.Entity<Node>(entity =>
            {
                entity.ToTable("Node");

                entity.Property(e => e.NodeId).HasColumnName("node_id");

                entity.Property(e => e.NodeType).HasColumnName("node_type");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("Reservation");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("date")
                    .HasColumnName("birthdate");

                entity.Property(e => e.Contacttypeid).HasColumnName("contacttypeid");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Text)
                    .HasMaxLength(50)
                    .HasColumnName("text");

                entity.HasOne(d => d.Contacttype)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.Contacttypeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservation_ContactType_Id");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.UserAvatarUrl)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("user_avatar_url");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("user_email");

                entity.Property(e => e.UserLastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("user_last_name");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("user_name");

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("user_password");

                entity.Property(e => e.UserStatus).HasColumnName("user_status");

                entity.HasOne(d => d.UserNavigation)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Node_Id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}