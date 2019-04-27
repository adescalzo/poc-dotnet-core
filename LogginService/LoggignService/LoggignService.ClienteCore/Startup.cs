using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog;

namespace LogginService.ClienteCore
{
    public class Startup
    {
        private static readonly Logger logger = LogManager.GetLogger(typeof(Startup).FullName);

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            var loggingWebService = Configuration.GetSection("LoggingWebService");
            var loggingServiceName = Configuration.GetSection("LoggingServiceName");

            GlobalDiagnosticsContext.Set("LoggingServiceName", loggingServiceName.Value);
            GlobalDiagnosticsContext.Set("LoggingWebService", loggingWebService.Value);

            logger.Info("Application Start");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
