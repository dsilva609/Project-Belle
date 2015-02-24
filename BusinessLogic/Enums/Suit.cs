using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Enums
{
	public enum Suit
	{
		[Display(Name = "-Select Suit-")]
		Default,							//0

		Heart,								//1
		Diamond,							//2
		Club,								//3
		Spade								//4
	}
}