namespace BusinessLogic.Migrations
{
	using BusinessLogic.Enums;
	using BusinessLogic.Models;
	using System.Data.Entity.Migrations;

	internal sealed class Configuration : DbMigrationsConfiguration<BusinessLogic.DAL.ProjectArielContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(BusinessLogic.DAL.ProjectArielContext context)
		{
			context.Players.AddOrUpdate(x => x.Name,
				 new Player { Name = "Smitty Werbenjagermanjensen", ID = 1, IsActive = true },
				 new Player { Name = "Liam Neeson", ID = 2, IsActive = true },
				 new Player { Name = "Rachel McAdams", ID = 3, IsActive = true },
				 new Player { Name = "Marky Mark and the Funky Bunch", ID = 4, IsActive = true }
			 );

			#region Cards

			#region Roles

			context.Cards.AddOrUpdate(x => x.Name,
				new Card { Name = "Sheriff", ID = 1, Expansion = Expansion.Standard, Cardtype = CardType.Role, IsActive = true },
				new Card { Name = "Deputy", ID = 2, Expansion = Expansion.Standard, Cardtype = CardType.Role, IsActive = true },
				new Card { Name = "Outlaw", ID = 3, Expansion = Expansion.Standard, Cardtype = CardType.Role, IsActive = true },
				new Card { Name = "Renegade", ID = 4, Expansion = Expansion.Standard, Cardtype = CardType.Role, IsActive = true }
			);

			#endregion Roles

			#region Characters

			context.Cards.AddOrUpdate(x => x.Name,
				//--Standard Expansion
				new Card { Name = "Bart Cassidy", Expansion = Expansion.Standard, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Black Jack", Expansion = Expansion.Standard, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Calamity Janet", Expansion = Expansion.Standard, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "El Gringo", Expansion = Expansion.Standard, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Jesse Jones", Expansion = Expansion.Standard, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Jourdonnais", Expansion = Expansion.Standard, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Kit Carlson", Expansion = Expansion.Standard, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Lucky Duke", Expansion = Expansion.Standard, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Paul Regret", Expansion = Expansion.Standard, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Pedro Ramirez", Expansion = Expansion.Standard, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Rose Doolan", Expansion = Expansion.Standard, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Sid Ketchum", Expansion = Expansion.Standard, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Slab the Killer", Expansion = Expansion.Standard, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Suzy Lafayette", Expansion = Expansion.Standard, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Vulture Sam", Expansion = Expansion.Standard, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Willy the Kid", Expansion = Expansion.Standard, Cardtype = CardType.Character, IsActive = true },

				//--Dodge City
				new Card { Name = "Apache Kid", Expansion = Expansion.DodgeCity, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Belle Star", Expansion = Expansion.DodgeCity, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Bill Noface", Expansion = Expansion.DodgeCity, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Chuck Wengam", Expansion = Expansion.DodgeCity, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Doc Holyday", Expansion = Expansion.DodgeCity, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Elena Fuente", Expansion = Expansion.DodgeCity, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Greg Digger", Expansion = Expansion.DodgeCity, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Herb Hunter", Expansion = Expansion.DodgeCity, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Jose Delgado", Expansion = Expansion.DodgeCity, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Molly Stark", Expansion = Expansion.DodgeCity, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Pat Brennan", Expansion = Expansion.DodgeCity, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Pixie Pete", Expansion = Expansion.DodgeCity, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Sean Mallory", Expansion = Expansion.DodgeCity, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Tequila Joe", Expansion = Expansion.DodgeCity, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Vera Custer", Expansion = Expansion.DodgeCity, Cardtype = CardType.Character, IsActive = true },

				//--Wild West Show
				new Card { Name = "Flint Westwood", Expansion = Expansion.WildWestShow, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Big Spencer", Expansion = Expansion.WildWestShow, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Lee Van Cleef", Expansion = Expansion.WildWestShow, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Youl Grinner", Expansion = Expansion.WildWestShow, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "John Pain", Expansion = Expansion.WildWestShow, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Greygory Deck", Expansion = Expansion.WildWestShow, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Gary Looter", Expansion = Expansion.WildWestShow, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Teren Kill", Expansion = Expansion.WildWestShow, Cardtype = CardType.Character, IsActive = true },

				//--Gold Rush
				new Card { Name = "Don Bell", Expansion = Expansion.GoldRush, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Dutch Will", Expansion = Expansion.GoldRush, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Jacky Murieta", Expansion = Expansion.GoldRush, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Josh McCloud", Expansion = Expansion.GoldRush, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Madam Yto", Expansion = Expansion.GoldRush, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Pretty Luzena", Expansion = Expansion.GoldRush, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Raddie Snake", Expansion = Expansion.GoldRush, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Simeon Picos", Expansion = Expansion.GoldRush, Cardtype = CardType.Character, IsActive = true },

				//--Valley of Shadows
				new Card { Name = "Limonade Jim", Expansion = Expansion.ValleyOfShadows, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Henry Block", Expansion = Expansion.ValleyOfShadows, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Evelyn the Bang", Expansion = Expansion.ValleyOfShadows, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Colorado Bill", Expansion = Expansion.ValleyOfShadows, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Mick Defender", Expansion = Expansion.ValleyOfShadows, Cardtype = CardType.Character, IsActive = true },

				//--Bang! The Bullet
				new Card { Name = "Uncle Will", Expansion = Expansion.BangTheBullet, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Johnny Kisch", Expansion = Expansion.BangTheBullet, Cardtype = CardType.Character, IsActive = true },
				new Card { Name = "Claus \"The Saint\"", Expansion = Expansion.BangTheBullet, Cardtype = CardType.Character, IsActive = true },

				//--Anniversary
				new Card { Name = "Annie Versary", Expansion = Expansion.Anniversary, Cardtype = CardType.Character, IsActive = true }

			);

			#endregion Characters

			#region Playable Cards

			#region Basic

			context.Cards.AddOrUpdate(x => x.Name,
				new Card { Name = "Bang!", Expansion = Expansion.Standard, Cardtype = CardType.Basic, IsActive = true },
				new Card { Name = "Missed!", Expansion = Expansion.Standard, Cardtype = CardType.Basic, IsActive = true },
				new Card { Name = "Beer", Expansion = Expansion.Standard, Cardtype = CardType.Alcohol, IsActive = true },
				new Card { Name = "Panic!", Expansion = Expansion.Standard, Cardtype = CardType.Draw, Range = 1, IsActive = true },
				new Card { Name = "Cat Balou", Expansion = Expansion.Standard, Cardtype = CardType.Draw, IsActive = true },
				new Card { Name = "Stagecoach", Expansion = Expansion.Standard, Cardtype = CardType.Draw, IsActive = true },
				new Card { Name = "Wells Fargo", Expansion = Expansion.Standard, Cardtype = CardType.Draw, IsActive = true },
				new Card { Name = "Gatling", Expansion = Expansion.Standard, Cardtype = CardType.TargetAll, IsActive = true },
				new Card { Name = "Indians!", Expansion = Expansion.Standard, Cardtype = CardType.TargetAll, IsActive = true },
				new Card { Name = "Duel", Expansion = Expansion.Standard, Cardtype = CardType.Event, IsActive = true },
				new Card { Name = "General Store", Expansion = Expansion.Standard, Cardtype = CardType.Event, IsActive = true },
				new Card { Name = "Saloon", Expansion = Expansion.Standard, Cardtype = CardType.Event, IsActive = true },
				new Card { Name = "Jail", Expansion = Expansion.Standard, Cardtype = CardType.TimeDelay, IsActive = true },
				new Card { Name = "Dynamite", Expansion = Expansion.Standard, Cardtype = CardType.TimeDelay, IsActive = true },
				new Card { Name = "Barrel", Expansion = Expansion.Standard, Cardtype = CardType.Equipment, IsActive = true },
				new Card { Name = "Scope", Expansion = Expansion.Standard, Cardtype = CardType.Equipment, IsActive = true },
				new Card { Name = "Mustang", Expansion = Expansion.Standard, Cardtype = CardType.Equipment, IsActive = true }
			);

			#endregion Basic

			#region Weapons

			context.Cards.AddOrUpdate(x => x.Name,
				new Card { Name = "Volcanic", Expansion = Expansion.Standard, Cardtype = CardType.Weapon, Range = 1, IsActive = true },
				new Card { Name = "Schofield", Expansion = Expansion.Standard, Cardtype = CardType.Weapon, Range = 2, IsActive = true },
				new Card { Name = "Remington", Expansion = Expansion.Standard, Cardtype = CardType.Weapon, Range = 3, IsActive = true },
				new Card { Name = "Rev. Carabine", Expansion = Expansion.Standard, Cardtype = CardType.Weapon, Range = 4, IsActive = true },
				new Card { Name = "Winchester", Expansion = Expansion.Standard, Cardtype = CardType.Weapon, Range = 5, IsActive = true }
			);

			#endregion Weapons

			#region Events

			//--Placeholder

			#endregion Events

			#endregion Playable Cards

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