using GraphQL.Types;
using PoliticalAdministrativeDivision.Models;
using PoliticalAdministrativeDivision.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoliticalAdministrativeDivision.Schema
{
    public class PoliticalAdministrativeDivisionQuery : ObjectGraphType<object>
    {
        public PoliticalAdministrativeDivisionQuery(
            IRegionService regions,
            IProvinceService provinces,
            ICommuneService communes
        )
        {
            Name = "Query";

            Field<ListGraphType<RegionType>>(
                "regions",
                "Regiones de Chile",
                resolve: context => regions.GetRegionsAsync()
            );
            Field<ListGraphType<ProvinceType>>(
                "provinces",
                "Provincias de Chile",
                resolve: context => provinces.GetProvincesAsync()
            );

            Field<ListGraphType<CommuneType>>(
                "communes",
                "Comunas de Chile",
                resolve: context => communes.GetCommunesAsync()
            );

        }
    }
}
