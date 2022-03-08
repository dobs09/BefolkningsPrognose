using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BefolkPostGres.Models;
using Microsoft.EntityFrameworkCore;
using BefolkPostGres.Repositories;
using Newtonsoft.Json.Serialization;


namespace BefolkPostGres
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
            services.AddDbContext<egedalContext>(options => options.UseNpgsql(Configuration.GetConnectionString("PostgreSqlConnectionString")));
            services.AddControllersWithViews();
            //services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddScoped<IRepository<CprPrognoseSamlet>, CPR_Samlet_REPO>();
            services.AddScoped<IRepository<CprPrognoseSamlet1>, CPR_Samlet_REPO1>();
            services.AddScoped<IRepository<CprPrognoseSamlet2>, CPR_Samlet_REPO2>();
            services.AddScoped<IRepository<CprPrognoseSamlet3>, CPR_Samlet_REPO3>();
            services.AddScoped<IRepository<CprPrognoseSamlet4>, CPR_Samlet_REPO4>();
            services.AddScoped<IRepository<PrognoseHardcodet>, PROGNOSE_hardcodet_REPO>();
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
