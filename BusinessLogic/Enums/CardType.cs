using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Enums
{
	public enum CardType
	{
		[Display(Name = "-Select Card Type-")]
		Default,									//0

		Basic,										//1
		Alcohol,									//2
		Draw,										//3

		[Display(Name = "Time Delay")]
		TimeDelay,									//4

		Weapon,										//5
		Equipment,									//6

		[Display(Name = "Target All")]
		TargetAll,									//7

		Role,										//8
		Event,										//9
		Character									//10
	}
}