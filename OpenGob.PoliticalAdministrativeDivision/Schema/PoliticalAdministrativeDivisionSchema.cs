using GraphQL;
using GraphQL.Types;
using OpenGob.PoliticalAdministrativeDivision.Models;
using OpenGob.PoliticalAdministrativeDivision.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenGob.PoliticalAdministrativeDivision.Schema
{
    public class PoliticalAdministrativeDivisionSchema : GraphQL.Types.Schema
    {
        public PoliticalAdministrativeDivisionSchema(
            PoliticalAdministrativeDivisionQuery query, 
            IDependencyResolver resolver)
        {
            Query = query;
            DependencyResolver = resolver;
        }
    }
}
