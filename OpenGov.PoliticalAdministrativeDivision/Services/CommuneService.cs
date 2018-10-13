﻿using Newtonsoft.Json;
using OpenGov.PoliticalAdministrativeDivision.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenGov.PoliticalAdministrativeDivision.Services
{
    public class CommuneService : ICommuneService
    {
        readonly HttpClient client = new HttpClient();
        public CommuneService(IConfigurationService configurationService)
        {
            client.BaseAddress = configurationService.Configuration.ApiDigitalGobClDPAUri;
        }
        public async Task<List<Commune>> GetCommunesAsync()
        {
            HttpResponseMessage response = await client.GetAsync("comunas");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<Commune>>(await response.Content.ReadAsStringAsync());
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
