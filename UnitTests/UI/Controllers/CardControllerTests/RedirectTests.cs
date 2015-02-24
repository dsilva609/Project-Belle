using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace UnitTests.UI.Controllers.CardControllerTests
{
	[TestClass]
	public class RedirectTests : CardControllerTestBase
	{
		[TestMethod]
		public void ThatRediredtWhenUserIsAdminRedirectsToEditPage()
		{
			//--Arrange
			base._cardController.Object.ControllerContext = base._controllerTestBase.SetupAuthorization("Admin", true, true).Object;
			base._cardController.Setup(mock => mock.RedirectUser()).Returns(new ViewResult { ViewName = base._cardController.Object.User.IsInRole("Admin") ? MVC.Card.Views.Edit : MVC.Card.Views.Details });

			//--Act
			var result = base._cardController.Object.RedirectUser() as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Card.Views.Edit, result.ViewName);
		}

		[TestMethod]
		public void ThatRedirectWhenUserIsNotAdminRedirectsToDetailsPage()
		{
			//--Arrange
			base._cardController.Object.ControllerContext = base._controllerTestBase.SetupAuthorization("NotAdmin", true, true).Object;
			base._cardController.Setup(mock => mock.RedirectUser()).Returns(new ViewResult { ViewName = base._cardController.Object.User.IsInRole("Admin") ? MVC.Card.Views.Edit : MVC.Card.Views.Details });

			//--Act
			var result = base._cardController.Object.RedirectUser() as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Card.Views.Details, result.ViewName);
		}
	}
}