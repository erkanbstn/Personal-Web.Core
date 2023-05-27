using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Personal.Core.Dto.Dtos.About;
using Personal.Core.Service.Services;

namespace PersonalUI.Core.ViewComponents
{
    public class _AboutPartial : ViewComponent
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public _AboutPartial(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_mapper.Map<List<AboutListDto>>(await _aboutService.ToListByFilterAsync(x => x.Status == true)));
        }
    }
}
