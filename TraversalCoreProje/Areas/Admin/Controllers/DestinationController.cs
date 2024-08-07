﻿using BussinesLayer.Abstract;
using BussinesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/[controller]/[action]")]
	public class DestinationController : Controller
	{
		private readonly IDestinationService _destinationService;

		public DestinationController(IDestinationService destinationService)
		{
			_destinationService = destinationService;
		}

		public IActionResult Index()
		{
			var values = _destinationService.TGetList();
			return View(values);
		}

		[HttpGet]
		public IActionResult AddDestination()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddDestination(Destination destination)
		{
			_destinationService.TAdd(destination);
			return RedirectToAction("Index");
		}

		public IActionResult DeleteDestination(int id)
		{
			var values = _destinationService.TGetByID(id);
			_destinationService.TDelete(values);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult UpdateDestination(int id)
		{
			var values = _destinationService.TGetByID(id);
			return View(values);
		}

		[HttpPost]
		public IActionResult UpdateDestination(Destination destination)
		{
			_destinationService.TUpdate(destination);
			return RedirectToAction("Index");
		}

		public IActionResult GetCitiesSearchByName(string searchString)
		{
			ViewData["CurrentFilter"] = searchString;
			var values = from x in _destinationService.TGetList() select x;

			if (!string.IsNullOrEmpty(searchString))
			{
				values = values.Where(y => y.City.ToLower().Contains(searchString.ToLower()));
			}
			return View(values.ToList());
		}

	}
}
