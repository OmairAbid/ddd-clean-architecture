using Persistence.Commands.ORM.EntityConfigurations;
using static Application.Commands.Common.Constants.Constants;

namespace Persistence.Commands.ORM
{
	public class AppDBContext : DbContext
	{
		#region Public Properties

		public DbSet<Connector> Connector { get; set; }

		public DbSet<ConnectorDetail> ConnectorDetail { get; set; }

		public DbSet<SystemSetting> SystemSetting { get; set; }
		public DbSet<Profile> Profile { get; set; }
		public DbSet<ProfileDetail> ProfileDetail { get; set; }
		public DbSet<ProfileDetailValue> ProfileDetailValues { get; set; }

		#endregion Public Properties

		#region Public Constructors

		public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
		{
		}

		#endregion Public Constructors

		#region Public Methods

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			foreach (var entry in ChangeTracker.Entries<EntityBase>())
			{
				switch (entry.State)
				{
                    case EntityState.Added:
                        entry.Entity.CreatedOn = DateTime.UtcNow;
                        entry.Entity.CreatedBy = DatabaseStaticData.ADMIN;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedOn = DateTime.UtcNow;
                        entry.Entity.LastModifiedBy = DatabaseStaticData.ADMIN;
                        break;
                }
			}

			return base.SaveChangesAsync(cancellationToken);
		}

		#endregion Public Methods

		#region Protected Methods

		protected override void OnModelCreating(ModelBuilder builder)
		{
			new SystemSettingEntityConfiguration().Configure(builder.Entity<SystemSetting>());
			new ConnectorEntityConfiguration().Configure(builder.Entity<Connector>());
			new ConnectorDetailEntityConfiguration().Configure(builder.Entity<ConnectorDetail>());
			new ProfileEntityConfiguration().Configure(builder.Entity<Profile>());
            new ProfileDetailEntityConfiguration().Configure(builder.Entity<ProfileDetail>());
			new ProfileDetailValueEntityConfiguration().Configure(builder.Entity<ProfileDetailValue>());
        }

        #endregion Protected Methods
    }
}