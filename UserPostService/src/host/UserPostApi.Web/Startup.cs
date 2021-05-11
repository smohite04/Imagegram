using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphiQl;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using UserPostApi.Contracts;
using UserPostApi.GraphQL.Service;
using UserPostApi.Service.Mock;

namespace UserPostService
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            AddGraphQLConfigurations(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseGraphQL<UserPostSchema>();
            app.UseGraphiQl();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            app.UseHttpsRedirection();
            app.UseMvc();
        }
        private static void AddGraphQLConfigurations(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton<ContextServiceLocator>();
            services.AddTransient<IPostService, MockPostService>();
            services.AddTransient<ICommentService, MockCommentService>();
            services.AddSingleton<UserPostQuery>();
            services.AddSingleton<GetPostResponseType>();
            services.AddSingleton<CommentDetailsType>();
            services.AddSingleton<PagingDetailsType>();
            services.AddSingleton<PaginatedCommentDetailsType>();
            services.AddSingleton<IDependencyResolver>(x => new FuncDependencyResolver(x.GetRequiredService));
            services.AddSingleton<ISchema, UserPostSchema>();
            services.AddGraphQL().AddGraphTypes(ServiceLifetime.Singleton);

            services.AddGraphiQl(x =>
            {
                x.GraphiQlPath = "/graphiql-ui";
                x.GraphQlApiPath = "graphql";
            });
        }
    }
}
