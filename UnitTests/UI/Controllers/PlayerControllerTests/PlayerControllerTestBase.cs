using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Mvc;
using UI.Controllers;

namespace UnitTests.UI.Controllers.PlayerControllerTests
{
	[TestClass]
	public class PlayerControllerTestBase
	{
		protected Mock<PlayerController> _playerController;
		protected ControllerTestBase _controllerTestBase;
		//protected Mock<ControllerContext> _context;
		//protected MockHttpSession _session;

		[TestInitialize]
		public virtual void Setup()
		{
			this._playerController = new Mock<PlayerController>();
			this._controllerTestBase = new ControllerTestBase();

			this._playerController.Object.ControllerContext = this._controllerTestBase.SetupSession().Object;
		}
	}
}