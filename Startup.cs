using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using BEAST_API.Models;
using BEAST_API.Queries;
using BEAST_API.Schemas;
using BEAST_API.Repositories;
using GraphQL.Types;
using GraphQL.Execution;
using GraphQL;
using GraphQL.Http;

namespace BEAST_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton<IDocumentWriter, DocumentWriter>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddScoped<BeastQuery>();
            services.AddScoped<ISchema, BeastSchema>(); 
            services.AddScoped<IApplicationRepository, ApplicationRepository>();


            var connection = @"Server=localhost;Database=beast;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<BeastContext>(opt => opt.UseSqlServer(connection));
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

             app.UseCors(
                    options => options.WithOrigins("https://cawsp.com").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
            );
            app.UseMiddleware<GraphQLMiddleware>();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();
            app.UseMvc();

        }
    }
}
