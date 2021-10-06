using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CInvestimentos.Models;
using CInvestimentos.Repositories;
using CInvestimentos.Repositories.Interfaces;
using CInvestimentos.Services;
using CInvestimentos.Services.Interface;
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

namespace CInvestimentos
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
            // services.AddDbContext<Context>();
            services.AddDbContext<Context>(options => options
            .UseSqlServer(Configuration
            
            .GetConnectionString("DefaultConnection")));

            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddScoped<IAcaoRepository,AcaoRepository>();
            services.AddScoped<IAcaoService, AcaoService>();

            services.AddScoped<ICompraRepository,CompraRepository>();
            services.AddScoped<ICompraService,CompraService>();

            services.AddScoped<IVendaRepository,VendaRepository>();
            services.AddScoped<IVendaService,VendaService>();
            
            services.AddScoped<IInvestidorRepository,InvestidorRepository>();
            services.AddScoped<IInvestidorService,InvestidorService>();

            services.AddScoped<IInvestimentoRepository,InvestimentoRepository>();
            services.AddScoped<IInvestimentoService,InvestimentoService>();

            services.AddScoped<ITransacaoRepository,TransacaoRepository>();
            services.AddScoped<ITransacaoService,TransacaoService>();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "CInvestimentos API",
                    Version = "v1",
                    Description = "API CInvestimentos",
                    TermsOfService = new Uri("https://cinvestimentos.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Christofer Andriotti",
                        Email = "andriottichris@gmail.com",
                        Url = new Uri("https://twitter.com/cinvestimentos"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "CInvestimentos API LICX",
                        Url = new Uri("https://cinvestimentos.com/license"),
                    }

                    
                });
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CInvestimentos V1");
                c.RoutePrefix = "swagger/ui";
                // c.RoutePrefix = string.Empty; // define a rota. Com string.Empty a rota fica: localhost:5001/index.html
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
