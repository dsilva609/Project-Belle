using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Mvc;
using UI.Models;

namespace UnitTests.UI.Controllers.PlayerControllerTests
{
	[TestClass]
	public class CreatePostTests : PlayerControllerTestBase
	{
		private PlayerViewModel _populatedCreateViewModel;

		[TestInitialize]
		public override void Setup()
		{
			base.Setup();

			this._populatedCreateViewModel = new PlayerViewModel
			{
				Name = "Liam Neeson",
			};
		}

		[TestMethod]
		public void ThatWhenModelStateIsNotValidItRedirectsBackToCreateView()
		{
			//--Arrange
			base._playerController.Setup(mock => mock.Create(It.IsNotNull<PlayerViewModel>())).Returns(new ViewResult { ViewName = MVC.Player.Views.Create });
			base._playerController.Object.ModelState.AddModelError("", "");

			//--Act
			var result = base._playerController.Object.Create(this._populatedCreateViewModel) as ViewResult;

			//--Assert
			Assert.IsTrue(!base._playerController.Object.ModelState.IsValid);
			Assert.AreEqual(MVC.Player.Views.Create, result.ViewName);
		}

		[TestMethod]
		public void ThatWhenModelStateIsValidItRedirectsToIndexView()
		{
			//--Arrange
			base._playerController.Setup(mock => mock.Create(It.IsNotNull<PlayerViewModel>())).Returns(new ViewResult { ViewName = MVC.Player.Views.Index });

			//--Act
			var result = base._playerController.Object.Create(this._populatedCreateViewModel) as ViewResult;

			//--Assert
			Assert.IsTrue(base._playerController.Object.ModelState.IsValid);
			Assert.AreEqual(MVC.Player.Views.Index, result.ViewName);
		}
	}
}