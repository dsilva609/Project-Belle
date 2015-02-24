using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace UnitTests.UI.Controllers.PlayerControllerTests
{
	[TestClass]
	public class CreateTests : PlayerControllerTestBase
	{
		[TestMethod]
		public void ThatCreateActionReturnsEditView()
		{
			//--Arrange
			base._playerController.Setup(mock => mock.Create()).Returns(new ViewResult { ViewName = MVC.Player.Views.Edit });

			//--Act
			var result = base._playerController.Object.Create() as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Player.Views.Edit, result.ViewName);
		}
	}
}