using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using UI.Models;

namespace UnitTests.UI.Controllers.CardControllerTests
{
	[TestClass]
	public class CreateGetTests : CardControllerTestBase
	{
		private string _CARD_CREATE_MESSAGE = "Create New Card";
		private CardViewModel _expectedCardViewModel;

		[TestInitialize]
		public override void Setup()
		{
			base.Setup();

			this._expectedCardViewModel = new CardViewModel { ViewTitle = this._CARD_CREATE_MESSAGE };
		}

		[TestMethod]
		public void ThatCreateActionReturnsCreateView()
		{
			//--Arrange
			base._cardController.Setup(mock => mock.Create()).Returns(new ViewResult { ViewName = MVC.Card.Views.Create });

			//--Act
			var result = base._cardController.Object.Create() as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Card.Views.Create, result.ViewName);
		}

		[TestMethod]
		public void ThatSpecifiedDefaultViewModelIsSentToView()
		{
			//--Arrange
			base._cardController.Setup(mock => mock.Create()).Returns(new ViewResult { ViewData = new ViewDataDictionary(this._expectedCardViewModel) });

			//--Act
			var result = base._cardController.Object.Create() as ViewResult;

			//--Assert
			Assert.AreEqual(this._expectedCardViewModel, result.ViewData.Model);
		}

		[TestMethod]
		public void ThatViewModelTitleIsCreate()
		{
			//--Arrange
			base._cardController.Setup(mock => mock.Create()).Returns(new ViewResult { ViewData = new ViewDataDictionary(this._expectedCardViewModel) });

			//--Act
			var result = base._cardController.Object.Create() as ViewResult;
			var viewResultModel = result.ViewData.Model as CardViewModel;

			//--Assert
			Assert.AreEqual(this._CARD_CREATE_MESSAGE, viewResultModel.ViewTitle);
		}
	}
}