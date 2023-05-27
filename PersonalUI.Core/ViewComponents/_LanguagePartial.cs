using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Personal.Core.Dto.Dtos.Language;
using Personal.Core.Service.Services;

namespace PersonalUI.Core.ViewComponents
{
    public class _LanguagePartial : ViewComponent
    {
        private readonly ILanguageService _LanguageService;
        private readonly IMapper _mapper;

        public _LanguagePartial(ILanguageService LanguageService, IMapper mapper)
        {
            _LanguageService = LanguageService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_mapper.Map<List<LanguageListDto>>(await _LanguageService.ToListByFilterAsync(x => x.Status == true)));
        }
    }
}
