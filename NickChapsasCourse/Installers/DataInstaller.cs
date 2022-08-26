using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NickChapsasCourse.Services;

namespace NickChapsasCourse.Installers
{
    public class DataInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container.
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<NickChapsasCourse.Data.DataContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<NickChapsasCourse.Data.DataContext>();

            services.AddSingleton<IPostService, PostService>();
        }
    }
}
