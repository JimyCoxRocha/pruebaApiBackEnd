using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using storeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeAPI
{
    public class Startup
    {
        private readonly string _policyName = "CorsPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
               .ConfigureApiBehaviorOptions(opt
                   =>
               {
                   opt.InvalidModelStateResponseFactory =
                       (context => new BadRequestObjectResult(new
                       {
                           Code = 400,
                           Message = context.ModelState.Values.SelectMany(x => x.Errors)
                            .Select(x => x.ErrorMessage),
                           Data = ""
                       }));
               });
            services.AddCors(opt =>
            {
                opt.AddPolicy(name: _policyName, builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            
            services.AddDbContext<storeapiContext>(
                    options =>
                    options.
                    UseSqlServer("Server=DESKTOP-K77OCLB;Database=storeapi;Trusted_Connection=True;")
                );

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "storeAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "storeAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(_policyName);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
