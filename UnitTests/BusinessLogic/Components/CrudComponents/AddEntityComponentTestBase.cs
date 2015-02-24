using BusinessLogic.Components.CrudComponents;
using BusinessLogic.Models;
using BusinessLogic.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests.BusinessLogic.Components.CrudComponents
{
	[TestClass]
	public class AddEntityComponentTestBase
	{
		protected IRepository<Card> _cardRepo;
		protected IRepository<Player> _playerRepo;
		protected AddEntityComponent _addEntityComponent;
		protected Mock<IRepository<Card>> _cardRepositoryMock;
		protected Mock<IRepository<Player>> _playerRepositoryMock;

		[TestInitialize]
		public virtual void Setup()
		{
			this._addEntityComponent = new AddEntityComponent();
			this._cardRepositoryMock = new Mock<IRepository<Card>>();
			this._playerRepositoryMock = new Mock<IRepository<Player>>();
		}
	}
}