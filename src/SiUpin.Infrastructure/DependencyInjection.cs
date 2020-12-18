using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Infrastructure.Common;
using SiUpin.Infrastructure.Persistence;
using SiUpin.Infrastructure.Repository;
using SiUpin.Infrastructure.Services;
using SiUpin.Shared;

namespace SiUpin.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var fortifexOptions = configuration.GetSection(SiUpinOptions.RootSection).Get<SiUpinOptions>();

            var connection = configuration["ConnectionStrings:Database"];
            var connectionOld = configuration["ConnectionStrings:DatabaseOld"];

            services.AddTransient<IDateTimeOffsetService, DateTimeOffsetService>();
            services.AddTransient<IFileService, FileService>();

            services.AddTransient<IDapperCommand, DapperCommand>();
            services.AddTransient<IEntityRepository, EntityRepository>();

            services.AddDbContext<SiUpinDBContext>(options => options.UseMySQL(connection));

            services.AddScoped<ISiUpinDBContext>(provider => provider.GetService<SiUpinDBContext>());

            return services;
        }
    }
}