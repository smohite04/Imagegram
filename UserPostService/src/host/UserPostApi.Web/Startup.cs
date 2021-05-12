using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserPostApi.Contracts;
using UserPostApi.GraphQL.Service;
using UserPostApi.Service.Mock;
using UserPostApi.Web;

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
            //TODO: added mock implementations , need to be replaced with actual implementation
            services.AddTransient<IPostServiceAdapter, MockPostService>();
            services.AddTransient<ICommentServiceAdapter, MockCommentService>();
            services.AddTransient<IAccountAuthenticationAdapter, MockTokenAuthenticationAdapter>();
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
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions
            {
                GraphQLEndPoint = "/api/v1.0/postDetails",
                Path = "/api/v1.0/postDetails/playground",
            });
            app.UseExceptionMiddleWare();
            app.UseContextCreationMiddleware();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
        private static void AddGraphQLConfigurations(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton<ContextServiceLocator>();            
            services.AddSingleton<UserPostQuery>();
            services.AddSingleton<IDependencyResolver>(x => new FuncDependencyResolver(x.GetRequiredService));
            services.AddSingleton<ISchema,UserPostSchema>();
            services.AddGraphQL().AddGraphTypes(typeof(GetPostResponseType).Assembly, ServiceLifetime.Singleton);          
        }
    }
}
