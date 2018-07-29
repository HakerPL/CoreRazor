using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreData;
using CoreData.Repositories.Interface;
using CoreData.Repositories.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FirstCore
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
            // we get connect string from appsettings.json
            services.AddDbContext<LibraryDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SqlServer")));

            // here we add our repositories to conteiner DI (AutoFac)
            services.AddTransient<IReaderRepository, ReaderRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IBookHistoryRepository, BookHistoryRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();

            // we will be use MVC pattern
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            // routing in our aplication /Controler/Action/id?
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
