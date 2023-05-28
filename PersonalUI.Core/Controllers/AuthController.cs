using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Personal.Core.Dto.Dtos.Manager;
using Personal.Core.Service.Services;
using PersonalUI.Core.Areas.Admin.Controllers;

namespace PersonalUI.Core.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly IManagerService _managerService;

        public AuthController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(ManagerLoginDto managerLoginDto)
        {
            ViewBag.failure = null;
            var userLogin = await _managerService.SignInAsync(new()
            {
                UserName = managerLoginDto.UserName,
                Password = managerLoginDto.Password,
            });
            if (userLogin == null)
            {
                ViewBag.failure = "Hatalı Kullanıcı Adı Veya Şifre";
                return View();
            }
            await HttpContext.SignInAsync(await _managerService.SignInWithClaimAsync(userLogin));
            return Redirect("~/Admin/Entrance/Index");
        }
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Main");
        }
    }
}
