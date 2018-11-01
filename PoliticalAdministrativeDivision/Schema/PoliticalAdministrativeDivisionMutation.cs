using GraphQL.Types;
using PoliticalAdministrativeDivision.Models;
using PoliticalAdministrativeDivision.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoliticalAdministrativeDivision.Schema
{
    public class PoliticalAdministrativeDivisionMutation : ObjectGraphType<object>
    {
        public PoliticalAdministrativeDivisionMutation(
            IRegionService regions,
            IProvinceService provinces,
            ICommuneService communes
        )
        {
            Field<CommuneType>(
               "getCommune",
               arguments: new QueryArguments(
                 new QueryArgument<StringGraphType> {
                     Name = "code",
                     Description = "Código de la comuna"
                 }
               ),
               resolve: context =>
               {
                   return communes.GetCommune(context.GetArgument<string>("code"));
               }
            );

            Field<ProvinceType>(
               "getProvince",
               arguments: new QueryArguments(
                 new QueryArgument<StringGraphType>
                 {
                     Name = "code",
                     Description = "Código de la provincia"
                 }
               ),
               resolve: context =>
               {
                   return provinces.GetProvince(context.GetArgument<string>("code"));
               }
            );

            Field<RegionType>(
               "getRegion",
               arguments: new QueryArguments(
                 new QueryArgument<StringGraphType>
                 {
                     Name = "code",
                     Description = "Código de la región"
                 }
               ),
               resolve: context =>
               {
                   return regions.GetRegion(context.GetArgument<string>("code"));
               }
            );

        }
    }
}
