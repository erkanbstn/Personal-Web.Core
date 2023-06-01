using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Personal.Core.Dto.Dtos.Education;
using Personal.Core.Service.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using Personal.Core.Core.Models;

namespace PersonalUI.Core.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class EducationController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEducationService _educationService;

        public EducationController(IEducationService educationService, IMapper mapper)
        {
            _educationService = educationService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<List<EducationListDto>>(await _educationService.ToListAsync()));
        }
        public async Task<IActionResult> NewEducation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewEducation(EducationEditDto EducationEditDto)
        {
            await _educationService.InsertAsync(new()
            {
                Content = EducationEditDto.Content,
                Address = EducationEditDto.Address,
                Date = EducationEditDto.Date,
                Degree = EducationEditDto.Degree,
                Graduation = EducationEditDto.Graduation,
            });
            return Redirect("~/Admin/Education/Index");
        }
        public async Task<IActionResult> EditEducation(int id)
        {
            var Education = await _educationService.GetByIdAsync(id);
            return View(new EducationEditDto()
            {
                Id = Education.Id,
                Content = Education.Content,
                Status = Education.Status,
                Address = Education.Address,
                Date = Education.Date,
                Degree = Education.Degree,
                Graduation = Education.Graduation
            });
        }
        [HttpPost]
        public async Task<IActionResult> EditEducation(EducationEditDto EducationEditDto)
        {
            var Education = await _educationService.GetByIdAsync(EducationEditDto.Id);
            Education.Content = EducationEditDto.Content;
            Education.Address = EducationEditDto.Address;
            Education.Date = EducationEditDto.Date;
            Education.Degree = EducationEditDto.Degree;
            Education.Graduation = EducationEditDto.Graduation;
            await _educationService.UpdateAsync(Education);
            return Redirect("~/Admin/Education/Index");
        }
        public async Task<IActionResult> DeleteEducation(int id)
        {
            var Education = await _educationService.GetByIdAsync(id);
            Education.Status = false;
            Education.DeletedAt = DateTime.Now;
            await _educationService.UpdateAsync(Education);
            return Redirect("~/Admin/Education/Index");
        }
        public async Task<IActionResult> ChangeStatusEducation(int id)
        {
            var Education = await _educationService.GetByIdAsync(id);
            await _educationService.ChangeStatusAsync(Education, Education.Status);
            return Redirect("~/Admin/Education/Index");
        }
    }
}
