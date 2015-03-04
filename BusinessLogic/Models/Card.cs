using BusinessLogic.Enums;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models
{
	public class Card
	{
		[Required]
		public string Name { get; set; }

		public int ID { get; set; }

		public string Description { get; set; }

		public string Action { get; set; }

		[Required]
		public Rank Rank { get; set; }

		public string RankString { get; set; }

		[Required]
		public int Rarity { get; set; }

		[Display(Name = "Image Location")]
		public string ImageLocation { get; set; }

		[Display(Name = "Active")]
		public bool IsActive { get; set; }
	}
}