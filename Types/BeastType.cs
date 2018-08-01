using GraphQL.Types;
using BEAST_API.Models;

namespace BEAST_API.Types {
    public class BeastType : ObjectGraphType<Beast> {
        public BeastType() {
            Field(i => i.id);
            Field(i => i.firstName);
            Field(i => i.lastName);

        }
    }
}