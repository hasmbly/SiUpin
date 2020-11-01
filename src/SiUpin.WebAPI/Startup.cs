using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SiUpin.Application;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Infrastructure;
using SiUpin.Shared;
using SiUpin.Shared.Common;
using SiUpin.WebAPI.Services;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace SiUpin.WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public PhysicalFileProvider physicalProvider { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddInfrastructure(Configuration);
            services.AddControllers();

            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            services.AddRazorPages();

            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "SiUpin",
                    Description = "Behind the scene of SiUpin - Kementan",
                    Contact = new OpenApiContact
                    {
                        Name = "hasmbly",
                        Email = "justhasby@gmail.com",
                        Url = new Uri("https://google.com/"),
                    }
                });

                setupAction.CustomSchemaIds(x => x.FullName);

                setupAction.AddSecurityDefinition("bearer", new OpenApiSecurityScheme()
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = "Input your Bearer token to access this API",
                });

                setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "bearer",
                            },
                        }, new List<string>()
                    },
                });
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = SchemeProvider.Fortifex;
            })
                .AddCookie(SchemeProvider.Fortifex, options =>
                {
                    options.LoginPath = new PathString("/account/login");
                })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("SiUpin:TokenSecurityKey").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            bool exists = Directory.Exists(Configuration.GetSection(SiUpinOptions.RootSection).Get<SiUpinOptions>().UploadsRootFolderPath);

            if (!exists)
            {
                Console.WriteLine($"-- Create new SiUpinFiles Folder --");
                Directory.CreateDirectory(Configuration.GetSection(SiUpinOptions.RootSection).Get<SiUpinOptions>().UploadsRootFolderPath);
            }
            else
            {
                Console.WriteLine($"-- SiUpinFiles Folder was ready --");
            }

            physicalProvider = new PhysicalFileProvider(Configuration.GetSection(SiUpinOptions.RootSection).Get<SiUpinOptions>().UploadsRootFolderPath);

            services.AddSingleton<IFileProvider>(physicalProvider);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "REST API V1");
                c.DefaultModelExpandDepth(2);
                c.DefaultModelRendering(ModelRendering.Model);
                c.DocExpansion(DocExpansion.None);
                c.EnableDeepLinking();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}