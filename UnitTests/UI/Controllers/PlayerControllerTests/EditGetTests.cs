using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using System.Web.Mvc;
using UI.Models;

namespace UnitTests.UI.Controllers.PlayerControllerTests
{
	[TestClass]
	public class EditGetTests : PlayerControllerTestBase
	{
		private string _PLAYER_CREATE_MESSAGE = "Create Player";
		private string _PLAYER_EDIT_MESSAGE = "Edit Player: ";
		private PlayerViewModel _expectedEditPlayerModel;
		private PlayerViewModel _expectedDefaultPlayerModel;

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

			this._expectedDefaultPlayerModel = new PlayerViewModel { ViewTitle = this._PLAYER_CREATE_MESSAGE };
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
		public void ThatSpecifiedDefaultViewModelIsSentToView()
		{
			//--Arrange
			base._playerController.Setup(mock => mock.Edit(It.IsNotNull<int>())).Returns(new ViewResult { ViewData = new ViewDataDictionary(this._expectedDefaultPlayerModel) });

			//--Act
			var result = base._playerController.Object.Edit(It.IsNotNull<int>()) as ViewResult;

			//--Assert
			Assert.AreEqual(this._expectedDefaultPlayerModel, result.ViewData.Model);
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
		public void ThatWhenIDIsLessThanOrEqualToZeroViewModelTitleIsCreate()
		{
			//--Arrange
			base._playerController.Setup(mock => mock.Edit(0)).Returns(new ViewResult { ViewData = new ViewDataDictionary(this._expectedDefaultPlayerModel) });

			//--Act
			var result = base._playerController.Object.Edit(0) as ViewResult;
			var viewResultModel = result.ViewData.Model as PlayerViewModel;

			//--Assert
			Assert.AreEqual(this._PLAYER_CREATE_MESSAGE, viewResultModel.ViewTitle);
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

		[TestMethod]
		public void ThatWhenParameterIsNullItReturnsHttpNotFoundError()
		{
			//--Arrange
			base._playerController.Setup(mock => mock.Edit(null)).Returns(new HttpNotFoundResult());

			//--Act
			var result = base._playerController.Object.Edit(null) as HttpNotFoundResult;

			//--Assert
			Assert.AreEqual((int)HttpStatusCode.NotFound, result.StatusCode);
		}
	}
}