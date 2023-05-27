using Personal.Core.Repository.DataAccess;
using Personal.Core.Repository.Interfaces;
using Personal.Core.Service.Managers;
using Personal.Core.Service.Services;

namespace PersonalUI.Core.Extensions
{
	public static class StartupConfiguration
	{
		public static void ConfigureProgramDependencies(this IServiceCollection services)
		{
			// Default Mvc

			services.AddControllersWithViews();

			// Auto Mapper

			services.AddAutoMapper(typeof(Program));

			// Configure Interfaces Dependencies

			services.AddScoped<IAboutRepository, AboutRepository>();
			services.AddScoped<IAboutService, AboutManager>();

            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IContactService, ContactManager>();

            services.AddScoped<IEducationRepository, EducationRepository>();
            services.AddScoped<IEducationService, EducationManager>();

            services.AddScoped<IEntranceRepository, EntranceRepository>();
            services.AddScoped<IEntranceService, EntranceManager>();

            services.AddScoped<IExperienceRepository, ExperienceRepository>();
            services.AddScoped<IExperienceService, ExperienceManager>();

            services.AddScoped<ILanguageRepository , LanguageRepository>();
            services.AddScoped<ILanguageService, LanguageManager>();

            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectService, ProjectManager>();

            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<ISkillService, SkillManager>();
        }
	}
}
