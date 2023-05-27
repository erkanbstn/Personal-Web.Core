using AutoMapper;
using Personal.Core.Core.Models;
using Personal.Core.Dto.Dtos.About;
using Personal.Core.Dto.Dtos.Education;
using Personal.Core.Dto.Dtos.Entrance;
using Personal.Core.Dto.Dtos.Experience;
using Personal.Core.Dto.Dtos.Language;
using Personal.Core.Dto.Dtos.Project;
using Personal.Core.Dto.Dtos.Skill;

namespace PersonalUI.Core.Mapping.AutoMapperProfile
{
	public class MapProfile : Profile
	{
		public MapProfile()
		{
			CreateMap<EntranceListDto, Entrance>().ReverseMap();
			CreateMap<AboutListDto, About>().ReverseMap();
			CreateMap<ExperienceListDto, Experience>().ReverseMap();
			CreateMap<EducationListDto, Education>().ReverseMap();
			CreateMap<ProjectListDto, Project>().ReverseMap();
			CreateMap<SkillListDto, Skill>().ReverseMap();
			CreateMap<LanguageListDto, Language>().ReverseMap();

		}
	}
}
