using BusinessLogic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Web.Mvc;

namespace UnitTests.UI.Controllers.PlayerControllerTests
{
	[TestClass]
	public class IndexTests : PlayerControllerTestBase
	{
		private readonly List<Player> _expectedIndexViewModel = new List<Player>();

		[TestInitialize]
		public override void Setup()
		{
			base.Setup();

			base._playerController.Setup(mock => mock.Index()).Returns(new ViewResult { ViewName = MVC.Player.Views.Index, ViewData = new ViewDataDictionary(this._expectedIndexViewModel) });
		}

		[TestMethod]
		public void ThatIndexActionReturnsAView()
		{
			//--Act
			var result = base._playerController.Object.Index() as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Player.Views.Index, result.ViewName);
		}

		[TestMethod]
		public void ThatSpecifiedViewModelIsSentToView()
		{
			//--Act
			var result = base._playerController.Object.Index() as ViewResult;

			//--Assert
			Assert.AreEqual(this._expectedIndexViewModel, result.ViewData.Model);
		}
	}
}