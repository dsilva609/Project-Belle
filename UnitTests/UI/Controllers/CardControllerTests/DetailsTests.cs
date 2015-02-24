using BusinessLogic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using System.Web.Mvc;

namespace UnitTests.UI.Controllers.CardControllerTests
{
	[TestClass]
	public class DetailsTests : CardControllerTestBase
	{
		[TestMethod]
		public void ThatDetailsActionReturnsAView()
		{
			//--Arrange
			base._cardController.Setup(mock => mock.Details()).Returns(new ViewResult { ViewName = MVC.Card.Views.Details });

			//--Act
			var result = base._cardController.Object.Details() as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Card.Views.Details, result.ViewName);
		}

		[TestMethod]
		public void ThatSpecifiedViewModelIsSentToView()
		{
			//--Arrange
			var expectedViewModel = new Card();
			base._cardController.Setup(mock => mock.Details(It.IsAny<int>())).Returns(new ViewResult { ViewData = new ViewDataDictionary(expectedViewModel) });

			//--Act
			var result = base._cardController.Object.Details(42) as ViewResult;

			//--Assert
			Assert.AreEqual(expectedViewModel, result.ViewData.Model);
		}

		[TestMethod]
		public void ThatWhenParameterIsNullItReturnsHttpNotFoundError()
		{
			//--Arrange
			base._cardController.Setup(mock => mock.Details(null)).Returns(new HttpNotFoundResult());

			//--Act
			var result = base._cardController.Object.Details(null) as HttpNotFoundResult;

			//--Assert
			Assert.AreEqual((int)HttpStatusCode.NotFound, result.StatusCode);
		}
	}
}