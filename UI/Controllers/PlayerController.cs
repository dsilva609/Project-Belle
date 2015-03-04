using AutoMapper;
using BusinessLogic.DAL;
using BusinessLogic.Models;
using BusinessLogic.Repositories;
using BusinessLogic.Services;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
	public partial class PlayerController : Controller
	{
		private readonly string PLAYER_SORT_ASCENDING_STRING = "PlayerSortAscending";
		private readonly string PLAYER_SORT_PREFERENCE_STRING = "PlayerSortPreference";
		private readonly IUnitOfWork _Uow;
		private readonly PlayerService _Service;

		public PlayerController()
		{
			this._Uow = new UnitOfWork<ProjectBelleContext>();
			this._Service = new PlayerService(this._Uow);
		}

		#region HttpGet

		[HttpGet]
		public virtual ActionResult Index()
		{
			return View(this._Service.GetAll((bool)Session[this.PLAYER_SORT_ASCENDING_STRING], Session[this.PLAYER_SORT_PREFERENCE_STRING].ToString()));
		}

		[HttpGet]
		public virtual ActionResult RedirectUser(int ID)
		{
			if (User.IsInRole("Admin"))
				return RedirectToAction(MVC.Player.Edit(ID));

			return RedirectToAction(MVC.Player.Details(ID));
		}

		[HttpGet]
		public virtual ActionResult Details(int? ID)
		{
			var player = this._Service.GetByID(ID);

			if (player == null)
				return HttpNotFound();

			return View(player);
		}

		[Authorize(Roles = "Admin")]
		[HttpGet]
		public virtual ActionResult Create()
		{
			var playerViewModel = new PlayerViewModel();
			playerViewModel.ViewTitle = "Create Player";

			return View(playerViewModel);
		}

		[Authorize(Roles = "Admin")]
		[HttpGet]
		public virtual ActionResult Edit(int ID)
		{
			var playerViewModel = new PlayerViewModel();

			var player = this._Service.GetByID(ID);
			Mapper.Map<Player, PlayerViewModel>(player, playerViewModel);
			playerViewModel.ViewTitle = "Edit Player: " + player.Name;

			return View(playerViewModel);
		}

		[Authorize(Roles = "Admin")]
		[HttpGet]
		public virtual ActionResult Delete(int ID)
		{
			this._Service.Delete(ID);

			return RedirectToAction(MVC.Player.Index());
		}

		[HttpGet]
		public virtual ActionResult SortPlayers(string sortPreference)
		{
			if ((bool)Session[this.PLAYER_SORT_ASCENDING_STRING])
				Session[this.PLAYER_SORT_ASCENDING_STRING] = false;
			else
				Session[this.PLAYER_SORT_ASCENDING_STRING] = true;

			Session[this.PLAYER_SORT_PREFERENCE_STRING] = sortPreference;

			return RedirectToAction(MVC.Player.Index());
		}

		#endregion HttpGet

		#region HttpPost

		[Authorize(Roles = "Admin")]
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.

		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual ActionResult Create(PlayerViewModel playerModel)
		{
			if (ModelState.IsValid)
			{
				var player = new Player();

				Mapper.Map<PlayerViewModel, Player>(playerModel, player);

				player.IsActive = true;

				this._Service.Add(player);

				return RedirectToAction(MVC.Player.Index());
			}
			return View(playerModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual ActionResult Edit(PlayerViewModel playerViewModel, int ID)
		{
			if (ModelState.IsValid)
			{
				var player = new Player();

				Mapper.Map<PlayerViewModel, Player>(playerViewModel, player);

				this._Service.Edit(ID, player);

				return RedirectToAction(MVC.Player.Index());
			}
			return View(playerViewModel);
		}

		#endregion HttpPost

		#region Helpers

		[NonAction]
		protected override void Dispose(bool disposing)
		{
			if (disposing)
				this._Uow.Dispose();

			base.Dispose(disposing);
		}
	}

		#endregion Helpers
}