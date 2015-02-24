using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Enums
{
	public enum Rank
	{
		[Display(Name = "-Select Rank-")]
		Default,							//0

		Two = 2,							//2
		Three = 3,							//3
		Four = 4,							//4
		Five = 5,							//5
		Six = 6,							//6
		Seven = 7,							//7
		Eight = 8,							//8
		Nine = 9,							//9
		Ten = 10,							//10
		Jack = 11,							//11
		Queen = 12,							//12
		King = 13,							//13
		Ace = 14							//14
	}
}