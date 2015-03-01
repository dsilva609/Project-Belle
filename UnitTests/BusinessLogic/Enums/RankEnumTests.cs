﻿using BusinessLogic.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests.BusinessLogic.Enums
{
	[TestClass]
	public class RankEnumTests
	{
		private const string ENUM_FAILURE_MESSAGE = "Enum value is not correct. Enum and update scripts may be out of date.";

		[TestMethod]
		public void ThatDefaultValueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(Rank.Default);

			//--Assert
			Assert.AreEqual(0, result, ENUM_FAILURE_MESSAGE);
		}

		[TestMethod]
		public void ThatTwoValueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(Rank.Two);

			//--Assert
			Assert.AreEqual(2, result, ENUM_FAILURE_MESSAGE);
		}

		[TestMethod]
		public void ThatThreeValueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(Rank.Three);

			//--Assert
			Assert.AreEqual(3, result, ENUM_FAILURE_MESSAGE);
		}

		[TestMethod]
		public void ThatFourValueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(Rank.Four);

			//--Assert
			Assert.AreEqual(4, result, ENUM_FAILURE_MESSAGE);
		}

		[TestMethod]
		public void ThatFiveValueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(Rank.Five);

			//--Assert
			Assert.AreEqual(5, result, ENUM_FAILURE_MESSAGE);
		}

		[TestMethod]
		public void ThatSixValueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(Rank.Six);

			//--Assert
			Assert.AreEqual(6, result, ENUM_FAILURE_MESSAGE);
		}

		[TestMethod]
		public void ThatSevenValueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(Rank.Seven);

			//--Assert
			Assert.AreEqual(7, result, ENUM_FAILURE_MESSAGE);
		}

		[TestMethod]
		public void ThatEightValueHasCorrectValue()
		{
			//--Act
			var result = Convert.ToInt32(Rank.Eight);

			//--Assert
			Assert.AreEqual(8, result, ENUM_FAILURE_MESSAGE);
		}
	}
}