using System;
namespace OpenGov.PoliticalAdministrativeDivision.Models
{
    public abstract class BaseDivision : IDivision
    {
        string code;
        string name;
        double lat;
        double lng;
        string parentCode;

        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public double Lat { get => lat; set => lat = value; }
        public double Lng { get => lng; set => lng = value; }
        public string ParentCode { get => parentCode; set => parentCode = value; }
    }
}
