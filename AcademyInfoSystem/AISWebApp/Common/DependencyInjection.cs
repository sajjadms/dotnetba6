using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Globalization;
using System.Reflection;

namespace AIS.WebApp.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services, ConfigurationManager configuration)
        {

            services.AddControllers();
            services.AddRazorPages();
            services.AddControllersWithViews();

            // DBContext LazyLoading & Connection String
            //services.AddDbContext<MicrocareDbContext>(option =>
                 //option.UseLazyLoadingProxies().UseSqlServer(configuration.GetConnectionString("defaultConn")));

            // Session Management
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // Cookie Authentication
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                            .AddCookie(options =>
                            {
                                options.LoginPath = "/../../Authenticate/Login";
                                options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                                options.SlidingExpiration = true;
                                options.AccessDeniedPath = "/../../Authenticate/AccessDeniedPage";
                            });

            services.AddHttpContextAccessor();

            //Mapping(MAPSTER)
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
            // *******************

            return services;
        }
    }
}
