using Microsoft.AspNetCore.Mvc;

namespace PersonalUI.Core.ViewComponents
{
    public class _AboutPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
