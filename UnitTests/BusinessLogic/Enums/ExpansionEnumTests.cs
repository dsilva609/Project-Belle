using BusinessLogic.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests.BusinessLogic.Enums
{
	[TestClass]
	public class ExpansionEnumTests
	{
		private const string ENUM_FAILURE_MESSAGE = "Enum value is not correct. Enum and update scripts may be out of date.";

		[TestMethod]
		public void ThatDefaultValueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(Expansion.Default);

			//--Assert
			Assert.AreEqual(0, result, ENUM_FAILURE_MESSAGE);
		}

		[TestMethod]
		public void ThatStandardValueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(Expansion.Standard);

			//--Assert
			Assert.AreEqual(1, result, ENUM_FAILURE_MESSAGE);
		}

		[TestMethod]
		public void ThatHighNoonValueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(Expansion.HighNoon);

			//--Assert
			Assert.AreEqual(2, result, ENUM_FAILURE_MESSAGE);
		}

		[TestMethod]
		public void ThatDodgeCityValueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(Expansion.DodgeCity);

			//--Assert
			Assert.AreEqual(3, result, ENUM_FAILURE_MESSAGE);
		}

		[TestMethod]
		public void ThatAFistfulOfCardsValueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(Expansion.AFistfulOfCards);

			//--Assert
			Assert.AreEqual(4, result, ENUM_FAILURE_MESSAGE);
		}

		[TestMethod]
		public void ThatWildWestShowValueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(Expansion.WildWestShow);

			//--Assert
			Assert.AreEqual(5, result, ENUM_FAILURE_MESSAGE);
		}

		[TestMethod]
		public void ThatGoldRushValueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(Expansion.GoldRush);

			//--Assert
			Assert.AreEqual(6, result, ENUM_FAILURE_MESSAGE);
		}

		[TestMethod]
		public void ThatValleyOfShadowsValueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(Expansion.ValleyOfShadows);

			//--Assert
			Assert.AreEqual(7, result, ENUM_FAILURE_MESSAGE);
		}

		[TestMethod]
		public void ThatElDoradotValueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(Expansion.ElDorado);

			//--Assert
			Assert.AreEqual(8, result, ENUM_FAILURE_MESSAGE);
		}

		[TestMethod]
		public void ThatDeathMesaValueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(Expansion.DeathMesa);

			//--Assert
			Assert.AreEqual(9, result, ENUM_FAILURE_MESSAGE);
		}

		[TestMethod]
		public void ThatRobbersRoostValueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(Expansion.RobbersRoost);

			//--Assert
			Assert.AreEqual(10, result, ENUM_FAILURE_MESSAGE);
		}

		[TestMethod]
		public void ThatBangTheBulletValueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(Expansion.BangTheBullet);

			//--Assert
			Assert.AreEqual(11, result, ENUM_FAILURE_MESSAGE);
		}

		[TestMethod]
		public void ThatAnniversaryValueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(Expansion.Anniversary);

			//--Assert
			Assert.AreEqual(12, result, ENUM_FAILURE_MESSAGE);
		}
	}
}