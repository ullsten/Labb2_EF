using Labb2_EF.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Labb2_EF.Controllers
{
    [Authorize(Roles ="Administrator")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        public AdminController(UserManager<IdentityUser> _userManager)
        {
            userManager = _userManager;
        }
        public async Task<ActionResult> Index()
        {
            var admin = (await userManager
                .GetUsersInRoleAsync("Administrator"))
                .ToArray();

            var model = new AdminViewModel
            {
                Administrators = admin,
            };

            return View();
        }
    }
}
