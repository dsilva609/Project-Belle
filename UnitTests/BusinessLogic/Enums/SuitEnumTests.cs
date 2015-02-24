using BusinessLogic.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests.BusinessLogic.Enums
{
	[TestClass]
	public class SuitEnumTests
	{
		private const string ENUM_FAILURE_MESSAGE = "Enum value is not correct, enum values and update scripts may be out of date.";

		[TestMethod]
		public void ThatDefaultValueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(Suit.Default);

			//-Assert
			Assert.AreEqual(0, result, ENUM_FAILURE_MESSAGE);
		}

		[TestMethod]
		public void ThatHeartValueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(Suit.Heart);

			//--Assert
			Assert.AreEqual(1, result, ENUM_FAILURE_MESSAGE);
		}

		[TestMethod]
		public void ThatDiamondValueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(Suit.Diamond);

			//--Assert
			Assert.AreEqual(2, result, ENUM_FAILURE_MESSAGE);
		}

		[TestMethod]
		public void ThatClubValueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(Suit.Club);

			//--Assert
			Assert.AreEqual(3, result, ENUM_FAILURE_MESSAGE);
		}

		[TestMethod]
		public void ThatSpadeValueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(Suit.Spade);

			//--Assert
			Assert.AreEqual(4, result, ENUM_FAILURE_MESSAGE);
		}
	}
}