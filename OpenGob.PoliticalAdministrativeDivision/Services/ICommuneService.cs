using Newtonsoft.Json;
using OpenGob.PoliticalAdministrativeDivision.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenGob.PoliticalAdministrativeDivision.Services
{
    public interface ICommuneService
    {
        Task<List<Commune>> GetCommunesAsync();
        Task<List<Commune>> GetCommunesByProvinceAsync(string provinceCode);
    }
}
