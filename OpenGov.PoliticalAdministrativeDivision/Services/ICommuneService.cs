using Newtonsoft.Json;
using OpenGov.PoliticalAdministrativeDivision.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenGov.PoliticalAdministrativeDivision.Services
{
    public interface ICommuneService
    {
        Task<List<Commune>> GetCommunesAsync();
        Task<List<Commune>> GetCommunesByProvinceAsync(string provinceCode);
        List<Commune> GetCommunes();
        List<Commune> GetCommunesByProvince(string provinceCode);
        Commune GetCommune(string code);
    }
}
