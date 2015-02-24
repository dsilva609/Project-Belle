using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UI.Controllers;

namespace UnitTests.UI.Controllers.HomeControllerTests
{
	[TestClass]
	public class HomeControllerTestBase
	{
		protected Mock<HomeController> _homeControllerMock;

		[TestInitialize]
		public void Setup()
		{
			this._homeControllerMock = new Mock<HomeController>();
		}
	}
}