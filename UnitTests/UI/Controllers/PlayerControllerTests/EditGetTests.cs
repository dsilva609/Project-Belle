using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Mvc;
using UI.Models;

namespace UnitTests.UI.Controllers.PlayerControllerTests
{
	[TestClass]
	public class EditGetTests : PlayerControllerTestBase
	{
		private string _PLAYER_EDIT_MESSAGE = "Edit Player: ";
		private PlayerViewModel _expectedEditPlayerModel;

		[TestInitialize]
		public override void Setup()
		{
			base.Setup();

			this._expectedEditPlayerModel = new PlayerViewModel
			{
				ID = 1,
				Name = "Smitty Werbenjagermanjensen",
				ViewTitle = this._PLAYER_EDIT_MESSAGE
			};

			this._PLAYER_EDIT_MESSAGE += this._expectedEditPlayerModel.Name;
		}

		[TestMethod]
		public void ThatEditActionReturnsAView()
		{
			//--Arrange
			base._playerController.Setup(mock => mock.Edit()).Returns(new ViewResult { ViewName = MVC.Player.Views.Edit });

			//--Act
			var result = base._playerController.Object.Edit() as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Player.Views.Edit, result.ViewName);
		}

		[TestMethod]
		public void ThatSpecifiedPopulatedViewModelIsSentToView()
		{
			//--Arrange
			base._playerController.Setup(mock => mock.Edit(It.IsAny<int>())).Returns(new ViewResult { ViewData = new ViewDataDictionary(this._expectedEditPlayerModel) });

			//--Act
			var result = base._playerController.Object.Edit(1) as ViewResult;
			var viewResultModel = result.ViewData.Model as PlayerViewModel;

			//--Assert
			Assert.AreEqual(this._expectedEditPlayerModel, viewResultModel);
		}

		[TestMethod]
		public void ThatWhenIDIsGreaterThanZeroViewModelTitleIsEdit()
		{
			//--Arrange
			base._playerController.Setup(mock => mock.Edit(It.IsAny<int>())).Returns(new ViewResult { ViewData = new ViewDataDictionary(this._expectedEditPlayerModel) });

			//--Act
			var result = base._playerController.Object.Edit(1) as ViewResult;
			var viewResultModel = result.ViewData.Model as PlayerViewModel;

			//--Assert
			Assert.AreEqual(this._expectedEditPlayerModel.ViewTitle, viewResultModel.ViewTitle);
		}
	}
}