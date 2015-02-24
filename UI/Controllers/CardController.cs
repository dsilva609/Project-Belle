using AutoMapper;
using BusinessLogic.DAL;
using BusinessLogic.Models;
using BusinessLogic.Repositories;
using BusinessLogic.Services;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
	public partial class CardController : Controller
	{
		private readonly string CARD_SORT_ASCENDING_STRING = "CardSortAscending";
		private readonly string CARD_SORT_PREFERENCE_STRING = "CardSortPreference";
		private readonly IUnitOfWork _Uow;
		private readonly CardService _Service;

		public CardController()
		{
			this._Uow = new UnitOfWork<ProjectArielContext>();
			this._Service = new CardService(this._Uow);
		}

		#region HttpGet

		[HttpGet]
		public virtual ActionResult Index()
		{
			return View(this._Service.GetAll((bool)Session[this.CARD_SORT_ASCENDING_STRING], Session[this.CARD_SORT_PREFERENCE_STRING].ToString()));
		}

		[HttpGet]
		public virtual ActionResult RedirectUser(int? ID)
		{
			if (User.IsInRole("Admin"))
				return RedirectToAction(MVC.Card.Edit(ID));

			return RedirectToAction(MVC.Card.Details(ID));
		}

		[HttpGet]
		public virtual ActionResult Details(int? ID)
		{
			var card = this._Service.GetByID(ID);
			if (card == null)
			{
				return HttpNotFound();
			}

			return View(card);
		}

		[Authorize(Roles = "Admin")]
		[HttpGet]
		public virtual ActionResult Create()
		{
			return RedirectToAction(MVC.Card.Edit());
		}

		[Authorize(Roles = "Admin")]
		[HttpGet]
		public virtual ActionResult Edit(int? ID)
		{
			var card = new Card();
			var cardViewModel = new CardViewModel();
			cardViewModel.ViewTitle = "Create New Card";
			//ViewBag.Title = "Create New Card";

			if (ID > 0)
			{
				card = this._Service.GetByID(ID);
				Mapper.Map<Card, CardViewModel>(card, cardViewModel);
				cardViewModel.ViewTitle = "Edit Card: " + card.Name;
				//ViewBag.Title = "Edit Card: " + card.Name;
			}

			if (card == null)
			{
				return HttpNotFound();
			}

			return View(cardViewModel);
		}

		[Authorize(Roles = "Admin")]
		[HttpGet]
		public virtual ActionResult Delete(int ID)
		{
			this._Service.Delete(ID);

			return RedirectToAction(MVC.Card.Index());
		}

		[HttpGet]
		public virtual ActionResult SortPlayers(string sortPreference)
		{
			if ((bool)Session[this.CARD_SORT_ASCENDING_STRING])
				Session[this.CARD_SORT_ASCENDING_STRING] = false;
			else
				Session[this.CARD_SORT_ASCENDING_STRING] = true;

			Session[this.CARD_SORT_PREFERENCE_STRING] = sortPreference;

			return RedirectToAction(MVC.Player.Index());
		}

		#endregion HttpGet

		[Authorize(Roles = "Admin")]

		#region HttpPost

		// POST: Card/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual ActionResult Edit([Bind(Include = "ID,Name,Description,Expansion,Action,Range,Cardtype,Suit,Rank,ImageLocation,IsActive")] CardViewModel cardViewModel, int ID)
		{
			if (ModelState.IsValid)
			{
				var card = new Card();

				Mapper.Map<CardViewModel, Card>(cardViewModel, card);
				if (ID == 0)
				{
					cardViewModel.IsActive = true;
					this._Service.Add(card);
				}
				this._Service.ConvertEnums(card);
				this._Service.Edit(ID, card);

				return RedirectToAction(MVC.Card.Index());
			}
			return View(cardViewModel);
		}

		#endregion HttpPost

		[NonAction]
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this._Uow.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}