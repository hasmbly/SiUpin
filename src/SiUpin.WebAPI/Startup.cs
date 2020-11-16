using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
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

        public IWebHostEnvironment _hostEnvironment;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            _hostEnvironment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddInfrastructure(Configuration);
            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddControllers();
            services.AddRazorPages();
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });
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
                options.DefaultScheme = SchemeProvider.SiUpin;
            })
                .AddCookie(SchemeProvider.SiUpin, options =>
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

            var physicalProvider = new PhysicalFileProvider(Path.Combine(_hostEnvironment.ContentRootPath, Configuration.GetSection(SiUpinOptions.RootSection).Get<SiUpinOptions>().UploadsRootFolderPath));

            services.AddSingleton<IFileProvider>(physicalProvider);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseForwardedHeaders();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(_hostEnvironment.ContentRootPath,
                Configuration.GetSection(SiUpinOptions.RootSection).Get<SiUpinOptions>().UploadsRootFolderPath)),
                RequestPath = new PathString("/images")
            });
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