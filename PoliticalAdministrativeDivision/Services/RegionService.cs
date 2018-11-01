using Newtonsoft.Json;
using PoliticalAdministrativeDivision.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalAdministrativeDivision.Services
{
    public class RegionService : IRegionService
    {

        readonly HttpClient client = new HttpClient();
        readonly List<Region> regions;
        public RegionService(IConfigurationService configurationService)
        {
            client.BaseAddress = configurationService.Configuration.ApiDigitalGobClDPAUri;
            regions = GetRegionsAsync().Result;
        }

        public async Task<List<Region>> GetRegionsAsync()
        {
            HttpResponseMessage response = await client.GetAsync("regiones");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<Region>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new HttpRequestException();
            }
        }

        public async Task<Region> GetRegionAsync(string code)
        {
            HttpResponseMessage response = await client.GetAsync($"regiones/{code}");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Region>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new HttpRequestException();
            }
        }

        public List<Region> GetRegions()
        {
            return regions;
        }

        public Region GetRegion(string code)
        {
            return regions.Find(r => r.Code == code);
        }
    }
}
