using Newtonsoft.Json;
using PoliticalAdministrativeDivision.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalAdministrativeDivision.Services
{
    public interface IRegionService
    {
        Task<List<Region>> GetRegionsAsync();
        Task<Region> GetRegionAsync(string code);
        List<Region> GetRegions();
        Region GetRegion(string code);
    }
}
