using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace UnitTests.UI.Controllers.CardControllerTests
{
	[TestClass]
	public class CreateTests : CardControllerTestBase
	{
		[TestMethod]
		public void ThatCreateActionReturnsEditView()
		{
			//--Arrange
			base._cardController.Setup(mock => mock.Create()).Returns(new ViewResult { ViewName = MVC.Card.Views.Edit });

			//--Act
			var result = base._cardController.Object.Create() as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Card.Views.Edit, result.ViewName);
		}
	}
}