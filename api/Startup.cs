using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using data.Context1;
using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace ProjectManagement.Api
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
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin",
                    options =>
                    options.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    );
            });

            services.AddControllers();
            services.AddMediatR(typeof(Startup));
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddDbContext<BibliothequeContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DevConnection"));
            });

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BGT_Declasse Project", Version = "v1" });
            //});

            services.AddAutoMapper(typeof(Startup));
            //RegisterServices(services);

        }

        //private void RegisterServices(IServiceCollection services)
        //{
        //    DependencyContainer.RegisterServices(services);
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BGT_Declasse Project V1");
            //});
            // else
            // {
            //     var path = Environment.GetEnvironmentVariable("service");
            //     var basePath = ":31633/" + Environment.GetEnvironmentVariable("service");
            //     app.UseExceptionHandler("/Error");
            //     app.UseSwagger(c =>
            //     {

            //         c.RouteTemplate = "swagger/{documentName}/swagger.json";
            //         c.PreSerializeFilters.Add((swaggerDoc, httpReq) => swaggerDoc.Servers = new List<OpenApiServer>
            //         {
            //             new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}{basePath}"}
            //         });

            //     });

            //     var endpoint = "/" + path + "/swagger/v1/swagger.json";
            //     app.UseSwaggerUI(c =>
            //     {
            //         c.SwaggerEndpoint(endpoint, "API V1");
            //     });
            // }

            app.UseHttpsRedirection();

            app.UseRouting();

            // app.UseAuthorization();
            app.UseCors("AllowOrigin");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}