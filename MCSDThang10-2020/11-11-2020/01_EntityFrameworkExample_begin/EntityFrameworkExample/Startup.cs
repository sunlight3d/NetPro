using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkExample.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkExample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PersonContext>(options =>
                options.UseSqlite("Data Source=person.db"));
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
