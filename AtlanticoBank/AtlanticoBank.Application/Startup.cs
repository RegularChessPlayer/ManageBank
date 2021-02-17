using AtlanticoBank.Application.HubConfig;
using AtlanticoBank.Infrastructure.Data.Context;
using AtlanticoBank.Infrastructure.Data.Repository;
using AtlanticoBank.Infrastructure.Data.Repository.Interfaces;
using AtlanticoBank.Services.Interfaces;
using AtlanticoBank.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtlanticoBank.Application
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

            services.AddDbContext<DataContext>(p =>
                p.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")
            ));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICaixaRepository, CaixaRepository>();
            services.AddScoped<IEstoqueCaixaRepository, EstoqueCaixaRepository>();
            services.AddScoped<ICaixaService, CaixaService>();


            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                .WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            });

            services.AddSignalR();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<BankHub>("/bankhub");

            });

        }
    }
}
