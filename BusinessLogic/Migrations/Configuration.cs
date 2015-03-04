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
				new Card { Name = "Guard", ID = 1, Rank = Rank.One, RankString = "One", Rarity = 5, Description = "Name a non-Guard card and choose another player. If that player has that card, he or she is out of the round.", IsActive = true },
				new Card { Name = "Priest", ID = 2, Rank = Rank.Two, RankString = "Two", Rarity = 2, Description = "Look at another player's hand.", IsActive = true },
				new Card { Name = "Baron", ID = 3, Rank = Rank.Three, RankString = "Three", Rarity = 2, Description = "You and another player secretly compare hands. The player with the lower value is out of the round.", IsActive = true },
				new Card { Name = "Handmaid", ID = 4, Rank = Rank.Four, RankString = "Four", Rarity = 2, Description = "Until your next turn, ignore all effects from other players' cards.", IsActive = true },
				new Card { Name = "Prince", ID = 5, Rank = Rank.Five, RankString = "Five", Rarity = 2, Description = "Choose any player (including yourself) to discard his or her hand and draw a new card.", IsActive = true },
				new Card { Name = "King", ID = 6, Rank = Rank.Six, RankString = "Six", Rarity = 1, Description = "Trade hands with another player of your choice.", IsActive = true },
				new Card { Name = "Countess", ID = 7, Rank = Rank.Seven, RankString = "Seven", Rarity = 1, Description = "If you have this card and the King or Prince in your hand, you must discard this card.", IsActive = true },
				new Card { Name = "Princess", ID = 8, Rank = Rank.Eight, RankString = "Eight", Rarity = 1, Description = "If you discard this card, you are out of the round.", IsActive = true }
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