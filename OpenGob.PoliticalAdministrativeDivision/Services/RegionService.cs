using Newtonsoft.Json;
using OpenGob.PoliticalAdministrativeDivision.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenGob.PoliticalAdministrativeDivision.Services
{
    public class RegionService : IRegionService
    {

        readonly HttpClient client = new HttpClient();

        public RegionService()
        {
            client.BaseAddress = new Uri(@"http://apis.digital.gob.cl/dpa/");
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
    }
}
