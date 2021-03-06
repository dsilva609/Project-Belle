﻿using AutoMapper;
using BusinessLogic.DAL;
using BusinessLogic.Models;
using BusinessLogic.Repositories;
using BusinessLogic.Services;
using System.Collections.Generic;
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
			this._Uow = new UnitOfWork<ProjectBelleContext>();
			this._Service = new CardService(this._Uow);
		}

		#region HttpGet

		[HttpGet]
		public virtual ActionResult Index()
		{
			var viewModel = new List<CardViewModel>();
			var cardList = this._Service.GetAll((bool)Session[this.CARD_SORT_ASCENDING_STRING], Session[this.CARD_SORT_PREFERENCE_STRING].ToString());
			Mapper.Map<List<Card>, List<CardViewModel>>(cardList, viewModel);
			return View(viewModel);
		}

		[HttpGet]
		public virtual ActionResult Details(int ID)
		{
			var card = this._Service.GetByID(ID);

			return View(card);
		}

		[Authorize(Roles = "Admin")]
		[HttpGet]
		public virtual ActionResult Create()
		{
			var cardViewModel = new CardViewModel();
			cardViewModel.ViewTitle = "Create New Card";

			return View(cardViewModel);
		}

		[Authorize(Roles = "Admin")]
		[HttpGet]
		public virtual ActionResult Edit(int ID)
		{
			var cardViewModel = new CardViewModel();

			var card = this._Service.GetByID(ID);
			Mapper.Map<Card, CardViewModel>(card, cardViewModel);
			cardViewModel.ViewTitle = "Edit Card: " + card.Name;

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

		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual ActionResult Create(CardViewModel cardViewModel)
		{
			if (ModelState.IsValid)
			{
				var card = new Card();

				Mapper.Map<CardViewModel, Card>(cardViewModel, card);

				this._Service.ConvertEnums(card);
				card.IsActive = true;
				this._Service.Add(card);

				return RedirectToAction(MVC.Card.Index());
			}
			return View(cardViewModel);
		}

		// POST: Card/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual ActionResult Edit(CardViewModel cardViewModel, int ID)
		{
			if (ModelState.IsValid)
			{
				var card = new Card();

				Mapper.Map<CardViewModel, Card>(cardViewModel, card);

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
				this._Uow.Dispose();

			base.Dispose(disposing);
		}
	}
}