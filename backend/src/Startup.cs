using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pz.Cheeseria.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Pz.Cheeseria.Api.Controllers;
using Pz.Cheeseria.Api.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Pz.Cheeseria.Api.Services;

namespace Pz.Cheeseria.Api
{
    public class Startup
    {
        public IHostingEnvironment HostingEnvironment { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            HostingEnvironment = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
       
            services.AddDbContext<DbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<OrgDB>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pz Cheeseria Api V1", Version = "v1", });
            });
            services.AddScoped<DbContext, OrgDB>();
            services.AddScoped<ICheeseService, CheeseService>();
            services.AddScoped<IOrgDbContext, OrgDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseMvc(routes =>
            //{
            //    if (HostingEnvironment.IsDevelopment())
            //    {
            //        routes.MapRoute("swagger-doc", "swagger/index.html");
            //    }
            //    routes.MapRoute("swagger", "swagger/{version}/swagger.json");
            //    routes.MapRoute("api", "api/{version}/{controller}/{*action}");
            //});

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pz Cheeseria Api V1");
            });
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
