using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Nagarro.Training.MVC.DAL
{
    public class BookReadingEventContext :  DbContext
    {
        public BookReadingEventContext() : base("BookReadingEventContext")
        {
        }
        public DbSet<EventEntity> EventEntity { get; set; }
        public DbSet<EventInvitesEntity> EventInvitesEntity { get; set; }
        public DbSet<UserEntity> UserEntity { get; set; }
        public DbSet<CommentsEntity> CommentsEntity { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

}

