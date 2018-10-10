using Newtonsoft.Json;
using OpenGob.PoliticalAdministrativeDivision.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenGob.PoliticalAdministrativeDivision.Services
{
    public class CommuneService : ICommuneService
    {
        HttpClient client = new HttpClient();
        public CommuneService()
        {
            client.BaseAddress = new Uri(@"http://apis.digital.gob.cl/dpa/");
        }
        public async Task<List<Commune>> GetCommunesAsync()
        {
            HttpResponseMessage response = await client.GetAsync("comunas");
            if (response.IsSuccessStatusCode)
            {

                var a = JsonConvert.DeserializeObject<List<Commune>>(await response.Content.ReadAsStringAsync());
                return a;
            }
            else
            {
                throw new HttpRequestException();
            }
        }

        public async Task<List<Commune>> GetCommunesByProvinceAsync(string provinceCode)
        {
            HttpResponseMessage response = await client.GetAsync($"provincias/{provinceCode}/comunas");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<Commune>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new HttpRequestException();
            }
        }
    }
}
