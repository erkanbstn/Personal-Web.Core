using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Personal.Core.Dto.Dtos.Skill;
using Personal.Core.Service.Services;

namespace PersonalUI.Core.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SkillController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ISkillService _skillService;

        public SkillController(IMapper mapper, ISkillService skillService)
        {
            _mapper = mapper;
            _skillService = skillService;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<List<SkillListDto>>(await _skillService.ToListAsync()));
        }
        public async Task<IActionResult> NewSkill()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewSkill(SkillAddDto skillAddDto)
        {
            await _skillService.InsertAsync(new()
            {
                Content = skillAddDto.Content,
            });
            return Redirect("~/Admin/Skill/Index");
        }
        public async Task<IActionResult> EditSkill(int id)
        {
            var Skill = await _skillService.GetByIdAsync(id);
            return View(new SkillEditDto()
            {
                Content = Skill.Content,
                Id = Skill.Id,
            });
        }
        [HttpPost]
        public async Task<IActionResult> EditSkill(SkillEditDto skillEditDto)
        {
            var Skill = await _skillService.GetByIdAsync(skillEditDto.Id);
            Skill.Content = skillEditDto.Content;
            await _skillService.UpdateAsync(Skill);
            return Redirect("~/Admin/Skill/Index");
        }
        public async Task<IActionResult> DeleteSkill(int id)
        {
            var Skill = await _skillService.GetByIdAsync(id);
            Skill.Status = false;
            Skill.DeletedAt = DateTime.Now;
            await _skillService.UpdateAsync(Skill);
            return Redirect("~/Admin/Skill/Index");
        }
        public async Task<IActionResult> ChangeStatusSkill(int id)
        {
            var Skill = await _skillService.GetByIdAsync(id);
            await _skillService.ChangeStatusAsync(Skill, Skill.Status);
            return Redirect("~/Admin/Skill/Index");
        }
    }
}
