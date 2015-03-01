using BusinessLogic.Enums;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
	public class CardViewModel
	{
		public string Name { get; set; }

		public int ID { get; set; }

		public string Description { get; set; }

		public string Action { get; set; }

		public Rank Rank { get; set; }

		[Display(Name = "Rank")]
		public string RankString { get; set; }

		[Display(Name = "Image Location")]
		public string ImageLocation { get; set; }

		[Display(Name = "Active")]
		public bool IsActive { get; set; }

		public string ViewTitle { get; set; }
	}
}