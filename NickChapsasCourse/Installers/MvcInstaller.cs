using Microsoft.OpenApi.Models;

namespace NickChapsasCourse.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews();

            services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Tweetbook API",
                    Description = "Test API Nick Chapsas course",
                    Contact = new OpenApiContact
                    {
                        Name = "Vasily Levkovsky",
                        Email = "v.levkovskiy@21vek.by"
                    }
                });
            });
        }
    }
}
