using Newtonsoft.Json;
using OpenGov.PoliticalAdministrativeDivision.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenGov.PoliticalAdministrativeDivision.Services
{
    public interface IProvinceService
    {
        Task<List<Province>> GetProvincesAsync();
        Task<Province> GetProvinceAsync(string provinceCode);

        Task<List<Province>> GetProvincesByRegionAsync(string regionCode);
        List<Province> GetProvinces();
        Province GetProvince(string provinceCode);
        List<Province> GetProvincesByRegion(string regionCode);
    }
}
