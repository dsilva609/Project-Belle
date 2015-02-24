using BusinessLogic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTests.BusinessLogic.Services
{
	[TestClass]
	public class PlayerServiceTests : PlayerServiceTestBase
	{
		private List<Player> _playerList;

		[TestInitialize]
		public void Setup()
		{
			base.Setup();

			this._playerList = new List<Player>
			{
				new Player
				{
					ID = 1,
					Name = "Smitty Werbenjagermanjensen"
				},
				new Player
				{
					ID = 2,
					Name = "Neesons"
				},
				new Player
				{
					ID = 3,
					Name = "Willis"
				},
				new Player
				{
					ID = 4,
					Name = "Hank Moody"
				}
			};
		}

		[TestMethod]
		public void ThatGetAllMethodOrdersAscending()
		{
			//--Arrange
			base._Uow.Setup(x => x.GetRepository<Player>()).Returns(base._playerRepositoryMock.Object);
			base._playerRepositoryMock.Setup(x => x.GetAll()).Returns(this._playerList);

			//--Act
			var results = base._Service.Object.GetAll(true, "Name");

			//--Assert
			Assert.AreEqual("Hank Moody", results[0].Name);
		}

		[TestMethod]
		public void ThatGetAllMethodOrdersDescending()
		{
			//--Arrange
			base._Uow.Setup(x => x.GetRepository<Player>()).Returns(base._playerRepositoryMock.Object);
			base._playerRepositoryMock.Setup(x => x.GetAll()).Returns(this._playerList);

			//--Act
			var results = base._Service.Object.GetAll(false, "Name");

			//--Assert
			Assert.AreEqual("Willis", results[0].Name);
		}
	}
}