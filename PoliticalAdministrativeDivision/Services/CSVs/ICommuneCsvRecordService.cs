﻿using PoliticalAdministrativeDivision.Models.CSVs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalAdministrativeDivision.Services.CSVs
{
    internal interface ICommuneCsvRecordService 
    {
        string GetCommuneImagePath(string communeCode);
    }
}
