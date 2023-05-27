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

			//services.AddScoped<IApplicationBuilder, ApplicationBuilder>();
		}
	}
}
