using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace UnitTests.UI.Controllers.PlayerControllerTests
{
	[TestClass]
	public class RedirectTests : PlayerControllerTestBase
	{
		[TestMethod]
		public void ThatRedirectWhenUserIsAdminRedirectsToEditPage()
		{
			//--Arrange
			base._playerController.Object.ControllerContext = base._controllerTestBase.SetupAuthorization("Admin", true, true).Object;
			base._playerController.Setup(mock => mock.RedirectUser()).Returns(new ViewResult { ViewName = base._playerController.Object.User.IsInRole("Admin") ? MVC.Player.Views.Edit : MVC.Player.Views.Details });

			//--Act
			var result = base._playerController.Object.RedirectUser() as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Player.Views.Edit, result.ViewName);
		}

		[TestMethod]
		public void ThatRedirectWhenUserIsNotAdminRedirectsToDetailsPage()
		{
			//--Arrange
			base._playerController.Object.ControllerContext = base._controllerTestBase.SetupAuthorization("NotAdmin", true, true).Object;
			base._playerController.Setup(mock => mock.RedirectUser()).Returns(new ViewResult { ViewName = base._playerController.Object.User.IsInRole("Admin") ? MVC.Player.Views.Edit : MVC.Player.Views.Details });

			//--Act
			var result = base._playerController.Object.RedirectUser() as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Player.Views.Details, result.ViewName);
		}
	}
}