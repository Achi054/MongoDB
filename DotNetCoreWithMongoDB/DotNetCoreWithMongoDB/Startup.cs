using DotNetCoreWithMongoDB.Application;
using DotNetCoreWithMongoDB.Application.Commands;
using DotNetCoreWithMongoDB.Application.Queries;
using DotNetCoreWithMongoDB.Infrastructure;
using DotNetCoreWithMongoDB.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetCoreWithMongoDB
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
            services.AddMvc()
                .AddJsonOptions(options => options.UseMemberCasing())
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.Configure<BooksStoreSettings>(Configuration.GetSection(nameof(BooksStoreSettings)));

            services.AddSingleton<IBooksStoreSettings, BooksStoreSettings>();

            services.AddTransient<IBooksRepository, BooksRepository>();

            services.AddTransient<IBookQueries, BookQueries>();

            services.AddTransient<IBookCommands, BookCommands>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
