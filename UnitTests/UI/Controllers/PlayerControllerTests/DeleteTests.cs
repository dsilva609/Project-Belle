using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Mvc;

namespace UnitTests.UI.Controllers.PlayerControllerTests
{
	[TestClass]
	public class DeleteTests : PlayerControllerTestBase
	{
		[TestMethod]
		public void ThatIndexViewIsReturnedAfterDelete()
		{
			//--Arrange
			base._playerController.Setup(mock => mock.Delete(It.IsNotNull<int>())).Returns(new ViewResult { ViewName = MVC.Player.Views.Index });

			//--Act
			var result = base._playerController.Object.Delete(42) as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Player.Views.Index, result.ViewName);
		}
	}
}