using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Enums
{
	public enum Expansion
	{
		[Display(Name = "-Select Expansion-")]
		Default,									//0

		Standard,									//1

		[Display(Name = "High Noon")]
		HighNoon,									//2

		[Display(Name = "Dodge City")]
		DodgeCity,									//3

		[Display(Name = "A Fistful Of Cards")]
		AFistfulOfCards,							//4

		[Display(Name = "Wild West Show")]
		WildWestShow,								//5

		[Display(Name = "Gold Rush")]
		GoldRush,									//6

		[Display(Name = "Valley Of Shadows")]
		ValleyOfShadows,							//7

		[Display(Name = "El Dorado")]
		ElDorado,									//8

		[Display(Name = "Death Mesa")]
		DeathMesa,									//9

		[Display(Name = "Robber's Roost")]
		RobbersRoost,								//10

		[Display(Name = "Bang! The Bullet")]
		BangTheBullet,								//11

		Anniversary									//12
	}
}