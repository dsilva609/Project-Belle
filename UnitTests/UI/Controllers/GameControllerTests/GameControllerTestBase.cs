using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UI.Controllers;

namespace UnitTests.UI.Controllers.GameControllerTests
{
	[TestClass]
	public class GameControllerTestBase
	{
		protected Mock<GameController> _gameController;

		[TestInitialize]
		public virtual void Setup()
		{
			this._gameController = new Mock<GameController>();
		}
	}
}