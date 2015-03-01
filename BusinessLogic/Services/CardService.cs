using BusinessLogic.Components.CrudComponents;
using BusinessLogic.Enums;
using BusinessLogic.Models;
using BusinessLogic.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Services
{
	public class CardService
	{
		private readonly IRepository<Card> _Repository;
		private readonly GetEntityListComponent _getEntityListComponent;
		private readonly AddEntityComponent _addEntityComponent;
		private readonly GetEntityByIDComponent _getEntityByIDComponent;
		private readonly EditEntityComponent _editEntityComponent;
		private readonly DeleteEntityComponent _deleteEntityComponent;

		public CardService(IUnitOfWork uow)
		{
			this._Repository = uow.GetRepository<Card>();
			this._getEntityListComponent = new GetEntityListComponent();
			this._addEntityComponent = new AddEntityComponent();
			this._getEntityByIDComponent = new GetEntityByIDComponent();
			this._editEntityComponent = new EditEntityComponent();
			this._deleteEntityComponent = new DeleteEntityComponent();
		}

		public void Add(Card card)
		{
			this._addEntityComponent.Execute(this._Repository, card);
		}

		public List<Card> GetAll(bool sortAscending, string sortPreference)
		{
			List<Card> cardList = this._getEntityListComponent.Execute(this._Repository);

			if (sortPreference == "Name")
			{
				if (sortAscending)
					cardList = cardList.OrderBy(x => x.Name).ToList();
				else
					cardList = cardList.OrderByDescending(x => x.Name).ToList();
			}
			else if (sortPreference == "Rank")
			{
				if (sortAscending)
					cardList = cardList.OrderBy(x => x.Rank).ToList();
				else
					cardList = cardList.OrderByDescending(x => x.Rank).ToList();
			}

			return cardList;
		}

		public Card GetByID(int? ID)
		{//TODO needs null check
			return this._getEntityByIDComponent.Execute(this._Repository, ID);
		}

		public void Edit(int ID, Card card)
		{
			this._editEntityComponent.Execute(this._Repository, card);
		}

		public void Delete(int ID)
		{
			this._deleteEntityComponent.Execute(this._Repository, ID);
		}

		public void ConvertEnums(Card card)
		{
			switch (card.Rank)
			{
				case Rank.Default:
					card.RankString = null;
					break;

				case Rank.One:
					card.RankString = "One";
					break;

				case Rank.Two:
					card.RankString = "Two";
					break;

				case Rank.Three:
					card.RankString = "Three";
					break;

				case Rank.Four:
					card.RankString = "Four";
					break;

				case Rank.Five:
					card.RankString = "Five";
					break;

				case Rank.Six:
					card.RankString = "Six";
					break;

				case Rank.Seven:
					card.RankString = "Seven";
					break;

				case Rank.Eight:
					card.RankString = "Eight";
					break;

				default:
					break;
			}
		}
	}
}