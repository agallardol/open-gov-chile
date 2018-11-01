using GraphQL.Types;
using PoliticalAdministrativeDivision.Models;
using PoliticalAdministrativeDivision.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoliticalAdministrativeDivision.Schema
{
    internal class ProvinceType : ObjectGraphType<Province>
    {
        public ProvinceType(
            IRegionService regions, 
            IProvinceService provinces,
            ICommuneService communes
        )
        {
            Field(o => o.Code);
            Field(o => o.Name);
            Field(o => o.Lat);
            Field(o => o.Lng);

            Field<RegionType>(
                "region",
                "Región a la que pertenece la provincia.",
                resolve: context => regions.GetRegion(context.Source.ParentCode)
            );

            Field<ListGraphType<CommuneType>>(
                "communes",
                "Comunas pertenecientes a la provincia.",
                resolve: context => communes.GetCommunesByProvince(context.Source.Code)
            );
        }
    }
}
