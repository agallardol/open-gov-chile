using GraphQL.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PoliticalAdministrativeDivision;

namespace PoliticalAdministrativeDivisionApp
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            services.AddPoliticalAdministrativeDivision();
            services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
            });
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
                app.UseHsts();
            }

            app.UseMvc();
            app.UseWelcomePage("/");

            IConfigurationSection padConfig = Configuration.GetSection("PAD");
            app.UsePoliticalAdministrativeDivision(
                new PoliticalAdministrativeDivisionConfiguration(
                    padConfig.GetValue<string>("ApiDigitalGobClDPA"),
                    padConfig.GetValue<string>("GraphQLPath"),
                    padConfig.GetValue<string>("DeployedBaseUrl"),
                    padConfig.GetValue<string>("GraphQLPlaygroundPath")
                )
            );

        }
    }
}
