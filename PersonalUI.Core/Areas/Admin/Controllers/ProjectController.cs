using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Personal.Core.Dto.Dtos.Entrance;
using Personal.Core.Dto.Dtos.Project;
using Personal.Core.Service.Services;

namespace PersonalUI.Core.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        public ProjectController(IMapper mapper, IFileService fileService, IProjectService projectService)
        {
            _mapper = mapper;
            _fileService = fileService;
            _projectService = projectService;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<List<ProjectListDto>>(await _projectService.ToListAsync()));
        }
        public async Task<IActionResult> NewProject()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewProject(ProjectAddDto projectAddDto)
        {
            if (projectAddDto.Picture != null && projectAddDto.Picture.Length > 0)
            {
                projectAddDto.ImageUrl = await _fileService.UploadImageAsync(projectAddDto.Picture.FileName, projectAddDto.Picture);
            }
            await _projectService.InsertAsync(new()
            {
                Title = projectAddDto.Title,
                Content = projectAddDto.Content,
                ImageUrl = projectAddDto.ImageUrl,
            });
            return Redirect("~/Admin/Project/Index");
        }
        public async Task<IActionResult> EditProject(int id)
        {
            var project = await _projectService.GetByIdAsync(id);
            return View(new ProjectEditDto()
            {
                Id = project.Id,
                Content = project.Content,
                Title = project.Title,
            });
        }
        [HttpPost]
        public async Task<IActionResult> EditProject(ProjectEditDto projectEditDto)
        {
            var project = await _projectService.GetByIdAsync(projectEditDto.Id);
            project.Title = projectEditDto.Title;
            project.Content = projectEditDto.Content;
            if (projectEditDto.Picture != null && projectEditDto.Picture.Length > 0)
            {
                project.ImageUrl = await _fileService.UploadImageAsync(projectEditDto.Picture.FileName, projectEditDto.Picture);
            }
            await _projectService.UpdateAsync(project);
            return Redirect("~/Admin/Project/Index");
        }
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _projectService.GetByIdAsync(id);
            project.Status = false;
            project.DeletedAt = DateTime.Now;
            await _projectService.UpdateAsync(project);
            return Redirect("~/Admin/Project/Index");
        }
        public async Task<IActionResult> ChangeStatusProject(int id)
        {
            var project = await _projectService.GetByIdAsync(id);
            await _projectService.ChangeStatusAsync(project, project.Status);
            return Redirect("~/Admin/Project/Index");
        }
    }
}
