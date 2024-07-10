using BussinesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalCoreProje.Areas.Member.Controllers
{
	[AllowAnonymous]
	[Area("Member")]
	[Route("Member/[controller]/[action]")]
	public class DestinationController : Controller
	{
		DestinationManager destinationManager = new DestinationManager(new EfDestinationtDal());

		public IActionResult Index()
		{
			var values = destinationManager.TGetList();
			return View(values);
		}

		//public IActionResult GetCitiesSearchByName(string searchString)
		//{
		//	ViewData["CurrentFilter"] = searchString;
		//	var values = from x in destinationManager.TGetList() select x;

		//	if (!string.IsNullOrEmpty(searchString))
		//	{
		//		values = values.Where(y => y.City.ToLower().Contains(searchString.ToLower()));
		//	}
		//	return View(values.ToList());
		//}
	}
}
