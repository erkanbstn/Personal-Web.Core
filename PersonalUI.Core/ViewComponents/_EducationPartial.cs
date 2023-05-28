using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Personal.Core.Dto.Dtos.Education;
using Personal.Core.Service.Services;

namespace PersonalUI.Core.ViewComponents
{
    public class _EducationPartial : ViewComponent
    {
        private readonly IEducationService _EducationService;
        private readonly IMapper _mapper;

        public _EducationPartial(IEducationService EducationService, IMapper mapper)
        {
            _EducationService = EducationService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_mapper.Map<List<EducationListDto>>(await _EducationService.OrderByDescendingEducation()));
        }
    }
}
