using GraphQL.Types;
using GraphQL.Resolvers;
using BEAST_API.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GraphQL.Execution;
using System;
using System.Collections.Generic;
using BEAST_API.Repositories;


namespace BEAST_API.Types {
    public class ApplicationType : ObjectGraphType<Application> {
        public ApplicationType(IApplicationRepository applicationRepository) {
            Field(i => i.id);
            Field(i => i.title);
        }
    }
}