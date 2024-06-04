using BussinesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalCoreProje.ViewComponents.Comments
{
    public class _CommentList : ViewComponent
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());

        public IViewComponentResult Invoke(int id)
        {
            var values = commentManager.TGetListCommentWithDestinationAndUser(id);
            ViewBag.commentCount = values.Count();
            return View(values);

        }
    }
}
