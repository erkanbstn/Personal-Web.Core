using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Personal.Core.Dto.Dtos.Skill;
using Personal.Core.Service.Services;

namespace PersonalUI.Core.ViewComponents
{
    public class _SkillPartial : ViewComponent
    {
        private readonly ISkillService _SkillService;
        private readonly IMapper _mapper;

        public _SkillPartial(ISkillService SkillService, IMapper mapper)
        {
            _SkillService = SkillService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_mapper.Map<List<SkillListDto>>(await _SkillService.ToListByFilterAsync(x => x.Status == true)));
        }
    }
}
