using AutoMapper;
using BussinesLayer.Abstract;
using DTOLayer.DTOs.ContactUsDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Drawing.Printing;

namespace TraversalCoreProje.Controllers
{
	public class ContactUsController : Controller
	{
		private readonly IContactUsService _contactUsService;
		private readonly IMapper _mapper;

		public ContactUsController(IContactUsService contactUsService, IMapper mapper)
		{
			_contactUsService = contactUsService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(SendMessageDTO model)
		{
			if (ModelState.IsValid)
			{
				_contactUsService.TAdd(new ContactUs()
				{
					Name = model.Name,
					Mail = model.Mail,
					Subject = model.Subject,
					MessageBody = model.MessageBody,
					MessageStatus = true,
					MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
				});
				return RedirectToAction("Index","Default");
			}
			return View(model);
		}
	}
}
