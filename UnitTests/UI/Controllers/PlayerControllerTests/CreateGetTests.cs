using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using UI.Models;

namespace UnitTests.UI.Controllers.PlayerControllerTests
{
	[TestClass]
	public class CreateGetTests : PlayerControllerTestBase
	{
		private string _PLAYER_CREATE_MESSAGE = "Create Player";
		private PlayerViewModel _expectedDefaultPlayerModel;

		[TestInitialize]
		public override void Setup()
		{
			base.Setup();

			this._expectedDefaultPlayerModel = new PlayerViewModel { ViewTitle = this._PLAYER_CREATE_MESSAGE };
		}

		[TestMethod]
		public void ThatCreateActionReturnsEditView()
		{
			//--Arrange
			base._playerController.Setup(mock => mock.Create()).Returns(new ViewResult { ViewName = MVC.Player.Views.Create });

			//--Act
			var result = base._playerController.Object.Create() as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Player.Views.Create, result.ViewName);
		}

		[TestMethod]
		public void ThatSpecifiedDefaultViewModelIsSentToView()
		{
			//--Arrange
			base._playerController.Setup(mock => mock.Create()).Returns(new ViewResult { ViewData = new ViewDataDictionary(this._expectedDefaultPlayerModel) });

			//--Act
			var result = base._playerController.Object.Create() as ViewResult;

			//--Assert
			Assert.AreEqual(this._expectedDefaultPlayerModel, result.ViewData.Model);
		}

		[TestMethod]
		public void ThatViewModelTitleIsCreate()
		{
			//--Arrange
			base._playerController.Setup(mock => mock.Create()).Returns(new ViewResult { ViewData = new ViewDataDictionary(this._expectedDefaultPlayerModel) });

			//--Act
			var result = base._playerController.Object.Create() as ViewResult;
			var viewResultModel = result.ViewData.Model as PlayerViewModel;

			//--Assert
			Assert.AreEqual(this._PLAYER_CREATE_MESSAGE, viewResultModel.ViewTitle);
		}
	}
}