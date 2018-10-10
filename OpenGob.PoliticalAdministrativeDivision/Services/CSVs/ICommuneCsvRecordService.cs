using OpenGob.PoliticalAdministrativeDivision.Models.CSVs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenGob.PoliticalAdministrativeDivision.Services.CSVs
{
    internal interface ICommuneCsvRecordService 
    {
        string GetCommuneImagePath(string communeCode);
    }
}
