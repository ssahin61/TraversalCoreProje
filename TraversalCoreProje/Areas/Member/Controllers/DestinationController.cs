using BussinesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Member.Controllers
{
	[AllowAnonymous]
	[Area("Member")]
	public class DestinationController : Controller
	{
		DestinationManager destinationManager = new DestinationManager(new EfDestinationtDal());

		public IActionResult Index()
		{
			var values = destinationManager.TGetList();
			return View(values);
		}
	}
}
