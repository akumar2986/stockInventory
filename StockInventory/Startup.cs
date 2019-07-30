using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stock.Web.Core.BAL;
using Stock.Web.Data;
using Stock.Web.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Stock.Web.Utility;
using Stock.Web.Entities;

namespace Stock.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton<IStockBll, StockBll>();


            services.AddDbContext<StockContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            InjectDependency(services);

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.  
                // options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            services.AddMvc();
        }

        private static void InjectDependency(IServiceCollection services)
        {
            services.AddTransient<IBatchBll, BatchBll>();
            services.AddTransient<IBatchRepository, BatchRepository>();
            services.AddTransient<IDataRepository<Product>, ProductRepository>();
            services.AddTransient<IDataRepository<ProductStock>, ProductStockRepository>();
            services.AddTransient<IStockBll, StockBll>();
            services.AddSingleton<ILog, Log>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILog logger)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.ConfigureExceptionHandler(logger);
            app.UseStaticFiles();

            app.UseCookiePolicy();
            app.UseAuthentication();

           
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Batch}/{action=Index}/{id?}");
                
                routes.MapRoute(name: "api", template: "api/{controller=StockAPI}");                
            });

        }
    }
}
