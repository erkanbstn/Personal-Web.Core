using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Personal.Core.Repository.DataAccess;
using Personal.Core.Repository.Interfaces;
using Personal.Core.Service.Managers;
using Personal.Core.Service.Services;

namespace PersonalUI.Core.Extensions
{
    public static class StartupConfiguration
    {
        // Container Services Dependencies
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Context Configuration

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Sql"));
            });

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

            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<ILanguageService, LanguageManager>();

            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectService, ProjectManager>();

            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<ISkillService, SkillManager>();

            services.AddScoped<IManagerRepository, ManagerRepository>();
            services.AddScoped<IManagerService, ManagerManager>();

            services.AddScoped<IFileService, FileManager>();
            // File Configuration

            services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Directory.GetCurrentDirectory()));

            // Authentication
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(x => { x.LoginPath = "/Auth/SignIn"; });
        }
        // Container App Dependencies
        public static WebApplication ConfigureApp(this WebApplication webApplication)
        {

            if (!webApplication.Environment.IsDevelopment())
            {
                webApplication.UseExceptionHandler("/Home/Error");
                webApplication.UseHsts();
            }
            // Error Page Configuration

            webApplication.UseStatusCodePages();
            webApplication.UseStatusCodePagesWithReExecute("/Main/Error", "?code={0}");


            webApplication.UseHttpsRedirection();
            webApplication.UseStaticFiles();
            webApplication.UseRouting();
            webApplication.UseAuthentication();
            webApplication.UseAuthorization();

            // Default Controllers
            webApplication.MapControllerRoute(
                name: "default",
                pattern: "{controller=Main}/{action=Index}/{id?}");

            // Area Controllers
            webApplication.MapControllerRoute(
               name: "areas",
                  pattern: "{area:exists}/{controller=Entrance}/{action=Index}/{id?}");

            webApplication.Run();
            return webApplication;
        }
    }
}
