﻿using CopaFilmes.Domain.Handlers;
using CopaFilmes.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace CopaFilmes.Api
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
            services.AddScoped<MovieHandler, MovieHandler>();
            services.AddScoped<ICopaFilmesService, CopaFilmesService>();
            services.AddScoped<IMoviesChampionshipService, MoviesChampionshipService>();
            services.AddScoped<MovieHandler, MovieHandler>();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder => { builder.AllowAnyOrigin(); });
                options.AddPolicy("AllowOrigin", builder => builder.WithOrigins(
                    "http://localhost:61203", 
                    "http://10.0.2.2:61203",
                    "http://127.0.0.1",
                    "http://localhost:80",
                    "http://localhost",
                    "http://10.0.2.2"));
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/CopaFilmes.Api/swagger/v1/swagger.json", "My API V1");
            });

            app.UseCors();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
