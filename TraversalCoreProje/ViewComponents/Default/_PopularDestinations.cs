using BussinesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _PopularDestinations:ViewComponent
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationtDal());

        public IViewComponentResult Invoke()
        {
            var values = destinationManager.TGetList();
            return View(values);
        }
    }
}
