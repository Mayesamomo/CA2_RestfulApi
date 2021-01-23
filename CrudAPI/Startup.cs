using AutoMapper;
using CrudAPI.Domain.Repositories;
using CrudAPI.Domain.Serrvices;
using CrudAPI.Persistence.Contexts;
using CrudAPI.Persistence.Repositories;
using CrudAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(typeof(Startup));
            //Register swagger UI APi documentation
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("V1", new OpenApiInfo { 
                Title ="AnimeDB API",
                Version ="V1"
                });
            });
            services.AddControllers();
            services.AddMvc();
            //add the connection stream
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DbAnime")));
             //configuring our dependency bindings and injection.
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IAnimeRepository, AnimeRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAnimeService, AnimeService>();
            // bind the unit of work interface to its respective class.
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            //regist8er the end points 
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/V1/swagger.json", "AnimeDB API V1");
            });

            app.UseHttpsRedirection();
          //  app.UseMvc();
            app.UseRouting();

            app.UseAuthorization();
          
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
