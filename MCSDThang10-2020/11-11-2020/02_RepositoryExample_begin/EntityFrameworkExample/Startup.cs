using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkExample.Data;
using EntityFrameworkExample.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkExample
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public void ConfigureServices(IServiceCollection services)
        {
            //_configuration.GetConnectionString => doc du lieu tu file appsettings.json 
            //PersonContext noi den DB, ko phai table
            services.AddDbContext<PersonContext>(options =>
               options.UseSqlServer(_configuration.GetConnectionString("KetNoiDB")));

            services.AddScoped<IRepository, MyRepository>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, PersonContext personContext)
        {
            app.UseStaticFiles();
            personContext.Database.EnsureDeleted();
            personContext.Database.EnsureCreated();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "defaultRoute",
                    template: "{controller=Person}/{action=Index}/{id?}");
            });
        }
    }
}
