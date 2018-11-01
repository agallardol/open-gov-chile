using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoliticalAdministrativeDivision
{
    public class PoliticalAdministrativeDivisionConfiguration
    {
        public GraphQLPlaygroundOptions GraphQLPlaygroundOptions { get; }
        public Uri FileStoreUri { get; }
        public Uri GraphQLUri { get; }
        public Uri GraphQLPlaygroundUri { get; }
        public Uri ApiDigitalGobClDPAUri { get; }

        public PoliticalAdministrativeDivisionConfiguration(string apiDigitalGobClDPA, string graphQLPath, string deployedBaseUrl)
        {
            GraphQLPlaygroundOptions = null;
            GraphQLPlaygroundUri = null;
            ApiDigitalGobClDPAUri = new Uri(apiDigitalGobClDPA);
            FileStoreUri = new Uri(new Uri(deployedBaseUrl), graphQLPath);
            GraphQLUri = new Uri(new Uri(deployedBaseUrl), graphQLPath);
        }

        public PoliticalAdministrativeDivisionConfiguration(string apiDigitalGobClDPA, string graphQLPath, string deployedBaseUrl, string graphQLPlaygroundPath)
            : this(apiDigitalGobClDPA, graphQLPath, deployedBaseUrl)
        {

            GraphQLPlaygroundUri = new Uri(new Uri(deployedBaseUrl), graphQLPlaygroundPath);
            GraphQLPlaygroundOptions = new GraphQLPlaygroundOptions
            {
                Path = GraphQLPlaygroundUri.AbsolutePath,
                GraphQLEndPoint = GraphQLUri.AbsolutePath
            };
        }
    }
}