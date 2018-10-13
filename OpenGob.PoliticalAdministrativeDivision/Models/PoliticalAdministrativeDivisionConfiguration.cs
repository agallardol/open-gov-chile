using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenGob.PoliticalAdministrativeDivision.Models
{
    public class PoliticalAdministrativeDivisionConfiguration
    {
        private GraphQLPlaygroundOptions graphQLPlaygroundOptions;
        private Uri filePathUri;
        private Uri graphQLUri;
        private Uri graphQLPlaygroundUri;

        public GraphQLPlaygroundOptions GraphQLPlaygroundOptions { get => graphQLPlaygroundOptions; }
        public Uri FileStoreUri { get => filePathUri; }
        public Uri GraphQLUri { get => graphQLUri; }
        public Uri GraphQLPlaygroundUri { get => graphQLPlaygroundUri; }

        public PoliticalAdministrativeDivisionConfiguration(){}
        public PoliticalAdministrativeDivisionConfiguration(string graphQLPath, string deployedBaseUrl)
        {
            graphQLPlaygroundOptions = null;
            graphQLPlaygroundUri = null;
            filePathUri = new Uri(new Uri(deployedBaseUrl), graphQLPath);
            graphQLUri = new Uri(new Uri(deployedBaseUrl), graphQLPath);
        }

        public PoliticalAdministrativeDivisionConfiguration(string graphQLPath, string deployedBaseUrl, string graphQLPlaygroundPath)
            : this(graphQLPath, deployedBaseUrl)
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