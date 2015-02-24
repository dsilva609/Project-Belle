using BusinessLogic.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BusinessLogic.DAL
{
	public class ProjectArielContext : DbContext
	{
		public DbSet<Player> Players { get; set; }

		public DbSet<Card> Cards { get; set; }

		public ProjectArielContext()
			: base("ProjectAriel")
		{
			this.Configuration.LazyLoadingEnabled = false;
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}