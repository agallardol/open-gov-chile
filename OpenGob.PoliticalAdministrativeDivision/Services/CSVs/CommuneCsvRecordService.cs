using CsvHelper;
using CsvHelper.Configuration;
using OpenGob.PoliticalAdministrativeDivision.Models.CSVs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OpenGob.PoliticalAdministrativeDivision.Services.CSVs
{
    internal class CommuneCsvRecordService : ICommuneCsvRecordService
    {
        readonly List<CommuneCsvRecord> communeCsvRecords;

        readonly string COMMUNE_IMAGE_PATH = "public/images/communes/";
        readonly string CSV_RESOURCE_PATH = $"{Assembly.GetExecutingAssembly().GetName().Name}.CSVs.Municipalidades.csv";
        readonly string DELIMITER = ";";

        public CommuneCsvRecordService()
        {
            CsvReader csvReader;
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(CSV_RESOURCE_PATH))
                using (TextReader reader = new StreamReader(stream))
                {
                    csvReader = new CsvReader(reader, new Configuration
                    {
                        HasHeaderRecord = false,
                        Delimiter = DELIMITER,
                        Encoding = Encoding.UTF8
                    });
                    communeCsvRecords = csvReader.GetRecords<CommuneCsvRecord>().ToList();
                }
        }

        public string GetCommuneImagePath(string communeCode)
        {
            return COMMUNE_IMAGE_PATH + this.communeCsvRecords.Find(r => r.Code == communeCode).FileName;
        }
    }
}
