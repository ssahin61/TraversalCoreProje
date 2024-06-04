using BussinesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Composition.Convention;

namespace TraversalCoreProje.Controllers
{
	public class CommentController : Controller
	{
		CommentManager commentManager = new CommentManager(new EfCommentDal());

		[HttpGet]
		public PartialViewResult AddComment()
		{
			return PartialView();
		}

		[HttpPost]
		public IActionResult AddComment(Comment p)
		{
			p.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
			p.CommentState = true; ;
			commentManager.TAdd(p);
			return RedirectToAction("Index", "Destination");
		}
	}
}
