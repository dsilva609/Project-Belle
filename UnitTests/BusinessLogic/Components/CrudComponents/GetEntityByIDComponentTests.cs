using BusinessLogic.Enums;
using BusinessLogic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.BusinessLogic.Components.CrudComponents
{
	[TestClass]
	public class GetEntityByIDComponentTests : GetEntityByIDComponentTestBase
	{
		private Card _card;
		private Player _player;

		[TestInitialize]
		public override void Setup()
		{
			base.Setup();

			this._card = new Card
			{
				Name = "Bang!",
				ID = 1,
				Description = "Kill 'Em All",
				Suit = Suit.Spade,
				Rank = Rank.Ace,
				Cardtype = CardType.Basic,
				IsActive = true
			};

			this._player = new Player
			{
				ID = 1,
				Name = "Smitty Werbenjagermanjensen",
				IsActive = true
			};
		}

		[TestMethod]
		public void ThatCardOfMatchingIDIsReturned()
		{
			//--Arrange
			base._cardRepositoryMock.Setup(m => m.GetByID(1)).Returns(this._card);
			base._cardRepo = base._cardRepositoryMock.Object;

			//--Act
			var result = base._getEntityByIDComponent.Execute(base._cardRepo, 1);

			//--Assert
			Assert.AreEqual(1, result.ID);
		}

		[TestMethod]
		public void ThatPlayerOfMatchingIDIsReturned()
		{
			//--Arrange
			base._playerRepositoryMock.Setup(m => m.GetByID(1)).Returns(this._player);
			base._playerRepo = base._playerRepositoryMock.Object;

			//--Act
			var result = base._getEntityByIDComponent.Execute(base._playerRepo, 1);

			//--Assert
			Assert.AreEqual(1, result.ID);
		}
	}
}