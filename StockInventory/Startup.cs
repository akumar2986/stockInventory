using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stock.Web.Core.BAL;
using Stock.Web.Data;
using Stock.Web.Data.Repository;
using Stock.Web.Data.Repository;

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
            services.AddTransient<IBatchBll, BatchBll>();
            services.AddTransient<IBatchRepository, BatchRepository>();
            services.AddTransient<IDataRepository<Product>, ProductRepository>();
            services.AddTransient<IDataRepository<ProductStock>, ProductStockRepository>();
            services.AddTransient<IStockBll, StockBll>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Batch}/{action=Index}/{id?}");
                //routes.MapRoute(name: "batch", template: "{controller=Batch}/{action=Index}/{id?}");
                routes.MapRoute(name: "api", template: "api/{controller=ProductStockAPI}");                
            });

        }
    }
}
