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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace NiCatApp_DONETCORE {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddCors (options => {
                // CorsPolicy 是自訂的 Policy 名稱
                options.AddPolicy ("CorsPolicy", policy => {
                    policy.WithOrigins ("http://localhost:4200")
                        .AllowAnyHeader ()
                        .AllowAnyMethod ()
                        .AllowCredentials ();
                });
            });
            services.AddControllers ();
            services.AddSwaggerGen (c => {
                c.SwaggerDoc ("v1", new OpenApiInfo { Title = "NiCatApp_DONETCORE", Version = "v1" });
            });
            services.AddTransient<DbConnection> (_ => new DbConnection (Configuration["ConnectionStrings:MYSQL"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
                app.UseSwagger ();
                app.UseSwaggerUI (c => c.SwaggerEndpoint ("/swagger/v1/swagger.json", "NiCatApp_DONETCORE v1"));
            }

            app.UseHttpsRedirection ();

            app.UseRouting ();

            app.UseCors ("CorsPolicy");

            app.UseAuthorization ();

            app.UseEndpoints (endpoints => {
                endpoints.MapControllers ();
            });
        }
    }
}