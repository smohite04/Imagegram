using Newtonsoft.Json.Linq;

namespace UserPostApi.GraphQL.Service
{
    public class GraphQLQuery
    {
        public string Query { get; set; }
        public JObject Variables { get; set; }
    }
}
