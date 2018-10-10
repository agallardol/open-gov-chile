using GraphQL.Server.Ui.Playground;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenGob.PoliticalAdministrativeDivision.Models
{
    public class Configuration
    {
        public string GraphQlPath { get; set; }
        public string DeployedBaseUrl { get; set; }
        public string FileStorePath { get => DeployedBaseUrl + GraphQlPath + "/"; }

        public GraphQLPlaygroundOptions GraphQLPlaygroundOptions { get; set; }
    }
}
