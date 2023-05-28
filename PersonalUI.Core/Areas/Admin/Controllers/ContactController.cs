using Microsoft.AspNetCore.Mvc;

namespace PersonalUI.Core.Areas.Admin.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
