﻿using Newtonsoft.Json;
using OpenGov.PoliticalAdministrativeDivision.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenGov.PoliticalAdministrativeDivision.Services
{
    public class ProvinceService : IProvinceService
    {

        readonly HttpClient client = new HttpClient();

        public ProvinceService(IConfigurationService configurationService)
        {
            client.BaseAddress = configurationService.Configuration.ApiDigitalGobClDPAUri;
        }
        public async Task<List<Province>> GetProvincesAsync()
        {
            HttpResponseMessage response = await client.GetAsync("provincias");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<Province>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new HttpRequestException();
            }
        }

        public async Task<Province> GetProvinceAsync(string provinceCode)
        {
            HttpResponseMessage response = await client.GetAsync($"provincias/{provinceCode}");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Province>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new HttpRequestException();
            }
        }

        public async Task<List<Province>> GetProvincesByRegionAsync(string regionCode)
        {
            HttpResponseMessage response = await client.GetAsync($"regiones/{regionCode}/provincias");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<Province>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new HttpRequestException();
            }
        }
    }
}
