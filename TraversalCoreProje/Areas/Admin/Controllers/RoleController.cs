using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
		private readonly UserManager<AppUser> _userManager;

		public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
		{
			_roleManager = roleManager;
			_userManager = userManager;
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

		public IActionResult UserList()
		{
			var values = _userManager.Users.ToList();
			return View(values);
		}

		[HttpGet]
		public async Task<IActionResult> AssignRole(int id)
		{
			var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
			TempData["userid"] = user.Id;
			var role = await _roleManager.Roles.ToListAsync();
			var userRoles = await _userManager.GetRolesAsync(user);
			List<RoleAssignViewModel> roleAssignViewModels = new List<RoleAssignViewModel>();
			foreach (var item in role)
			{
				RoleAssignViewModel model = new RoleAssignViewModel();
				model.RoleID = item.Id;
				model.RoleName = item.Name;
				model.RoleExist = userRoles.Contains(item.Name);
				roleAssignViewModels.Add(model);
			}
			return View(roleAssignViewModels);
		}

		[HttpPost]
		public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
		{
			var userid = (int)TempData["userid"];
			var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userid);
			foreach (var item in model)
			{
				if (item.RoleExist)
				{
					await _userManager.AddToRoleAsync(user, item.RoleName);
				}
				else
				{
					await _userManager.RemoveFromRoleAsync(user, item.RoleName);
				}
			}
			return RedirectToAction("UserList");
		}

	}
}
