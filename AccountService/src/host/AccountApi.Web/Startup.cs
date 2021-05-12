using AccountApi.Contracts;
using AccountApi.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;

namespace AccountApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                   .AddJsonOptions(options =>
                   {
                       options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                       options.SerializerSettings.Converters.Add(new StringEnumConverter { CamelCaseText = true });                      
                   });
            services.AddTransient<ITokenService, TokenService.TokenService>();
            services.AddTransient<ITokenStore, Mock.MockTokenStore>();
            services.AddTransient<IAccountStore, Mock.MockAccountStore>();
            services.AddTransient<IAccountService, AccountService.AccountService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseExceptionMiddleWare();
            app.UseContextCreationMiddleware();

            app.UseHttpsRedirection();           
            app.UseMvc();
        }
    }
}
