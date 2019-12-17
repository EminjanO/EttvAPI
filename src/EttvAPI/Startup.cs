using System.Reflection;
using AutoMapper;
using EttvAPI.Data.Models;
using EttvAPI.Repos.Interfaces.Repositories;
using EttvAPI.Repos.Repositories;
using EttvAPI.Services;
using EttvAPI.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using SwaggerOptions = EttvAPI.Help.Options.SwaggerOptions;

namespace EttvAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<EttvDbContext>(option =>
                option.UseSqlServer(Configuration.GetConnectionString("EttvDb")));

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IVideoContentService, VideoContentService>();
            services.AddScoped<IChannelProgramService, ChannelProgramService>();

            services.AddAutoMapper();

            services.AddSwaggerGen(x => { x.SwaggerDoc("v1", new Info{Title="Ettv API", Version = "v1"}); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            var swaggerOptions = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

            app.UseSwagger(option => { option.RouteTemplate = swaggerOptions.JsonRoute; });
            app.UseSwaggerUI(option =>
                {
                    option.SwaggerEndpoint(swaggerOptions.UiEndpoint, swaggerOptions.Description);
                });

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
