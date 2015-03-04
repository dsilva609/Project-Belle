using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Mvc;
using UI.Models;

namespace UnitTests.UI.Controllers.CardControllerTests
{
	[TestClass]
	public class CreatePostTests : CardControllerTestBase
	{
		private CardViewModel _populatedCardViewModel;

		[TestInitialize]
		public override void Setup()
		{
			base.Setup();

			this._populatedCardViewModel = new CardViewModel
			{
				Name = "Medic",
			};
		}

		[TestMethod]
		public void ThatWhenModelStateIsNotValidItRedirectsBackToCreateView()
		{
			//--Arrange
			base._cardController.Setup(mock => mock.Create(It.IsNotNull<CardViewModel>())).Returns(new ViewResult { ViewName = MVC.Card.Views.Create });
			base._cardController.Object.ModelState.AddModelError("", "");

			//--Act
			var result = base._cardController.Object.Create(this._populatedCardViewModel) as ViewResult;

			//--Assert
			Assert.IsTrue(!base._cardController.Object.ModelState.IsValid);
			Assert.AreEqual(MVC.Card.Views.Create, result.ViewName);
		}

		[TestMethod]
		public void ThatWhenModelStateIsValidItRedirectsToIndexView()
		{
			//--Arrange
			base._cardController.Setup(mock => mock.Create(It.IsNotNull<CardViewModel>())).Returns(new ViewResult { ViewName = MVC.Card.Views.Index });

			//--Act
			var result = base._cardController.Object.Create(this._populatedCardViewModel) as ViewResult;

			//--Assert
			Assert.IsTrue(base._cardController.Object.ModelState.IsValid);
			Assert.AreEqual(MVC.Card.Views.Index, result.ViewName);
		}
	}
}