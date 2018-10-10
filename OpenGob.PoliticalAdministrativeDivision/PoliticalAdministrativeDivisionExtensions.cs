using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Transports.AspNetCore;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using OpenGob.PoliticalAdministrativeDivision.Models;
using OpenGob.PoliticalAdministrativeDivision.Schema;
using OpenGob.PoliticalAdministrativeDivision.Services;
using OpenGob.PoliticalAdministrativeDivision.Services.CSVs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace OpenGob.PoliticalAdministrativeDivision
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

        public static IApplicationBuilder UsePoliticalAdministrativeDivision(this IApplicationBuilder builder, Configuration config)
        {
            builder.ApplicationServices.GetRequiredService<IConfigurationService>().Configuration = config;
            builder.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new EmbeddedFileProvider(
                    Assembly.GetExecutingAssembly()
                ),
                RequestPath = config.GraphQlPath
            });
            new Configuration
            {
                GraphQlPath = config.GraphQlPath,
                DeployedBaseUrl = config.DeployedBaseUrl,
                GraphQLPlaygroundOptions = config.GraphQLPlaygroundOptions
            };
            builder.UseGraphQL<PoliticalAdministrativeDivisionSchema>(config.GraphQlPath);
            if(config.GraphQLPlaygroundOptions != null) {
                builder.UseGraphQLPlayground(config.GraphQLPlaygroundOptions);
            }
            return builder;
        }
    }
}
