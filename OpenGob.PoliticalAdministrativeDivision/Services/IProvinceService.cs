using Newtonsoft.Json;
using OpenGob.PoliticalAdministrativeDivision.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenGob.PoliticalAdministrativeDivision.Services
{
    public interface IProvinceService
    {
        Task<List<Province>> GetProvincesAsync();
        Task<Province> GetProvinceAsync(string provinceCode);

        Task<List<Province>> GetProvincesByRegionAsync(string regionCode);
    }
}
