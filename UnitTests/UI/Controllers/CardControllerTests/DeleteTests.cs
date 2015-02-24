using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Mvc;

namespace UnitTests.UI.Controllers.CardControllerTests
{
	[TestClass]
	public class DeleteTests : CardControllerTestBase
	{
		[TestMethod]
		public void ThatIndexViewIsReturnedAfterDelete()
		{
			//--Arrange
			base._cardController.Setup(mock => mock.Delete(It.IsNotNull<int>())).Returns(new ViewResult { ViewName = MVC.Card.Views.Index });

			//--Act
			var result = base._cardController.Object.Delete(1886) as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Card.Views.Index, result.ViewName);
		}
	}
}