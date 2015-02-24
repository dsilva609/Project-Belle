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

		public Expansion Expansion { get; set; }

		[Display(Name = "Expansion")]
		public string ExpansionString { get; set; }

		public CardType CardType { get; set; }

		[Display(Name = "Card Type")]
		public string CardTypeString { get; set; }

		public Suit Suit { get; set; }

		[Display(Name = "Suit")]
		public string SuitString { get; set; }

		public Rank Rank { get; set; }

		[Display(Name = "Rank")]
		public string RankString { get; set; }

		public int? Range { get; set; }

		[Display(Name = "Image Location")]
		public string ImageLocation { get; set; }

		[Display(Name = "Active")]
		public bool IsActive { get; set; }

		public string ViewTitle { get; set; }
	}
}