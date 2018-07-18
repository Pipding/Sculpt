using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;

namespace Sculpt
{
    /// <summary>
    /// Sets up base functionality of the application
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// App configuration
        /// </summary>
        public IConfiguration Configuration { get; }


        /// <summary>
        /// Function which runs on app start
        /// </summary>
        /// <param name="configuration">Application config</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container
        /// </summary>
        /// <param name="services">Application services</param>
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton<IConfiguration>(Configuration);

            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Sculpt", Version = "v1" });

                var xmlPath = Path.Combine(AppContext.BaseDirectory, "Sculpt.xml");
                c.IncludeXmlComments(xmlPath);
            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        /// </summary>
        /// <param name="app">Application builder</param>
        public void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sculpt V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseMvc();
        }
    }
}