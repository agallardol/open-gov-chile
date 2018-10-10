using Newtonsoft.Json;
using OpenGob.PoliticalAdministrativeDivision.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenGob.PoliticalAdministrativeDivision.Services
{
    public class ConfigurationService : IConfigurationService
    {
        public Configuration Configuration { get; set; }
        public ConfigurationService()
        {
            this.Configuration = new Configuration();
        }
        public ConfigurationService(Configuration config)
        {
            Configuration = config;
        }
    }
}
