using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Http;
using GraphQL.Server;
using GraphQL.Server.Transports.AspNetCore;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenGob.PoliticalAdministrativeDivision;
using OpenGob.PoliticalAdministrativeDivision.Schema;
using OpenGob.PoliticalAdministrativeDivision.Services;

namespace OpenGob
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddPoliticalAdministrativeDivision();
            services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UsePoliticalAdministrativeDivision(
                new PoliticalAdministrativeDivision.Models.Configuration
                {
                    GraphQlPath = "/graphql/pad",
                    DeployedBaseUrl = "https://localhost:5001",
                    GraphQLPlaygroundOptions = new GraphQLPlaygroundOptions
                    {
                        Path = "/ui/pad",
                        GraphQLEndPoint = "/graphql/pad"
                    }
                }
            );

        }
    }
}
