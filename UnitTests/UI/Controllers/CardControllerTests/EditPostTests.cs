using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Mvc;
using UI.Models;

namespace UnitTests.UI.Controllers.CardControllerTests
{
	[TestClass]
	public class EditPostTests : CardControllerTestBase
	{
		private CardViewModel _editViewModel;

		[TestInitialize]
		public override void Setup()
		{
			base.Setup();

			this._editViewModel = new CardViewModel
			{
				Name = "Medic",
				ID = 0
			};
		}

		[TestMethod]
		public void ThatWhenModelStateIsNotValidItRedirectsBackToEditView()
		{
			//--Arrange
			base._cardController.Setup(mock => mock.Edit(It.IsNotNull<CardViewModel>(), It.IsAny<int>())).Returns(new ViewResult { ViewName = MVC.Card.Views.Edit });
			base._cardController.Object.ModelState.AddModelError("", "");

			//--Act
			var result = base._cardController.Object.Edit(this._editViewModel, this._editViewModel.ID) as ViewResult;

			//--Assert
			Assert.IsTrue(!base._cardController.Object.ModelState.IsValid);
			Assert.AreEqual(MVC.Card.Views.Edit, result.ViewName);
		}

		[TestMethod]
		public void ThatWhenModelStateIsValidItRedirectsToIndexView()
		{
			//--Arrange
			base._cardController.Setup(mock => mock.Edit(It.IsNotNull<CardViewModel>(), It.IsAny<int>())).Returns(new ViewResult { ViewName = MVC.Card.Views.Index });

			//--Act
			var result = base._cardController.Object.Edit(this._editViewModel, this._editViewModel.ID) as ViewResult;

			//--Assert
			Assert.IsTrue(base._cardController.Object.ModelState.IsValid);
			Assert.AreEqual(MVC.Card.Views.Index, result.ViewName);
		}
	}
}