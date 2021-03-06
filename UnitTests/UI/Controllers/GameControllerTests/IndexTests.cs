﻿using BusinessLogic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Web.Mvc;

namespace UnitTests.UI.Controllers.GameControllerTests
{
	[TestClass]
	public class IndexTests : GameControllerTestBase
	{
		private readonly List<Card> _expectedViewModel = new List<Card>();

		[TestInitialize]
		public override void Setup()
		{
			base.Setup();

			base._gameController.Setup(mock => mock.Index()).Returns(new ViewResult { ViewName = MVC.Game.Views.Index, ViewData = new ViewDataDictionary(this._expectedViewModel) });
		}

		[TestMethod]
		public void ThatIndexActionReturnsAView()
		{
			//--Arrange
			var result = this._gameController.Object.Index() as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Game.Views.Index, result.ViewName);
		}

		[TestMethod]
		public void ThatSpecifiedViewModelIsSentToView()
		{
			//--Arrange
			var result = base._gameController.Object.Index() as ViewResult;

			//--Assert
			Assert.AreEqual(this._expectedViewModel, result.ViewData.Model);
		}
	}
}