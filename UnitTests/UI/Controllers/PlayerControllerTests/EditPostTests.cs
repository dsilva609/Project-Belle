using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Mvc;
using UI.Models;

namespace UnitTests.UI.Controllers.PlayerControllerTests
{
	[TestClass]
	public class EditPostTests : PlayerControllerTestBase
	{
		private PlayerViewModel _editViewModel;

		[TestInitialize]
		public override void Setup()
		{
			base.Setup();

			this._editViewModel = new PlayerViewModel
			{
				Name = "Liam Neeson",
				ID = 0,
			};
		}

		[TestMethod]
		public void ThatWhenModelStateIsNotValidItRedirectsBackToEditView()
		{
			//--Arrange
			base._playerController.Setup(mock => mock.Edit(It.IsNotNull<PlayerViewModel>(), It.IsAny<int>())).Returns(new ViewResult { ViewName = MVC.Player.Views.Edit });
			base._playerController.Object.ModelState.AddModelError("", "");

			//--Act
			var result = base._playerController.Object.Edit(this._editViewModel, this._editViewModel.ID) as ViewResult;

			//--Assert
			Assert.IsTrue(!base._playerController.Object.ModelState.IsValid);
			Assert.AreEqual(MVC.Player.Views.Edit, result.ViewName);
		}

		[TestMethod]
		public void ThatWhenModelStateIsValidItRedirectsToIndexView()
		{
			//--Arrange
			base._playerController.Setup(mock => mock.Edit(It.IsNotNull<PlayerViewModel>(), It.IsAny<int>())).Returns(new ViewResult { ViewName = MVC.Player.Views.Index });

			//--Act
			var result = base._playerController.Object.Edit(this._editViewModel, this._editViewModel.ID) as ViewResult;

			//--Assert
			Assert.IsTrue(base._playerController.Object.ModelState.IsValid);
			Assert.AreEqual(MVC.Player.Views.Index, result.ViewName);
		}
	}
}