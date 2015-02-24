using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using System.Web.Mvc;
using UI.Models;

namespace UnitTests.UI.Controllers.CardControllerTests
{
	[TestClass]
	public class EditGetTests : CardControllerTestBase
	{
		private string _CARD_CREATE_MESSAGE = "Create New Card";
		private string _CARD_EDIT_MESSAGE = "Edit Card: ";
		private CardViewModel _expectedEditCardModel;
		private CardViewModel _expectedDefaultCardModel;

		[TestInitialize]
		public override void Setup()
		{
			base.Setup();

			this._expectedEditCardModel = new CardViewModel
			{
				ID = 1,
				Name = "Punch",
				ViewTitle = this._CARD_EDIT_MESSAGE
			};

			this._CARD_EDIT_MESSAGE += this._expectedEditCardModel.Name;

			this._expectedDefaultCardModel = new CardViewModel { ViewTitle = this._CARD_CREATE_MESSAGE };
		}

		[TestMethod]
		public void ThatEditActionReturnsAView()
		{
			//--Arrange
			base._cardController.Setup(mock => mock.Edit()).Returns(new ViewResult { ViewName = MVC.Card.Views.Edit });

			//--Act
			var result = base._cardController.Object.Edit() as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Card.Views.Edit, result.ViewName);
		}

		[TestMethod]
		public void ThatSpecifiedDefaultViewModelIsSentToView()
		{
			//--Arrange
			base._cardController.Setup(mock => mock.Edit(It.IsNotNull<int>())).Returns(new ViewResult { ViewData = new ViewDataDictionary(this._expectedDefaultCardModel) });

			//--Act
			var result = base._cardController.Object.Edit(It.IsNotNull<int>()) as ViewResult;

			//--Assert
			Assert.AreEqual(this._expectedDefaultCardModel, result.ViewData.Model);
		}

		[TestMethod]
		public void ThatSpecifiedPopulatedViewModelIsSentToView()
		{
			//--Arrange
			base._cardController.Setup(mock => mock.Edit(It.IsAny<int>())).Returns(new ViewResult { ViewData = new ViewDataDictionary(this._expectedEditCardModel) });

			//--Act
			var result = base._cardController.Object.Edit(12345) as ViewResult;
			var viewResultModel = result.ViewData.Model as CardViewModel;

			//--Assert
			Assert.AreEqual(this._expectedEditCardModel, viewResultModel);
		}

		[TestMethod]
		public void ThatWhenIDIsLessThanOrEqualToZeroViewModelTitleIsCreate()
		{
			//--Arrange
			base._cardController.Setup(mock => mock.Edit(0)).Returns(new ViewResult { ViewData = new ViewDataDictionary(this._expectedDefaultCardModel) });

			//--Act
			var result = base._cardController.Object.Edit(0) as ViewResult;
			var viewResultModel = result.ViewData.Model as CardViewModel;

			//--Assert
			Assert.AreEqual(this._CARD_CREATE_MESSAGE, viewResultModel.ViewTitle);
		}

		[TestMethod]
		public void ThatWhenIDIsGreaterThanZeroViewModelTitleIsEdit()
		{
			//--Arrange
			base._cardController.Setup(mock => mock.Edit(It.IsAny<int>())).Returns(new ViewResult { ViewData = new ViewDataDictionary(this._expectedEditCardModel) });

			//--Act
			var result = base._cardController.Object.Edit(12345) as ViewResult;
			var viewResultModel = result.ViewData.Model as CardViewModel;

			//--Assert
			Assert.AreEqual(this._expectedEditCardModel.ViewTitle, viewResultModel.ViewTitle);
		}

		[TestMethod]
		public void ThatWhenParameterIsNullItResultsHttpNotFoundError()
		{
			//--Arrange
			base._cardController.Setup(mock => mock.Edit(null)).Returns(new HttpNotFoundResult());

			//--Act
			var result = base._cardController.Object.Edit(null) as HttpNotFoundResult;

			//--Assert
			Assert.AreEqual((int)HttpStatusCode.NotFound, result.StatusCode);
		}
	}
}