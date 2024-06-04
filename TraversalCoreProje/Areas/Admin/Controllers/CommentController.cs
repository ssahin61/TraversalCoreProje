using BussinesLayer.Abstract;
using BussinesLayer.Concrete;
using DataAccesLayer.Abstract;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CommentController : Controller
	{
		private readonly ICommentService _commentService;

		public CommentController(ICommentService commentService)
		{
			_commentService = commentService;
		}

		public IActionResult Index()
		{
			var values = _commentService.TGetListCommentWithDestination();
			return View(values);
		}

		public IActionResult DeleteComment(int id)
		{
			var values = _commentService.TGetByID(id);
			_commentService.TDelete(values);
			return RedirectToAction("Index");
		}
	}
}
