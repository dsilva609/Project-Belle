namespace BusinessLogic.Migrations
{
	using BusinessLogic.Enums;
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

			context.Cards.AddOrUpdate(x => x.Name,
				new Card { Name = "Guard", ID = 1, Rank = Rank.One, IsActive = true },
				new Card { Name = "Priest", ID = 2, Rank = Rank.Two, IsActive = true },
				new Card { Name = "Baron", ID = 3, Rank = Rank.Three, IsActive = true },
				new Card { Name = "Handmaid", ID = 4, Rank = Rank.Four, IsActive = true },
				new Card { Name = "Prince", ID = 5, Rank = Rank.Five, IsActive = true },
				new Card { Name = "King", ID = 6, Rank = Rank.Six, IsActive = true },
				new Card { Name = "Countess", ID = 7, Rank = Rank.Seven, IsActive = true },
				new Card { Name = "Princess", ID = 8, Rank = Rank.Eight, IsActive = true }
			);

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