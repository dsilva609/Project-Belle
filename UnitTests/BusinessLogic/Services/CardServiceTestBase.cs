using BusinessLogic.Models;
using BusinessLogic.Repositories;
using BusinessLogic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests.BusinessLogic.Services
{
	[TestClass]
	public class CardServiceTestBase
	{
		protected Mock<IUnitOfWork> _Uow;
		protected Mock<CardService> _Service;
		protected Mock<IRepository<Card>> _cardRepositoryMock;

		[TestInitialize]
		public virtual void Setup()
		{
			this._Uow = new Mock<IUnitOfWork>();
			this._Service = new Mock<CardService>(this._Uow.Object);
			this._cardRepositoryMock = new Mock<IRepository<Card>>();
		}
	}
}