using AutoMapper;
using BusinessLogicLayer.AutoHelper;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.AppContext;
using DataAccessLayer.Repositories.EFRepositories.NetMonitoring;
using DataAccessLayer.Repositories.EFRepositories.Shops;
using DataAccessLayer.Repositories.Interfaces.NetMonitoring;
using DataAccessLayer.Repositories.Interfaces.Shops;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace StoreStatusBoard
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionStringSQL08 = "Data Source=sql08;Initial Catalog=NetMonitoring;Persist Security Info=True;User ID=j-sql08-read-NetMonitoring;Password=9g0sl3l9z1l0;Connection Timeout=150";
            string connectionStringSQL26 = "Data Source=sql26;Initial Catalog=Shops;Persist Security Info=True;User ID=j-sql26-reader-shops;Password=1GAxzpWtGojxCWnW8sYY";
            services.AddDbContext<NetMonitoringContext>(opts => opts.UseSqlServer(connectionStringSQL08));
            services.AddDbContext<ShopsContext>(opts => opts.UseSqlServer(connectionStringSQL26));
            services.AddScoped<IDeviceRepository, DeviceRepository>();
            services.AddScoped<IMonitoringRepository, MonitoringRepository>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IRStockRepository, RStockRepository>();
            services.AddScoped<IProviderRepository, ProviderRepository>();
            services.AddScoped<IShopProvidersRepository, ShopProvidersRepository>();
            services.AddScoped<IShopWorkTimesRepository, ShopWorkTimesRepository>();
            services.AddScoped<IShopRegionLocalizationsRepository, ShopRegionLocalizationsRepository>();
            services.AddScoped<IShopsRepository, ShopsRepository>();
            services.AddScoped<ITempImportAddressesRepository, TempImportAddressesRepository>();
            services.AddScoped<IBoardService, BoardService>();
            services.AddControllersWithViews();

            MapperConfiguration mapperconfig = new MapperConfiguration(cfg =>
            {   
                cfg.AddProfile<MapperProfile>();
            });
            IMapper mapper = mapperconfig.CreateMapper();
            services.AddSingleton(mapper);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
