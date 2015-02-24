using BusinessLogic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTests.BusinessLogic.Services
{
	[TestClass]
	public class CardServiceTests : CardServiceTestBase
	{
		private List<Card> _cardList;

		[TestInitialize]
		public override void Setup()
		{
			base.Setup();

			this._cardList = new List<Card>
			{
				new Card
				{
					ID = 1,
					Name = "Bam!"
				},
				new Card
				{
					ID = 2,
					Name = "Arruga"
				},
				new Card
				{
					ID = 3,
					Name = "Kapow"
				},
				new Card
				{
					ID = 4,
					Name = "Thud"
				}
			};
		}

		[TestMethod]
		public void ThatGetAllMethodSortsAscending()
		{
			//--Arrange
			base._Uow.Setup(x => x.GetRepository<Card>()).Returns(base._cardRepositoryMock.Object);
			base._cardRepositoryMock.Setup(x => x.GetAll()).Returns(this._cardList);

			//--Act
			var results = base._Service.Object.GetAll(true, "Name");

			//--Assert
			Assert.AreEqual("Arruga", results[0].Name);
		}

		[TestMethod]
		public void ThatGetAllMethodSortsDescending()
		{
			//--Arrange
			base._Uow.Setup(x => x.GetRepository<Card>()).Returns(base._cardRepositoryMock.Object);
			base._cardRepositoryMock.Setup(x => x.GetAll()).Returns(this._cardList);

			//--Act
			var results = base._Service.Object.GetAll(false, "Name");

			//--Assert
			Assert.AreEqual("Thud", results[0].Name);
		}
	}
}