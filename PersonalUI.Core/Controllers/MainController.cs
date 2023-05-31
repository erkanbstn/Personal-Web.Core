using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Personal.Core.Dto.Dtos.Contact;
using Personal.Core.Dto.Dtos.Entrance;
using Personal.Core.Dto.Dtos.Experience;
using Personal.Core.Dto.Dtos.Project;
using Personal.Core.Service.Services;
namespace PersonalUI.Core.Controllers
{
    [AllowAnonymous]
    public class MainController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IEntranceService _entranceService;
        private readonly IContactService _contactService;
        private readonly IExperienceService _experienceService;
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;
        private readonly IPdfService _pdfService;
        private readonly IFileProvider _fileProvider;
        public MainController(IEntranceService entranceService, IMapper mapper, IContactService contactService, IExperienceService experienceService, IProjectService projectService, IFileProvider fileProvider, IAboutService aboutService, IPdfService pdfService)
        {
            _entranceService = entranceService;
            _mapper = mapper;
            _contactService = contactService;
            _experienceService = experienceService;
            _projectService = projectService;
            _fileProvider = fileProvider;
            _aboutService = aboutService;
            _pdfService = pdfService;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<List<EntranceListDto>>(await _entranceService.ToListByFilterAsync(x => x.Status == true)));
        }
        public async Task<IActionResult> Resume()
        {
            ViewBag.clickCount = await _aboutService.GetClickCountAsync();
            return View(_mapper.Map<List<ExperienceListDto>>(await _experienceService.OrderByDescendingExperience()));
        }
        public async Task<IActionResult> Contact()
        {
            return View();
        }
        public async Task<IActionResult> Projects()
        {
            return View(_mapper.Map<List<ProjectListDto>>(await _projectService.OrderByDescendingProject()));
        }
        // Error Page
        public async Task<IActionResult> Error()
        {
            return View();
        }
        // Send Message
        [HttpPost]
        public async Task<JsonResult> SendMessage(ContactAddDto contactAddDto)
        {
            await _contactService.InsertAsync(new()
            {
                Email = contactAddDto.Email,
                FullName = contactAddDto.FullName,
                Phone = contactAddDto.Phone,
                Message = contactAddDto.Message,
            });
            return Json(new { data = true });
        }
        public async Task<IActionResult> ExportPdf(string id)
        {
            return File(await _pdfService.ExportResumeAsync("wwwroot/Files", $"CV_Erkan_Bostan_{id}.pdf"), "application/pdf", $"CV_Erkan_Bostan_{id}.pdf");
        }
        [HttpPost]
        public async Task<JsonResult> IncreaseDownloadCount()
        {
            var about = await _aboutService.GetByIdAsync(1);
            about.ClickCount++;
            await _aboutService.UpdateAsync(about);
            var count = await _aboutService.GetClickCountAsync();
            return Json(new { data = count });
        }
    }
}
