using Newtonsoft.Json;
using OpenGov.PoliticalAdministrativeDivision.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenGov.PoliticalAdministrativeDivision.Services
{
    public interface IConfigurationService
    {
        PoliticalAdministrativeDivisionConfiguration Configuration { get; set; }
    }
}
