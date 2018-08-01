using BEAST_API.Queries;
using GraphQL.Types;

namespace BEAST_API.Schemas {

    public class BeastSchema : Schema {
        public BeastSchema(BeastQuery query) {
            Query = query;
        }
    }
}