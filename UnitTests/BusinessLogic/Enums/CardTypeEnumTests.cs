using BusinessLogic.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests.BusinessLogic.Enums
{
	[TestClass]
	public class CardTypeEnumTests
	{
		private const string ENUM_FAILURE_MESSAGE = "Enum value is not correct. Enum and update scripts may be out of date.";

		[TestMethod]
		public void ThatDefaultValueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(CardType.Default);

			//--Assert
			Assert.AreEqual(0, result, ENUM_FAILURE_MESSAGE);
		}

		[TestMethod]
		public void ThatBasicValueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(CardType.Basic);

			//--Assert
			Assert.AreEqual(1, result, ENUM_FAILURE_MESSAGE);
		}

		[TestMethod]
		public void ThatAlcoholValueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(CardType.Alcohol);

			//--Assert
			Assert.AreEqual(2, result, ENUM_FAILURE_MESSAGE);
		}

		[TestMethod]
		public void ThatDrawValueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(CardType.Draw);

			//--Assert
			Assert.AreEqual(3, result, ENUM_FAILURE_MESSAGE);
		}

		[TestMethod]
		public void ThatTimeDelayValueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(CardType.TimeDelay);

			//--Assert
			Assert.AreEqual(4, result, ENUM_FAILURE_MESSAGE);
		}

		[TestMethod]
		public void ThatWeaponValueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(CardType.Weapon);

			//--Assert
			Assert.AreEqual(5, result, ENUM_FAILURE_MESSAGE);
		}

		[TestMethod]
		public void ThatEquipmentValueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(CardType.Equipment);

			//--Assert
			Assert.AreEqual(6, result, ENUM_FAILURE_MESSAGE);
		}

		[TestMethod]
		public void ThatTargetAllalueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(CardType.TargetAll);

			//--Assert
			Assert.AreEqual(7, result, ENUM_FAILURE_MESSAGE);
		}

		[TestMethod]
		public void ThatRoleValueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(CardType.Role);

			//--Assert
			Assert.AreEqual(8, result, ENUM_FAILURE_MESSAGE);
		}

		[TestMethod]
		public void ThatEventValueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(CardType.Event);

			//--Assert
			Assert.AreEqual(9, result, ENUM_FAILURE_MESSAGE);
		}

		[TestMethod]
		public void ThatCharacterValueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(CardType.Character);

			//--Assert
			Assert.AreEqual(10, result, ENUM_FAILURE_MESSAGE);
		}
	}
}