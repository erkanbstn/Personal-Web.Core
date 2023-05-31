using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Personal.Core.Dto.Dtos.About;
using Personal.Core.Service.Services;

namespace PersonalUI.Core.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<List<AboutListDto>>(await _aboutService.ToListAsync()));
        }
        public async Task<IActionResult> EditAbout(int id)
        {
            var about = await _aboutService.GetByIdAsync(id);
            return View(new AboutEditDto()
            {
                Id = about.Id,
                Content = about.Content,
                Status = about.Status,
                Title = about.Title,
                GithubUrl = about.GithubUrl,
                LinkedInUrl = about.LinkedInUrl,
                ClickCount = about.ClickCount,
            });
        }
        [HttpPost]
        public async Task<IActionResult> EditAbout(AboutEditDto aboutEditDto)
        {
            var about = await _aboutService.GetByIdAsync(aboutEditDto.Id);
            about.Title = aboutEditDto.Title;
            about.Content = aboutEditDto.Content;
            about.LinkedInUrl = aboutEditDto.LinkedInUrl;
            about.GithubUrl = aboutEditDto.GithubUrl;
            about.ClickCount = aboutEditDto.ClickCount;
            await _aboutService.UpdateAsync(about);
            return Redirect("~/Admin/About/Index");
        }
        public async Task<IActionResult> DeleteAbout(int id)
        {
            var about = await _aboutService.GetByIdAsync(id);
            about.Status = false;
            about.DeletedAt = DateTime.Now;
            await _aboutService.UpdateAsync(about);
            return Redirect("~/Admin/About/Index");
        }
        public async Task<IActionResult> ChangeStatusAbout(int id)
        {
            var about = await _aboutService.GetByIdAsync(id);
            await _aboutService.ChangeStatusAsync(about, about.Status);
            return Redirect("~/Admin/about/Index");
        }
    }
}
