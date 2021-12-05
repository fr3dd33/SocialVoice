using Application.Common.Interfaces;
using Common;
using Domain.Entites;
using Infrastructure.Files;
using Microsoft.Extensions.DependencyInjection;
using OfficeOpenXml;
using System.Collections.Generic;

namespace Infrastructure
{
    public static class InfrastructureExtension
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services
        )
        {
            services.AddTransient<IDateTime, MachineDateTime>();

            services.AddScoped<IXslsReader<(ICollection<Organization>, ICollection<Region>)>, XlsxReader>();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            return services;
        }
    }
}
