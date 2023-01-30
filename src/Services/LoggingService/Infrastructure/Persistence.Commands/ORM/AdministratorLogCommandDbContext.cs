using Persistence.Commands.ORM.EntityConfigurations;

namespace Persistence.Commands.ORM
{
    public class AdministratorLogCommandDbContext : DbContext
    {
        #region Public Constructors

        public AdministratorLogCommandDbContext(DbContextOptions<AdministratorLogCommandDbContext> options) : base(options)
        {
        }

        #endregion Public Constructors

        #region Public Properties

        public DbSet<AdministratorLog> AdministratorLog { get; set; }

        public DbSet<AdministratorLogDetail> AdministratorLogDetail { get; set; }

        public DbSet<Profile> Profile { get; set; }

        public DbSet<Serviceplan> Serviceplan { get; set; }

        #endregion Public Properties

        #region Public Methods

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedOn = DateTime.Now;
                        if (entry.Entity.GetType() == AdministratorLog.GetType())
                            entry.Entity.LastModifiedBy = "ADMIN";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        #endregion Public Methods

        #region Protected Methods

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new AdministratorLogEntityConfiguration().Configure(builder.Entity<AdministratorLog>());
            new AdministratorLogDetailEntityConfiguration().Configure(builder.Entity<AdministratorLogDetail>());
            new ProfileEntityConfiguration().Configure(builder.Entity<Profile>());
            new ServiceplanEntityConfiguration().Configure(builder.Entity<Serviceplan>());
        }

        #endregion Protected Methods
    }
}