using GraphQL.Types;
using PoliticalAdministrativeDivision.Models;
using PoliticalAdministrativeDivision.Services;
using PoliticalAdministrativeDivision.Services.CSVs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoliticalAdministrativeDivision.Schema
{
    internal class CommuneType : ObjectGraphType<Commune>
    {
        public CommuneType(IProvinceService provinceService, ICommuneCsvRecordService communeCsvRecordService, IConfigurationService configurationService)
        {
            Field(o => o.Code);
            Field(o => o.Name);
            Field(o => o.Lat);
            Field(o => o.Lng);
            Field<ProvinceType>(
                "province",
                "Provincia a la que pertenece la comuna.",
                resolve: context => provinceService.GetProvince(context.Source.ParentCode)
            );
            Field<StringGraphType>(
                "imageUrl",
                "Url del escudo de la comuna o en su defecto el logo de la municipalidad.",
                resolve: context => configurationService.Configuration.FileStoreUri.AbsoluteUri + communeCsvRecordService.GetCommuneImagePath(context.Source.Code)
            );
        }
    }
}
