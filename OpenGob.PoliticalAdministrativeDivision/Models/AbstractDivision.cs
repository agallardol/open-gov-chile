using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenGob.PoliticalAdministrativeDivision.Models
{
    public abstract class AbstractDivision
    {
        [JsonProperty("codigo")]
        public string Code;

        [JsonProperty("nombre")]
        public string Name { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lng")]
        public double Lng { get; set; }

        [JsonProperty("codigo_padre")]
        public string ParentCode { get; set; }
    }
}
