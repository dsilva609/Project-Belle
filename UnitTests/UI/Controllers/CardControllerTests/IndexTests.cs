using BusinessLogic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Web.Mvc;

namespace UnitTests.UI.Controllers.CardControllerTests
{
	[TestClass]
	public class IndexTests : CardControllerTestBase
	{
		private readonly List<Card> _expectedViewModel;

		[TestInitialize]
		public override void Setup()
		{
			base.Setup();

			base._cardController.Setup(mock => mock.Index()).Returns(new ViewResult { ViewName = MVC.Card.Views.Index, ViewData = new ViewDataDictionary(this._expectedViewModel) });
		}

		[TestMethod]
		public void ThatIndexActionReturnsAView()
		{
			//--Arrange
			var result = base._cardController.Object.Index() as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Card.Views.Index, result.ViewName);
		}

		[TestMethod]
		public void ThatSpecifiedViewModelIsSentToView()
		{
			//--Arrange
			var result = base._cardController.Object.Index() as ViewResult;

			//--Assert
			Assert.AreEqual(this._expectedViewModel, result.ViewData.Model);
		}
	}
}