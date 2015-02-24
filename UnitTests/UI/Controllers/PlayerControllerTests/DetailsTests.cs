using BusinessLogic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using System.Web.Mvc;

namespace UnitTests.UI.Controllers.PlayerControllerTests
{
	[TestClass]
	public class DetailsTests : PlayerControllerTestBase
	{
		[TestMethod]
		public void ThatDetailsActionReturnsAView()
		{
			//--Arrange
			base._playerController.Setup(mock => mock.Details()).Returns(new ViewResult { ViewName = MVC.Player.Views.Details });

			//--Act
			var result = base._playerController.Object.Details() as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Player.Views.Details, result.ViewName);
		}

		[TestMethod]
		public void ThatWhenParameterIsNullItReturnsHttpNotFoundError()
		{
			//--Arrange
			base._playerController.Setup(mock => mock.Details(null)).Returns(new HttpNotFoundResult());

			//--Act
			var result = base._playerController.Object.Details(null) as HttpNotFoundResult;

			//--Assert
			Assert.AreEqual((int)HttpStatusCode.NotFound, result.StatusCode);
		}

		[TestMethod]
		public void ThatSpecifiedViewModelIsSentToView()
		{
			//--Arrange
			var expectedViewModel = new Player();
			base._playerController.Setup(mock => mock.Details(It.IsAny<int>())).Returns(new ViewResult { ViewData = new ViewDataDictionary(expectedViewModel) });

			//--Act
			var result = base._playerController.Object.Details(5) as ViewResult;

			//--Assert
			Assert.AreEqual(expectedViewModel, result.ViewData.Model);
		}
	}
}