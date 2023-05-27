using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Personal.Core.Dto.Dtos.Contact;
using Personal.Core.Dto.Dtos.Entrance;
using Personal.Core.Service.Services;

namespace PersonalUI.Core.Controllers
{
    public class MainController : Controller
    {
        private readonly IEntranceService _entranceService;
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        public MainController(IEntranceService entranceService, IMapper mapper, IContactService contactService)
        {
            _entranceService = entranceService;
            _mapper = mapper;
            _contactService = contactService;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<List<EntranceListDto>>(await _entranceService.ToListByFilterAsync(x => x.Status == true)));
        }
        public async Task<IActionResult> Resume()
        {
            return View();
        }
        public async Task<IActionResult> Contact()
        {
            return View();
        }
        public async Task<IActionResult> Projects()
        {
            return View();
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
    }
}
