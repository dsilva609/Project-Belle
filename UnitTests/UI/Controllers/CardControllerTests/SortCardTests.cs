using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Mvc;

namespace UnitTests.UI.Controllers.CardControllerTests
{
	[TestClass]
	public class SortCardTests : CardControllerTestBase
	{
		private readonly string _CARD_SORT_KEY = "CardSortAscending";

		[TestInitialize]
		public override void Setup()
		{
			base.Setup();

			base._cardController.Setup(mock => mock.SortPlayers(It.IsNotNull<string>())).Returns(new ViewResult { ViewName = MVC.Card.Views.Index })
				.Callback(() =>
				{
					base._cardController.Object.Session[this._CARD_SORT_KEY] = (bool)base._cardController.Object.Session[this._CARD_SORT_KEY] ? false : true;
				});
		}

		[TestMethod]
		public void ThatSortPlayerActionReturnsAView()
		{
			//--Arrange
			base._cardController.Setup(mock => mock.SortPlayers(It.IsNotNull<string>())).Returns(new ViewResult { ViewName = MVC.Card.Views.Index });

			//--Act
			var result = base._cardController.Object.SortPlayers("apple") as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Card.Views.Index, result.ViewName);
		}

		[TestMethod]
		public void ThatIfSortIsAscendingSessionValueChangesToFalse()
		{
			//--Arrange
			base._cardController.Object.Session[this._CARD_SORT_KEY] = true;

			//--Act
			base._cardController.Object.SortPlayers("Ders");

			//--Assert
			Assert.IsFalse((bool)base._cardController.Object.Session[this._CARD_SORT_KEY]);
		}

		[TestMethod]
		public void ThatIfSortIsNotAscendingSessionValueChangesToTrue()
		{
			//--Arrange
			base._cardController.Object.Session[this._CARD_SORT_KEY] = false;

			//--Act
			base._cardController.Object.SortPlayers("Weiss");

			//--Assert
			Assert.IsTrue((bool)base._cardController.Object.Session[this._CARD_SORT_KEY]);
		}
	}
}