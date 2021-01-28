using GraphQL.Types;
using GraphQL.Utilities;
using System;

namespace WebAPI_GraphQL.GraphQL
{
    public class StarWarsSchema : Schema
    {
        public StarWarsSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<StarWarsQuery>();
            Mutation = provider.GetRequiredService<StarWarsMutation>();
        }
    }
}
