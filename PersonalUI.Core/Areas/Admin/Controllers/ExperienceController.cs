using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Personal.Core.Dto.Dtos.Experience;
using Personal.Core.Service.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;

namespace PersonalUI.Core.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ExperienceController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IExperienceService _ExperienceService;

        public ExperienceController(IExperienceService experienceService, IMapper mapper)
        {
            _ExperienceService = experienceService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<List<ExperienceListDto>>(await _ExperienceService.ToListAsync()));
        }
        public async Task<IActionResult> NewExperience()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewExperience(ExperienceEditDto ExperienceEditDto)
        {
            await _ExperienceService.InsertAsync(new()
            {
                Content = ExperienceEditDto.Content,
                Address = ExperienceEditDto.Address,
                Date = ExperienceEditDto.Date,
                Company = ExperienceEditDto.Company,
                Title = ExperienceEditDto.Title,
            });
            return Redirect("~/Admin/Experience/Index");
        }
        public async Task<IActionResult> EditExperience(int id)
        {
            var Experience = await _ExperienceService.GetByIdAsync(id);
            return View(new ExperienceEditDto()
            {
                Content = Experience.Content,
                Address = Experience.Address,
                Date = Experience.Date,
                Company = Experience.Company,
                Title = Experience.Title,
                Id = Experience.Id,
            });
        }
        [HttpPost]
        public async Task<IActionResult> EditExperience(ExperienceEditDto ExperienceEditDto)
        {
            var Experience = await _ExperienceService.GetByIdAsync(ExperienceEditDto.Id);
            Experience.Content = ExperienceEditDto.Content;
            Experience.Address = ExperienceEditDto.Address;
            Experience.Date = ExperienceEditDto.Date;
            Experience.Company = ExperienceEditDto.Company;
            Experience.Title = ExperienceEditDto.Title;
            await _ExperienceService.UpdateAsync(Experience);
            return Redirect("~/Admin/Experience/Index");
        }
        public async Task<IActionResult> DeleteExperience(int id)
        {
            var Experience = await _ExperienceService.GetByIdAsync(id);
            Experience.Status = false;
            Experience.DeletedAt = DateTime.Now;
            await _ExperienceService.UpdateAsync(Experience);
            return Redirect("~/Admin/Experience/Index");
        }
        public async Task<IActionResult> ChangeStatusExperience(int id)
        {
            var Experience = await _ExperienceService.GetByIdAsync(id);
            await _ExperienceService.ChangeStatusAsync(Experience, Experience.Status);
            return Redirect("~/Admin/Experience/Index");
        }
    }
}
