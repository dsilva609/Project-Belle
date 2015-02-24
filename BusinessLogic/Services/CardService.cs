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
			else if (sortPreference == "CardType")
			{
				if (sortAscending)
					cardList = cardList.OrderBy(x => x.CardTypeString).ToList();
				else
					cardList = cardList.OrderByDescending(x => x.CardTypeString).ToList();
			}
			else if (sortPreference == "Expansion")
			{
				if (sortAscending)
					cardList = cardList.OrderBy(x => x.ExpansionString).ToList();
				else
					cardList.OrderByDescending(x => x.ExpansionString).ToList();
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
			switch (card.Cardtype)
			{
				case CardType.Default:
					card.CardTypeString = string.Empty;
					break;

				case CardType.Basic:
					card.CardTypeString = "Basic";
					break;

				case CardType.Alcohol:
					card.CardTypeString = "Alcohol";
					break;

				case CardType.Draw:
					card.CardTypeString = "Draw";
					break;

				case CardType.TimeDelay:
					card.CardTypeString = "Time Delay";
					break;

				case CardType.Weapon:
					card.CardTypeString = "Weapon";
					break;

				case CardType.Equipment:
					card.CardTypeString = "Equipment";
					break;

				case CardType.TargetAll:
					card.CardTypeString = "Target All";
					break;

				case CardType.Role:
					card.CardTypeString = "Role";
					break;

				case CardType.Event:
					card.CardTypeString = "Event";
					break;

				case CardType.Character:
					card.CardTypeString = "Character";
					break;

				default:
					break;
			}

			switch (card.Suit)
			{
				case Suit.Default:
					card.SuitString = null;
					break;

				case Suit.Heart:
					card.SuitString = "Heart";
					break;

				case Suit.Diamond:
					card.SuitString = "Diamond";
					break;

				case Suit.Club:
					card.SuitString = "Club";
					break;

				case Suit.Spade:
					card.SuitString = "Spade";
					break;

				default:
					break;
			}

			switch (card.Rank)
			{
				case Rank.Default:
					card.RankString = null;
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

				case Rank.Nine:
					card.RankString = "Nine";
					break;

				case Rank.Ten:
					card.RankString = "Ten";
					break;

				case Rank.Jack:
					card.RankString = "Jack";
					break;

				case Rank.Queen:
					card.RankString = "Queen";
					break;

				case Rank.King:
					card.RankString = "King";
					break;

				case Rank.Ace:
					card.RankString = "Ace";
					break;

				default:
					break;
			}
			switch (card.Expansion)
			{
				case Expansion.Default:
					card.ExpansionString = string.Empty;
					break;

				case Expansion.Standard:
					card.ExpansionString = "Standard";
					break;

				case Expansion.HighNoon:
					card.ExpansionString = "High Noon";
					break;

				case Expansion.DodgeCity:
					card.ExpansionString = "Dodge City";
					break;

				case Expansion.AFistfulOfCards:
					card.ExpansionString = "A Fistful Of Cards";
					break;

				case Expansion.WildWestShow:
					card.ExpansionString = "Wild West Show";
					break;

				case Expansion.GoldRush:
					card.ExpansionString = "Gold Rush";
					break;

				case Expansion.ValleyOfShadows:
					card.ExpansionString = "Valley Of Shadows";
					break;

				case Expansion.ElDorado:
					card.ExpansionString = "El Dorado";
					break;

				case Expansion.DeathMesa:
					card.ExpansionString = "Death Mesa";
					break;

				case Expansion.RobbersRoost:
					card.ExpansionString = "Robber's Roost";
					break;

				case Expansion.BangTheBullet:
					card.ExpansionString = "Bang! The Bullet";
					break;

				case Expansion.Anniversary:
					card.ExpansionString = "Anniversary";
					break;

				default:
					break;
			}
		}
	}
}