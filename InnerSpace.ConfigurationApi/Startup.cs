using System;
using System.IO;
using System.Reflection;
using IdentityServer4.AccessTokenValidation;
using InnerSpace.Startup;
using InnerSpace.Swagger.API;
using InnerSpace.Swagger.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InnerSpace.ConfigurationApi
{
    public class Startup
    {
       
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            InnerSaceAPI = configuration.GetSection("InnerSaceAPI").Get<InnerSaceAPI>();
            string idpUrl = configuration.GetSection("Authentication:IdentityServerAddress")?.Value;
            APIClient = new APIClient(InnerSaceAPI.Name + "_" + env.EnvironmentName, "secret", idpUrl);
        }

        public InnerSaceAPI InnerSaceAPI { get; set; }
        public APIClient APIClient { get; set; }
        public IConfiguration Configuration { get; } 
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            string baseDirectory = AppContext.BaseDirectory;

            services.AddSwagger(APIClient, InnerSaceAPI, Path.Combine(baseDirectory, xmlFile));
            StartupIOC startup = new StartupIOC(Configuration, ProjectType.API);
            services = startup.ConfigureServices(services);
            services.AddCors();

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)

               .AddIdentityServerAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme, options =>
               {
                   options.RequireHttpsMetadata = false;
                   options.ApiName = InnerSaceAPI.Name;
                   options.Authority = APIClient.IdpUrl;
                   options.ClaimsIssuer = APIClient.IdpUrl;
                   options.SupportedTokens = SupportedTokens.Jwt;


               });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireClaim("role", "admin"));
                options.AddPolicy("FieldEngineerOnly", policy => policy.RequireClaim("role", "fieldEngineer"));
                options.AddPolicy("CustomerOnly", policy => policy.RequireClaim("role", "customer"));
                options.AddPolicy("AuditorOnly", policy => policy.RequireClaim("role", "auditor"));
                options.AddPolicy("CustomerOrFieldEngineerOnly", policy => policy.RequireClaim("role", "fieldEngineer", "customer"));
            });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection(); 
            app.UseAuthentication();
            app.UseCors(builder =>
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    );
            app.UseSwagger();


            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.InjectJavascript("swaggerinit.js");
                c.SwaggerEndpoint("/swagger/v1/swagger.json", InnerSaceAPI.Title);
                c.OAuthClientId(InnerSaceAPI.ClientId);
                c.OAuthAppName(InnerSaceAPI.Name);
            });
           // app.UseAuthorization();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
