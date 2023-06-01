using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Personal.Core.Dto.Dtos.Language;
using Personal.Core.Service.Services;

namespace PersonalUI.Core.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class LanguageController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILanguageService _languageService;

        public LanguageController(IMapper mapper, ILanguageService languageService)
        {
            _mapper = mapper;
            _languageService = languageService;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<List<LanguageListDto>>(await _languageService.ToListAsync()));
        }
        public async Task<IActionResult> NewLanguage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewLanguage(LanguageAddDto languageAddDto)
        {
            await _languageService.InsertAsync(new()
            {
                Content = languageAddDto.Content,
            });
            return Redirect("~/Admin/Language/Index");
        }
        public async Task<IActionResult> EditLanguage(int id)
        {
            var Language = await _languageService.GetByIdAsync(id);
            return View(new LanguageEditDto()
            {
                Content = Language.Content,
                Id = Language.Id,
            });
        }
        [HttpPost]
        public async Task<IActionResult> EditLanguage(LanguageEditDto languageEditDto)
        {
            var Language = await _languageService.GetByIdAsync(languageEditDto.Id);
            Language.Content = languageEditDto.Content;
            await _languageService.UpdateAsync(Language);
            return Redirect("~/Admin/Language/Index");
        }
        public async Task<IActionResult> DeleteLanguage(int id)
        {
            var Language = await _languageService.GetByIdAsync(id);
            Language.Status = false;
            Language.DeletedAt = DateTime.Now;
            await _languageService.UpdateAsync(Language);
            return Redirect("~/Admin/Language/Index");
        }
        public async Task<IActionResult> ChangeStatusLanguage(int id)
        {
            var Language = await _languageService.GetByIdAsync(id);
            await _languageService.ChangeStatusAsync(Language, Language.Status);
            return Redirect("~/Admin/Language/Index");
        }
    }
}
