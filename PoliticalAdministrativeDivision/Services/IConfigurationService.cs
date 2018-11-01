using Newtonsoft.Json;
using PoliticalAdministrativeDivision.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalAdministrativeDivision.Services
{
    public interface IConfigurationService
    {
        PoliticalAdministrativeDivisionConfiguration Configuration { get; set; }
    }
}
