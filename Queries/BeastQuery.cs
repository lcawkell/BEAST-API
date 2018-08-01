using GraphQL.Types;
using BEAST_API.Types;
using BEAST_API.Models;
using BEAST_API.Repositories;

namespace BEAST_API.Queries {

    public class BeastQuery : ObjectGraphType {
        public BeastQuery(IApplicationRepository applicationRepository) {
            Field<ListGraphType<ApplicationType>>(
                "applications",
                resolve: context => applicationRepository.GetApplications()
            );
            Field<ApplicationType>(
                "application",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id"}),
                resolve: context => {
                    var id = context.GetArgument<int>("id");
                    return applicationRepository.GetApplication(id);
                }
            );
            Field<ListGraphType<BeastType>>(
                "beasts",
                resolve: context => applicationRepository.GetBeasts()
            );
            Field<BeastType>(
                "beast",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id"}),
                resolve: context => {
                    var id = context.GetArgument<int>("id");
                    return applicationRepository.GetBeast(id);
                }
            );
        }
    }

}