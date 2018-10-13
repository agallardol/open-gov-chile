using System;
namespace OpenGov.PoliticalAdministrativeDivision.Models
{
    public abstract class BaseDivision : IDivision
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string ParentCode { get; set; }
    }
}
