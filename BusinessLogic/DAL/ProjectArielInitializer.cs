using BusinessLogic.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace BusinessLogic.DAL
{
	public class ProjectArielInitializer : DropCreateDatabaseIfModelChanges<ProjectArielContext>
	{
		protected override void Seed(ProjectArielContext context)
		{
			var players = new List<Player>
			{
				new Player { Name = "Liam Neeson", ID = 1, IsActive = true},
				new Player { Name = "Rachel McAdams", ID = 2, IsActive = true},
				new Player { Name = "Simone Simons", ID = 3, IsActive = true}
			};

			players.ForEach(p => context.Players.Add(p));
			context.SaveChanges();
		}
	}
}