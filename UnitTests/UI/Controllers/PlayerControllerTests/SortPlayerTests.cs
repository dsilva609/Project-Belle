using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Mvc;

namespace UnitTests.UI.Controllers.PlayerControllerTests
{
	[TestClass]
	public class SortPlayerTests : PlayerControllerTestBase
	{
		private readonly string _PLAYER_SORT_KEY = "PlayerSortAscending";

		[TestInitialize]
		public override void Setup()
		{
			base.Setup();

			base._playerController.Setup(mock => mock.SortPlayers(It.IsNotNull<string>())).Returns(new ViewResult { ViewName = MVC.Player.Views.Index })
				.Callback(() =>
				{
					base._playerController.Object.Session[this._PLAYER_SORT_KEY] = (bool)base._playerController.Object.Session[this._PLAYER_SORT_KEY] ? false : true;
				});
		}

		[TestMethod]
		public void ThatSortPlayerActionReturnsAView()
		{
			//--Arrange
			base._playerController.Setup(mock => mock.SortPlayers(It.IsNotNull<string>())).Returns(new ViewResult { ViewName = MVC.Player.Views.Index });

			//--Act

			var result = base._playerController.Object.SortPlayers("Newman") as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Player.Views.Index, result.ViewName);
		}

		[TestMethod]
		public void ThatIfSortIsAscendingSessionValueChangesToFalse()
		{
			//--Arrange
			base._playerController.Object.Session[this._PLAYER_SORT_KEY] = true;

			//--Act
			base._playerController.Object.SortPlayers("Kramer");

			//--Assert
			Assert.IsFalse((bool)base._playerController.Object.Session[this._PLAYER_SORT_KEY]);
		}

		[TestMethod]
		public void ThatIfSortIsNotAscendingSessionValueChangesToTrue()
		{
			//--Arrange
			base._playerController.Object.Session[this._PLAYER_SORT_KEY] = false;

			//--Act
			base._playerController.Object.SortPlayers("Kramer");

			//--Assert
			Assert.IsTrue((bool)base._playerController.Object.Session[this._PLAYER_SORT_KEY]);
		}
	}
}