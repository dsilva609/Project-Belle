using BusinessLogic.DAL;
using BusinessLogic.Repositories;
using BusinessLogic.Services;
using System.Web.Mvc;

namespace UI.Controllers
{
	public partial class GameController : Controller
	{
		private readonly IUnitOfWork _Uow;
		private readonly CardService _CardService;

		public GameController()
		{
			this._Uow = new UnitOfWork<ProjectArielContext>();
			this._CardService = new CardService(this._Uow);
		}

		#region HttpGet

		[HttpGet]
		public virtual ActionResult Index()
		{
			var cards = this._CardService.GetAll(false, "None");

			return View(cards);
		}

		#endregion HttpGet
	}
}