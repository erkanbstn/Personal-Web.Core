using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Personal.Core.Dto.Dtos.Manager;
using Personal.Core.Service.Services;

namespace PersonalUI.Core.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ManagerController : Controller
    {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        public async Task<IActionResult> EditManager()
        {
            var user = await _managerService.GetByNameAsync(User.Identity.Name);
            return View(new ManagerEditDto()
            {
                Id = user.Id,
                Password = user.Password,
                UserName = user.UserName
            });
        }
        [HttpPost]
        public async Task<IActionResult> EditManager(ManagerEditDto managerEditDto)
        {
            ViewBag.success = 0;
            var manager = await _managerService.GetByIdAsync(managerEditDto.Id);
            manager.UserName = managerEditDto.UserName;
            manager.Password = managerEditDto.Password;
            await _managerService.UpdateAsync(manager);
            ViewBag.success = 1;
            return Redirect("~/Admin/Manager/EditManager");
        }
    }
}
