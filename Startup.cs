using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ass_2.Helpers;
using Microsoft.EntityFrameworkCore;
using ass_2.Data;

namespace ass_2
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
			
			services.AddSingleton<IHelper, Helper>();

            services.AddDbContext<ass_2Context>(options =>
			{
			      var connectionString = Configuration.GetConnectionString("ass_2Context");
               
            if (Environment.IsDevelopment())
            {
                options.UseSqlite(@"Data Source=databases\ass-2.db");
            }
            else
            {
                //options.UseSqlServer(connectionString);
				options.UseSqlite(@"Data Source=app\heroku_output\databases\ass-2.db");
            }
            
			});
                
           
                    
                
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

             app.UseAuthentication();
        app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
				endpoints.MapRazorPages();
            });
        }
    }
}
