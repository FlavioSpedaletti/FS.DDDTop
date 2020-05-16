using System;
using AutoMapper;
using FS.DDDTop.Domain.Interfaces;
using FS.DDDTop.Infra.Data.Contexts;
using FS.DDDTop.Infra.Data.Repositories;
using FS.DDDTop.Web.AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StackExchange.Profiling;

namespace FS.DDDTop.Web
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
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<EFContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connection));
            services.AddAutoMapper(new Type[] { typeof(ViewModelToDomainMappingProfile), typeof(DomainToViewModelMappingProfile) });
            services.AddScoped(typeof(IClienteRepository), typeof(ClienteRepository));

            services.AddControllersWithViews();

            services.AddMiniProfiler(options =>
            {
                options.RouteBasePath = "/profiler";
                options.PopupRenderPosition = RenderPosition.BottomLeft;
                options.PopupShowTimeWithChildren = true;
                options.TrackConnectionOpenClose = true;
                options.SqlFormatter = new StackExchange.Profiling.SqlFormatters.InlineFormatter();
            }).AddEntityFramework();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseMiniProfiler();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
