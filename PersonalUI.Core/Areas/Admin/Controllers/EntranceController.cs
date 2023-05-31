using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Personal.Core.Dto.Dtos.Entrance;
using Personal.Core.Service.Services;

namespace PersonalUI.Core.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class EntranceController : Controller
    {
        private readonly IEntranceService _entranceService;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        public EntranceController(IEntranceService entranceService, IMapper mapper, IFileService fileService)
        {
            _entranceService = entranceService;
            _mapper = mapper;
            _fileService = fileService;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<List<EntranceListDto>>(await _entranceService.ToListAsync()));
        }
        public async Task<IActionResult> EditEntrance(int id)
        {
            var entrance = await _entranceService.GetByIdAsync(id);
            return View(new EntranceEditDto()
            {
                Id = entrance.Id,
                Content = entrance.Content,
                Detail = entrance.Detail,
                Status = entrance.Status,
                Title = entrance.Title,
            });
        }
        [HttpPost]
        public async Task<IActionResult> EditEntrance(EntranceEditDto entranceEditDto)
        {
            var entrance = await _entranceService.GetByIdAsync(entranceEditDto.Id);
            entrance.Title = entranceEditDto.Title;
            entrance.Content = entranceEditDto.Content;
            entrance.Detail = entranceEditDto.Detail;
            if (entranceEditDto.Picture != null && entranceEditDto.Picture.Length > 0)
            {
                entrance.ImageUrl = await _fileService.UploadImageAsync(entranceEditDto.Picture.FileName, entranceEditDto.Picture);
            }
            await _entranceService.UpdateAsync(entrance);
            return Redirect("~/Admin/Entrance/Index");
        }
        public async Task<IActionResult> DeleteEntrance(int id)
        {
            var entrance = await _entranceService.GetByIdAsync(id);
            entrance.Status = false;
            entrance.DeletedAt = DateTime.Now;
            await _entranceService.UpdateAsync(entrance);
            return Redirect("~/Admin/Entrance/Index");
        }
        public async Task<IActionResult> ChangeStatusEntrance(int id)
        {
            var entrance = await _entranceService.GetByIdAsync(id);
            await _entranceService.ChangeStatusAsync(entrance, entrance.Status);
            return Redirect("~/Admin/Entrance/Index");
        }
    }
}
