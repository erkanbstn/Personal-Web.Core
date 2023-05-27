using Microsoft.AspNetCore.Mvc;

namespace PersonalUI.Core.Controllers
{
	public class MainController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
        public IActionResult Resume()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Projects()
        {
            return View();
        }
        // Error Page
        public IActionResult Error()
		{
			return View();
		}
	}
}
