using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenGov.PoliticalAdministrativeDivision.Models
{
    public interface IDivision
    {
        [JsonProperty("codigo")]
        string Code { get; set; }

        [JsonProperty("nombre")]
        string Name { get; set; }

        [JsonProperty("lat")]
        double Lat { get; set; }

        [JsonProperty("lng")]
        double Lng { get; set; }

        [JsonProperty("codigo_padre")]
        string ParentCode { get; set; }
    }
}
