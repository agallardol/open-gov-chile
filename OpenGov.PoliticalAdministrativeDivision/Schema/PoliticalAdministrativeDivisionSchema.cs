using GraphQL;
using GraphQL.Types;
using OpenGov.PoliticalAdministrativeDivision.Models;
using OpenGov.PoliticalAdministrativeDivision.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenGov.PoliticalAdministrativeDivision.Schema
{
    public class PoliticalAdministrativeDivisionSchema : GraphQL.Types.Schema
    {
        public PoliticalAdministrativeDivisionSchema(
            PoliticalAdministrativeDivisionQuery query, 
            PoliticalAdministrativeDivisionMutation mutation,
            IDependencyResolver resolver)
        {
            Query = query;
            DependencyResolver = resolver;
            Mutation = mutation;
        }
    }
}
