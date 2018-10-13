using GraphQL.Types;
using OpenGov.PoliticalAdministrativeDivision.Models;
using OpenGov.PoliticalAdministrativeDivision.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenGov.PoliticalAdministrativeDivision.Schema
{
    internal class RegionType : ObjectGraphType<Region>
    {
        public RegionType(IRegionService regions, IProvinceService provinces)
        {
            Field(o => o.Code);
            Field(o => o.Name);
            Field(o => o.Lat);
            Field(o => o.Lng);
            Field<ListGraphType<ProvinceType>>(
                "provinces",
                "Provincias pertenecientes a la región.",
                resolve: context => provinces.GetProvincesByRegionAsync(context.Source.Code)
            );
        }
    }
}
