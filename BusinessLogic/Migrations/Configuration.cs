namespace BusinessLogic.Migrations
{
	using BusinessLogic.Models;
	using System.Data.Entity.Migrations;

	internal sealed class Configuration : DbMigrationsConfiguration<BusinessLogic.DAL.ProjectBelleContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(BusinessLogic.DAL.ProjectBelleContext context)
		{
			context.Players.AddOrUpdate(x => x.Name,
				 new Player { Name = "Smitty Werbenjagermanjensen", ID = 1, IsActive = true },
				 new Player { Name = "Liam Neeson", ID = 2, IsActive = true },
				 new Player { Name = "Rachel McAdams", ID = 3, IsActive = true },
				 new Player { Name = "Marky Mark and the Funky Bunch", ID = 4, IsActive = true }
			 );

			#region Cards

			//

			#endregion Cards

			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method
			//  to avoid creating duplicate seed data. E.g.
			//
			//    context.People.AddOrUpdate(
			//      p => p.FullName,
			//      new Person { FullName = "Andrew Peters" },
			//      new Person { FullName = "Brice Lambson" },
			//      new Person { FullName = "Rowan Miller" }
			//    );
			//
		}
	}
}