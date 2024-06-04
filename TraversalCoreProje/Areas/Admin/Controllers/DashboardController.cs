using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class DashboardController : Controller
	{
		Context c = new Context();
		public IActionResult Index()
		{
			ViewBag.v1 = c.Destinations.Count();
			ViewBag.v2 = c.Users.Count();
			return View();
		}
	}
}

