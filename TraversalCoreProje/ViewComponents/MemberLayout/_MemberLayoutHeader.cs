using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.MemberLayout
{
	public class _MemberLayoutHeader : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View(); 
		}
	}
}
