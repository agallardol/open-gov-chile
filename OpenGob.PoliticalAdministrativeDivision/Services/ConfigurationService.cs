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
        public PoliticalAdministrativeDivisionConfiguration Configuration { get; set; }
        public ConfigurationService()
        {
        }
        public ConfigurationService(PoliticalAdministrativeDivisionConfiguration config)
        {
            Configuration = config;
        }
    }
}
