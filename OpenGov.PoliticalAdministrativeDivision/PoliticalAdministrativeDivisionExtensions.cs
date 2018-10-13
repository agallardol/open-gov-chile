using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Transports.AspNetCore;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using OpenGov.PoliticalAdministrativeDivision.Models;
using OpenGov.PoliticalAdministrativeDivision.Schema;
using OpenGov.PoliticalAdministrativeDivision.Services;
using OpenGov.PoliticalAdministrativeDivision.Services.CSVs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace OpenGov.PoliticalAdministrativeDivision
{
    public static class PoliticalAdministrativeDivisionExtensions
    {
        public static IServiceCollection AddPoliticalAdministrativeDivision(this IServiceCollection services)
        {
            services.AddSingleton<IProvinceService, ProvinceService>();
            services.AddSingleton<IRegionService, RegionService>();
            services.AddSingleton<ICommuneService, CommuneService>();
            services.AddSingleton<ICommuneCsvRecordService, CommuneCsvRecordService>();

            services.AddSingleton<ProvinceType>();
            services.AddSingleton<RegionType>();
            services.AddSingleton<CommuneType>();

            services.AddSingleton<PoliticalAdministrativeDivisionQuery>();
            services.AddSingleton<PoliticalAdministrativeDivisionSchema>();

            services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddSingleton<IConfigurationService, ConfigurationService>(c => new ConfigurationService());
            return services;
        }

        public static IApplicationBuilder UsePoliticalAdministrativeDivision(this IApplicationBuilder builder, PoliticalAdministrativeDivisionConfiguration config)
        {
            builder.ApplicationServices.GetRequiredService<IConfigurationService>().Configuration = config;
            builder.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new EmbeddedFileProvider(
                    Assembly.GetExecutingAssembly()
                ),
                RequestPath = config.GraphQLUri.AbsolutePath
            });

            builder.UseGraphQL<PoliticalAdministrativeDivisionSchema>(config.GraphQLUri.AbsolutePath);
            if(config.GraphQLPlaygroundOptions != null) {
                builder.UseGraphQLPlayground(config.GraphQLPlaygroundOptions);
            }
            return builder;
        }
    }
}
