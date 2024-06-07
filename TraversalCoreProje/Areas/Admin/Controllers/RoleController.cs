using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/[controller]/[action]/{id?}")]
	public class RoleController : Controller
	{
		private readonly RoleManager<AppRole> _roleManager;

		public RoleController(RoleManager<AppRole> roleManager)
		{
			_roleManager = roleManager;
		}

		public IActionResult Index()
		{
			var values = _roleManager.Roles.ToList();
			return View(values);
		}

		[HttpGet]
		public IActionResult CreateRole()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateRole(CreateRoleViewModel createRoleViewModel)
		{
			AppRole role = new AppRole()
			{
				Name = createRoleViewModel.RoleName
			};
			var result = await _roleManager.CreateAsync(role);
			if (result.Succeeded)
			{
				return RedirectToAction("Index");
			}
			else
			{
				return View();
			}
		}

		public async Task<IActionResult> DeleteRole(int id)
		{
			var values = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
			await _roleManager.DeleteAsync(values);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> UpdateRole(int id)
		{
			var values = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
			UpdateRoleViewModel updateRoleViewModel = new UpdateRoleViewModel()
			{
				RoleID = values.Id,
				RoleName = values.Name,
			};
			return View(updateRoleViewModel);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateRole(UpdateRoleViewModel updateRoleViewModel)
		{
			var values = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == updateRoleViewModel.RoleID);
			values.Name = updateRoleViewModel.RoleName;
			await _roleManager.UpdateAsync(values);
			return RedirectToAction("Index");
		}

	}
}
