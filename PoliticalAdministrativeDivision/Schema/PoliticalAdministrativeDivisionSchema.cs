using GraphQL;
using GraphQL.Types;
using PoliticalAdministrativeDivision.Models;
using PoliticalAdministrativeDivision.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoliticalAdministrativeDivision.Schema
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
