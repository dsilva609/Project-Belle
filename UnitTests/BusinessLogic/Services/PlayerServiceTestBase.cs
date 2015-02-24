using BusinessLogic.Models;
using BusinessLogic.Repositories;
using BusinessLogic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests.BusinessLogic.Services
{
	[TestClass]
	public class PlayerServiceTestBase
	{
		protected Mock<IUnitOfWork> _Uow;
		protected Mock<PlayerService> _Service;
		protected Mock<IRepository<Player>> _playerRepositoryMock;

		[TestInitialize]
		public virtual void Setup()
		{
			this._Uow = new Mock<IUnitOfWork>();
			this._Service = new Mock<PlayerService>(this._Uow.Object);
			this._playerRepositoryMock = new Mock<IRepository<Player>>();
		}
	}
}