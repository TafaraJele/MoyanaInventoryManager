
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Inventory.Manager.Command.API.Services;
using InventoryManager.Comand.Core;
using InventoryManager.Comand.Core.Repositories;
using InventoryManager.Comand.Core.Repositories.Write;
using InventoryManager.Comand.Core.Services;
using InventoryManager.Core;
using InventoryManager.Infrastruture.Data.Mongo.Query;
using InventoryManager.Infrastruture.Data.Mongo.Write;
using InventoryManager.Query.Handlers.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace InventoryManagerCommandAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Info
            {
                Title = "Products Administration Command ",
                Version = "v1",
                Description = "Mananging Products.",
                TermsOfService = "None",
                Contact = new Contact { Name = "SD Technologies", Email = "info@sdteq.com", Url = "www.sdteq.com" },
                License = new License { Name = "Use under LICX", Url = "https:sdteq.com" },

            }));
          services.AddAutofac();
            services.Configure<AppSettings>(this.Configuration.GetSection("AppSettings"));

            services.AddTransient <ICustomerApplication, CustomerApplication>();
            services.AddTransient<ICustomerReport, CustomerReportRepository>();
            services.AddTransient<ICustomerRecordsRepository, CustomerRecordRepository>();
            services.AddTransient<IOrderReport, OrderReportRepository>();
            services.AddTransient<IEventDispatcher, EventDispatcher>();

            var containerBuilder = new ContainerBuilder();

            // Once you've registered everything in the ServiceCollection, call
            // Populate to bring those registrations into Autofac. This is
            // just like a foreach over the list of things in the collection
            // to add them to Autofac.
            containerBuilder.Populate(services);

            // Make your Autofac registrations. Order is important!
            // If you make them BEFORE you call Populate, then the
            // registrations in the ServiceCollection will override Autofac
            // registrations; if you make them AFTER Populate, the Autofac
            // registrations will override. You can make registrations
            // before or after Populate, however you choose.
            //containerBuilder.RegisterAssemblyModules<MessageHandler>().As<IHandler>();

            containerBuilder.RegisterModule(new EventsModule());

            // Creating a new AutofacServiceProvider makes the container
            // available to your app using the Microsoft IServiceProvider
            // interface so you can use those abstractions rather than
            // binding directly to Autofac.
            var container = containerBuilder.Build();
            var serviceProvider = new AutofacServiceProvider(container);

            return serviceProvider;

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Products Administation Command");
            });
            app.UseHttpsRedirection();
            app.UseMvc();
            
        }
    }
}
