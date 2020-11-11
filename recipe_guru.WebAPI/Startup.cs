using System;
using System.Collections.Generic;
using AutoMapper;
using recipe_guru.WebAPI.Database;
using recipe_guru.Model.Requests;
using recipe_guru.WebAPI.Filters;
using recipe_guru.WebAPI.Security;
using recipe_guru.WebAPI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace recipe_guru
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
            services.AddControllers();

            services.AddMvc(x => x.Filters.Add<ErrorFilter>()).SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddMvc(x => x.EnableEndpointRouting = false)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            // swagger configuration
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RecipeGuru API", Version = "v1" });

                // basic auth swagger
                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "basic"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            services.AddScoped<IKorisniciService, KorisniciService>();
            services.AddScoped<IService<Model.Uloga, object>, BaseService<Model.Uloga, object, Uloga>>();
            services.AddScoped<IService<Model.Kategorija, object>, BaseService<Model.Kategorija, object, Kategorija>>();
            services.AddScoped<IRecommenderService, RecommenderService>();

            services.AddScoped<ICRUDService<Model.ImageResource, ImageResourceSearchRequest, ImageResourceUpsertRequest, ImageResourceUpsertRequest>, ImageResourceService>();
            services.AddScoped<ICRUDService<Model.KnjigaRecepata, KnjigaRecepataSearchRequest, KnjigaRecepataUpsertRequest, KnjigaRecepataUpsertRequest>, KnjigaRecepataService>();
            services.AddScoped<ICRUDService<Model.Rating, RatingSearchRequest, RatingUpsertRequest, RatingUpsertRequest>, RatingService>();
            services.AddScoped<ICRUDService<Model.ReceptKorak, ReceptKoraciSearchRequest, ReceptKoraciUpsertRequest, ReceptKoraciUpsertRequest>, ReceptKoraciService>();
            services.AddScoped<ICRUDService<Model.Recept, ReceptSearchRequest, ReceptUpsertRequest, ReceptUpsertRequest>, ReceptService>();
            services.AddScoped<ICRUDService<Model.ReceptSastojak, ReceptSastojakSearchRequest, ReceptSastojakUpsertRequest, ReceptSastojakUpsertRequest>, ReceptSastojakService>();
            services.AddScoped<ICRUDService<Model.ReceptPregled, ReceptPregledSearchRequest, ReceptPregledUpsertRequest, ReceptPregledUpsertRequest>, ReceptPregledService>();

            // connection to database
            // Scaffold-DbContext -Connection "Server=(local);Database=RecipeGuru;Integrated Security=True;Trusted_Connection=True;" -Provider Microsoft.EntityFrameworkCore.SqlServer -OutputDir Database -context recipe_guruContext -force
            services.AddDbContext<recipeGuruContext>(opt => opt.UseSqlServer(Configuration["CONNECTION_STRING"])
            .EnableSensitiveDataLogging());

            // basic auth
            services.AddAuthentication("BasicAuthentication")
               .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            // auto mapper configuration
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            IServiceProvider serviceProvider)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "RecipeGuru");
                c.RoutePrefix = "";
            });

            app.UseAuthentication();

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
