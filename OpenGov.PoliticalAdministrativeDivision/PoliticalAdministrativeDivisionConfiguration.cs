using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenGov.PoliticalAdministrativeDivision
{
    public class PoliticalAdministrativeDivisionConfiguration
    {
        private readonly GraphQLPlaygroundOptions graphQLPlaygroundOptions;
        private readonly Uri filePathUri;
        private readonly Uri graphQLUri;
        private readonly Uri graphQLPlaygroundUri;
        private readonly Uri apiDigitalGobClDPAUri;
        public GraphQLPlaygroundOptions GraphQLPlaygroundOptions { get => graphQLPlaygroundOptions; }
        public Uri FileStoreUri { get => filePathUri; }
        public Uri GraphQLUri { get => graphQLUri; }
        public Uri GraphQLPlaygroundUri { get => graphQLPlaygroundUri; }
        public Uri ApiDigitalGobClDPAUri { get => apiDigitalGobClDPAUri; }

        public PoliticalAdministrativeDivisionConfiguration(){}
        public PoliticalAdministrativeDivisionConfiguration(string apiDigitalGobClDPA, string graphQLPath, string deployedBaseUrl)
        {
            graphQLPlaygroundOptions = null;
            graphQLPlaygroundUri = null;
            apiDigitalGobClDPAUri = new Uri(apiDigitalGobClDPA);
            filePathUri = new Uri(new Uri(deployedBaseUrl), graphQLPath);
            graphQLUri = new Uri(new Uri(deployedBaseUrl), graphQLPath);
        }

        public PoliticalAdministrativeDivisionConfiguration(string apiDigitalGobClDPA, string graphQLPath, string deployedBaseUrl, string graphQLPlaygroundPath)
            : this(apiDigitalGobClDPA, graphQLPath, deployedBaseUrl)
        {

            graphQLPlaygroundUri = new Uri(new Uri(deployedBaseUrl), graphQLPlaygroundPath);
            graphQLPlaygroundOptions = new GraphQLPlaygroundOptions
            {
                Path = graphQLPlaygroundUri.AbsolutePath,
                GraphQLEndPoint = graphQLUri.AbsolutePath
            };
        }
    }
}