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

		public Expansion Expansion { get; set; }

		public string ExpansionString { get; set; }

		[Display(Name = "Type")]
		public CardType Cardtype { get; set; }

		public string CardTypeString { get; set; }

		public Suit Suit { get; set; }

		public string SuitString { get; set; }

		public Rank Rank { get; set; }

		public string RankString { get; set; }

		public int? Range { get; set; }

		[Display(Name = "Image Location")]
		public string ImageLocation { get; set; }

		[Display(Name = "Active")]
		public bool IsActive { get; set; }
	}
}